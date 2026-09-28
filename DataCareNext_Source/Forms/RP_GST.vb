' ============================================================
' DataCareNext - RP_GST : GST Report (GSTR-1 / GSTR-2)
' GSTR-1 (sales) and GSTR-2 (purchases) with HSN-wise, B2B, B2C breakup.
' ============================================================
Imports System.Data.SqlClient

Public Class RP_GST
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub RP_GST_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM TAX_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: ' AND A.TAX_SIGN = '+' AND B.AC_GSTNO = '' GROUP BY C.STATE_CODE,B.AC_STATE
    ' SQL: ' AND B.MAIN_BOOK = 'OTH COMM' AND A.NET_AMT <> 0 AND A.CGST_TAX <> 0  AND C.SR_NO = 2 AND D.AC_GST_TYPE <> 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'OTH COMM' AND A.NET_AMT <> 0 AND A.IGST_TAX <> 0  AND C.SR_NO = 3 AND D.AC_GST_TYPE = 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'OTH EXP' AND A.NET_AMT <> 0 AND A.CGST_TAX <> 0  AND C.SR_NO = 2 AND D.AC_GST_TYPE <> 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'OTH EXP' AND A.NET_AMT <> 0 AND A.IGST_TAX <> 0  AND C.SR_NO = 0
    ' SQL: ' AND B.MAIN_BOOK = 'OTH EXP' AND A.NET_AMT <> 0 AND A.IGST_TAX <> 0  AND C.SR_NO = 3 AND D.AC_GST_TYPE = 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'OTH INC' AND A.NET_AMT <> 0 AND A.CGST_TAX <> 0  AND C.SR_NO = 2 AND D.AC_GST_TYPE <> 'I'
    ' SQL: ' AND B.MAIN_BOOK = 'OTH INC' AND A.NET_AMT <> 0 AND A.IGST_TAX <> 0  AND C.SR_NO = 0
    ' SQL: ' AND B.MAIN_BOOK = 'OTH INC' AND A.NET_AMT <> 0 AND A.IGST_TAX <> 0  AND C.SR_NO = 3 AND D.AC_GST_TYPE = 'I'
    ' SQL: ' AND C.BOOK_TYPE = 'T' AND (B.AC_PIN = '' OR B.AC_GSTNO = '') GROUP BY A.AC_CODE,B.AC_NAME,B.AC_GSTNO,B.AC_PIN
    ' SQL: ' AND C.BOOK_TYPE = 'T' AND (B.HSN_CODE = '' OR B.HSN_CODE IS NULL) GROUP BY B.IT_NAME
    ' SQL: ' AND C.MAIN_BOOK IN ('SALES','LABOUR WORK','SERVICE INC','E INVOICE') GROUP BY B.HSN_CODE,B.RATE_TYPE,B.IT_TYPE,D.AC_GS
    ' SQL: ' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.A
    ' SQL: ' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.A
    ' SQL: ' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.A

End Class
