
using System;
using System.Windows.Forms;
using System.ComponentModel;

// ============================================================
// STUB: AxMSFlexGrid / MSFlexGrid — compile-time stubs only
// ============================================================

namespace AxMSFlexGridLib {
    [AxHost.ClsidAttribute("{...}")]
    public class AxMSFlexGrid : System.Windows.Forms.Control {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public object TextMatrix { get; set; }
        public string Text { get; set; }
        public object this[int r, int c] { get => null; set { } }
        public void Clear() { }
        public void AddItem(string item) { }
        public int FixedRows { get; set; }
        public int FixedCols { get; set; }
        public int ColWidth { get; set; }
        public object ColAlignment { get; set; }
        public object FillStyle { get; set; }
        public object SelectionMode { get; set; }
        public object HighLight { get; set; }
        public object GridLines { get; set; }
        public int RowHeight { get; set; }
    }
}

namespace MSFlexGridLib {
    public class MSFlexGrid { }
}
