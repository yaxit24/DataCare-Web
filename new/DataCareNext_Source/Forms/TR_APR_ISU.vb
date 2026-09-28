' ============================================================
' DataCareNext - TR_APR_ISU : Approval Issue
' Send items on approval/consignment to customer.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_APR_ISU
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_APR_ISU_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM APR_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {APR_DETL.VCH_DATE} <= #
    ' SQL: '  UNION ALL SELECT VCH_NO FROM APR_DETL WHERE CO_CODE = '
    ' SQL: ' AND APR_DETL.BOOK_NAME = 'EMP ISU' AND B.VCH_NO = '
    ' SQL: ' AND APR_DETL.CO_BOOK = '
    ' SQL: ' AND APR_DETL.CO_BOOK = '018'  AND B.VCH_NO = '
    ' SQL: ' AND APR_DETL.CO_BOOK = '018' AND B.VCH_NO = '
    ' SQL: ' AND APR_DETL.CO_BOOK = '051' AND B.VCH_NO = '
    ' SQL: ' AND APR_DETL.CO_YEAR = '
    ' SQL: ' AND APR_DETL.ISU_REC = 'N'
    ' SQL: ' AND APR_DETL.LC_CODE = '
    ' SQL: ' AND APR_DETL.VCH_NO = '
    ' SQL: ' AND B.MAIN_BOOK = 'CON ISU' AND B.BOOK_INOUT = 'O'
    ' SQL: ' AND {APR_DATA.CO_BOOK} = '
    ' SQL: ' AND {APR_DATA.CO_YEAR} = '
    ' SQL: ' AND {APR_DATA.LC_CODE} = '
    ' SQL: ' AND {APR_DATA.VCH_NO} = '
    ' SQL: ' AND {APR_DETL.ISU_REC} = 'N' AND {APR_DETL.VCH_DATE} >= #
    ' SQL: ' AND {APR_DETL.VCH_DATE} >= #
    ' SQL: ' And D.BOOK_NAME = 'RATE CUT' And D.ISU_NO <> '' ) AS X  WHERE X.ISU_YRCD = APR_DETL.CO_YEAR And X.ISU_DBCD = APR_DETL.
    ' SQL: ' And EXISTS (Select 1 FROM (Select A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,A.ISU_SRNO From APR_DETL A  Where A.CO_CODE = '

End Class
