// Minimal Excel Interop stubs — ONLY the types actually used in RP_ORD_TRACK.cs and UT_E_INVOICE.cs
// These do NOT define conflicting types like TextBox, Label, DataTable, CheckBox, Font etc.

namespace Microsoft.Office.Interop.Excel
{
    // Use explicit interface to avoid name clashes — only define non-conflicting names
    public interface _Application {
        bool Visible { get; set; }
        bool DisplayAlerts { get; set; }
        void Quit();
        Workbooks Workbooks { get; }
    }

    public interface Workbooks {
        Workbook Open(string Filename, object UpdateLinks = null, object ReadOnly = null,
            object Format = null, object Password = null, object WriteResPassword = null,
            object IgnoreReadOnlyRecommended = null, object Origin = null, object Delimiter = null,
            object Editable = null, object Notify = null, object Converter = null,
            object AddToMru = null, object Local = null, object CorruptLoad = null);
    }

    public interface Workbook {
        Sheets Worksheets { get; }
        Sheets Sheets { get; }
        void Close(object SaveChanges = null, object Filename = null, object RouteWorkbook = null);
        void Save();
        void SaveAs(object Filename = null, object FileFormat = null, object Password = null,
            object WriteResPassword = null, object ReadOnlyRecommended = null,
            object CreateBackup = null, object AccessMode = null, object ConflictResolution = null,
            object AddToMru = null, object TextCodepage = null, object TextVisualLayout = null,
            object Local = null);
        PageSetup PageSetup { get; }
        ExcelRange get_Range(object Cell1, object Cell2 = null);
        Sheets ActiveSheet { get; }
    }

    public interface Sheets {
        Worksheet this[object Index] { get; }
        int Count { get; }
        Worksheet Add(object Before = null, object After = null, object Count = null, object Type = null);
    }

    public interface Worksheet {
        ExcelRange Cells { get; }
        ExcelRange get_Range(object Cell1, object Cell2 = null);
        ExcelRange UsedRange { get; }
        string Name { get; set; }
        void Activate();
        void Delete();
        PageSetup PageSetup { get; }
        int Index { get; }
        void SaveAs(string Filename);
    }

    public interface ExcelRange {
        object Value { get; set; }
        object Value2 { get; set; }
        object this[object RowIndex, object ColumnIndex] { get; set; }
        ExcelBorders Borders { get; }
        ExcelFont Font { get; }
        ExcelInterior Interior { get; }
        object HorizontalAlignment { get; set; }
        object VerticalAlignment { get; set; }
        object WrapText { get; set; }
        object NumberFormat { get; set; }
        object MergeCells { get; set; }
        double RowHeight { get; set; }
        double ColumnWidth { get; set; }
        int Count { get; }
        int Row { get; }
        int Column { get; }
        int Rows { get; }
        int Columns { get; }
        ExcelRange MergeArea { get; }
        void Merge(object Across = null);
        void AutoFit();
        void Select();
        void ClearContents();
        void Clear();
        void AutoFilter(int Field = 1, object Criteria1 = null, object Operator = null,
            object Criteria2 = null, object VisibleDropDown = null);
    }

    public interface ExcelBorders {
        ExcelBorder this[XlBordersIndex Border] { get; }
        object Color { get; set; }
        object LineStyle { get; set; }
        object Weight { get; set; }
    }

    public interface ExcelBorder {
        object Color { get; set; }
        object LineStyle { get; set; }
        object Weight { get; set; }
    }

    public interface ExcelFont {
        bool Bold { get; set; }
        object Color { get; set; }
        double Size { get; set; }
        string Name { get; set; }
        bool Italic { get; set; }
        bool Underline { get; set; }
    }

    public interface ExcelInterior {
        object Color { get; set; }
        object Pattern { get; set; }
        object ColorIndex { get; set; }
    }

    public interface PageSetup {
        XlPaperSize PaperSize { get; set; }
        XlPageOrientation Orientation { get; set; }
        double LeftMargin { get; set; }
        double RightMargin { get; set; }
        double TopMargin { get; set; }
        double BottomMargin { get; set; }
        double HeaderMargin { get; set; }
        double FooterMargin { get; set; }
        bool FitToPage { get; set; }
        int FitToPagesWide { get; set; }
        int FitToPagesTall { get; set; }
        bool CenterHorizontally { get; set; }
        bool CenterVertically { get; set; }
        double Zoom { get; set; }
        string LeftHeader { get; set; }
        string CenterHeader { get; set; }
        string RightHeader { get; set; }
        string LeftFooter { get; set; }
        string CenterFooter { get; set; }
        string RightFooter { get; set; }
    }

    // Enums
    public enum XlBordersIndex {
        xlDiagonalDown = 5, xlDiagonalUp = 6, xlEdgeLeft = 7, xlEdgeTop = 8,
        xlEdgeBottom = 9, xlEdgeRight = 10, xlInsideVertical = 11, xlInsideHorizontal = 12
    }
    public enum XlLineStyle { xlContinuous = 1, xlDot = -4118, xlDash = -4115, xlNone = -4142 }
    public enum XlBorderWeight { xlHairline = 1, xlThin = 2, xlMedium = -4138, xlThick = 4 }
    public enum XlHAlign { xlHAlignGeneral = 1, xlHAlignLeft = -4131, xlHAlignCenter = -4108, xlHAlignRight = -4152, xlHAlignFill = 5, xlHAlignJustify = -4130, xlHAlignCenterAcrossSelection = 7, xlHAlignDistributed = -4117 }
    public enum XlVAlign { xlVAlignTop = -4160, xlVAlignCenter = -4108, xlVAlignBottom = -4107, xlVAlignJustify = -4130, xlVAlignDistributed = -4117 }
    public enum XlFileFormat { xlWorkbookDefault = 51, xlOpenXMLWorkbook = 51, xlCSV = 6 }
    public enum XlPaperSize { xlPaperA4 = 9, xlPaperLetter = 1 }
    public enum XlPageOrientation { xlPortrait = 1, xlLandscape = 2 }
    public enum XlAutoFilterOperator { xlAnd = 1, xlOr = 2 }
    public enum XlCellType { xlCellTypeVisible = 12 }
}
