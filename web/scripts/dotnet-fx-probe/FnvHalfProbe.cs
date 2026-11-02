// Probe: how does the DESKTOP runtime (.NET Framework, Microsoft.VisualBasic) round the local half-tax of the
// RP_GST HSN summary?   RP_GST.cs:2933-2939 does  Strings.Format(Fnv(ItmTax) / 2.0, "0.00")  with
// Fnv = Conversion.Val(Value.ToString())  (DC_Main.cs:2088-2102).
// A half lands on an exact 2-decimal midpoint only when the tax has an odd number of paise (t = 2k+1 paise,
// half = k.5 paise). This program formats every such value through the same two VB calls and reports whether the
// result equals exact half-up (away from zero), exact half-even, or neither.
// Build/run (Windows, Framework csc):  csc /nologo /r:Microsoft.VisualBasic.dll FnvHalfProbe.cs && FnvHalfProbe.exe out.csv
using System;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

static class FnvHalfProbe
{
    static string Paise(long p)
    {
        // exact "ddd.dd" text of a non-negative paise count, as SQL Server would hand it to Val(...).
        return (p / 100).ToString(CultureInfo.InvariantCulture) + "." + (p % 100).ToString("00", CultureInfo.InvariantCulture);
    }

    static string HalfUp(long t)   // t odd: t/200 rupees, midpoint at 2dp, away from zero
    {
        long k = t / 2; // floor
        return Paise(k + 1);
    }

    static string HalfEven(long t)
    {
        long k = t / 2;
        return Paise(k % 2 == 0 ? k : k + 1);
    }

    static string Fx(long t)
    {
        double val = Conversion.Val(Paise(t));           // Fnv
        return Strings.Format((object)(val / 2.0), "0.00"); // Format(Fnv/2.0,"0.00")
    }

