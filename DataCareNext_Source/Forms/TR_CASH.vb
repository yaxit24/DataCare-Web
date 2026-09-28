' ============================================================
' DataCareNext - TR_CASH : Cash Voucher
' Cash payment and receipt voucher; writes to AC_DATA + ROJ_MEL_DATA
' ============================================================
Imports System.Data.SqlClient

Public Class TR_CASH
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_CASH_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM CASH_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {CASH_DATA.VCH_DATE} <= #
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.V
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VC
    ' SQL: '  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_
    ' SQL: ' AND A.BOOK_NAME = 'BUL SALE' AND A.INOUT_TYPE = 'O' AND A.ITM_GWT-A.ADJ_WT > 0   ORDER BY A.VCH_NO,A.SR_NO
    ' SQL: ' AND A.BOOK_NAME IN ('MFG GHAT REC','MFG MINO REC','MFG STNG REC') AND A.REP_ADJ = 'N' AND A.INOUT_TYPE = 'I' AND A.ORD
    ' SQL: ' AND A.BOOK_NAME IN ('MFG STNG ISU','MFG POLISH ISU') AND A.REP_ADJ = 'N' AND A.INOUT_TYPE = 'O' AND A.KR_CODE = '
    ' SQL: ' AND A.ENTRY_TYPE = 'C' AND A.REP_ADJ = 'N' AND A.INOUT_TYPE = 'O' AND A.AC_CODE = '
    ' SQL: ' AND A.INOUT_TYPE = 'I' AND A.ITM_GWT-A.ADJ_WT > 0   ORDER BY A.VCH_NO,A.SR_NO
    ' SQL: ' AND A.REP_ADJ = 'N' AND ENTRY_TYPE IN ('C') AND INOUT_TYPE = 'O' ORDER BY A.TAG_NO
    ' SQL: ' AND A.REP_ADJ = 'N' AND ENTRY_TYPE IN ('F') AND INOUT_TYPE = 'O' ORDER BY A.TAG_NO
    ' SQL: ' AND A.REP_ADJ = 'N' AND ENTRY_TYPE IN ('G','F','C') AND INOUT_TYPE = 'I' ORDER BY A.TAG_NO
    ' SQL: ' AND A.REP_ADJ = 'N' AND ENTRY_TYPE IN ('G','J','F','C','P') AND INOUT_TYPE = 'I' ORDER BY ENTRY_TYPE,A.DESIGN_NO
    ' SQL: ' AND A.REP_ADJ = 'N' AND ENTRY_TYPE IN ('J') AND INOUT_TYPE = 'O' ORDER BY A.TAG_NO
    ' SQL: ' AND A.REP_ADJ = 'N' AND ENTRY_TYPE IN ('J','F','C','G','P') AND INOUT_TYPE = 'I' ORDER BY A.TAG_NO

End Class
