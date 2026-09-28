' ============================================================
' DataCareNext - UT_WAPP_WITH_API : WhatsApp Business API
' Send WhatsApp messages (bills, OS reminders, schemes) via WhatsApp Cloud API.
' ============================================================
Imports System.Data.SqlClient

Public Class UT_WAPP_WITH_API
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub UT_WAPP_WITH_API_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM MSG_MAST WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: "messaging_product": "whatsapp",
    ' SQL: #   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: #   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: #   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 
    ' SQL: %' OR AC_MOBILE Like  '
    ' SQL: %' OR AC_MOBILE Like '%
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SI
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING Sum(A.CR_AMT-A.DR_AMT)+ SUM(CASE WHEN A.IT_TYPE = 'G' THE
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 
    ' SQL: '   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING Sum(A.CR_AMT-A.DR_AMT)+ SUM(CASE WHEN A.IT_TY
    ' SQL: '  GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_CITY,C.IT_TYPE ORDER BY B.AC_NAME

End Class
