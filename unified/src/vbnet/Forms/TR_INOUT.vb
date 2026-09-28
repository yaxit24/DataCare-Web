' ============================================================
' DataCareNext - TR_INOUT : Stock In/Out Transfer
' General stock movement: branch transfer, adjust, write-off.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_INOUT
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_INOUT_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM INOUT_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: ' AND {INOUT_DATA.CO_BOOK} = '
    ' SQL: ' AND {INOUT_DATA.CO_YEAR} = '
    ' SQL: ' AND {INOUT_DATA.LC_CODE} = '
    ' SQL: ','ItCode' + '/' + IT_CODE + ' TagNo' + '/' + TAG_NO FROM INOUT_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_C
    ' SQL: .dbo.BUL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,B
    ' SQL: ALTER TABLE BUL_DATA ADD TO_LC_CODE VARCHAR(2)
    ' SQL: ALTER TABLE INOUT_DATA ADD FROM_LC_CODE VARCHAR(2)
    ' SQL: ALTER TABLE INOUT_DATA ADD STK_TRFR VARCHAR(1) DEFAULT 'N'
    ' SQL: ALTER TABLE INOUT_DATA ADD TO_VCH_NO VARCHAR(8),TO_CO_BOOK VARCHAR(3),FROM_VCH_NO VARCHAR(8),FROM_CO_BOOK VARCHAR(3)
    ' SQL: ALTER TABLE INOUT_DATA ADD USER_UPDATE VARCHAR(1) Not NULL DEFAULT 'N',USER_DELETE VARCHAR(1) Not NULL DEFAULT 'N'
    ' SQL: ALTER TABLE INOUT_DETL ADD DATA_TYPE VARCHAR(1)Not NULL DEFAULT 'A'
    ' SQL: ALTER TABLE INOUT_DETL ADD DESIGN_IMG_ID VARCHAR(50)Not NULL DEFAULT 'N'
    ' SQL: ALTER TABLE INOUT_DETL ADD FROM_LC_CODE VARCHAR(2)
    ' SQL: ALTER TABLE INOUT_DETL ADD ITM_COLOR VARCHAR(15)
    ' SQL: ALTER TABLE INOUT_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''
    ' SQL: ALTER TABLE INOUT_DETL ADD ITM_STYLE VARCHAR(20)Not NULL DEFAULT ''
    ' SQL: ALTER TABLE INOUT_DETL ADD JDT_JDT_WT FLOAT Not NULL Default 0,JDT_GHT_WT FLOAT Not NULL Default 0,JDT_KUN_WT FLOAT Not 
    ' SQL: ALTER TABLE INOUT_DETL ADD JDT_KUN_TOUCH FLOAT Not NULL Default 0,JDT_KUN_NET FLOAT Not NULL Default 0,JDT_WAX_WT FLOAT 
    ' SQL: ALTER TABLE INOUT_DETL ADD KR_COST FLOAT Not NULL Default 0,ITM_MARGIN FLOAT Not NULL Default 0
    ' SQL: ALTER TABLE INOUT_DETL ADD KR_COST FLOAT Not NULL Default 0,TAG_COST FLOAT Not NULL Default 0,ITM_MARGIN FLOAT Not NULL 

End Class
