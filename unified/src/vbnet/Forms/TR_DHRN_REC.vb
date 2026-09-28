' ============================================================
' DataCareNext - TR_DHRN_REC : Dhiran Receipt
' Loan repayment – principal + interest. Links back to DHRN_ISU_DATA.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_DHRN_REC
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_DHRN_REC_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM DHRN_REC_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: ' AND {DHRN_REC_DATA.CO_BOOK} = '
    ' SQL: ' AND {DHRN_REC_DATA.CO_YEAR} = '
    ' SQL: ' AND {DHRN_REC_DATA.LC_CODE} = '
    ' SQL: ' AND {DHRN_REC_DATA.VCH_NO} = '
    ' SQL: ' GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL HAVING SUM(B.INT_REC_AMT
    ' SQL: ',  B.BOOK_NAME,AC_CODE,AC_NAME,0,INT_REC_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'
    ' SQL: ',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_
    ' SQL: ',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_
    ' SQL: ',SUBSTRING(VCH_DESC,1,149) FROM DHRN_REC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.
    ' SQL: .dbo.RATE_CUT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,IT_TYPE,  AC_CODE,AC_NAME,
    ' SQL: ALTER TABLE CO_SET ADD INT_DAY VARCHAR(1)
    ' SQL: ALTER TABLE DHRN_REC_DATA ADD LOAN_TYPE VARCHAR(1)
    ' SQL: ALTER TABLE DHRN_REC_DATA ADD RCUT_RATE FLOAT Not NULL Default 0,RCUT_AMT FLOAT Not NULL Default 0,RCUT_PAY_AMT FLOAT No
    ' SQL: ALTER TABLE DHRN_REC_DATA ADD UNCHAK_DHRN_REC FLOAT Not NULL DEFAULT 0
    ' SQL: ALTER TABLE DHRN_REC_DATA ADD USER_UPDATE VARCHAR(1) Not NULL DEFAULT 'N',USER_DELETE VARCHAR(1) Not NULL DEFAULT 'N'

End Class
