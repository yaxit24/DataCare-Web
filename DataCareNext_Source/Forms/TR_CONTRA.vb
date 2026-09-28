' ============================================================
' DataCareNext - TR_CONTRA : Contra Voucher
' Bank-to-cash or cash-to-bank transfer. Writes dual AC_DATA entries.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_CONTRA
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_CONTRA_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM CONTRA_DATA WHERE CO_CODE='" & gCoCode & "'")
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
            ' DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN CONTRA_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE
            ' DELETE CONTRA_DATA FROM CONTRA_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_
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
    ' SQL: ' AND S.MAIN_BOOK = 'RATE CUT'  GROUP BY N.CO_CODE,N.LC_CODE,N.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT O.CO_CODE,O.LC_CODE
    ' SQL: ' AND S.MAIN_BOOK = 'TAG CANCEL'  GROUP BY E.CO_CODE,E.LC_CODE,E.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT CO_CODE,LC_CODE,C
    ' SQL: ' AND {CONTRA_DATA.CO_BOOK} = '
    ' SQL: ' AND {CONTRA_DATA.CO_YEAR} = '
    ' SQL: ' AND {CONTRA_DATA.LC_CODE} = '
    ' SQL: ' AND {CONTRA_DATA.VCH_NO} = '
    ' SQL: ',SUBSTRING(IT_DESC,1,149) FROM CONTRA_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_
    ' SQL: ) AS NEXT_VCH_NO  From CONTRA_DATA WHERE CO_CODE = '
    ' SQL: ALTER TABLE CONTRA_DATA ADD CR_FINE FLOAT DEFAULT 0,DR_FINE FLOAT DEFAULT 0,IT_TYPE VARCHAR(1)
    ' SQL: ALTER TABLE CONTRA_DATA ADD RE_TRFR VARCHAR(1)Not NULL DEFAULT 'N'
    ' SQL: ALTER TABLE CONTRA_DATA ADD USER_UPDATE VARCHAR(1) Not NULL DEFAULT 'N',USER_DELETE VARCHAR(1) Not NULL DEFAULT 'N'
    ' SQL: CREATE TABLE CONTRA_DATA(CO_CODE VARCHAR(2),LC_CODE VARCHAR(2),CO_YEAR VARCHAR(10),CO_BOOK VARCHAR(3),VCH_NO VARCHAR(8),
    ' SQL: DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN CONTRA_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.C
    ' SQL: DELETE CONTRA_DATA FROM CONTRA_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND
    ' SQL: DELETE FROM CONTRA_DATA WHERE  CO_CODE = '

End Class
