' ============================================================
' DataCareNext - RP_DHRN_LOAN : Dhiran Loan Report
' Gold loan outstanding with interest accrual, overdue, packet-wise.
' ============================================================
Imports System.Data.SqlClient

Public Class RP_DHRN_LOAN
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub RP_DHRN_LOAN_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM DHRN_ISU_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {DHRN_ISU_DATA.VCH_DATE} <= #
    ' SQL: # and {ITEM_MAST.IT_TYPE} = 'G' AND  ({DHRN_ISU_DATA.DHRN_AMT}-{DHRN_ISU_DATA.DHRN_REC_AMT}) > 0
    ' SQL: # and {ITEM_MAST.IT_TYPE} = 'S' AND  ({DHRN_ISU_DATA.DHRN_AMT}-{DHRN_ISU_DATA.DHRN_REC_AMT}) > 0
    ' SQL: '  GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL,A.GOLD_DESC HAVING SUM(
    ' SQL: ' AND A.DHRN_AMT - A.DHRN_REC_AMT > 0 AND A.ENTRY_TYPE = 'D' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO
    ' SQL: ' AND A.DHRN_AMT - A.DHRN_REC_AMT > 0 AND A.ENTRY_TYPE = 'L' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO
    ' SQL: ' AND A.DHRN_DUE_DATE IS NOT NULL GROUP BY A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.AC_CODE,A.AC_NAME,A.VCH_NO,A.VCH_DA
    ' SQL: ' AND A.ENTRY_TYPE = 'L' GROUP BY A.CUST_NAME,A.PACKET_NO,B.AC_NAME,A.VCH_NO ORDER BY A.CUST_NAME,B.AC_NAME
    ' SQL: ' AND {DHRN_ISU_DATA.CO_BOOK} = '
    ' SQL: ' AND {DHRN_ISU_DATA.CO_YEAR} = '
    ' SQL: ' AND {DHRN_ISU_DATA.LC_CODE} = '
    ' SQL: ' AND {DHRN_ISU_DATA.VCH_DATE} >= #

End Class