    static int Main(string[] args)
    {
        string csv = args.Length > 0 ? args[0] : "mismatch.csv";
        Console.WriteLine("clr=" + Environment.Version + " os=" + Environment.OSVersion.VersionString);
        Console.WriteLine("mscorlib=" + typeof(object).Assembly.Location);
        Console.WriteLine("culture=" + CultureInfo.CurrentCulture.Name);

        long total = 0, upMatch = 0, evenMatch = 0, bothMatch = 0, neither = 0, upMiss = 0;
        var sb = new StringBuilder("tax_paise,tax,dotnet,half_up,half_even\n");
        int shown = 0;

        Action<long> test = t =>
        {
            string fx = Fx(t), up = HalfUp(t), ev = HalfEven(t);
            total++;
            bool u = fx == up, e = fx == ev;
            if (u) upMatch++;
            if (e) evenMatch++;
            if (u && e) bothMatch++;
            if (!u && !e) neither++;
            if (!u)
            {
                upMiss++;
                sb.Append(t).Append(',').Append(Paise(t)).Append(',').Append(fx).Append(',').Append(up).Append(',').Append(ev).Append('\n');
                if (shown++ < 25) Console.WriteLine("  differs from half-up: tax " + Paise(t) + " -> " + fx + " (half-up " + up + ", half-even " + ev + ")");
            }
        };

        // dense: every odd paise count up to 40,000.01 rupees
        for (long t = 1; t <= 4000001; t += 2) test(t);
        // sparse, fixed seed: large bills up to 99,999,999.99 rupees
        var rnd = new Random(20261102);
        for (int i = 0; i < 500000; i++) { long t = (long)(rnd.NextDouble() * 9999999998L); test(t | 1L); }

        Console.WriteLine("RESULT total=" + total + " equalsHalfUp=" + upMatch + " equalsHalfEven=" + evenMatch +
                          " equalsBoth=" + bothMatch + " equalsNeither=" + neither + " differsFromHalfUp=" + upMiss);
        // Part 2: negatives (sales-return rows enter the HSN sum as SUM(-RTN_IT_TAX_AMT)) and 3-4 decimal taxes
        // (SUM(IT_TAX_AMT) is not limited to paise). Reference = System.Decimal, half away from zero, which is what
        // decimal.js ROUND_HALF_UP does in the web.
        long negTotal = 0, negMiss = 0, decTotal = 0, decMiss = 0;
        var sb2 = new StringBuilder("kind,tax,dotnet,reference\n");
        Action<string, decimal> ref2 = (kind, tax) =>
        {
            string txt = tax.ToString(CultureInfo.InvariantCulture);
            string fx = Strings.Format((object)(Conversion.Val(txt) / 2.0), "0.00");
            string rf = Math.Round(tax / 2m, 2, MidpointRounding.AwayFromZero).ToString("0.00", CultureInfo.InvariantCulture);
            if (kind == "neg") negTotal++; else decTotal++;
            if (fx != rf)
            {
                if (kind == "neg") negMiss++; else decMiss++;
                sb2.Append(kind).Append(',').Append(txt).Append(',').Append(fx).Append(',').Append(rf).Append('\n');
                if (shown++ < 60) Console.WriteLine("  " + kind + " differs: tax " + txt + " -> " + fx + " (reference " + rf + ")");
            }
        };
        for (long t = 1; t <= 2000001; t += 2) ref2("neg", -(decimal)t / 100m);                 // negative midpoints
        for (long t = 1; t <= 2000001; t += 2) ref2("neg", -(decimal)t / 100m - 0.0001m);       // just past a negative midpoint
        for (long t = 1; t <= 2000001; t += 2) ref2("dec", (decimal)t / 100m + 0.0001m);        // just past a midpoint
        for (long t = 1; t <= 2000001; t += 2) ref2("dec", (decimal)t / 100m - 0.0001m);        // just before a midpoint
        for (int i = 0; i < 1000000; i++)
        {
            long raw = (long)(rnd.NextDouble() * 99999999999L);  // up to 9,999,999.9999 with 4 decimals
            ref2("dec", (decimal)raw / 10000m);
        }
        Console.WriteLine("RESULT2 negatives=" + negTotal + " negativeMismatches=" + negMiss + " fractional=" + decTotal + " fractionalMismatches=" + decMiss);
        File.WriteAllText(csv.Replace(".csv", "-part2.csv"), sb2.ToString());

        // Part 3: the IGST column, RP_GST.cs:2951-2956: Strings.Format(Fnv(ItmTax), "0.00") with no halving.
        long igTotal = 0, igMiss = 0;
        Action<decimal> igst = tax =>
        {
            string txt = tax.ToString(CultureInfo.InvariantCulture);
            string fx = Strings.Format((object)Conversion.Val(txt), "0.00");
            string rf = Math.Round(tax, 2, MidpointRounding.AwayFromZero).ToString("0.00", CultureInfo.InvariantCulture);
            if (rf == "-0.00") rf = "0.00";
            igTotal++;
            if (fx != rf) { igMiss++; if (shown++ < 80) Console.WriteLine("  igst differs: tax " + txt + " -> " + fx + " (reference " + rf + ")"); }
        };
        for (long m = 1; m <= 2000000; m++) { igst((decimal)m / 1000m); igst(-(decimal)m / 1000m); igst((decimal)m / 10000m + 0.00005m); }
        for (int i = 0; i < 1000000; i++) { long raw = (long)(rnd.NextDouble() * 99999999999L); igst((decimal)raw / 10000m); igst(-(decimal)raw / 10000m); }
        Console.WriteLine("RESULT3 igstChecked=" + igTotal + " igstMismatches=" + igMiss);
        Console.WriteLine("NEGZERO " + Strings.Format((object)Conversion.Val("-0.004"), "0.00") + " / half " + Strings.Format((object)(Conversion.Val("-0.004") / 2.0), "0.00"));

        // Spot values named in the plan / probe: 1908.29 (3% of 63,609.50 rounded) and the 2043.29 bill of G181.
        foreach (long t in new long[] { 190829, 204329, 1, 3, 5, 7, 9, 99999999999L / 100 | 1 })
            Console.WriteLine("SPOT tax " + Paise(t) + " -> " + Fx(t));
        File.WriteAllText(csv, sb.ToString());
        return 0;
    }
}
