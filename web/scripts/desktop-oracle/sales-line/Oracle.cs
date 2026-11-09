// Desktop oracle, family 1: the Sale line (WP-40 / WP-41 family 1, LITE-MASTER-PLAN.md §6 O2).
//
// This program runs the DESKTOP's own sale-line arithmetic on the desktop's own runtime (.NET Framework 4.8 +
// Microsoft.VisualBasic) and writes what it computes. It is an evidence tool: it changes no product code.
//
// What is verbatim and what is not:
//   * `TR_SALE.CommPassTotal` below is TR_SALE.cs:9524-11891 copied verbatim, line for line, except the two lines of
//     its single catch clause, which the Framework csc (C# 5) cannot compile as ILSpy wrote them:
//       desktop:  catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
//                 {
//       here:     catch (Exception obj)
//                 { if (!(obj is Exception && num3 != 0 && num == 0)) throw;
//     C# 5 has no exception filters and only catches Exception types. The rewrite catches the same exceptions and
//     handles exactly the ones the filter admitted (VB "On Error Resume Next"); any other is rethrown, as before.
//     `web/packages/core/test/desktopOracle.salesLine.test.ts` re-reads TR_SALE.cs and fails if this copy drifts.
//   * `DC_Main.Fnv` is DC_Main.cs:2088-2102 copied verbatim.
//   * Everything else is a STAND-IN for the Windows Forms surroundings the method touches, and nothing more:
//     - `AxMSFlexGrid`: the grid. `val[row, col]` is TextMatrix (a string; "" when never set), `val[col]` is the
//       column width (the desktop tests `> 0` / `!= 0` to ask "is this column shown"), `Row` and `Col` are the
//       current cell.
//     - `TEXT_ENTRY.Text`: the in-cell editor, read when the current column is 13, 23, 35 or 36.
//     - `MSG_TOT_FILL` and `BILL_TOTAL` refresh the totals grid (family 2); here they do nothing.
//     - `Interaction.MsgBox` records the prompt instead of opening a window (CI has no desktop).
//     - `DC_Main` holds only the company settings the method reads, with the values each vector gives.
//
// Usage:  Oracle.exe vectors.json expected.json <run-id> <commit-sha>
// Build:  csc /nologo /r:Microsoft.VisualBasic.dll /r:System.Web.Extensions.dll /out:Oracle.exe Oracle.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DesktopOracle.SalesLine
{
	public class AxMSFlexGrid
	{
		private readonly Dictionary<long, string> cells = new Dictionary<long, string>();
		private readonly Dictionary<int, int> widths = new Dictionary<int, int>();

		public int Row { get; set; }
		public int Col { get; set; }

		public string this[int row, int col]
		{
			get
			{
				string value;
				return cells.TryGetValue(((long)row << 16) | (uint)col, out value) ? value : "";
			}
			set { cells[((long)row << 16) | (uint)col] = value ?? ""; }
		}

		/// <summary>Column width. Every column is shown (1000 twips) unless the vector hides it.</summary>
		public int this[int col]
		{
			get
			{
				int width;
				return widths.TryGetValue(col, out width) ? width : 1000;
			}
		}

		public void SetWidth(int col, int width) { widths[col] = width; }
	}

	public class TextEntryStandIn
	{
		public string Text { get; set; }
	}

	public static class Interaction
	{
		public static string LastPrompt;

		public static MsgBoxResult MsgBox(object Prompt, MsgBoxStyle Buttons = MsgBoxStyle.OkOnly, object Title = null)
		{
			LastPrompt = Convert.ToString(Prompt, CultureInfo.InvariantCulture);
			return MsgBoxResult.Ok;
		}
	}

	public static class DC_Main
	{
		public static string SSRegSrNo = "";
		public static string MsMetalType = "G";
		public static string MsLbrGen = "N";
		public static string MsSlAmtType = "N";
		public static int MsLbrRof = 2;
		public static int MsItmRateRof = 2;
		public static string MsLbrWithGht = "Y";
		public static string MsAllRofRemove = "N";
		public static string MsNegativeStkSale = "Y";

		// DC_Main.cs:2088-2102 (verbatim)
		public static double Fnv(ref object Value)
		{
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(Value)))
			{
				return 0.0;
			}
			if (Value == null)
			{
				return 0.0;
			}
			if (Operators.CompareString(Value.ToString(), "", false) == 0)
			{
				return 0.0;
			}
			return Conversion.Val(Value.ToString());
		}
	}

	public class TR_SALE
	{
		public readonly AxMSFlexGrid MSG = new AxMSFlexGrid();
		public readonly TextEntryStandIn TEXT_ENTRY = new TextEntryStandIn { Text = "" };
		public string EntryMode = "A";
		public double CurItGwtStk;
		public double ToDayGlRate;
		public DataTable RsGrTch = new DataTable();
		public string FormMainBook = "SALE";

		private void MSG_TOT_FILL() { }

		private void BILL_TOTAL() { }

		public void Run() { CommPassTotal(); }

		// ===== BEGIN VERBATIM TR_SALE.cs:9524-11891 =====
	private void CommPassTotal()
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int digits = default(int);
		int digits2 = default(int);
		double num5 = default(double);
		string text = default(string);
		DataView dataView = default(DataView);
		int num6 = default(int);
		double num8 = default(double);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				object Value;
				DataRowView dataRowView;
				double num7;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 20508:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_000f;
						case 4:
							goto IL_0014;
						case 5:
							goto IL_0043;
						case 6:
							goto IL_0047;
						case 7:
						case 8:
							goto IL_004f;
						case 9:
							goto IL_0059;
						case 10:
							goto IL_0082;
						case 11:
							goto IL_00db;
						case 12:
							goto IL_00f8;
						case 13:
							goto IL_011e;
						case 15:
						case 16:
						case 17:
						case 18:
						case 19:
							goto IL_015a;
						case 20:
							goto IL_0192;
						case 21:
							goto IL_01ac;
						case 22:
							goto IL_01c6;
						case 23:
						case 24:
							goto IL_0200;
						case 25:
							goto IL_023b;
						case 26:
							goto IL_0255;
						case 27:
							goto IL_026f;
						case 28:
							goto IL_02a7;
						case 29:
							goto IL_02f5;
						case 30:
							goto IL_0343;
						case 31:
							goto IL_035c;
						case 32:
							goto IL_0376;
						case 33:
						case 34:
							goto IL_0392;
						case 35:
							goto IL_03be;
						case 36:
							goto IL_0411;
						case 37:
							goto IL_045f;
						case 38:
							goto IL_0479;
						case 39:
						case 40:
						case 41:
							goto IL_04cb;
						case 42:
							goto IL_04e2;
						case 43:
							goto IL_051d;
						case 44:
							goto IL_0555;
						case 45:
							goto IL_059e;
						case 46:
							goto IL_05b8;
						case 47:
						case 48:
						case 49:
							goto IL_05d6;
						case 50:
							goto IL_0659;
						case 51:
							goto IL_0673;
						case 52:
							goto IL_06ab;
						case 53:
							goto IL_06e3;
						case 54:
							goto IL_073b;
						case 55:
							goto IL_0773;
						case 56:
							goto IL_078c;
						case 58:
							goto IL_07ad;
						case 59:
							goto IL_07e5;
						case 60:
							goto IL_081d;
						case 61:
						case 62:
							goto IL_0839;
						case 63:
							goto IL_0898;
						case 64:
							goto IL_08b2;
						case 65:
							goto IL_08ea;
						case 66:
							goto IL_0942;
						case 67:
							goto IL_095b;
						case 57:
						case 68:
						case 69:
						case 70:
							goto IL_0978;
						case 71:
							goto IL_09b3;
						case 72:
							goto IL_09cd;
						case 73:
							goto IL_09e7;
						case 74:
							goto IL_0a37;
						case 76:
							goto IL_0a95;
						case 77:
							goto IL_0ae5;
						case 75:
						case 78:
						case 79:
							goto IL_0b3e;
						case 80:
						case 81:
							goto IL_0b78;
						case 82:
							goto IL_0bcb;
						case 83:
						case 84:
							goto IL_0bf7;
						case 85:
						case 86:
							goto IL_0c4d;
						case 87:
							goto IL_0c88;
						case 88:
							goto IL_0ca2;
						case 89:
							goto IL_0cbc;
						case 90:
							goto IL_0cd6;
						case 91:
							goto IL_0cf0;
						case 92:
							goto IL_0d28;
						case 93:
							goto IL_0d76;
						case 94:
							goto IL_0dae;
						case 95:
							goto IL_0e17;
						case 97:
							goto IL_0e9f;
						case 96:
						case 98:
						case 99:
						case 100:
							goto IL_0eda;
						case 101:
							goto IL_0f15;
						case 102:
							goto IL_0f2f;
						case 103:
							goto IL_0f67;
						case 104:
							goto IL_0fd0;
						case 105:
						case 106:
						case 107:
							goto IL_1058;
						case 108:
							goto IL_1093;
						case 109:
							goto IL_10ad;
						case 110:
							goto IL_10e5;
						case 111:
							goto IL_114e;
						case 112:
						case 113:
						case 114:
							goto IL_11d6;
						case 115:
							goto IL_1215;
						case 116:
						case 117:
							goto IL_1265;
						case 118:
							goto IL_1273;
						case 119:
							goto IL_127d;
						case 120:
							goto IL_1295;
						case 121:
							goto IL_12c7;
						case 122:
							goto IL_12eb;
						case 123:
							goto IL_1305;
						case 126:
							goto IL_1320;
						case 124:
						case 125:
						case 127:
						case 128:
							goto IL_132b;
						case 129:
							goto IL_134a;
						case 130:
							goto IL_1365;
						case 131:
							goto IL_13d1;
						case 132:
							goto IL_144e;
						case 133:
							goto IL_1476;
						case 135:
							goto IL_14be;
						case 138:
							goto IL_14e0;
						case 141:
							goto IL_1501;
						case 142:
							goto IL_151d;
						case 144:
							goto IL_153e;
						case 134:
						case 136:
						case 137:
						case 139:
						case 140:
						case 143:
						case 145:
						case 146:
							goto IL_155c;
						case 147:
							goto IL_1586;
						case 148:
						case 149:
							goto IL_15a5;
						case 150:
							goto IL_161d;
						case 151:
							goto IL_1658;
						case 152:
							goto IL_1676;
						case 154:
							goto IL_16c4;
						case 156:
							goto IL_1721;
						case 158:
							goto IL_178b;
						case 160:
							goto IL_17f5;
						case 161:
							goto IL_181f;
						case 163:
							goto IL_1869;
						case 164:
							goto IL_1893;
						case 166:
							goto IL_18ee;
						case 153:
						case 155:
						case 157:
						case 159:
						case 162:
						case 165:
						case 167:
						case 168:
						case 169:
							goto IL_194c;
						case 170:
						case 171:
							goto IL_196a;
						case 172:
							goto IL_1984;
						case 173:
							goto IL_1a42;
						case 175:
							goto IL_1a90;
						case 177:
							goto IL_1aec;
						case 179:
							goto IL_1b55;
						case 181:
							goto IL_1bbe;
						case 182:
							goto IL_1be8;
						case 184:
							goto IL_1c2f;
						case 174:
						case 176:
						case 178:
						case 180:
						case 183:
						case 185:
						case 186:
						case 187:
							goto IL_1c8c;
						case 188:
						case 189:
						case 190:
							goto IL_1ccb;
						case 191:
							goto IL_1d2d;
						case 192:
							goto IL_1d68;
						case 193:
							goto IL_1dbb;
						case 195:
							goto IL_1e15;
						case 194:
						case 196:
						case 197:
							goto IL_1e7b;
						case 198:
							goto IL_1e9c;
						case 199:
							goto IL_1ec8;
						case 200:
							goto IL_1ee4;
						case 201:
							goto IL_1f00;
						case 202:
						case 203:
						case 204:
						case 205:
							goto IL_1f22;
						case 206:
							goto IL_1f46;
						case 207:
							goto IL_1f7b;
						case 208:
							goto IL_1fa2;
						case 209:
						case 210:
						case 211:
							goto IL_1fc3;
						case 212:
							goto IL_2025;
						case 213:
							goto IL_2061;
						case 215:
							goto IL_20c4;
						case 217:
							goto IL_2122;
						case 218:
							goto IL_2141;
						case 220:
							goto IL_219d;
						case 223:
							goto IL_2212;
						case 225:
							goto IL_2290;
						case 227:
							goto IL_22eb;
						case 214:
						case 216:
						case 219:
						case 221:
						case 222:
						case 224:
						case 226:
						case 228:
						case 229:
							goto IL_235c;
						case 230:
							goto IL_2397;
						case 232:
							goto IL_23ba;
						case 233:
							goto IL_2401;
						case 235:
							goto IL_244f;
						case 237:
							goto IL_24b0;
						case 238:
							goto IL_24cf;
						case 240:
							goto IL_252e;
						case 243:
							goto IL_25a6;
						case 245:
							goto IL_2624;
						case 234:
						case 236:
						case 239:
						case 241:
						case 242:
						case 244:
						case 246:
						case 247:
							goto IL_2682;
						case 231:
						case 248:
						case 249:
						case 250:
							goto IL_26c0;
						case 251:
							goto IL_2713;
						case 252:
						case 253:
							goto IL_277a;
						case 254:
							goto IL_27a9;
						case 255:
						case 256:
							goto IL_2806;
						case 257:
							goto IL_2832;
						case 258:
							goto IL_2852;
						case 259:
						case 260:
						case 261:
							goto IL_28a7;
						case 262:
							goto IL_28d9;
						case 263:
							goto IL_292f;
						case 264:
							goto IL_2994;
						case 266:
							goto IL_29e9;
						case 265:
						case 267:
						case 268:
							goto IL_2a25;
						case 269:
							goto IL_2a54;
						case 270:
						case 271:
							goto IL_2ac1;
						case 272:
							goto IL_2add;
						case 273:
							goto IL_2af9;
						case 274:
							goto IL_2b15;
						case 275:
							goto IL_2b31;
						case 277:
							goto IL_2b54;
						case 278:
							goto IL_2b6e;
						case 279:
							goto IL_2ba4;
						case 280:
						case 281:
							goto IL_2bc2;
						case 282:
							goto IL_2bf4;
						case 283:
							goto IL_2c23;
						case 284:
							goto IL_2c85;
						case 285:
							goto IL_2cfd;
						case 286:
							goto IL_2d2c;
						case 291:
							goto IL_2d94;
						case 292:
							goto IL_2dc6;
						case 293:
							goto IL_2dff;
						case 294:
							goto IL_2e1e;
						case 296:
							goto IL_2e87;
						case 297:
							goto IL_2ed0;
						case 302:
							goto IL_2f3e;
						case 303:
							goto IL_2f87;
						case 287:
						case 288:
						case 289:
						case 290:
						case 295:
						case 298:
						case 299:
						case 300:
						case 301:
						case 304:
						case 305:
						case 306:
						case 307:
							goto IL_2fed;
						case 308:
							goto IL_301f;
						case 309:
							goto IL_303b;
						case 310:
							goto IL_3057;
						case 312:
						case 313:
							goto IL_3091;
						case 314:
							goto IL_30de;
						case 316:
							goto IL_312c;
						case 318:
							goto IL_318d;
						case 320:
							goto IL_31fb;
						case 322:
							goto IL_3269;
						case 323:
							goto IL_3285;
						case 325:
							goto IL_32d1;
						case 315:
						case 317:
						case 319:
						case 321:
						case 324:
						case 326:
						case 327:
						case 328:
							goto IL_3333;
						case 329:
						case 330:
							goto IL_3370;
						case 331:
							goto IL_33ae;
						case 332:
							goto IL_3405;
						case 334:
							goto IL_3453;
						case 336:
							goto IL_34b4;
						case 337:
							goto IL_34d3;
						case 339:
							goto IL_3532;
						case 342:
							goto IL_35aa;
						case 344:
							goto IL_3628;
						case 333:
						case 335:
						case 338:
						case 340:
						case 341:
						case 343:
						case 345:
						case 346:
							goto IL_3686;
						case 347:
							goto IL_36c1;
						case 348:
							goto IL_3717;
						case 349:
							goto IL_376a;
						case 351:
							goto IL_37ba;
						case 350:
						case 352:
						case 353:
						case 354:
						case 355:
						case 356:
						case 357:
							goto IL_381e;
						case 358:
							goto IL_3848;
						case 359:
						case 360:
							goto IL_38c7;
						case 361:
							goto IL_38f3;
						case 276:
						case 362:
						case 363:
						case 364:
							goto IL_3973;
						case 365:
							goto IL_399f;
						case 366:
						case 367:
							goto IL_39dc;
						case 368:
							goto IL_39f6;
						case 369:
							goto IL_3a2c;
						case 370:
							goto IL_3a62;
						case 371:
						case 372:
						case 373:
							goto IL_3a82;
						case 374:
							goto IL_3ab4;
						case 375:
							goto IL_3ae1;
						case 376:
							goto IL_3afd;
						case 377:
							goto IL_3b68;
						case 378:
							goto IL_3b8a;
						case 379:
							goto IL_3bb9;
						case 380:
						case 381:
							goto IL_3c2a;
						case 383:
							goto IL_3c78;
						case 385:
							goto IL_3cd9;
						case 387:
							goto IL_3d47;
						case 389:
							goto IL_3db5;
						case 390:
							goto IL_3dd1;
						case 392:
							goto IL_3e1d;
						case 382:
						case 384:
						case 386:
						case 388:
						case 391:
						case 393:
						case 394:
						case 395:
							goto IL_3e7f;
						case 397:
							goto IL_3ec1;
						case 398:
							goto IL_3f11;
						case 396:
						case 399:
						case 400:
						case 401:
							goto IL_3f82;
						case 402:
							goto IL_3fec;
						case 403:
							goto IL_403a;
						case 405:
							goto IL_4091;
						case 406:
							goto IL_40e2;
						case 407:
							goto IL_4101;
						case 409:
							goto IL_4156;
						case 412:
							goto IL_41c4;
						case 413:
							goto IL_4212;
						case 415:
							goto IL_4273;
						case 416:
							goto IL_42c1;
						case 418:
							goto IL_4316;
						case 404:
						case 408:
						case 410:
						case 411:
						case 414:
						case 417:
						case 419:
						case 420:
						case 421:
							goto IL_4380;
						case 422:
							goto IL_43d6;
						case 423:
							goto IL_4402;
						case 424:
						case 425:
							goto IL_445f;
						case 426:
							goto IL_4479;
						case 427:
							goto IL_44a6;
						case 428:
							goto IL_44fc;
						case 429:
							goto IL_4557;
						case 430:
							goto IL_4592;
						case 431:
						case 432:
						case 433:
						case 434:
						case 435:
							goto IL_45b6;
						case 438:
							goto IL_45f7;
						case 436:
						case 437:
						case 439:
						case 440:
							goto IL_4633;
						case 441:
							goto IL_4655;
						case 442:
							goto IL_46ab;
						case 443:
							goto IL_46be;
						case 444:
							goto IL_46ea;
						case 445:
							goto IL_46f3;
						case 446:
							goto IL_470c;
						case 447:
							goto IL_475f;
						case 448:
							goto IL_4787;
						case 449:
							goto IL_47db;
						case 451:
							goto IL_482b;
						case 452:
							goto IL_4847;
						case 450:
						case 453:
						case 454:
						case 455:
						case 456:
							goto IL_48be;
						case 457:
							goto IL_48c1;
						case 458:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 14:
						case 311:
						case 459:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_4847:
					num2 = 452;
					val[val.Row, 40] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 39]) / 100.0), "0.000");
					goto IL_48be;
					IL_48be:
					val = null;
					goto IL_48c1;
					IL_482b:
					num2 = 451;
					val[val.Row, 106] = "100.00";
					goto IL_4847;
					IL_48c1:
					num2 = 457;
					MSG_TOT_FILL();
					break;
					IL_000b:
					num2 = 2;
					digits = 0;
					goto IL_000f;
					IL_000f:
					num2 = 3;
					digits2 = 0;
					goto IL_0014;
					IL_0014:
					num2 = 4;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM035NPDM", false) == 0) | (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0))
					{
						goto IL_0043;
					}
					goto IL_004f;
					IL_0043:
					num2 = 5;
					digits = 2;
					goto IL_0047;
					IL_0047:
					num2 = 6;
					digits2 = 2;
					goto IL_004f;
					IL_004f:
					num2 = 8;
					val = MSG;
					goto IL_0059;
					IL_0059:
					num2 = 9;
					if (Operators.CompareString(val[val.Row, 1], "", false) == 0)
					{
						goto IL_0082;
					}
					goto IL_015a;
					IL_0082:
					num2 = 10;
					if ((Operators.CompareString(DC_Main.MsNegativeStkSale, "N", false) == 0) & (Operators.CompareString(val[val.Row, 63], "A", false) == 0) & (Operators.CompareString(val[val.Row, 5], "", false) == 0))
					{
						goto IL_00db;
					}
					goto IL_015a;
					IL_00db:
					num2 = 11;
					if (Operators.CompareString(FormMainBook, "SL QUOT", false) != 0)
					{
						goto IL_00f8;
					}
					goto IL_015a;
					IL_00f8:
					num2 = 12;
					if (Conversion.Val(val[val.Row, 12]) > CurItGwtStk)
					{
						goto IL_011e;
					}
					goto IL_015a;
					IL_011e:
					num2 = 13;
					Interaction.MsgBox((object)("Negative Stock is Not Allow Curent Stock = " + Strings.Format((object)CurItGwtStk, "0.000") + " "), (MsgBoxStyle)0, (object)null);
					goto end_IL_0001_3;
					IL_015a:
					num2 = 19;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 107]))
					{
						goto IL_0192;
					}
					goto IL_0200;
					IL_0192:
					num2 = 20;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_01ac;
					IL_01ac:
					num2 = 21;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_01c6;
					IL_01c6:
					num2 = 22;
					val[val.Row, 107] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0");
					goto IL_0200;
					IL_0200:
					num2 = 24;
					if (Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_023b;
					}
					goto IL_0392;
					IL_023b:
					num2 = 25;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_0255;
					IL_0255:
					num2 = 26;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_026f;
					IL_026f:
					num2 = 27;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_02a7;
					IL_02a7:
					num2 = 28;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_02f5;
					IL_02f5:
					num2 = 29;
					val[val.Row, 43] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 42])), "0.000");
					goto IL_0343;
					IL_0343:
					num2 = 30;
					val[val.Row, 93] = "N";
					goto IL_035c;
					IL_035c:
					num2 = 31;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_0376;
					IL_0376:
					num2 = 32;
					val[val.Row, 105] = Conversions.ToString(0);
					goto IL_0392;
					IL_0392:
					num2 = 34;
					if ((Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0) & (val[10] != 0))
					{
						goto IL_03be;
					}
					goto IL_04cb;
					IL_03be:
					num2 = 35;
					if ((Conversion.Val(val[val.Row, 10]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0411;
					}
					goto IL_04cb;
					IL_0411:
					num2 = 36;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_045f;
					IL_045f:
					num2 = 37;
					val[val.Row, 84] = Conversions.ToString(0);
					goto IL_0479;
					IL_0479:
					num2 = 38;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_04cb;
					IL_04cb:
					num2 = 41;
					if (val.Col == 13)
					{
						goto IL_04e2;
					}
					goto IL_05d6;
					IL_04e2:
					num2 = 42;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 84]))
					{
						goto IL_051d;
					}
					goto IL_05d6;
					IL_051d:
					num2 = 43;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_0555;
					IL_0555:
					num2 = 44;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(TEXT_ENTRY.Text)), "0.000");
					goto IL_059e;
					IL_059e:
					num2 = 45;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_05b8;
					IL_05b8:
					num2 = 46;
					val[val.Row, 105] = Conversions.ToString(0);
					goto IL_05d6;
					IL_05d6:
					num2 = 49;
					if ((Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 105])) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0659;
					}
					goto IL_07ad;
					IL_0659:
					num2 = 50;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_0673;
					IL_0673:
					num2 = 51;
					val[val.Row, 105] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_06ab;
					IL_06ab:
					num2 = 52;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_06e3;
					IL_06e3:
					num2 = 53;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 16]) / 100.0), "0.000");
					goto IL_073b;
					IL_073b:
					num2 = 54;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.000");
					goto IL_0773;
					IL_0773:
					num2 = 55;
					val[val.Row, 93] = "N";
					goto IL_078c;
					IL_078c:
					num2 = 56;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_0978;
					IL_07ad:
					num2 = 58;
					if (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 105]))
					{
						goto IL_07e5;
					}
					goto IL_0839;
					IL_07e5:
					num2 = 59;
					val[val.Row, 105] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_081d;
					IL_081d:
					num2 = 60;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_0839;
					IL_0839:
					num2 = 62;
					if ((Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 68])) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0898;
					}
					goto IL_0978;
					IL_0898:
					num2 = 63;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_08b2;
					IL_08b2:
					num2 = 64;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_08ea;
					IL_08ea:
					num2 = 65;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 15]) / 100.0), "0.000");
					goto IL_0942;
					IL_0942:
					num2 = 66;
					val[val.Row, 93] = "N";
					goto IL_095b;
					IL_095b:
					num2 = 67;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_0978;
					IL_0978:
					num2 = 70;
					if (Conversion.Val(val[val.Row, 17]) != Conversion.Val(val[val.Row, 69]))
					{
						goto IL_09b3;
					}
					goto IL_0b78;
					IL_09b3:
					num2 = 71;
					val[val.Row, 28] = Conversions.ToString(0);
					goto IL_09cd;
					IL_09cd:
					num2 = 72;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_09e7;
					IL_09e7:
					num2 = 73;
					if ((Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0a37;
					}
					goto IL_0a95;
					IL_0a37:
					num2 = 74;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 16]) / 100.0), "0.000");
					goto IL_0b3e;
					IL_0a95:
					num2 = 76;
					if ((Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0ae5;
					}
					goto IL_0b3e;
					IL_0ae5:
					num2 = 77;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 15]) / 100.0), "0.000");
					goto IL_0b3e;
					IL_0b3e:
					num2 = 79;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.000");
					goto IL_0b78;
					IL_0b78:
					num2 = 81;
					if ((Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_0bcb;
					}
					goto IL_0c4d;
					IL_0bcb:
					num2 = 82;
					if (!(Conversion.Val((object)val[28]) >= 0.0))
					{
					}
					goto IL_0bf7;
					IL_0bf7:
					num2 = 84;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_0c4d;
					IL_0c4d:
					num2 = 86;
					if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_0c88;
					}
					goto IL_0eda;
					IL_0c88:
					num2 = 87;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_0ca2;
					IL_0ca2:
					num2 = 88;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_0cbc;
					IL_0cbc:
					num2 = 89;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_0cd6;
					IL_0cd6:
					num2 = 90;
					val[val.Row, 105] = Conversions.ToString(0);
					goto IL_0cf0;
					IL_0cf0:
					num2 = 91;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
					goto IL_0d28;
					IL_0d28:
					num2 = 92;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_0d76;
					IL_0d76:
					num2 = 93;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_0dae;
					IL_0dae:
					num2 = 94;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0e17;
					}
					goto IL_0e9f;
					IL_0e17:
					num2 = 95;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0eda;
					IL_0e9f:
					num2 = 97;
					val[val.Row, 20] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
					goto IL_0eda;
					IL_0eda:
					num2 = 100;
					if (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 70]))
					{
						goto IL_0f15;
					}
					goto IL_1058;
					IL_0f15:
					num2 = 101;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_0f2f;
					IL_0f2f:
					num2 = 102;
					val[val.Row, 70] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_0f67;
					IL_0f67:
					num2 = 103;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0fd0;
					}
					goto IL_1058;
					IL_0fd0:
					num2 = 104;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_1058;
					IL_1058:
					num2 = 107;
					if (Conversion.Val(val[val.Row, 19]) != Conversion.Val(val[val.Row, 71]))
					{
						goto IL_1093;
					}
					goto IL_11d6;
					IL_1093:
					num2 = 108;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_10ad;
					IL_10ad:
					num2 = 109;
					val[val.Row, 71] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_10e5;
					IL_10e5:
					num2 = 110;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_114e;
					}
					goto IL_11d6;
					IL_114e:
					num2 = 111;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_11d6;
					IL_11d6:
					num2 = 114;
					if (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) == 0.0)
					{
						goto IL_1215;
					}
					goto IL_1265;
					IL_1215:
					num2 = 115;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])), "0.000");
					goto IL_1265;
					IL_1265:
					num2 = 117;
					num5 = 0.0;
					goto IL_1273;
					IL_1273:
					num2 = 118;
					text = "N";
					goto IL_127d;
					IL_127d:
					num2 = 119;
					if (val[21] > 0)
					{
						goto IL_1295;
					}
					goto IL_1320;
					IL_1295:
					num2 = 120;
					if (Operators.CompareString(val[val.Row, 102], val[val.Row, 21], false) != 0)
					{
						goto IL_12c7;
					}
					goto IL_132b;
					IL_12c7:
					num2 = 121;
					val[val.Row, 102] = val[val.Row, 21];
					goto IL_12eb;
					IL_12eb:
					num2 = 122;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_1305;
					IL_1305:
					num2 = 123;
					text = val[val.Row, 21];
					goto IL_132b;
					IL_1320:
					num2 = 126;
					text = DC_Main.MsSlAmtType;
					goto IL_132b;
					IL_132b:
					num2 = 128;
					if (Operators.CompareString(text, "F", false) == 0)
					{
						goto IL_134a;
					}
					goto IL_1501;
					IL_134a:
					num2 = 129;
					if (val[20] != 0)
					{
						goto IL_1365;
					}
					goto IL_14e0;
					IL_1365:
					num2 = 130;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_13d1;
					}
					goto IL_14be;
					IL_13d1:
					num2 = 131;
					num5 = Conversions.ToDouble(Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000"));
					goto IL_144e;
					IL_144e:
					num2 = 132;
					val[val.Row, 20] = Strings.Format((object)num5, "0.000");
					goto IL_1476;
					IL_1476:
					num2 = 133;
					val[val.Row, 23] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_155c;
					IL_14be:
					num2 = 135;
					num5 = Conversion.Val(val[val.Row, 14]);
					goto IL_155c;
					IL_14e0:
					num2 = 138;
					num5 = Conversion.Val(val[val.Row, 14]);
					goto IL_155c;
					IL_1501:
					num2 = 141;
					if (Operators.CompareString(text, "G", false) == 0)
					{
						goto IL_151d;
					}
					goto IL_153e;
					IL_151d:
					num2 = 142;
					num5 = Conversion.Val(val[val.Row, 12]);
					goto IL_155c;
					IL_153e:
					num2 = 144;
					num5 = Conversion.Val(val[val.Row, 14]);
					goto IL_155c;
					IL_155c:
					num2 = 146;
					if (Operators.CompareString(val[val.Row, 21], "F", false) == 0)
					{
						goto IL_1586;
					}
					goto IL_15a5;
					IL_1586:
					num2 = 147;
					num5 = Conversion.Val(val[val.Row, 20]);
					goto IL_15a5;
					IL_15a5:
					num2 = 149;
					if ((Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 82])) & (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_161d;
					}
					goto IL_196a;
					IL_161d:
					num2 = 150;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_1658;
					IL_1658:
					num2 = 151;
					val[val.Row, 83] = Conversions.ToString(0);
					goto IL_1676;
					IL_1676:
					num2 = 152;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_1721;
					case "K":
						goto IL_178b;
					default:
						goto IL_17f5;
					}
					goto IL_16c4;
					IL_17f5:
					num2 = 160;
					if (Operators.CompareString(val[val.Row, 21], "F", false) == 0)
					{
						goto IL_181f;
					}
					goto IL_1869;
					IL_181f:
					num2 = 161;
					val[val.Row, 23] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 22]), digits), "0.00");
					goto IL_194c;
					IL_1869:
					num2 = 163;
					if (Operators.CompareString(val[val.Row, 21], "P", false) == 0)
					{
						goto IL_1893;
					}
					goto IL_18ee;
					IL_1893:
					num2 = 164;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 22]), digits), "0.00");
					goto IL_194c;
					IL_18ee:
					num2 = 166;
					val[val.Row, 23] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 22]), digits), "0.00");
					goto IL_194c;
					IL_178b:
					num2 = 158;
					val[val.Row, 23] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 22]) / 1000.0), digits), "0.00");
					goto IL_194c;
					IL_1721:
					num2 = 156;
					val[val.Row, 23] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 22]) / 10.0), digits), "0.00");
					goto IL_194c;
					IL_16c4:
					num2 = 154;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 22]), digits), "0.00");
					goto IL_194c;
					IL_194c:
					num2 = 169;
					val[val.Row, 93] = "N";
					goto IL_196a;
					IL_196a:
					num2 = 171;
					if (val.Col == 23)
					{
						goto IL_1984;
					}
					goto IL_1ccb;
					IL_1984:
					num2 = 172;
					if ((Conversion.Val(val[val.Row, 22]) == 0.0) | ((Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 82])) & (Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 11]) != 0.0)))
					{
						goto IL_1a42;
					}
					goto IL_1ccb;
					IL_1a42:
					num2 = 173;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_1aec;
					case "K":
						goto IL_1b55;
					default:
						goto IL_1bbe;
					}
					goto IL_1a90;
					IL_1bbe:
					num2 = 181;
					if (Operators.CompareString(val[val.Row, 21], "F", false) == 0)
					{
						goto IL_1be8;
					}
					goto IL_1c2f;
					IL_1be8:
					num2 = 182;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_1c8c;
					IL_1c2f:
					num2 = 184;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / num5 + Conversion.Val(val[val.Row, 17]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1c8c;
					IL_1b55:
					num2 = 179;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1c8c;
					IL_1aec:
					num2 = 177;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 17])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1c8c;
					IL_1a90:
					num2 = 175;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 11]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1c8c;
					IL_1c8c:
					num2 = 187;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_1ccb;
					IL_1ccb:
					num2 = 190;
					if ((Conversion.Val(val[val.Row, 24]) != Conversion.Val(val[val.Row, 83])) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_1d2d;
					}
					goto IL_1f22;
					IL_1d2d:
					num2 = 191;
					val[val.Row, 83] = Strings.Format((object)Conversion.Val(val[val.Row, 24]), "0.00");
					goto IL_1d68;
					IL_1d68:
					num2 = 192;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM199NEPK", false) == 0) & (ToDayGlRate != 0.0) & (Operators.CompareString(val[val.Row, 59], "G", false) == 0))
					{
						goto IL_1dbb;
					}
					goto IL_1e15;
					IL_1dbb:
					num2 = 193;
					val[val.Row, 26] = Strings.Format((object)Math.Round(ToDayGlRate * Conversion.Val(val[val.Row, 24]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1e7b;
					IL_1e15:
					num2 = 195;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * Conversion.Val(val[val.Row, 24]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1e7b;
					IL_1e7b:
					num2 = 197;
					if (0u - ((val.Col == 24) ? 1u : 0u) != 0)
					{
						goto IL_1e9c;
					}
					goto IL_1f22;
					IL_1e9c:
					num2 = 198;
					if (Conversion.Val(val[val.Row, 24]) == 0.0)
					{
						goto IL_1ec8;
					}
					goto IL_1f22;
					IL_1ec8:
					num2 = 199;
					val[val.Row, 83] = "";
					goto IL_1ee4;
					IL_1ee4:
					num2 = 200;
					val[val.Row, 26] = "";
					goto IL_1f00;
					IL_1f00:
					num2 = 201;
					val[val.Row, 27] = "";
					goto IL_1f22;
					IL_1f22:
					num2 = 205;
					if ((val.Col == 25) & (val[25] != 0))
					{
						goto IL_1f46;
					}
					goto IL_1fc3;
					IL_1f46:
					num2 = 206;
					if (Operators.CompareString(val[val.Row, 25], val[val.Row, 85], false) != 0)
					{
						goto IL_1f7b;
					}
					goto IL_1fc3;
					IL_1f7b:
					num2 = 207;
					val[val.Row, 85] = val[val.Row, 25];
					goto IL_1fa2;
					IL_1fa2:
					num2 = 208;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_1fc3;
					IL_1fc3:
					num2 = 211;
					if ((Conversion.Val(val[val.Row, 26]) != 0.0) & (Conversion.Val(val[val.Row, 76]) != Conversion.Val(val[val.Row, 26])))
					{
						goto IL_2025;
					}
					goto IL_23ba;
					IL_2025:
					num2 = 212;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_2061;
					IL_2061:
					num2 = 213;
					switch (val[val.Row, 25])
					{
					case "P":
						break;
					case "N":
						goto IL_2122;
					case "K":
						goto IL_2212;
					case "G":
						goto IL_2290;
					default:
						goto IL_22eb;
					}
					goto IL_20c4;
					IL_22eb:
					num2 = 227;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_235c;
					IL_2290:
					num2 = 225;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_235c;
					IL_2212:
					num2 = 223;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 26]) / 1000.0), digits2), "0.00");
					goto IL_235c;
					IL_2122:
					num2 = 217;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_2141;
					}
					goto IL_219d;
					IL_2141:
					num2 = 218;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_235c;
					IL_219d:
					num2 = 220;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_235c;
					IL_20c4:
					num2 = 215;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_235c;
					IL_235c:
					num2 = 229;
					val[val.Row, 77] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_2397;
					IL_2397:
					num2 = 230;
					val[val.Row, 93] = "N";
					goto IL_26c0;
					IL_23ba:
					num2 = 232;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
					{
						goto IL_2401;
					}
					goto IL_26c0;
					IL_2401:
					num2 = 233;
					switch (val[val.Row, 25])
					{
					case "P":
						break;
					case "N":
						goto IL_24b0;
					case "K":
						goto IL_25a6;
					default:
						goto IL_2624;
					}
					goto IL_244f;
					IL_2624:
					num2 = 245;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12]), DC_Main.MsLbrRof), "0.00");
					goto IL_2682;
					IL_25a6:
					num2 = 243;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_2682;
					IL_24b0:
					num2 = 237;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_24cf;
					}
					goto IL_252e;
					IL_24cf:
					num2 = 238;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 14]), DC_Main.MsLbrRof), "0.00");
					goto IL_2682;
					IL_252e:
					num2 = 240;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])), DC_Main.MsLbrRof), "0.00");
					goto IL_2682;
					IL_244f:
					num2 = 235;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_2682;
					IL_2682:
					num2 = 247;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_26c0;
					IL_26c0:
					num2 = 250;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 27]) != 0.0))
					{
						goto IL_2713;
					}
					goto IL_277a;
					IL_2713:
					num2 = 251;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) * Conversion.Val(val[val.Row, 31]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_277a;
					IL_277a:
					num2 = 253;
					if (Conversion.Val(val[val.Row, 32]) != 0.0)
					{
						goto IL_27a9;
					}
					goto IL_2806;
					IL_27a9:
					num2 = 254;
					val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) - Conversion.Val(val[val.Row, 32]), DC_Main.MsLbrRof), "0.00");
					goto IL_2806;
					IL_2806:
					num2 = 256;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_2832;
					}
					goto IL_28a7;
					IL_2832:
					num2 = 257;
					if (Operators.CompareString(EntryMode, "A", false) == 0)
					{
						goto IL_2852;
					}
					goto IL_28a7;
					IL_2852:
					num2 = 258;
					val[val.Row, 38] = Strings.Format((object)(Conversion.Val(val[val.Row, 50]) + Conversion.Val(val[val.Row, 51])), "0.0");
					goto IL_28a7;
					IL_28a7:
					num2 = 261;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_28d9;
					}
					goto IL_2b54;
					IL_28d9:
					num2 = 262;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 30]) != 0.0))
					{
						goto IL_292f;
					}
					goto IL_29e9;
					IL_292f:
					num2 = 263;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 30]) * Conversion.Val(val[val.Row, 31]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_2994;
					IL_2994:
					num2 = 264;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 30]) - Conversion.Val(val[val.Row, 32])), "0.00");
					goto IL_2a25;
					IL_29e9:
					num2 = 266;
					val[val.Row, 35] = Strings.Format((object)Conversion.Val(val[val.Row, 30]), "0.00");
					goto IL_2a25;
					IL_2a25:
					num2 = 268;
					if (Conversion.Val(val[val.Row, 36]) != 0.0)
					{
						goto IL_2a54;
					}
					goto IL_2ac1;
					IL_2a54:
					num2 = 269;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 35]) / (Conversion.Val(val[val.Row, 36]) + 100.0) * 100.0, digits), "0.00");
					goto IL_2ac1;
					IL_2ac1:
					num2 = 271;
					val[val.Row, 22] = "";
					goto IL_2add;
					IL_2add:
					num2 = 272;
					val[val.Row, 23] = "";
					goto IL_2af9;
					IL_2af9:
					num2 = 273;
					val[val.Row, 27] = "";
					goto IL_2b15;
					IL_2b15:
					num2 = 274;
					val[val.Row, 26] = "";
					goto IL_2b31;
					IL_2b31:
					num2 = 275;
					val[val.Row, 29] = "";
					goto IL_3973;
					IL_2b54:
					num2 = 277;
					if (val.Col == 35)
					{
						goto IL_2b6e;
					}
					goto IL_381e;
					IL_2b6e:
					num2 = 278;
					if (Conversion.Val(val[val.Row, 35]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_2ba4;
					}
					goto IL_2bc2;
					IL_2ba4:
					num2 = 279;
					val[val.Row, 93] = "N";
					goto IL_2bc2;
					IL_2bc2:
					num2 = 281;
					if (Conversion.Val(val[val.Row, 32]) != 0.0)
					{
						goto IL_2bf4;
					}
					goto IL_2d94;
					IL_2bf4:
					num2 = 282;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_2c23;
					}
					goto IL_2fed;
					IL_2c23:
					num2 = 283;
					if (Conversion.Val(TEXT_ENTRY.Text) < Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 27]))
					{
						goto IL_2c85;
					}
					goto IL_2fed;
					IL_2c85:
					num2 = 284;
					val[val.Row, 32] = Strings.Format((object)(Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 27]) - Conversion.Val(TEXT_ENTRY.Text)), "0.00");
					goto IL_2cfd;
					IL_2cfd:
					num2 = 285;
					if (Conversion.Val(val[val.Row, 31]) != 0.0)
					{
						goto IL_2d2c;
					}
					goto IL_2fed;
					IL_2d2c:
					num2 = 286;
					val[val.Row, 31] = Strings.Format((object)(Conversion.Val(val[val.Row, 32]) * 100.0 / Conversion.Val(val[val.Row, 27])), "0.00");
					goto IL_2fed;
					IL_2d94:
					num2 = 291;
					if (Conversion.Val(val[val.Row, 36]) != 0.0)
					{
						goto IL_2dc6;
					}
					goto IL_2f3e;
					IL_2dc6:
					num2 = 292;
					if (Conversion.Val(val[val.Row, 35]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_2dff;
					}
					goto IL_2fed;
					IL_2dff:
					num2 = 293;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "AK023NPAK", false) == 0)
					{
						goto IL_2e1e;
					}
					goto IL_2e87;
					IL_2e1e:
					num2 = 294;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 29]) - Conversion.Val(val[val.Row, 23])), "0.00");
					goto IL_2fed;
					IL_2e87:
					num2 = 296;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]))
					{
						goto IL_2ed0;
					}
					goto IL_2fed;
					IL_2ed0:
					num2 = 297;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 29]) - Conversion.Val(val[val.Row, 23])), "0.00");
					goto IL_2fed;
					IL_2f3e:
					num2 = 302;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]))
					{
						goto IL_2f87;
					}
					goto IL_2fed;
					IL_2f87:
					num2 = 303;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 29]) - Conversion.Val(val[val.Row, 23])), "0.00");
					goto IL_2fed;
					IL_2fed:
					num2 = 307;
					if (Conversion.Val(val[val.Row, 27]) <= 0.0)
					{
						goto IL_301f;
					}
					goto IL_3370;
					IL_301f:
					num2 = 308;
					val[val.Row, 27] = "";
					goto IL_303b;
					IL_303b:
					num2 = 309;
					val[val.Row, 26] = "";
					goto IL_3057;
					IL_3057:
					num2 = 310;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM240NPPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0))
					{
						goto end_IL_0001_3;
					}
					goto IL_3091;
					IL_3091:
					num2 = 313;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 29])), "0.00");
					goto IL_30de;
					IL_30de:
					num2 = 314;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_318d;
					case "K":
						goto IL_31fb;
					default:
						goto IL_3269;
					}
					goto IL_312c;
					IL_3269:
					num2 = 322;
					if (Operators.CompareString(text, "F", false) == 0)
					{
						goto IL_3285;
					}
					goto IL_32d1;
					IL_3285:
					num2 = 323;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_3333;
					IL_32d1:
					num2 = 325;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])), DC_Main.MsItmRateRof), "0.00");
					goto IL_3333;
					IL_31fb:
					num2 = 320;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3333;
					IL_318d:
					num2 = 318;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3333;
					IL_312c:
					num2 = 316;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsItmRateRof), "0.00");
					goto IL_3333;
					IL_3333:
					num2 = 328;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_3370;
					IL_3370:
					num2 = 330;
					if (Conversion.Val(val[val.Row, 27]) != Conversion.Val(val[val.Row, 77]))
					{
						goto IL_33ae;
					}
					goto IL_381e;
					IL_33ae:
					num2 = 331;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 26]) != 0.0))
					{
						goto IL_3405;
					}
					goto IL_381e;
					IL_3405:
					num2 = 332;
					switch (val[val.Row, 25])
					{
					case "P":
						break;
					case "N":
						goto IL_34b4;
					case "K":
						goto IL_35aa;
					default:
						goto IL_3628;
					}
					goto IL_3453;
					IL_3628:
					num2 = 344;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12]), DC_Main.MsLbrRof), "0.00");
					goto IL_3686;
					IL_35aa:
					num2 = 342;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_3686;
					IL_34b4:
					num2 = 336;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_34d3;
					}
					goto IL_3532;
					IL_34d3:
					num2 = 337;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 14]), DC_Main.MsLbrRof), "0.00");
					goto IL_3686;
					IL_3532:
					num2 = 339;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])), DC_Main.MsLbrRof), "0.00");
					goto IL_3686;
					IL_3453:
					num2 = 334;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_3686;
					IL_3686:
					num2 = 346;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_36c1;
					IL_36c1:
					num2 = 347;
					if ((Conversion.Val(val[val.Row, 24]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_3717;
					}
					goto IL_381e;
					IL_3717:
					num2 = 348;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM199NEPK", false) == 0) & (ToDayGlRate != 0.0) & (Operators.CompareString(val[val.Row, 59], "G", false) == 0))
					{
						goto IL_376a;
					}
					goto IL_37ba;
					IL_376a:
					num2 = 349;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / ToDayGlRate), "0.000");
					goto IL_381e;
					IL_37ba:
					num2 = 351;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / Conversion.Val(val[val.Row, 22])), "0.000");
					goto IL_381e;
					IL_381e:
					num2 = 357;
					if (Operators.CompareString(val[val.Row, 93], "N", false) == 0)
					{
						goto IL_3848;
					}
					goto IL_38c7;
					IL_3848:
					num2 = 358;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 32])), "0.00");
					goto IL_38c7;
					IL_38c7:
					num2 = 360;
					if (Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_38f3;
					}
					goto IL_3973;
					IL_38f3:
					num2 = 361;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 32])), "0.00");
					goto IL_3973;
					IL_3973:
					num2 = 364;
					if (Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_399f;
					}
					goto IL_39dc;
					IL_399f:
					num2 = 365;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 35]), "0.00");
					goto IL_39dc;
					IL_39dc:
					num2 = 367;
					if (val.Col == 36)
					{
						goto IL_39f6;
					}
					goto IL_3a82;
					IL_39f6:
					num2 = 368;
					if (Conversion.Val(TEXT_ENTRY.Text) != Conversion.Val(val[val.Row, 36]))
					{
						goto IL_3a2c;
					}
					goto IL_3a82;
					IL_3a2c:
					num2 = 369;
					val[val.Row, 36] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
					goto IL_3a62;
					IL_3a62:
					num2 = 370;
					val[val.Row, 93] = "N";
					goto IL_3a82;
					IL_3a82:
					num2 = 373;
					if (Conversion.Val(val[val.Row, 36]) != 0.0)
					{
						goto IL_3ab4;
					}
					goto IL_45f7;
					IL_3ab4:
					num2 = 374;
					if (Operators.CompareString(val[val.Row, 93], "N", false) == 0)
					{
						goto IL_3ae1;
					}
					goto IL_4633;
					IL_3ae1:
					num2 = 375;
					val[val.Row, 93] = "Y";
					goto IL_3afd;
					IL_3afd:
					num2 = 376;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 35]) / (Conversion.Val(val[val.Row, 36]) + 100.0) * 100.0, digits), "0.00");
					goto IL_3b68;
					IL_3b68:
					num2 = 377;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
					{
						goto IL_3b8a;
					}
					goto IL_3ec1;
					IL_3b8a:
					num2 = 378;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_3bb9;
					}
					goto IL_3c2a;
					IL_3bb9:
					num2 = 379;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 37]) - Conversion.Val(val[val.Row, 27]) - Conversion.Val(val[val.Row, 29]), digits2), "0.00");
					goto IL_3c2a;
					IL_3c2a:
					num2 = 381;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_3cd9;
					case "K":
						goto IL_3d47;
					default:
						goto IL_3db5;
					}
					goto IL_3c78;
					IL_3db5:
					num2 = 389;
					if (Operators.CompareString(text, "F", false) == 0)
					{
						goto IL_3dd1;
					}
					goto IL_3e1d;
					IL_3dd1:
					num2 = 390;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_3e7f;
					IL_3e1d:
					num2 = 392;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])), DC_Main.MsItmRateRof), "0.00");
					goto IL_3e7f;
					IL_3d47:
					num2 = 387;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3e7f;
					IL_3cd9:
					num2 = 385;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3e7f;
					IL_3c78:
					num2 = 383;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsItmRateRof), "0.00");
					goto IL_3e7f;
					IL_3e7f:
					num2 = 395;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_3f82;
					IL_3ec1:
					num2 = 397;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 32]) == 0.0))
					{
						goto IL_3f11;
					}
					goto IL_3f82;
					IL_3f11:
					num2 = 398;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 37]) - Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 29]), digits2), "0.00");
					goto IL_3f82;
					IL_3f82:
					num2 = 401;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & ((Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0) | (Conversion.Val(val[val.Row, 26]) != 0.0)))
					{
						goto IL_3fec;
					}
					goto IL_4380;
					IL_3fec:
					num2 = 402;
					if ((Operators.CompareString(val[val.Row, 25], "P", false) == 0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_403a;
					}
					goto IL_4091;
					IL_403a:
					num2 = 403;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 11])), "0.00");
					goto IL_4380;
					IL_4091:
					num2 = 405;
					if ((Operators.CompareString(val[val.Row, 25], "N", false) == 0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_40e2;
					}
					goto IL_41c4;
					IL_40e2:
					num2 = 406;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_4101;
					}
					goto IL_4156;
					IL_4101:
					num2 = 407;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 14])), "0.00");
					goto IL_4380;
					IL_4156:
					num2 = 409;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17]))), "0.00");
					goto IL_4380;
					IL_41c4:
					num2 = 412;
					if ((Operators.CompareString(val[val.Row, 25], "K", false) == 0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_4212;
					}
					goto IL_4273;
					IL_4212:
					num2 = 413;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12]) * 1000.0), "0.00");
					goto IL_4380;
					IL_4273:
					num2 = 415;
					if ((Operators.CompareString(val[val.Row, 25], "G", false) == 0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_42c1;
					}
					goto IL_4316;
					IL_42c1:
					num2 = 416;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12])), "0.00");
					goto IL_4380;
					IL_4316:
					num2 = 418;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17]))), "0.00");
					goto IL_4380;
					IL_4380:
					num2 = 421;
					if ((Conversion.Val(val[val.Row, 24]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_43d6;
					}
					goto IL_45b6;
					IL_43d6:
					num2 = 422;
					if (Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_4402;
					}
					goto IL_445f;
					IL_4402:
					num2 = 423;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / Conversion.Val(val[val.Row, 22])), "0.00");
					goto IL_445f;
					IL_445f:
					num2 = 425;
					if (val.Col == 36)
					{
						goto IL_4479;
					}
					goto IL_45b6;
					IL_4479:
					num2 = 426;
					if (Conversion.Val(TEXT_ENTRY.Text) != 0.0)
					{
						goto IL_44a6;
					}
					goto IL_45b6;
					IL_44a6:
					num2 = 427;
					if ((Conversion.Val(val[val.Row, 26]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_44fc;
					}
					goto IL_45b6;
					IL_44fc:
					num2 = 428;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / Conversion.Val(val[val.Row, 22])), "0.00");
					goto IL_4557;
					IL_4557:
					num2 = 429;
					val[val.Row, 83] = Strings.Format((object)Conversion.Val(val[val.Row, 24]), "0.00");
					goto IL_4592;
					IL_4592:
					num2 = 430;
					val[val.Row, 93] = "Y";
					goto IL_45b6;
					IL_45b6:
					num2 = 435;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_4633;
					IL_45f7:
					num2 = 438;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 35]), "0.00");
					goto IL_4633;
					IL_4633:
					num2 = 440;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
					{
						goto IL_4655;
					}
					goto IL_48be;
					IL_4655:
					num2 = 441;
					if ((Conversion.Val(val[val.Row, 39]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_46ab;
					}
					goto IL_48be;
					IL_46ab:
					num2 = 442;
					dataView = new DataView(RsGrTch);
					goto IL_46be;
					IL_46be:
					num2 = 443;
					dataView.RowFilter = "IT_CODE = '" + val[val.Row, 3] + "'";
					goto IL_46ea;
					IL_46ea:
					num2 = 444;
					num6 = 0;
					goto IL_46f3;
					IL_46f3:
					num2 = 445;
					if (dataView.Count > 0)
					{
						goto IL_470c;
					}
					goto IL_482b;
					IL_470c:
					num2 = 446;
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView[0])["MELTING_PRC"]);
					num7 = DC_Main.Fnv(ref Value);
					dataRowView["MELTING_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					num8 = Conversions.ToDouble(Strings.Format((object)num7, "0.00"));
					goto IL_475f;
					IL_475f:
					num2 = 447;
					val[val.Row, 106] = Strings.Format((object)num8, "0.00");
					goto IL_4787;
					IL_4787:
					num2 = 448;
					num6 = Conversions.ToInteger(Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * num8 / 100.0), "0.000"));
					goto IL_47db;
					IL_47db:
					num2 = 449;
					val[val.Row, 40] = Strings.Format((object)((double)num6 * Conversion.Val(val[val.Row, 39]) / 100.0), "0.000");
					goto IL_48be;
					end_IL_0001_2:
					break;
				}
				num2 = 458;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (Exception obj)
			{ if (!(obj is Exception && num3 != 0 && num == 0)) throw;
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 20508;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

		// ===== END VERBATIM TR_SALE.cs:9524-11891 =====
	}

	public static class Program
	{
		// The grid columns the result reports: every sale-line cell CommPassTotal reads or writes up to column 40,
		// plus the rate and labour shadows (82, 83) it keeps to detect an edit.
		private static readonly int[] ReportedColumns = BuildReportedColumns();

		private static int[] BuildReportedColumns()
		{
			var list = new List<int>();
			for (int c = 10; c <= 40; c++) list.Add(c);
			list.Add(82);
			list.Add(83);
			return list.ToArray();
		}

		private static void ApplySettings(IDictionary<string, object> s)
		{
			DC_Main.SSRegSrNo = "";
			DC_Main.MsMetalType = "G";
			DC_Main.MsLbrGen = "N";
			DC_Main.MsSlAmtType = "N";
			DC_Main.MsLbrRof = 2;
			DC_Main.MsItmRateRof = 2;
			DC_Main.MsLbrWithGht = "Y";
			DC_Main.MsAllRofRemove = "N";
			DC_Main.MsNegativeStkSale = "Y";
			if (s == null) return;
			foreach (var kv in s)
			{
				string v = Convert.ToString(kv.Value, CultureInfo.InvariantCulture);
				switch (kv.Key)
				{
					case "MsMetalType": DC_Main.MsMetalType = v; break;
					case "MsLbrGen": DC_Main.MsLbrGen = v; break;
					case "MsSlAmtType": DC_Main.MsSlAmtType = v; break;
					case "MsLbrRof": DC_Main.MsLbrRof = int.Parse(v, CultureInfo.InvariantCulture); break;
					case "MsItmRateRof": DC_Main.MsItmRateRof = int.Parse(v, CultureInfo.InvariantCulture); break;
					case "MsLbrWithGht": DC_Main.MsLbrWithGht = v; break;
					case "MsAllRofRemove": DC_Main.MsAllRofRemove = v; break;
					case "MsNegativeStkSale": DC_Main.MsNegativeStkSale = v; break;
					default: throw new InvalidDataException("unknown setting " + kv.Key);
				}
			}
		}

		private static string Json(string s)
		{
			var sb = new StringBuilder("\"");
			foreach (char ch in s ?? "")
			{
				switch (ch)
				{
					case '"': sb.Append("\\\""); break;
					case '\\': sb.Append("\\\\"); break;
					case '\n': sb.Append("\\n"); break;
					case '\r': sb.Append("\\r"); break;
					case '\t': sb.Append("\\t"); break;
					default:
						if (ch < 0x20) sb.Append("\\u").Append(((int)ch).ToString("x4")); else sb.Append(ch);
						break;
				}
			}
			return sb.Append('"').ToString();
		}

		public static int Main(string[] args)
		{
			if (args.Length < 4)
			{
				Console.Error.WriteLine("usage: Oracle.exe vectors.json expected.json <run-id> <commit-sha>");
				return 2;
			}
			// The desktop runs on Indian English Windows; "0.00" formats the same way there and on en-US.
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IN");
			var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
			var root = (IDictionary<string, object>)serializer.DeserializeObject(File.ReadAllText(args[0], Encoding.UTF8));
			var vectors = (object[])root["vectors"];

			var output = new StringBuilder();
			output.Append("{\n");
			output.Append("  \"family\": \"sales-line\",\n");
			output.Append("  \"source\": {\n");
			output.Append("    \"workflow\": \"desktop-oracle.yml\",\n");
			output.Append("    \"runId\": " + Json(args[2]) + ",\n");
			output.Append("    \"commit\": " + Json(args[3]) + ",\n");
			output.Append("    \"clr\": " + Json(Environment.Version.ToString()) + ",\n");
			output.Append("    \"culture\": " + Json(CultureInfo.CurrentCulture.Name) + ",\n");
			output.Append("    \"method\": \"TR_SALE.cs:9524-11891 CommPassTotal\"\n");
			output.Append("  },\n");
			output.Append("  \"results\": [\n");

			for (int i = 0; i < vectors.Length; i++)
			{
				var v = (IDictionary<string, object>)vectors[i];
				string id = Convert.ToString(v["id"], CultureInfo.InvariantCulture);
				ApplySettings(v.ContainsKey("settings") ? (IDictionary<string, object>)v["settings"] : null);
				Interaction.LastPrompt = null;

				var form = new TR_SALE();
				form.MSG.Row = 1;
				form.MSG.Col = Convert.ToInt32(v["col"], CultureInfo.InvariantCulture);
				var cells = (IDictionary<string, object>)v["cells"];
				foreach (var kv in cells)
				{
					form.MSG[1, int.Parse(kv.Key, CultureInfo.InvariantCulture)] = Convert.ToString(kv.Value, CultureInfo.InvariantCulture);
				}
				if (v.ContainsKey("colWidths"))
				{
					foreach (var kv in (IDictionary<string, object>)v["colWidths"])
					{
						form.MSG.SetWidth(int.Parse(kv.Key, CultureInfo.InvariantCulture), Convert.ToInt32(kv.Value, CultureInfo.InvariantCulture));
					}
				}
				form.TEXT_ENTRY.Text = v.ContainsKey("textEntry")
					? Convert.ToString(v["textEntry"], CultureInfo.InvariantCulture)
					: form.MSG[1, form.MSG.Col];
				int passes = v.ContainsKey("passes") ? Convert.ToInt32(v["passes"], CultureInfo.InvariantCulture) : 1;

				string error = null;
				try
				{
					for (int p = 0; p < passes; p++) form.Run();
				}
				catch (Exception ex)
				{
					error = ex.GetType().Name + ": " + ex.Message;
				}

				output.Append("    {\"id\": " + Json(id));
				if (error != null) output.Append(", \"error\": " + Json(error));
				if (Interaction.LastPrompt != null) output.Append(", \"msgBox\": " + Json(Interaction.LastPrompt));
				output.Append(", \"cells\": {");
				for (int c = 0; c < ReportedColumns.Length; c++)
				{
					if (c > 0) output.Append(", ");
					int col = ReportedColumns[c];
					output.Append("\"" + col.ToString(CultureInfo.InvariantCulture) + "\": " + Json(form.MSG[1, col]));
				}
				output.Append("}}");
				output.Append(i + 1 < vectors.Length ? ",\n" : "\n");
			}

			output.Append("  ]\n}\n");
			File.WriteAllText(args[1], output.ToString(), new UTF8Encoding(false));
			Console.WriteLine("vectors=" + vectors.Length + " clr=" + Environment.Version + " culture=" + CultureInfo.CurrentCulture.Name);
			return 0;
		}
	}
}
