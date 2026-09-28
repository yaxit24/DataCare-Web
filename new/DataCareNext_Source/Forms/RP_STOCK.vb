' ============================================================
' DataCareNext - RP_STOCK : Stock Report
' Item-wise closing stock by weight, fine, and amount.
' ============================================================
Imports System.Data.SqlClient

Public Class RP_STOCK
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub RP_STOCK_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM MAIN_STOCK WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {MAIN_STOCK.VCH_DATE} <= #
    ' SQL: '  AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.TAG_NO <> 'N'
    ' SQL: '  AND A.TAG_NO <> 'N'  GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.IT
    ' SQL: '  AND A.TAG_NO <> 'N' GROUP BY A.TAG_NO,A.IT_CODE,A.VCH_SRNO  HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A
    ' SQL: '  AND D.MAIN_BOOK IN ('PURCHASE') AND B.ITM_AMT = 0 AND B.WITH_STOCK = 'Y' AND B.ITM_FINE > B.FINE_CUT_FINE ORDER BY B.
    ' SQL: '  AND D.MAIN_BOOK IN ('WH SALES') AND B.ITM_AMT = 0 AND B.ITM_FINE > B.FINE_CUT_FINE ORDER BY B.VCH_NO,B.SR_NO
    ' SQL: '  And A.TAG_NO <> 'N' GROUP BY C.CO_CODE, C.LC_CODE, C.VCH_TYPE, C.VCH_NO,C.STK_DATE, C.TAG_NO, A.IT_CODE, C.VCH_SRNO H
    ' SQL: '  And A.TAG_NO <> 'N' GROUP BY C.TAG_NO, C.VCH_SRNO HAVING SUM(CASE WHEN A.ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRN
    ' SQL: '  GROUP BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE,B.AC_CODE,B.AC_NAME,A.MAIN_USER  UNION ALL SELECT C.CO_BOOK,C.VCH_NO,C.VCH_DAT
    ' SQL: '  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE
    ' SQL: '  GROUP BY C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_T
    ' SQL: '  THEN (CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE 0 END) ELSE 0 END) <> 0
    ' SQL: '  THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs from ((MAIN_STOCK AS A  LEFT JOIN BA
    ' SQL: '  THEN (CASE WHEN A.ITM_SIGN = '-' THEN 1 ELSE 0 END) ELSE 0 END) <> 0
    ' SQL: '  THEN (CASE WHEN A.ITM_SIGN = '-' THEN 1 ELSE 0 END) ELSE 0 END) AS OutPcs from ((MAIN_STOCK AS A  LEFT JOIN BAR_DETL 

End Class
