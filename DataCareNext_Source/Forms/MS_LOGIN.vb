' ==============================================================
' DataCareNext - MS_LOGIN : Login / Authentication Form
' ==============================================================
Imports System.Data.SqlClient

Public Class MS_LOGIN
    Inherits Form

    Private WithEvents tUser  As New TextBox()
    Private WithEvents tPass  As New TextBox() With {.PasswordChar = "*"c}
    Private WithEvents cboLoc As New ComboBox()
    Private WithEvents BtnOk  As New Button() With {.Text = "Login", .DialogResult = DialogResult.OK}
    Private WithEvents BtnExt As New Button() With {.Text = "Exit",  .DialogResult = DialogResult.Cancel}
    Private tCoCode As New TextBox() With {.Text = "01"}

    Public Sub New()
        Me.Text = "DataCareNext – Login"
        Me.Size = New Drawing.Size(380, 280)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Dim lbl1 As New Label() With {.Text="Company:", .Location=New Drawing.Point(20,20), .AutoSize=True}
        Dim lbl2 As New Label() With {.Text="Location:", .Location=New Drawing.Point(20,60), .AutoSize=True}
        Dim lbl3 As New Label() With {.Text="User ID:", .Location=New Drawing.Point(20,100), .AutoSize=True}
        Dim lbl4 As New Label() With {.Text="Password:", .Location=New Drawing.Point(20,140), .AutoSize=True}
        tCoCode.Location = New Drawing.Point(120,17): tCoCode.Width = 60
        cboLoc.Location  = New Drawing.Point(120,57): cboLoc.Width  = 200: cboLoc.DropDownStyle = ComboBoxStyle.DropDownList
        tUser.Location   = New Drawing.Point(120,97): tUser.Width   = 200
        tPass.Location   = New Drawing.Point(120,137): tPass.Width  = 200
        BtnOk.Location   = New Drawing.Point(80, 185): BtnOk.Width  = 80
        BtnExt.Location  = New Drawing.Point(180,185): BtnExt.Width = 80
        Me.Controls.AddRange({lbl1,lbl2,lbl3,lbl4,tCoCode,cboLoc,tUser,tPass,BtnOk,BtnExt})
        Me.AcceptButton = BtnOk
        Me.CancelButton = BtnExt
    End Sub

    Private Sub MS_LOGIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadLocations()
    End Sub

    Private Sub LoadLocations()
        cboLoc.Items.Clear()
        Dim dt = FillTable($"SELECT LC_CODE, LC_NAME FROM LOCT_MAST WHERE CO_CODE='{tCoCode.Text.Trim()}' ORDER BY LC_CODE")
        For Each r As DataRow In dt.Rows
            cboLoc.Items.Add(New KeyValuePair(Of String,String)(r("LC_CODE").ToString().Trim(), r("LC_NAME").ToString().Trim()))
        Next
        If cboLoc.Items.Count > 0 Then cboLoc.SelectedIndex = 0
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(tUser.Text.Trim()) Then
            MsgBox("Please enter User ID.", MsgBoxStyle.Exclamation) : DialogResult = DialogResult.None : Return
        End If

        Dim coCode = tCoCode.Text.Trim()
        Dim userId = tUser.Text.Trim().ToUpper()
        Dim pwd    = tPass.Text.Trim()

        ' Authenticate
        Dim dt = FillTable(
            $"SELECT L.*, U.USER_LC_CODE, U.USER_UPDATE, U.USER_DELETE, U.USER_PRINT " &
            $"FROM LOGIN_MAST L LEFT JOIN USER_SET U ON L.CO_CODE=U.CO_CODE AND L.LOGIN_NAME=U.LOGIN_NAME " &
            $"WHERE L.CO_CODE='{coCode}' AND L.LOGIN_NAME='{userId}' AND L.PASSWORD='{pwd}'")

        If dt.Rows.Count = 0 Then
            MsgBox("Invalid User ID or Password.", MsgBoxStyle.Exclamation)
            tPass.Clear() : tPass.Focus()
            DialogResult = DialogResult.None
            Return
        End If

        ' Check HDD key
        Dim hddKey = GetValue("HDD_MAST","REF_NO","1=1")
        If String.IsNullOrEmpty(hddKey) Then
            MsgBox("Hardware key not found. Please contact support.", MsgBoxStyle.Critical)
            DialogResult = DialogResult.None : Return
        End If

        ' Set globals
        gCoCode   = coCode
        gMainUser = userId
        gLcCode   = If(cboLoc.SelectedItem IsNot Nothing,
                       CType(cboLoc.SelectedItem, KeyValuePair(Of String,String)).Key, "00")
        gUserCanUpdate = (dt.Rows(0)("USER_UPDATE").ToString() <> "N")
        gUserCanDelete = (dt.Rows(0)("USER_DELETE").ToString() <> "N")
        gUserCanPrint  = (dt.Rows(0)("USER_PRINT").ToString()  <> "N")

        LoadCompanySettings(coCode)
    End Sub
End Class
