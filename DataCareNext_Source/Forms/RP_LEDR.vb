' ============================================================
' DataCareNext - RP_LEDR : Ledger Report
' Account ledger with opening balance, all Dr/Cr entries, and closing balance.
' ============================================================
Imports System.Data.SqlClient

Public Class RP_LEDR
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub RP_LEDR_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM AC_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: #   GROUP BY A.AC_CODE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0
    ' SQL: #   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: #   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: #   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 
    ' SQL: '   GROUP BY A.AC_CODE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING Sum(A.CR_AMT-A.DR_AMT)+ SUM(CASE WHEN A.IT_TYPE = 'G' THE
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING Sum(A.CR_AMT-A.DR_AMT)+ SUM(CASE WHEN A.IT_TY
    ' SQL: '  AND A.DESIGN_ISU = 'N' AND A.TAG_STK_LESS <> 'Y'  ORDER BY A.VCH_DATE,A.VCH_NO,A.SR_NO
    ' SQL: '  AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.TAG_NO <> 'N'
    ' SQL: '  AND A.TAG_NO <> 'N'  GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.IT
    ' SQL: '  AND A.TAG_NO <> 'N' GROUP BY A.TAG_NO,A.IT_CODE,A.VCH_SRNO  HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A
    ' SQL: '  And A.TAG_NO <> 'N' GROUP BY C.CO_CODE, C.LC_CODE, C.VCH_TYPE, C.VCH_NO,C.STK_DATE, C.TAG_NO, A.IT_CODE, C.VCH_SRNO H
    ' SQL: '  And A.TAG_NO <> 'N' GROUP BY C.TAG_NO, C.VCH_SRNO HAVING SUM(CASE WHEN A.ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRN
    ' SQL: '  GROUP BY A.AC_CODE,A.VCH_DATE,A.VCH_NO,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+
    ' SQL: '  GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD
    ' SQL: '  GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.OLD_GL,A.OLD_SL,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING S
    ' SQL: '  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE

End Class
