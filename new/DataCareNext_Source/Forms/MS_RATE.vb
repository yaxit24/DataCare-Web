' ============================================================
' DataCareNext - MS_RATE : Rate Master (Daily Rates)
' Enter daily gold and silver rates per group. Used throughout all transaction forms.
' ============================================================
Imports System.Data.SqlClient

Public Class MS_RATE
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub MS_RATE_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM RATE_MAST WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: '  AND {RATE_MAST.VCH_DATE} = #
    ' SQL: ' AND {RATE_MAST.LC_CODE} = '
    ' SQL: ' GROUP BY VCH_DATE,FINE_GL_RATE,FINE_SL_RATE ORDER BY VCH_DATE DESC
    ' SQL: ' GROUP BY VCH_DATE,MAIN_USER,FINE_GL_RATE,FINE_SL_RATE  ORDER BY VCH_DATE DESC
    ' SQL: ',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_
    ' SQL: ',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_
    ' SQL: ',CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,
    ' SQL: ',GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_
    ' SQL: ',GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_US
    ' SQL: ',GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_US
    ' SQL: ALTER TABLE CO_SET ADD RATE_MAST_OPEN VARCHAR(1)
    ' SQL: ALTER TABLE RATE_MAST ADD GR_TOUCH FLOAT NOT NULL DEFAULT 0

End Class
