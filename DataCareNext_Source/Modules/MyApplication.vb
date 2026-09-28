' ==============================================================
' DataCareNext - Application Entry Point
' ==============================================================
Imports System.Data.SqlClient

Module MyApplication
    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' ── Connect to SQL Server ────────────────────────────
        Dim conStr As String = My.Settings.ConnectionString
        Try
            Using testCon As New SqlConnection(conStr)
                testCon.Open()
            End Using
        Catch ex As Exception
            MsgBox("Cannot connect to database." & vbCrLf & ex.Message &
                   vbCrLf & vbCrLf & "Check connection string in App.config.",
                   MsgBoxStyle.Critical, "DataCareNext – Connection Error")
            Return
        End Try
        gConStr = conStr

        ' ── Login ────────────────────────────────────────────
        Dim loginFrm As New MS_LOGIN()
        If loginFrm.ShowDialog() <> DialogResult.OK Then Return

        ' ── Launch main MDI shell ────────────────────────────
        Application.Run(New MDI_FORM())
    End Sub
End Module
