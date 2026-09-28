' ============================================================
' DataCareNext - TR_FINE_SL_PR : Fine Gold/Silver Sale & Purchase
' Rate-cut / gold fixing transactions for fine metal
' ============================================================
Imports System.Data.SqlClient

Public Class TR_FINE_SL_PR
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_FINE_SL_PR_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM CUT_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {RATE_CUT_DATA.VCH_DATE} <= #
    ' SQL: ' AND S.MAIN_BOOK = 'KARIGAR RECEIPT'  GROUP BY M.CO_CODE,M.LC_CODE,M.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT N.CO_CODE,N.
    ' SQL: ' AND S.MAIN_BOOK = 'SALES'  GROUP BY H.CO_CODE,H.LC_CODE,H.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT I.CO_CODE,I.LC_CODE,I.
    ' SQL: ' AND {CUT_DATA.CO_BOOK} = '
    ' SQL: ' AND {CUT_DATA.CO_YEAR} = '
    ' SQL: ' AND {CUT_DATA.LC_CODE} = '
    ' SQL: ' AND {CUT_DATA.VCH_NO} = '
    ' SQL: ' AND {RATE_CUT_DATA.CO_BOOK} = '
    ' SQL: ' AND {RATE_CUT_DATA.CO_YEAR} = '
    ' SQL: ' AND {RATE_CUT_DATA.LC_CODE} = '
    ' SQL: ' AND {RATE_CUT_DATA.VCH_DATE} >= #
    ' SQL: ' AND {RATE_CUT_DATA.VCH_NO} = '
    ' SQL: ','','','FSL','KADLI FINE SILVER', 0,
    ' SQL: ','134','Wh Sales Return','WHRTN','I','F','A','','WH RTN','Y','A','N','Wh Sl Return','RATE_CUT_DATA')
    ' SQL: ','405','Fine Sales','FINSL','O','T','A','FS','FINE SALE','Y','A','N','Fine Sales','CUT_DATA')

End Class
