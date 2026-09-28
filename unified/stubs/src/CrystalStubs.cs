
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

// ============================================================
// STUB: SAP Crystal Reports — compile-time stubs only
// Replace with real Crystal Reports DLLs for runtime.
// ============================================================

namespace CrystalDecisions.CrystalReports.Engine {
    public class ReportDocument : IDisposable {
        public void Load(string filename) { }
        public void SetDataSource(DataTable dt) { }
        public void SetDataSource(DataSet ds) { }
        public void SetParameterValue(string paramName, object val) { }
        public ReportSelectionFormula RecordSelectionFormula { get; set; } = "";
        public DataDefinition DataDefinition { get; } = new DataDefinition();
        public Database Database { get; } = new Database();
        public PrintOptions PrintOptions { get; } = new PrintOptions();
        public void PrintToPrinter(int copies, bool collated, int startPage, int endPage) { }
        public void ExportToDisk(ExportFormatType format, string path) { }
        public System.IO.Stream ExportToStream(ExportFormatType format) => new System.IO.MemoryStream();
        public void Dispose() { }
        public void Close() { }
        public void Refresh() { }
        public ReportDefinition ReportDefinition { get; } = new ReportDefinition();
    }
    public class ReportSelectionFormula { public string Text { get; set; } public static implicit operator ReportSelectionFormula(string s) => new ReportSelectionFormula { Text = s }; public static implicit operator string(ReportSelectionFormula f) => f?.Text; }
    public class DataDefinition { public FormulaFieldDefinitions FormulaFields { get; } = new FormulaFieldDefinitions(); }
    public class FormulaFieldDefinitions { public FormulaFieldDefinition this[string name] => new FormulaFieldDefinition(); }
    public class FormulaFieldDefinition { public string Text { get; set; } }
    public class Database { public Tables Tables { get; } = new Tables(); }
    public class Tables { public Table this[int i] => new Table(); public int Count => 0; }
    public class Table { public TableLogOnInfo LogOnInfo { get; } = new TableLogOnInfo(); public void ApplyLogOnInfo(TableLogOnInfo info) { } }
    public class TableLogOnInfo { public ConnectionInfo ConnectionInfo { get; } = new ConnectionInfo(); }
    public class ConnectionInfo { public string ServerName { get; set; } public string DatabaseName { get; set; } public string UserID { get; set; } public string Password { get; set; } public bool IntegratedSecurity { get; set; } }
    public class PrintOptions { public string PrinterName { get; set; } }
    public class ReportDefinition { }
    public enum ExportFormatType { PortableDocFormat, MicrosoftWord, MicrosoftExcel, HTML40, CrystalReport }
}

namespace CrystalDecisions.Windows.Forms {
    public class CrystalReportViewer : System.Windows.Forms.Control {
        public CrystalDecisions.CrystalReports.Engine.ReportDocument ReportSource { get; set; }
        public bool ShowRefreshButton { get; set; }
        public bool ShowCloseButton { get; set; }
        public void RefreshReport() { }
    }
}

namespace CrystalDecisions.Shared {
    public class ExportOptions { }
    public class PdfRtfWordFormatOptions { }
}

namespace Interop.Crystal {
    public class CrystalActiveXReportViewerClass { }
}
