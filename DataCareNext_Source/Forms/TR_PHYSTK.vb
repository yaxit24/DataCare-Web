' ============================================================
' DataCareNext - TR_PHYSTK : Physical Stock Entry
' Physical stock count entry – reconciles system stock with actual.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_PHYSTK
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_PHYSTK_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM MAIN_STOCK WHERE CO_CODE='" & gCoCode & "'")
    End Sub

    ' ── Save ──────────────────────────────────────────────
    Private Sub BtnSave_Click(s As Object, e As EventArgs) Handles BtnSave.Click
        Try
            BeginTransaction()
            ' ---- INSERT / UPDATE logic ----
            ' INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,
            ' UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'BAR_CAN_DATA',BOOK_TBL_DETL = 'BAR_CAN_DETL' WHERE MAIN_BOOK I
            ' UPDATE BOOK_DATA SET MENU_NAME = 'Physical Stock' WHERE MAIN_BOOK = 'PHY STOCK'
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
            ' Delete All Physical Stock ?
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
    ' SQL: '   AND A.MAIN_BOOK Not IN ('OPSTK','CASH REC','CASH PAY','BANK REC','BANK PAY','TAG GEN','TAG CANCEL','APR ISU','APR RT
    ' SQL: After Physical InOut
    ' SQL: Delete All Physical Stock ?
    ' SQL: INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('
    ' SQL: Physical Stock Differenc Report
    ' SQL: Physical Stock Is ReSet...
    ' SQL: Physical Stock Report
    ' SQL: Physical Stock will Reset permantley ?
    ' SQL: UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'BAR_CAN_DATA',BOOK_TBL_DETL = 'BAR_CAN_DETL' WHERE MAIN_BOOK IN ('TAG CANCEL','STO
    ' SQL: UPDATE BOOK_DATA SET MENU_NAME = 'Physical Stock' WHERE MAIN_BOOK = 'PHY STOCK'
    ' SQL: UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Physical Stock'

End Class
