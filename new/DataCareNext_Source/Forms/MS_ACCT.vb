' ============================================================
' DataCareNext - MS_ACCT : Account / Ledger Master
' Customer, supplier, bank, expense account master with GST, PAN, contact info.
' ============================================================
Imports System.Data.SqlClient

Public Class MS_ACCT
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub MS_ACCT_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM AC_MAST WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {AC_MAST.LAST_VISIT} <= #
    ' SQL: '   GROUP BY A.AC_CODE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING Sum(A.CR_AMT-A.DR_AMT)+ SUM(CASE WHEN A.IT_TYPE = 'G' THE
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING Sum(A.CR_AMT-A.DR_AMT)+ SUM(CASE WHEN A.IT_TY
    ' SQL: '  AND A.AC_CODE = '00001'   GROUP BY A.AC_CODE ORDER BY A.AC_CODE
    ' SQL: '  AND A.AC_CODE = '00001' and VCH_DATE < '
    ' SQL: '  AND A.TAG_NO <> 'N'  GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.IT
    ' SQL: '  AND AC_CODE = '00001' and VCH_DATE <= '
    ' SQL: '  GROUP BY A.AC_CODE,A.VCH_DATE,A.VCH_NO,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+
    ' SQL: '  GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_CITY,C.IT_TYPE ORDER BY B.AC_NAME
    ' SQL: '  GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD
    ' SQL: '  GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.OLD_GL,A.OLD_SL,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING S
    ' SQL: '  GROUP BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE,B.AC_CODE,B.AC_NAME,A.MAIN_USER  UNION ALL SELECT C.CO_BOOK,C.VCH_NO,C.VCH_DAT

End Class
