' ============================================================
' DataCareNext - TR_TAG_CAN : Tag Cancellation
' Cancel/melt a jewellery tag – removes from TAG_STOCK.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_TAG_CAN
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_TAG_CAN_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM TAG_STOCK WHERE CO_CODE='" & gCoCode & "'")
    End Sub

    ' ── Save ──────────────────────────────────────────────
    Private Sub BtnSave_Click(s As Object, e As EventArgs) Handles BtnSave.Click
        Try
            BeginTransaction()
            ' ---- INSERT / UPDATE logic ----
            ' INSERT INTO COL_MAST (CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_CAN_D
            ' INSERT INTO COL_MAST(CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_CAN_DE
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
            ' DELETE FROM TAG_STOCK WHERE CO_CODE = '
            ' DELETE FROM TAG_STOCK_PRINT
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
    ' SQL: '   AND A.MAIN_BOOK Not IN ('OPSTK','CASH REC','CASH PAY','BANK REC','BANK PAY','TAG GEN','TAG CANCEL','APR ISU','APR RT
    ' SQL: ' AND B.BOOK_NAME IN ('TAG CANCEL')
    ' SQL: ' AND B.CUR_USE = 'Y' AND B.MAIN_BOOK IN ('TAG CANCEL','STOCK ADJUST','TAG TRFR')
    ' SQL: ' AND B.MAIN_BOOK IN ('TAG CANCEL')
    ' SQL: ' AND BOOK_NAME = 'TAG CANCEL'
    ' SQL: ' AND S.MAIN_BOOK = 'TAG CANCEL'  GROUP BY E.CO_CODE,E.LC_CODE,E.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT CO_CODE,LC_CODE,C
    ' SQL: AND BOOK_NAME  = 'TAG CANCEL'
    ' SQL: BOOK_NAME = 'TAG_CAN_DETL' AND COL_NAME = '
    ' SQL: DELETE FROM TAG_STOCK WHERE CO_CODE = '
    ' SQL: DELETE FROM TAG_STOCK_PRINT
    ' SQL: DELETE FROM TAG_STOCK_PRINT WHERE  CO_CODE = '
    ' SQL: DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '
    ' SQL: DELETE FROM TAG_STOCK_PRINT WHERE CO_YEAR <> '
    ' SQL: INSERT INTO COL_MAST (CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_CAN_DETL','Color','Color'
    ' SQL: INSERT INTO COL_MAST(CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_CAN_DETL','LCode','LCode',

End Class
