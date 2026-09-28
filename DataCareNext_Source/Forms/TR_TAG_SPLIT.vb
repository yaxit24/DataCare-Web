' ============================================================
' DataCareNext - TR_TAG_SPLIT : Tag Split
' Split one tag into multiple pieces (e.g. split a pair of earrings).
' ============================================================
Imports System.Data.SqlClient

Public Class TR_TAG_SPLIT
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_TAG_SPLIT_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM TAG_STOCK WHERE CO_CODE='" & gCoCode & "'")
    End Sub

    ' ── Save ──────────────────────────────────────────────
    Private Sub BtnSave_Click(s As Object, e As EventArgs) Handles BtnSave.Click
        Try
            BeginTransaction()
            ' ---- INSERT / UPDATE logic ----
            ' INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('TAG SPLIT',1,'O','00001',
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
    ' SQL: ' AND B.MAIN_BOOK = 'TAG SPLIT'
    ' SQL: ' AND B.MAIN_BOOK IN ('TAG SPLIT')
    ' SQL: ' AND B.MAIN_BOOK IN ('TAG SPLIT') AND B.BOOK_INOUT = 'O'
    ' SQL: ','195','Tag Split','SPLIT','O','F','A','','TAG SPLIT','N','A','N','Tag Split','LBR_DATA')
    ' SQL: ',COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB
    ' SQL: ',COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB
    ' SQL: ALTER TABLE CO_SET_NEW ADD SL_TAG_WT_DIFF VARCHAR(1) DEFAULT 'N'
    ' SQL: AND CR_FINE <> 0 AND AC_CODE <> '' AND A.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('TAG WT CHANGE','TAG SPLIT')
    ' SQL: AND DR_FINE <> 0 AND AC_CODE <> '' AND A.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('TAG WT CHANGE','TAG SPLIT')
    ' SQL: INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('TAG SPLIT',1,'O','00001','CASH ON HAND')

End Class
