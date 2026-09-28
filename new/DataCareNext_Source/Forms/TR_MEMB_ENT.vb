' ============================================================
' DataCareNext - TR_MEMB_ENT : Member Entry (Scheme)
' Advance/savings scheme member enrolment and monthly collection.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_MEMB_ENT
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_MEMB_ENT_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM AD_MEMB WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {AD_MEMB.JOIN_DATE} <= #
    ' SQL: '  AND {AD_MEMB.JOIN_DATE} >= #
    ' SQL: '  AND {AD_MEMB.SCHM_CODE} = '
    ' SQL: '  GROUP BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.SCHM_CODE,A.MEMB_CODE,B.MEMB_NAME,A.MAIN_USER ORDER BY A.VCH_NO
    ' SQL: '  GROUP BY A.MEMB_CODE,B.MEMB_NAME,B.MOBILE_NO,B.CARD_NO,C.AC_ADD1,C.AC_CITY ORDER BY B.CARD_NO,B.MEMB_NAME
    ' SQL: '  GROUP BY A.POINT_CODE,A.MEMB_CODE
    ' SQL: '  GROUP BY A.SCHM_CODE,A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE  ORDER BY A.SCHM_CODE,A.MEMB_CODE
    ' SQL: '  GROUP BY D.BOOK_SNAME,A.VCH_NO,A.VCH_DATE,B.MEMB_NAME,A.CO_BOOK,A.MEMB_CODE,D.MAIN_BOOK ,A.POINT_TYPE ORDER BY A.VCH_
    ' SQL: ' AND C.SCHM_CODE = A.SCHM_CODE AND C.MEMB_CODE = A.MEMB_CODE  ORDER BY C.SCHM_DATE DESC) As LastRecDt   FROM AD_MEMB AS
    ' SQL: ' AND DATA_TRFR = 'N' ORDER BY SCHM_CODE,MEMB_CODE
    ' SQL: ' AND VCH_NO <> '00000' AND SCHM_CODE = '
    ' SQL: ' GROUP BY  A.CO_CODE,A.LC_CODE,A.SCHM_CODE,A.MEMB_CODE,A.MEMB_AMT,A.MEMB_NAME,A.JOIN_DATE,A.AC_MOBILE ORDER BY A.SCHM_C
    ' SQL: ' GROUP BY  B.SCHM_CODE,B.MEMB_CODE,A.MEMB_AMT,A.MEMB_NAME,A.JOIN_DATE,A.AC_MOBILE ORDER BY B.SCHM_CODE,B.MEMB_CODE
    ' SQL: ' GROUP BY A.MEMB_CODE,B.MEMB_NAME,A.SCHM_CODE ORDER BY A.MEMB_CODE
    ' SQL: ' GROUP BY A.MEMB_CODE,B.MEMB_NAME,A.SCHM_CODE,B.MEMB_AMT

End Class
