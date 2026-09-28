
using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

// ============================================================
// STUB: DevExpress v19.1 — compile-time stubs only
// These are minimal implementations to allow compilation.
// Replace with real DevExpress v19.1 DLLs for runtime.
// ============================================================

namespace DevExpress.XtraEditors {
    public class SimpleButton : Button { public string ImageOptions_SvgImage { get; set; } }
    public class SearchControl : TextBox { }
    public class DateEdit : DateTimePicker { public object EditValue { get; set; } }
    public class TextEdit : TextBox { public object EditValue { get; set; } }
    public class SpinEdit : NumericUpDown { public object EditValue { get; set; } }
    public class CheckEdit : CheckBox { public object EditValue { get; set; } }
    public class ComboBoxEdit : ComboBox { public object EditValue { get; set; } }
    public class MemoEdit : TextBox { public object EditValue { get; set; } }
    public class PictureEdit : PictureBox { public object EditValue { get; set; } }
    public class LookUpEdit : ComboBox { public object EditValue { get; set; } }
    public class GridLookUpEdit : ComboBox { 
        public object EditValue { get; set; } 
        public DevExpress.XtraGrid.Views.Grid.GridView Properties { get; } = new DevExpress.XtraGrid.Views.Grid.GridView();
    }
    public class XtraForm : Form { }
    public class XtraFolderBrowserDialog : CommonDialog { public string SelectedPath { get; set; } public override void Reset() { } protected override bool RunDialog(IntPtr hwndOwner) => true; }
    public class XtraOpenFileDialog : CommonDialog { public string FileName { get; set; } public string[] FileNames { get; set; } public string Filter { get; set; } public override void Reset() { } protected override bool RunDialog(IntPtr hwndOwner) => true; }
    public class XtraSaveFileDialog : CommonDialog { public string FileName { get; set; } public string Filter { get; set; } public override void Reset() { } protected override bool RunDialog(IntPtr hwndOwner) => true; }
    public class XtraMessageBox { 
        public static DialogResult Show(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK) 
            => MessageBox.Show(text, caption, buttons);
    }
    public class PanelControl : Panel { }
    public class SplitterControl : Splitter { }
    public class ImageCollection : Component { public List<Image> Images { get; } = new List<Image>(); public List<Image> Images2 { get; } = new List<Image>(); }
    public class SvgImage { public static SvgImage FromFile(string path) => new SvgImage(); public static SvgImage FromStream(System.IO.Stream s) => new SvgImage(); }
    public class SvgImageCollection { }
}

namespace DevExpress.XtraEditors.Controls {
    public class EditorButton { public string Caption { get; set; } }
    public class ButtonCollection : List<EditorButton> { }
}

namespace DevExpress.XtraEditors.Repository {
    public class RepositoryItem { }
    public class RepositoryItemButtonEdit : RepositoryItem { }
    public class RepositoryItemComboBox : RepositoryItem { }
    public class RepositoryItemCheckEdit : RepositoryItem { }
    public class RepositoryItemImageEdit : RepositoryItem { }
    public class RepositoryItemTextEdit : RepositoryItem { }
    public class RepositoryItemSpinEdit : RepositoryItem { }
    public class RepositoryItemDateEdit : RepositoryItem { }
    public class RepositoryItemLookUpEdit : RepositoryItem { }
    public class RepositoryItemGridLookUpEdit : RepositoryItem { }
    public class RepositoryItemMemoEdit : RepositoryItem { }
    public class RepositoryItemHyperLinkEdit : RepositoryItem { }
    public class RepositoryItemCalcEdit : RepositoryItem { }
    public class RepositoryItemColorEdit : RepositoryItem { }
    public class RepositoryItemFontEdit : RepositoryItem { }
    public class RepositoryItemMemoExEdit : RepositoryItem { }
    public class RepositoryItemProgressBar : RepositoryItem { }
    public class RepositoryItemRatingEdit : RepositoryItem { }
    public class RepositoryItemToggleSwitchEdit : RepositoryItem { }
}

namespace DevExpress.XtraGrid {
    public class GridControl : System.Windows.Forms.Control {
        public DevExpress.XtraGrid.Views.Grid.GridView MainView { get; set; } = new DevExpress.XtraGrid.Views.Grid.GridView();
        public object DataSource { get; set; }
        public DevExpress.XtraGrid.Views.Base.BaseView FocusedView { get; set; }
        public List<DevExpress.XtraGrid.Views.Base.BaseView> Views { get; } = new List<DevExpress.XtraGrid.Views.Base.BaseView>();
        public void RefreshDataSource() { }
        public void BeginUpdate() { }
        public void EndUpdate() { }
        public void ForceInitialize() { }
    }
}

namespace DevExpress.XtraGrid.Views.Base {
    public class BaseView : Component { 
        public int FocusedRowHandle { get; set; }
        public object GetRow(int rowHandle) => null;
        public object GetRowCellValue(int rowHandle, string fieldName) => null;
        public object GetRowCellValue(int rowHandle, DevExpress.XtraGrid.Columns.GridColumn col) => null;
        public void SetRowCellValue(int rowHandle, string fieldName, object value) { }
        public void SetRowCellValue(int rowHandle, DevExpress.XtraGrid.Columns.GridColumn col, object value) { }
        public int RowCount { get; }
        public event EventHandler FocusedRowChanged;
        public event RowCellCustomDrawEventHandler CustomDrawCell;
    }
    public delegate void RowCellCustomDrawEventHandler(object sender, RowCellCustomDrawEventArgs e);
    public class RowCellCustomDrawEventArgs : EventArgs {
        public int RowHandle { get; }
        public DevExpress.XtraGrid.Columns.GridColumn Column { get; }
        public object CellValue { get; }
        public System.Drawing.Graphics Graphics { get; }
        public System.Drawing.Rectangle Bounds { get; }
        public void DefaultDraw() { }
        public bool Handled { get; set; }
    }
    public class FocusedRowChangedEventArgs : EventArgs {
        public int FocusedRowHandle { get; }
        public int PrevFocusedRowHandle { get; }
    }
}

