' ============================================================
' DataCareNext - TR_KR_ISU : Karigar Issue
' Issue raw metal to karigar (artisan). Reduces stock, creates INOUT_DATA.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_KR_ISU
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_KR_ISU_Load(s As Object, e As EventArgs) Handles Me.Load
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
    ' SQL: '  AND B.MAIN_BOOK IN ('PURCHASE','CASH PAY','BANK PAY','KARIGAR RECEIPT','SALES RETURNE','MEMB ADJUST','ORDER CANCEL','
    ' SQL: ' AND A.BOOK_NAME IN ('KARIGAR RECEIPT') AND A.CO_BOOK = '
    ' SQL: ' AND A.BOOK_NAME NOT IN ('KARIGAR RECEIPT','PURCHASE') AND A.CO_BOOK = '
    ' SQL: ' AND A.BOOK_NAME NOT IN ('KARIGAR RECEIPT','PURCHASE','FINE PURC') AND A.CO_BOOK = '
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT'
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_INOUT = 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_INOUT = 'I' AND A.WITH_STOCK = 'Y'
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_INOUT = 'I' AND B.ITM_TYPE <> 'A'
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_INOUT = 'I' AND B.ITM_TYPE = 'A'
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_INOUT = 'I' AND D.SR_NO = 0
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_TYPE = 'T'  AND A.NET_AMT <> 0 AND C.SR_NO = 1 AND D.AC_GST_TYPE <> 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_TYPE = 'T' AND A.NET_AMT <> 0 AND C.SR_NO = 2 AND D.AC_GST_TYPE <> 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'KARIGAR RECEIPT' AND B.BOOK_TYPE = 'T' AND A.NET_AMT <> 0 AND C.SR_NO = 3 AND D.AC_GST_TYPE = 'I'
    ' SQL: ' AND B.MAIN_BOOK IN ('KARIGAR RECEIPT')
    ' SQL: ' AND B.MAIN_BOOK IN ('KARIGAR RECEIPT')  AND B.BOOK_INOUT = 'I'
    ' SQL: ' AND B.MAIN_BOOK IN ('OPSTK','TAG GEN','PURCHASE','KARIGAR RECEIPT')   GROUP BY A.VCH_NO,replace(convert(NVARCHAR,A.VCH
    ' SQL: ' AND B.MAIN_BOOK IN ('OPSTK','TAG GEN','PURCHASE','KARIGAR RECEIPT')  GROUP BY A.VCH_NO,A.VCH_DATE,B.BOOK_NAME,A.STK_IT
    ' SQL: ' AND S.MAIN_BOOK = 'KARIGAR RECEIPT'  GROUP BY M.CO_CODE,M.LC_CODE,M.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT N.CO_CODE,N.
    ' SQL: ','350','Artisan Receipt','ARTRC','I','T','A','','KARIGAR RECEIPT','N','A','N','Y')
    ' SQL: ','KR_ISU','AvgAmt','AvgAmt','N','N')

End Class
