' ============================================================
' DataCareNext - TR_LEDR_ADJ : Ledger Adjustment
' Manual ledger balance adjustment (Dr/Cr) for corrections.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_LEDR_ADJ
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_LEDR_ADJ_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM LDR_ADJ_DATA WHERE CO_CODE='" & gCoCode & "'")
    End Sub

    ' ── Save ──────────────────────────────────────────────
    Private Sub BtnSave_Click(s As Object, e As EventArgs) Handles BtnSave.Click
        Try
            BeginTransaction()
            ' ---- INSERT / UPDATE logic ----
            ' INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BIL
            ' INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BIL
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
            ' DELETE FROM LDR_ADJ_DATA WHERE  CO_CODE = '
            ' DELETE FROM LDR_ADJ_DATA WHERE CO_CODE  IN (
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
    ' SQL: ' AND {LDR_ADJ_DATA.CO_BOOK} = '
    ' SQL: ' AND {LDR_ADJ_DATA.CO_YEAR} = '
    ' SQL: ' AND {LDR_ADJ_DATA.LC_CODE} = '
    ' SQL: ' AND {LDR_ADJ_DATA.VCH_NO} = '
    ' SQL: ALTER TABLE LDR_ADJ_DATA ADD ONLY_REMARK VARCHAR(1)Not NULL DEFAULT 'N'
    ' SQL: CREATE TABLE LDR_ADJ_DATA(CO_CODE VARCHAR(2),LC_CODE VARCHAR(2),CO_YEAR VARCHAR(10),CO_BOOK VARCHAR(3),VCH_NO VARCHAR(8)
    ' SQL: DELETE FROM LDR_ADJ_DATA WHERE  CO_CODE = '
    ' SQL: DELETE FROM LDR_ADJ_DATA WHERE CO_CODE  IN (
    ' SQL: DELETE FROM LDR_ADJ_DATA WHERE CO_CODE = '
    ' SQL: DELETE FROM LDR_ADJ_DATA WHERE CO_YEAR <> '
    ' SQL: INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_N
    ' SQL: INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_N

End Class
