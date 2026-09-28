' ============================================================
' DataCareNext - TR_SALE_ORD : Sales Order
' Customer order booking with advance collection and order tracking.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_SALE_ORD
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_SALE_ORD_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM SL_ORD_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {SL_ORD_DATA.VCH_DATE} <= #
    ' SQL: '  AND B.MAIN_BOOK IN ('MEMB ENTRY','SALES','SALES ORDER','MEMB ENTRY','CASH REC','BANK REC','KARIGAR ISSUE','VP PARCEL'
    ' SQL: ' AND (B.MAIN_BOOK = 'SALES ORDER' OR A.CO_BOOK = '220') AND A.VCH_DATE < '
    ' SQL: ' AND A.BOOK_NAME = 'KARIGAR ORDER' AND A.ISU_REC = 'N'  UNION ALL SELECT F.AC_NAME as CustNameL,D.VCH_NO As VchNoL,D.DE
    ' SQL: ' AND B.MAIN_BOOK = 'SALES ORDER' AND B.BOOK_INOUT = 'I'
    ' SQL: ' AND B.MAIN_BOOK IN ('SALES ORDER') AND A.VCH_DATE >= '
    ' SQL: ' AND B.MAIN_BOOK IN ('SALES ORDER','TOUR ORDER')
    ' SQL: ' AND B.MAIN_BOOK IN ('SALES ORDER','TOUR ORDER') AND B.BOOK_INOUT = 'I'
    ' SQL: ' AND BOOK_NAME = 'CONTRA'  GROUP BY CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME  UNION ALL SELECT G.CO_CODE,G.LC_CODE,G.CO_BOOK,M
    ' SQL: ' AND D.MAIN_BOOK = 'SALES ORDER'  ORDER BY A.VCH_NO,A.OLD_SRNO
    ' SQL: ' AND ITM_SIGN = '-' AND TAG_NO <> 'N' AND BOOK_NAME NOT IN ('APR ISU','SALES ORDER')  GROUP BY TAG_NO,VCH_SRNO HAVING C
    ' SQL: ' AND S.MAIN_BOOK = 'SALES ORDER'  GROUP BY G.CO_CODE,G.LC_CODE,G.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT H.CO_CODE,H.LC_C
    ' SQL: ' AND {SL_ORD_DATA.CO_BOOK} = '
    ' SQL: ' AND {SL_ORD_DATA.CO_YEAR} = '
    ' SQL: ' AND {SL_ORD_DATA.LC_CODE} = '

End Class
