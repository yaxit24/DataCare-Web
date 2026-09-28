' ============================================================
' DataCareNext - TR_PURC : Purchase Bill
' Purchase entry – mirrors TR_SALE but writes to PR_DATA/PR_DETL and creates stock +ve entry
' ============================================================
Imports System.Data.SqlClient

Public Class TR_PURC
    Inherits Form

    ' ── Controls ─────────────────────────────────────────
    Private WithEvents BtnSave   As New Button() With {.Text=Save,   .Location=New Drawing.Point(10,10)}}
    Private WithEvents BtnDelete As New Button() With {.Text=Delete, .Location=New Drawing.Point(95,10)}}
    Private WithEvents BtnPrint  As New Button() With {.Text=Print,  .Location=New Drawing.Point(180,10)}}
    Private WithEvents BtnExit   As New Button() With {.Text=Exit,   .Location=New Drawing.Point(265,10)}}
    Private WithEvents DgvMain   As New DataGridView() With {.Dock=DockStyle.Bottom,.Height=300}

    ' ── Form Load ──────────────────────────────────────────
    Private Sub TR_PURC_Load(s As Object, e As EventArgs) Handles Me.Load
        Me.Text = {info['title']}
        Me.Size = New Drawing.Size(1000, 650)
        Me.Controls.AddRange({BtnSave, BtnDelete, BtnPrint, BtnExit, DgvMain})
        LoadGrid()
    End Sub

    ' ── Load main grid ─────────────────────────────────────
    Private Sub LoadGrid()
        DgvMain.DataSource = FillTable("SELECT TOP 500 * FROM PR_DATA WHERE CO_CODE='" & gCoCode & "'")
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
    ' SQL: # AND {APR_DETL.VCH_DATE} <= #
    ' SQL: '  UNION ALL SELECT VCH_NO FROM APR_DETL WHERE CO_CODE = '
    ' SQL: ' AND ({PR_DATA.NET_AMT}+{PR_DATA.TOT_TAX_FREE_AMT}) <> 0 AND {PR_DATA.VCH_DATE} >= #
    ' SQL: ' AND APR_DETL.BOOK_NAME = 'EMP ISU' AND B.VCH_NO = '
    ' SQL: ' AND APR_DETL.CO_BOOK = '018'  AND B.VCH_NO = '
    ' SQL: ' AND APR_DETL.CO_BOOK = '018' AND B.VCH_NO = '
    ' SQL: ' AND APR_DETL.CO_BOOK = '051' AND B.VCH_NO = '
    ' SQL: ' AND S.MAIN_BOOK = 'WH SALES'  GROUP BY I.CO_CODE,I.LC_CODE,I.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT J.CO_CODE,J.LC_CODE
    ' SQL: ' AND {APR_DETL.ISU_REC} = 'N' AND {APR_DETL.VCH_DATE} >= #
    ' SQL: ' AND {APR_DETL.VCH_DATE} >= #
    ' SQL: ' AND {PR_DATA.NET_AMT} <> 0 AND {PR_DATA.VCH_DATE} >= #
    ' SQL: ' And D.BOOK_NAME = 'RATE CUT' And D.ISU_NO <> '' ) AS X  WHERE X.ISU_YRCD = APR_DETL.CO_YEAR And X.ISU_DBCD = APR_DETL.
    ' SQL: ' And EXISTS (Select 1 FROM (Select A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,A.ISU_SRNO From APR_DETL A  Where A.CO_CODE = '
    ' SQL: ' GROUP BY A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.IT_DESC,A.MAIN_USER  UNION ALL SELECT A.VCH_NO,replace(convert(NVARCHAR,A.VCH
    ' SQL: ' THEN(CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_GWT ELSE -A.ITM_GWT END) ELSE 0 END) AS PanWt FROM (APR_DETL AS A LE
    ' SQL: ','235','Purc Quotation','PRQUT','O','F','A','','PR QUOT','Y','A','N','Pr Quotation','PR_DATA')
    ' SQL: ','435','Purchase Invoice','PRINV','I','T','A','IP','ITEM PURC','Y','A','N','N','N','Item Purc','PR_DATA')
    ' SQL: ','735','B2B Purchase','B2BPR','I','T','A','','B2B PURC','Y','A','N','N','N','B2B Purc','PR_DATA')
    ' SQL: ','ItCode' + ' / ' + IT_CODE + '   TagNo' + ' / ' + TAG_NO FROM (APR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B
    ' SQL: ','ItCode' + '/' + IT_CODE FROM (PR_DATA AS C LEFT JOIN PR_DETL AS A ON C.CO_CODE = A.CO_CODE AND C.LC_CODE = A.LC_CODE 
    ' SQL: ) AS NEXT_VCH_NO  From PR_DATA WHERE CO_CODE = '
    ' SQL: ,SUM(A.ITM_PCS) As Pcs,SUM(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As Nwt   FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO
    ' SQL: .dbo.APR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,AC_CODE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTR
    ' SQL: ALTER TABLE APR_DATA ADD ISU_NO VARCHAR(8),ISU_LC_CODE VARCHAR(2),ISU_YRCD VARCHAR(10),ISU_DBCD VARCHAR(3)
    ' SQL: ALTER TABLE APR_DATA ADD USER_UPDATE VARCHAR(1) Not NULL DEFAULT 'N',USER_DELETE VARCHAR(1) Not NULL DEFAULT 'N'

End Class
