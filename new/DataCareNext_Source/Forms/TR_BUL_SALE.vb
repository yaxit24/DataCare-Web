' ============================================================
' DataCareNext - TR_BUL_SALE : Bullion Sale
' Raw gold/silver bar sale. Writes to BUL_DATA and AC_DATA.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_BUL_SALE
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_BUL_SALE_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM BUL_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {BUL_DATA.VCH_DATE} <= #
    ' SQL: ' AND A.BOOK_NAME = 'BUL SALE' AND A.INOUT_TYPE = 'O' AND A.ITM_GWT-A.ADJ_WT > 0   ORDER BY A.VCH_NO,A.SR_NO
    ' SQL: ' AND BOOK_NAME = 'BUL SALE'
    ' SQL: ' AND BOOK_NAME = 'BUL SALE' AND OLD_SRNO = 0
    ' SQL: ' AND {BUL_DATA.CO_BOOK} = '
    ' SQL: ' AND {BUL_DATA.CO_YEAR} = '
    ' SQL: ' AND {BUL_DATA.LC_CODE} = '
    ' SQL: ' AND {BUL_DATA.VCH_DATE} >= #
    ' SQL: ' AND {BUL_DATA.VCH_NO} = '
    ' SQL: ','250','Sales Booking','BOKSL','O','F','A','','BUL SALE','Y','A','N')
    ' SQL: ','252','Sales Lc Booking','OTLCB','O','F','A','','BUL SALE','N','A','N')
    ' SQL: ','260','Bul Sales','BULSL','O','T','A','','BUL WH SALE','Y','A','N')
    ' SQL: ',IT_DESC FROM BUL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK =
    ' SQL: .dbo.BUL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,B
    ' SQL: ALTER TABLE BUL_DATA ADD EMP_CODE VARCHAR(3)

End Class
