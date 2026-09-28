' ============================================================
' DataCareNext - TR_WH_SALE : Wholesale Sale
' Wholesale bill (WH SALES book). Same schema as retail sales.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_WH_SALE
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_WH_SALE_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM SL_DATA WHERE CO_CODE='" & gCoCode & "'")
    End Sub

    ' ── Save ──────────────────────────────────────────────
    Private Sub BtnSave_Click(s As Object, e As EventArgs) Handles BtnSave.Click
        Try
            BeginTransaction()
            ' ---- INSERT / UPDATE logic ----
            CommitTransaction()
            MsgBox("Saved successfully.", MsgBoxStyle.Information)
            LoadGrid()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ── Delete ─────────────────────────────────────────────
    Private Sub BtnDelete_Click(s As Object, e As EventArgs) Handles BtnDelete.Click
        If MsgBox("Delete this record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
        Try
            BeginTransaction()
            ' ---- DELETE logic ----
            CommitTransaction()
            MsgBox("Deleted successfully.")
            LoadGrid()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ── Print ──────────────────────────────────────────────
    Private Sub BtnPrint_Click(s As Object, e As EventArgs) Handles BtnPrint.Click
        ' TODO: load Crystal Report and preview
        MsgBox("Print / Preview not configured yet.")
    End Sub

    ' ── Exit ───────────────────────────────────────────────
    Private Sub BtnExit_Click(s As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    ' ── Keyboard shortcuts (F2=Save, F3=Delete, F5=Print, Esc=Exit) ──
    Private Sub KeyDown_Handler(s As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2    : BtnSave.PerformClick()
            Case Keys.F3    : BtnDelete.PerformClick()
            Case Keys.F5    : BtnPrint.PerformClick()
            Case Keys.Escape: Me.Close()
        End Select
    End Sub

    ' ── Key SQL strings extracted from binary ───────────────
    ' SQL: '  AND D.MAIN_BOOK IN ('WH SALES') AND B.ITM_AMT = 0 AND B.ITM_FINE > B.FINE_CUT_FINE ORDER BY B.VCH_NO,B.SR_NO
    ' SQL: '  AND PRINT_TYPE = 'WH SALES'  ORDER BY PRINT_FILE
    ' SQL: ' AND A.BOOK_NAME IN ('SALES','WH SALES', 'LABOUR WORK','SALES RETURNE') AND A.ITM_SIGN = '-'  AND A.VCH_DATE >= '
    ' SQL: ' AND A.BOOK_NAME IN ('WH SALES','TOUR SALES') AND A.AC_CODE = '
    ' SQL: ' AND A.BOOK_NAME IN ('WH SALES','TOUR SALES') AND A.CO_YEAR = '
    ' SQL: ' AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.BOOK_NAME IN ('SALES','WH SALES','TOUR SALES','LABOUR WORK')
    ' SQL: ' AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND B.MAIN_BOOK IN ('SALES','WH SALES','TOUR SALES','LABOUR WORK')
    ' SQL: ' AND A.MAIN_BOOK IN ('SALES','WH SALES')  ORDER BY A.MAIN_BOOK,A.CO_BOOK
    ' SQL: ' AND B.MAIN_BOOK = 'WH SALES' AND B.RESET_BOOK = 'Y'  AND A.TOT_FINE_DR = A.TOT_FINE_DR  AND A.SL_BILL_OS = 0 AND A.PR_
    ' SQL: ' AND B.MAIN_BOOK IN ('WH SALES','RATE CUT')  GROUP BY A.VCH_TYPE,A.CO_BOOK,B.MAIN_BOOK,A.VCH_NO,A.VCH_DATE ORDER BY A.V

End Class
