' ============================================================
' DataCareNext - RP_MFG : Manufacturing Report
' Manufacturing register with issue/receipt weights, touch, wastage, karigar-wise.
' ============================================================
Imports System.Data.SqlClient

Public Class RP_MFG
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub RP_MFG_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM MFG_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {MFG_DETL.VCH_DATE} <= #
    ' SQL: '  AND A.TAG_NO <> 'N'  GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.IT
    ' SQL: ' AND {MFG_DETL.VCH_DATE} >= #
    ' SQL: ' GROUP BY B.KR_NAME,D.IT_NAME ORDER BY B.KR_NAME,D.IT_NAME
    ' SQL: ' THEN IR_WT ELSE 0 END) As DifWtW,A.IT_CODE As IsuItL,A.IR_YRCD As MfgYearL,A.IR_DBCD As MfgDbCdL,A.IR_NO As MfgNoL,A.I
    ' SQL: ') As Day,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_S
    ' SQL: ') As Day,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_S
    ' SQL: ') As Day,C.TAG_NO As TagNo,C.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_S
    ' SQL: ',  B.BOOK_NAME,KR_NAME,TAG_NO,ITM_GWT,ITM_NWT,IT_TYPE,LBR_AMT,OTH_AMT,HD_VCH_NO,A.MAIN_USER,'
    ' SQL: ','270','Mfg Isu','MFGIS','O','F','A','','MFG ISU ITEM','Y','A','N','Mfg Isu','MFG_DATA')
    ' SQL: ','275','Mfg Rec','MFGRC','I','F','A','','MFG REC ITEM','Y','A','N','Mfg Rec','MFG_DATA')
    ' SQL: ','300','Melting Isu','MLTIS','O','F','A','','MLT PRO','N','A','N','Metal Isu','MFG_DATA')

End Class