namespace DevExpress.XtraGrid.Views.Grid {
    public class GridView : DevExpress.XtraGrid.Views.Base.BaseView {
        public DevExpress.XtraGrid.Columns.GridColumnCollection Columns { get; } = new DevExpress.XtraGrid.Columns.GridColumnCollection();
        public object DataSource { get; set; }
        public bool AutoWidth { get; set; }
        public bool ShowGroupPanel { get; set; }
        public bool OptionsBehavior_EditorShowMode { get; set; }
        public GridViewOptionsView OptionsView { get; } = new GridViewOptionsView();
        public GridViewOptionsBehavior OptionsBehavior { get; } = new GridViewOptionsBehavior();
        public GridViewOptionsSelection OptionsSelection { get; } = new GridViewOptionsSelection();
        public void PopulateColumns() { }
        public void BestFitColumns() { }
        public void AddNewRow() { }
        public void DeleteSelectedRows() { }
        public DataRow GetDataRow(int rowHandle) => null;
        public int GetDataSourceRowIndex(int rowHandle) => rowHandle;
        public bool IsNewItemRow(int rowHandle) => false;
        public int[] GetSelectedRows() => new int[0];
        public object GetFocusedRow() => null;
        public event EventHandler RowCellClick;
        public event EventHandler CellValueChanged;
        public event EventHandler CustomRowFilter;
        public event EventHandler ShownEditor;
        public event EventHandler ValidatingEditor;
        public event EventHandler KeyDown;
        public event EventHandler RowUpdated;
    }
    public class GridViewOptionsView { public bool ShowGroupPanel { get; set; } public bool ShowAutoFilterRow { get; set; } public bool EnableAppearanceEvenRow { get; set; } public bool EnableAppearanceOddRow { get; set; } }
    public class GridViewOptionsBehavior { public int EditorShowMode { get; set; } public bool AllowAddRows { get; set; } public bool AllowDeleteRows { get; set; } }
    public class GridViewOptionsSelection { public bool MultiSelect { get; set; } }
}

namespace DevExpress.XtraGrid.Views.Tile {
    public class TileView : DevExpress.XtraGrid.Views.Base.BaseView { }
    public class TileViewItem { }
}

namespace DevExpress.XtraGrid.Columns {
    public class GridColumn : Component {
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public int VisibleIndex { get; set; }
        public DevExpress.XtraEditors.Repository.RepositoryItem ColumnEdit { get; set; }
        public object AppearanceCell { get; set; }
        public object AppearanceHeader { get; set; }
        public ColumnEditOptionsEx OptionsColumn { get; } = new ColumnEditOptionsEx();
    }
    public class GridColumnCollection : System.Collections.Generic.List<GridColumn> {
        public GridColumn this[string fieldName] => this.Find(c => c.FieldName == fieldName);
        public void Add(string fieldName) => Add(new GridColumn { FieldName = fieldName });
    }
    public class ColumnEditOptionsEx { public bool AllowEdit { get; set; } public bool ReadOnly { get; set; } }
}

namespace DevExpress.XtraBars {
    public class BarManager : Component { }
    public class Bar : Component { }
    public class BarStaticItem : Component { public string Caption { get; set; } }
    public class BarButtonItem : Component { public string Caption { get; set; } public event EventHandler ItemClick; }
    public class BarCheckItem : Component { public string Caption { get; set; } public bool Checked { get; set; } public event EventHandler CheckedChanged; }
    public class BarSubItem : Component { public string Caption { get; set; } }
    public class PopupMenu : Component { public void ShowPopup(Point p) { } }
}

namespace DevExpress.XtraBars.Navigation {
    public class AccordionControl : System.Windows.Forms.Control { }
    public class AccordionControlElement { public string Text { get; set; } public event EventHandler Click; }
}

namespace DevExpress.XtraBars.Ribbon {
    public class RibbonControl : System.Windows.Forms.Control { }
    public class RibbonPage { public string Text { get; set; } }
}

namespace DevExpress.XtraCharts {
    public class ChartControl : System.Windows.Forms.Control { public object DataSource { get; set; } }
    public class Series { public string Name { get; set; } }
    public class SeriesCollection : List<Series> { }
}

namespace DevExpress.Utils {
    public class SvgImage : DevExpress.XtraEditors.SvgImage { }
    public class ImageCollection : DevExpress.XtraEditors.ImageCollection { }
    public class AppearanceObject { public Color BackColor { get; set; } public Color ForeColor { get; set; } public Font Font { get; set; } }
}

namespace DevExpress.XtraLayout {
    public class LayoutControl : System.Windows.Forms.Control { }
    public class LayoutControlGroup { }
    public class LayoutControlItem { }
}

namespace DevExpress.XtraPivotGrid {
    public class PivotGridControl : System.Windows.Forms.Control { }
}

namespace DevExpress.XtraTab {
    public class XtraTabControl : TabControl { }
    public class XtraTabPage : TabPage { }
}

namespace DevExpress.XtraTabbedMdi {
    public class XtraTabbedMdiManager : Component { }
}
