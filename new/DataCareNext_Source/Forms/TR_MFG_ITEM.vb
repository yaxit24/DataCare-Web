' ============================================================
' DataCareNext - TR_MFG_ITEM : Tag / Item Generation (Mfg)
' Create new jewellery tag from manufacturing. Inserts into TAG_STOCK.
' ============================================================
Imports System.Data.SqlClient

Public Class TR_MFG_ITEM
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_MFG_ITEM_Load(s As Object, e As EventArgs) Handles Me.Load
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
    ' SQL: # AND A.IT_CODE <> '' AND (A.TAG_NO = '' OR A.TAG_NO IS NULL)  GROUP BY A.IT_CODE,B.IT_NAME,B.IT_TYPE,B.GR_CODE,B.AVG_TO
    ' SQL: # AND A.IT_CODE <> '' AND (A.TAG_NO = '' OR A.TAG_NO IS NULL)  GROUP BY A.IT_CODE,B.IT_NAME,B.IT_TYPE,B.GR_CODE,B.IT_TOU
    ' SQL: # AND {MFG_DETL.VCH_DATE} <= #
    ' SQL: '   UNION ALL SELECT  MAX(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO))) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B 
    ' SQL: '  AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.TAG_NO <> 'N'
    ' SQL: '  AND A.TAG_NO <> 'N'  GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.IT
    ' SQL: '  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '
    ' SQL: '  AND A.TAG_NO <> 'N' AND C.STK_DATE <= '
    ' SQL: '  AND A.TAG_NO <> 'N' GROUP BY A.TAG_NO,A.IT_CODE,A.VCH_SRNO  HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A
    ' SQL: '  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=10  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.T
    ' SQL: '  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=9  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TA
    ' SQL: '  And A.TAG_NO <> 'N' GROUP BY C.CO_CODE, C.LC_CODE, C.VCH_TYPE, C.VCH_NO,C.STK_DATE, C.TAG_NO, A.IT_CODE, C.VCH_SRNO H
    ' SQL: '  And A.TAG_NO <> 'N' GROUP BY C.TAG_NO, C.VCH_SRNO HAVING SUM(CASE WHEN A.ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRN
    ' SQL: '  GROUP BY A.TAG_NO,A.TBL_CODE,A.IT_CODE
    ' SQL: '  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE
    ' SQL: '  GROUP BY C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_T
    ' SQL: '  GROUP BY TAG_NO,VCH_SRNO HAVING COUNT(*) > 1 ORDER BY TAG_NO
    ' SQL: '  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST
    ' SQL: '  THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs from ((MAIN_STOCK AS A  LEFT JOIN BA
    ' SQL: '  THEN (CASE WHEN A.ITM_SIGN = '-' THEN 1 ELSE 0 END) ELSE 0 END) AS OutPcs from ((MAIN_STOCK AS A  LEFT JOIN BAR_DETL 

End Class
