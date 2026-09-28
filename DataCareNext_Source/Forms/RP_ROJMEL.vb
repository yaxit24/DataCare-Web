' ============================================================
' DataCareNext - RP_ROJMEL : Day Book (Rojmel)
' Daily cash register – all transactions for a date range with running totals.
' ============================================================
Imports System.Data.SqlClient

Public Class RP_ROJMEL
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub RP_ROJMEL_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM ROJ_MEL_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: '  AND A.TAG_NO <> 'N'  GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.IT
    ' SQL: '  AND BOOK_NAME IN ('EMP ISU','EMP REC')  And
    ' SQL: '  THEN (CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS IsuWt, SUM(CASE WHEN A.VCH_DATE >= 
    ' SQL: '  THEN (CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS IsuPcs,SUM(CASE WHEN A.VCH_DATE >= 
    ' SQL: '  THEN (CASE WHEN A.BOOK_NAME = 'EMP REC' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS RecWt, SUM(CASE WHEN A.VCH_DATE <= 
    ' SQL: '  THEN (CASE WHEN A.BOOK_NAME = 'EMP REC' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS RecPcs, SUM(CASE WHEN A.VCH_DATE >=
    ' SQL: '  THEN (CASE WHEN A.BOOK_NAME = 'TOUR SALES' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS SaleWt, SUM(CASE WHEN A.VCH_DATE
    ' SQL: '  THEN (CASE WHEN A.BOOK_NAME = 'TOUR SALES' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SalePcs,SUM(CASE WHEN A.VCH_DATE
    ' SQL: '  THEN (CASE WHEN BOOK_NAME = 'EMP ISU' THEN
    ' SQL: '  THEN (CASE WHEN BOOK_NAME = 'EMP ISU' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs,SUM(CASE WHEN A.VCH_DATE >= '
    ' SQL: '  THEN (CASE WHEN BOOK_NAME = 'EMP REC' THEN
    ' SQL: '  THEN (CASE WHEN BOOK_NAME = 'EMP REC' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs, SUM(CASE WHEN A.VCH_DATE >= '
    ' SQL: ' AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N'
    ' SQL: ' AND A.BOOK_NAME = 'APR ISU' AND A.AC_CODE = '
    ' SQL: ' AND A.BOOK_NAME = 'APR RTN' AND A.ISU_NO <> ''  UNION ALL SELECT B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,B.ISU_SRNO FROM SL_DET

End Class
