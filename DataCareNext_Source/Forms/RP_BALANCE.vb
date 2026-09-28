' ============================================================
' DataCareNext - RP_BALANCE : Trial Balance
' Trial balance with Dr/Cr totals per account group and grand totals.
' ============================================================
Imports System.Data.SqlClient

Public Class RP_BALANCE
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub RP_BALANCE_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM LEDR_AC_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: '  AND B.AC_GR IN( '45','46','47')
    ' SQL: ' AND  AC_GR IN ('02','03','19','22','23')  ORDER BY AC_NAME
    ' SQL: ' AND (AC_GR = '12' OR  AC_CODE = '00013') ORDER BY AC_NAME
    ' SQL: ' AND (B.AC_GR = '46' OR A.AC_CODE = '00057')  AND A.DR_AMT <> 0  AND A.VCH_DATE >= '
    ' SQL: ' AND A.AC_GR <> '15' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME
    ' SQL: ' AND A.AC_GR <> '15' ORDER BY A.AC_NAME
    ' SQL: ' AND A.AC_GR <> '15' ORDER BY A.LC_CODE,A.AC_NAME
    ' SQL: ' AND A.AC_GR = '06' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME
    ' SQL: ' AND A.AC_GR = '06' ORDER BY A.AC_NAME
    ' SQL: ' AND A.AC_GR = '06' ORDER BY A.LC_CODE,A.AC_NAME
    ' SQL: ' AND A.AC_GR = '18' ORDER BY AC_NAME
    ' SQL: ' AND A.AC_GR = '25' ORDER BY AC_NAME

End Class
