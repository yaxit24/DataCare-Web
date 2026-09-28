' ============================================================
' DataCareNext - TR_UPI_REC : UPI Receipt
' Record UPI payment against sale or outstanding bill.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_UPI_REC
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_UPI_REC_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM UPI_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: ' AND A.UPI_AMT <> 0 GROUP BY A.CO_BOOK,A.VCH_NO HAVING SUM(UPI_AMT) > 0
    ' SQL: .dbo.SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_P
    ' SQL: ALTER TABLE LBR_DATA ADD UPI_AMT FLOAT Not NULL Default 0
    ' SQL: ALTER TABLE SL_DATA ADD UPI_AMT FLOAT Not NULL Default 0
    ' SQL: ALTER TABLE SL_ORD_DATA ADD UPI_AMT FLOAT Not NULL Default 0
    ' SQL: ALTER TABLE UPI_DATA ADD HD_VCH_NO VARCHAR(10)Not NULL DEFAULT ''
    ' SQL: ALTER TABLE UPI_DATA ADD ISR_NO FLOAT Not NULL Default 0
    ' SQL: ALTER TABLE UPI_DATA ADD OLD_VCH_NO VARCHAR(10)Not NULL DEFAULT '',NEW_VCH_NO VARCHAR(10)Not NULL DEFAULT ''
    ' SQL: ALTER TABLE UPI_DATA ADD SCHM_CODE VARCHAR(3)Not NULL DEFAULT ''
    ' SQL: ALTER TABLE UPI_DATA ADD SCHM_CODE VARCHAR(3)Not NULL DEFAULT '',ISR_NO FLOAT Not NULL Default 0

End Class
