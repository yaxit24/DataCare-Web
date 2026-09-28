' ============================================================
' DataCareNext - UT_E_INVOICE : E-Invoice (IRN) Generation
' Calls GSP REST API to generate IRN + QR code for GST e-Invoice.
' ============================================================
Imports System.Data.SqlClient

Public Class UT_E_INVOICE
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub UT_E_INVOICE_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        Dim sql As String = _
            "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,BILL_NO AS RefNoL,A.IRN_NO As IrnNoL,A.MAIN_USER As UserL,format(NET_AMT,'0.00') AS NetAmtR,format(TAX_AMT,'0.00') AS TaxAmtR,format(TOT_AMT,'0.00') AS TotAmtR,format(BILL_OS,'0.00') AS OsAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" &
            "SELECT IRN_NO,QR_LINK FROM E_DATA WHERE CO_CODE = '"
        DgvMain.DataSource = FillTable(sql)
    End Sub

    ' ── Save ──────────────────────────────────────────────
    Private Sub BtnSave_Click(s As Object, e As EventArgs) Handles BtnSave.Click
        Try
            BeginTransaction()
            ' ---- INSERT / UPDATE logic ----
            ' INSERT INTO SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CO
            ' INSERT INTO SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CO
            ' UPDATE SL_DATA SET IRN_NO = '
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
    ' SQL: .dbo.SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_P
    ' SQL: ALTER TABLE SL_DATA ADD ACK_NO VARCHAR(25) Not NULL DEFAULT 'N'
    ' SQL: ALTER TABLE SL_DATA ADD IRN_NO VARCHAR(100) Not NULL DEFAULT 'N'
    ' SQL: AND A.TAX_AMT <> 0 AND (C.IRN_NO = '' OR C.IRN_NO IS NULL)
    ' SQL: AND C.IT_TAX_AMT <> 0 AND E.IRN_NO <> '' AND C.TAX_TYPE = 'A'
    ' SQL: CREATE TABLE E_DATA(CO_CODE VARCHAR(2),LC_CODE VARCHAR(2),CO_YEAR VARCHAR(10),CO_BOOK VARCHAR(3),VCH_NO VARCHAR(8),  IRN
    ' SQL: CREATE TABLE E_MAST(CO_CODE VARCHAR(2),GSP_NAME VARCHAR(50),ASP_ID VARCHAR(50),ASP_PWD VARCHAR(50),AUTH_URL VARCHAR(250)
    ' SQL: INSERT INTO SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT
    ' SQL: INSERT INTO SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,AC_NAME,  NET_AMT
    ' SQL: SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,BILL_
    ' SQL: SELECT IRN_NO,QR_LINK FROM E_DATA WHERE CO_CODE = '
    ' SQL: UPDATE SL_DATA SET IRN_NO = '

End Class
