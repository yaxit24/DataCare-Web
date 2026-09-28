' ============================================================
' DataCareNext - MS_COMPANY : Company Settings
' Company profile, GST number, bank details, WhatsApp API, e-invoice GSP credentials.
' ============================================================
Imports System.Data.SqlClient

Public Class MS_COMPANY
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub MS_COMPANY_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM CO_MAST WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: ',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_
    ' SQL: ',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_
    ' SQL: ',COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB
    ' SQL: ',COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB
    ' SQL: ALTER TABLE CO_MAST ADD HTTP_NAME VARCHAR(150) DEFAULT ''
    ' SQL: ALTER TABLE CO_MAST ADD MAIL_API VARCHAR(100)Not NULL DEFAULT ''
    ' SQL: ALTER TABLE CO_MAST ADD RTGS_TYPE VARCHAR(1)Not NULL DEFAULT 'N'
    ' SQL: ALTER TABLE CO_MAST ADD URL_NAME VARCHAR(150) DEFAULT '',URL_ID VARCHAR(50) DEFAULT '',URL_PWD VARCHAR(25) DEFAULT ''
    ' SQL: ALTER TABLE CO_SET ADD ADMIN_SMS VARCHAR(1)
    ' SQL: ALTER TABLE CO_SET ADD ALL_ROF_REMOVE VARCHAR(1) Not NULL DEFAULT 'N'
    ' SQL: ALTER TABLE CO_SET ADD CARD_COM_ADJ VARCHAR(1) DEFAULT 'N'
    ' SQL: ALTER TABLE CO_SET ADD CASH_LIMIT FLOAT Not NULL Default 0
    ' SQL: ALTER TABLE CO_SET ADD CASH_PURC_AC VARCHAR(1) Not NULL DEFAULT 'N'
    ' SQL: ALTER TABLE CO_SET ADD CO_STK_MERGE VARCHAR(1)
    ' SQL: ALTER TABLE CO_SET ADD CUST_SMS VARCHAR(1)

End Class
