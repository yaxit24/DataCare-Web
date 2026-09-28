' ============================================================
' DataCareNext - TR_REP_REC : Repair Receipt
' Customer jewellery repair billing. Links to karigar issue.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_REP_REC
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_REP_REC_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM REP_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {REP_DETL.VCH_DATE} <= #
    ' SQL: '  GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL,A.GOLD_DESC HAVING SUM(
    ' SQL: ' AND A.BOOK_NAME = 'APR RTN' AND A.ISU_NO <> ''  UNION ALL SELECT B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,B.ISU_SRNO FROM SL_DET
    ' SQL: ' AND A.BOOK_NAME = 'CUSTREP RECEIPT'   UNION ALL Select D.REP_AC_NAME As PartyNameL,D.REP_AC_CODE As AcCodeL,D.REP_NO A
    ' SQL: ' AND A.BOOK_NAME = 'GHAT ISU' AND A.ISU_REC = 'N' AND A.ISU_NO <> ''  ORDER BY A.VCH_NO,A.SR_NO
    ' SQL: ' AND A.BOOK_NAME = 'KARIGAR ORDER' AND A.ISU_REC = 'N' AND A.ISU_NO <> ''  ORDER BY A.VCH_NO,A.SR_NO
    ' SQL: ' AND A.CO_BOOK = '051' AND A.ISU_REC = 'N' AND A.ISU_NO <> ''  ORDER BY A.VCH_NO,A.SR_NO
    ' SQL: ' AND B.BOOK_NAME = 'SALES' AND B.ISU_NO <> ''  UNION ALL SELECT C.ISU_YRCD,C.ISU_DBCD,C.ISU_NO,C.ISU_SRNO FROM RATE_CUT
    ' SQL: ' AND B.MAIN_BOOK IN ('SALES','B2B SALES') AND B.BOOK_INOUT = 'O' AND A.ISU_NO <> ''
    ' SQL: ' AND B.MAIN_BOOK IN ('WH SALES','RATE CUT') AND B.BOOK_INOUT = 'O' AND A.ISU_NO <> ''
    ' SQL: ' AND C.BOOK_NAME = 'WH SALES' AND C.ISU_NO <> ''
    ' SQL: ' AND Q.BOOK_NAME = 'OTH EXP'  GROUP BY Q.CO_CODE,Q.LC_CODE,Q.CO_BOOK,Q.BOOK_NAME   UNION ALL SELECT R.CO_CODE,R.LC_CODE
    ' SQL: ' AND R.BOOK_NAME = 'CUSTREP RECEIPT'  GROUP BY R.CO_CODE,R.LC_CODE,R.CO_BOOK,R.BOOK_NAME   UNION ALL SELECT W.CO_CODE,W
    ' SQL: ' AND T.BOOK_NAME = 'KRREP RECEIPT'  GROUP BY T.CO_CODE,T.LC_CODE,T.CO_BOOK,T.BOOK_NAME  UNION ALL SELECT U.CO_CODE,U.LC
    ' SQL: ' AND W.BOOK_NAME = 'KRREP ISSUE'  GROUP BY W.CO_CODE,W.LC_CODE,W.CO_BOOK,W.BOOK_NAME   UNION ALL SELECT T.CO_CODE,T.LC_

End Class
