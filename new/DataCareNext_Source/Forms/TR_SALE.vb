
' ==============================================================
' DataCareNext - TR_SALE : Sales Bill Form
' Full SQL extracted from DataCareNext.exe v11.06
' ==============================================================
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class TR_SALE
    Inherits Form

    ' ── Controls ──────────────────────────────────────────
    Private WithEvents BtnSave   As Button
    Private WithEvents BtnDelete As Button
    Private WithEvents BtnPrint  As Button
    Private WithEvents BtnExit   As Button
    Private WithEvents BtnNew    As Button
    Private WithEvents DgvItems  As DataGridView

    ' ── Header fields ─────────────────────────────────────
    Private WithEvents tVchNo    As TextBox  ' Voucher Number
    Private WithEvents tVchDate  As DateTimePicker
    Private WithEvents tBillNo   As TextBox  ' Bill Number
    Private WithEvents cboAcCode As ComboBox ' Customer A/c
    Private WithEvents tAcName   As TextBox
    Private WithEvents tMobile   As TextBox

    ' ── Amount fields ─────────────────────────────────────
    Private WithEvents tNetAmt    As TextBox
    Private WithEvents tDiscPrc   As TextBox
    Private WithEvents tDiscAmt   As TextBox
    Private WithEvents tTaxCode   As TextBox
    Private WithEvents tTaxPrc    As TextBox
    Private WithEvents tTaxAmt    As TextBox
    Private WithEvents tRofAmt    As TextBox
    Private WithEvents tTotAmt    As TextBox
    Private WithEvents tCashAmt   As TextBox
    Private WithEvents tCardAmt   As TextBox
    Private WithEvents tChqAmt    As TextBox
    Private WithEvents tBillOs    As TextBox
    Private WithEvents tIgstTax   As TextBox
    Private WithEvents tCgstTax   As TextBox
    Private WithEvents tSgstTax   As TextBox

    ' ── GST / E-Invoice ───────────────────────────────────
    Private WithEvents tIrnNo  As TextBox
    Private WithEvents tAckNo  As TextBox
    Private WithEvents BtnEInv As Button

    ' ── State ─────────────────────────────────────────────
    Private _isNew   As Boolean = True
    Private _coBook  As String = ""
    Private _dtItems As DataTable

    ' ─────────────────────────────────────────────────────
    Private Sub TR_SALE_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBookCode()
        InitGrid()
        LoadNewVoucher()
    End Sub

    Private Sub LoadBookCode()
        Dim dt = FillTable($"SELECT CO_BOOK FROM BOOK_DATA WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND MAIN_BOOK='SALES' AND BOOK_TYPE='T' AND CUR_IN_USE='Y'")
        If dt.Rows.Count > 0 Then _coBook = dt.Rows(0)("CO_BOOK").ToString().Trim()
    End Sub

    Private Sub LoadNewVoucher()
        _isNew = True
        tVchDate.Value = Today
        tVchNo.Text  = GetNextVchNo(gCoCode, gLcCode, gCoYear, _coBook)
        tBillNo.Text = ""
        tAcName.Text = ""
        tNetAmt.Text = "0.000"
        tTotAmt.Text = "0.000"
        tCashAmt.Text = "0.000"
        _dtItems = New DataTable()
        _dtItems.Columns.Add("TAG_NO")
        _dtItems.Columns.Add("IT_CODE")
        _dtItems.Columns.Add("IT_NAME")
        _dtItems.Columns.Add("DESIGN_NO")
        _dtItems.Columns.Add("ITM_SIZE")
        _dtItems.Columns.Add("ITM_PCS",  GetType(Decimal))
        _dtItems.Columns.Add("ITM_GWT",  GetType(Decimal))
        _dtItems.Columns.Add("ITM_NWT",  GetType(Decimal))
        _dtItems.Columns.Add("ITM_TOUCH",GetType(Decimal))
        _dtItems.Columns.Add("ITM_FINE", GetType(Decimal))
        _dtItems.Columns.Add("ITM_RATE", GetType(Decimal))
        _dtItems.Columns.Add("ITM_AMT",  GetType(Decimal))
        _dtItems.Columns.Add("LBR_TYPE")
        _dtItems.Columns.Add("LBR_PRC",  GetType(Decimal))
        _dtItems.Columns.Add("LBR_RATE", GetType(Decimal))
        _dtItems.Columns.Add("LBR_AMT",  GetType(Decimal))
        _dtItems.Columns.Add("OTH_AMT",  GetType(Decimal))
        _dtItems.Columns.Add("NET_AMT",  GetType(Decimal))
        _dtItems.Columns.Add("TAX_PRC",  GetType(Decimal))
        _dtItems.Columns.Add("IT_TAX_AMT",GetType(Decimal))
        _dtItems.Columns.Add("DISC_PRC", GetType(Decimal))
        _dtItems.Columns.Add("DISC_AMT", GetType(Decimal))
        _dtItems.Columns.Add("TOT_AMT",  GetType(Decimal))
        _dtItems.Columns.Add("RATE_TYPE")
        _dtItems.Columns.Add("IT_TYPE")
        _dtItems.Columns.Add("HM_ID")
        DgvItems.DataSource = _dtItems
    End Sub

    ' ── Customer lookup ────────────────────────────────────
    Private Sub cboAcCode_Leave(sender As Object, e As EventArgs) Handles cboAcCode.Leave
        If String.IsNullOrEmpty(cboAcCode.Text.Trim()) Then Exit Sub
        Dim dt = FillTable($"SELECT AC_NAME, AC_GST_TYPE, AC_GSTNO, AC_MOBILE, AC_CR_DAYS, TOUCH_MAST.AC_TOUCH " &
                           $"FROM AC_MAST LEFT JOIN TOUCH_MAST ON AC_MAST.CO_CODE=TOUCH_MAST.CO_CODE " &
                           $"AND AC_MAST.AC_CODE=TOUCH_MAST.AC_CODE " &
                           $"WHERE AC_MAST.CO_CODE='{gCoCode}' AND AC_MAST.AC_CODE='{cboAcCode.Text.Trim()}'")
        If dt.Rows.Count > 0 Then
            tAcName.Text = dt.Rows(0)("AC_NAME").ToString().Trim()
            tMobile.Text = dt.Rows(0)("AC_MOBILE").ToString().Trim()
        Else
            MsgBox("Account not found.", MsgBoxStyle.Information)
        End If
    End Sub

    ' ── Tag-based item scan ────────────────────────────────
    Public Sub LoadItemByTag(tagNo As String)
        Dim dt = FillTable(
            $"SELECT A.*, B.IT_NAME, B.IT_TYPE, B.GR_CODE, B.RATE_TYPE " &
            $"FROM TAG_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE=B.CO_CODE AND A.IT_CODE=B.IT_CODE " &
            $"WHERE A.CO_CODE='{gCoCode}' AND A.LC_CODE='{gLcCode}' AND A.TAG_NO='{tagNo}'")
        If dt.Rows.Count = 0 Then
            MsgBox("Tag not found in stock.", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim r = dt.Rows(0)
        Dim nr = _dtItems.NewRow()
        nr("TAG_NO")   = tagNo
        nr("IT_CODE")  = r("IT_CODE").ToString()
        nr("IT_NAME")  = r("IT_NAME").ToString()
        nr("ITM_GWT")  = CDec(r("ITM_GWT"))
        nr("ITM_NWT")  = CDec(r("ITM_NWT"))
        nr("LBR_PRC")  = CDec(r("LBR_PRC"))
        nr("LBR_TYPE") = r("LBR_TYPE").ToString()
        nr("LBR_RATE") = CDec(r("LBR_RATE"))
        nr("LBR_AMT")  = CDec(r("LBR_AMT"))
        nr("RATE_TYPE")= r("RATE_TYPE").ToString()
        nr("IT_TYPE")  = r("IT_TYPE").ToString()
        _dtItems.Rows.Add(nr)
        CalcTotal()
    End Sub

    ' ── Amount calculation ─────────────────────────────────
    Private Sub CalcTotal()
        Dim netAmt As Decimal = 0
        For Each r As DataRow In _dtItems.Rows
            If r.RowState <> DataRowState.Deleted Then netAmt += CDec(r("NET_AMT"))
        Next
        tNetAmt.Text = Fmt3(netAmt)

        Dim discPrc As Decimal = EmptyToZero(tDiscPrc.Text)
        Dim discAmt As Decimal = Math.Round(netAmt * discPrc / 100, 2)
        tDiscAmt.Text = Fmt2(discAmt)

        Dim taxPrc As Decimal = EmptyToZero(tTaxPrc.Text)
        Dim taxBase As Decimal = netAmt - discAmt
        Dim taxAmt  As Decimal = Math.Round(taxBase * taxPrc / 100, 2)
        tTaxAmt.Text = Fmt2(taxAmt)

        Dim rofAmt As Decimal = EmptyToZero(tRofAmt.Text)
        Dim totAmt As Decimal = netAmt - discAmt + taxAmt - rofAmt
        tTotAmt.Text = Fmt2(totAmt)

        ' GST split
        Dim acGstType As String = "C"   ' default intra-state
        If cboAcCode.Text.Trim() <> "" Then
            acGstType = GetValue("AC_MAST","AC_GST_TYPE",$"CO_CODE='{gCoCode}' AND AC_CODE='{cboAcCode.Text.Trim()}'")
        End If
        If acGstType = GST_IGST Then
            tIgstTax.Text = Fmt2(taxAmt)
            tCgstTax.Text = "0.00"
            tSgstTax.Text = "0.00"
        Else
            tIgstTax.Text = "0.00"
            tCgstTax.Text = Fmt2(Math.Round(taxAmt/2,2))
            tSgstTax.Text = Fmt2(Math.Round(taxAmt/2,2))
        End If
    End Sub

    ' ── Validation ────────────────────────────────────────
    Private Function Validate() As Boolean
        If String.IsNullOrEmpty(cboAcCode.Text.Trim()) Then
            MsgBox("Please select Account.", MsgBoxStyle.Exclamation) : Return False
        End If
        If _dtItems.Rows.Count = 0 Then
            MsgBox("Please add at least one item.", MsgBoxStyle.Exclamation) : Return False
        End If
        If CDec(tCashAmt.Text) > gCashLimit Then
            MsgBox($"Cash amount exceeds limit of ₹{gCashLimit:N0}. PAN required.", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function

    ' ── SAVE ──────────────────────────────────────────────
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not Validate() Then Exit Sub
        Try
            BeginTransaction()
            SaveHeader()
            SaveDetails()
            SaveAccountEntry()
            SaveStockEntry()
            SaveTaxEntry()
            CommitTransaction()
            MsgBox("Voucher saved successfully.", MsgBoxStyle.Information)
            LoadNewVoucher()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub SaveHeader()
        Dim vn = tVchNo.Text.Trim()
        Dim acCode = cboAcCode.Text.Trim()
        Dim vd = tVchDate.Value.ToString("MM/dd/yyyy")
        Dim netAmt = CDec(tNetAmt.Text)
        Dim discPrc = EmptyToZero(tDiscPrc.Text)
        Dim discAmt = EmptyToZero(tDiscAmt.Text)
        Dim taxCode = tTaxCode.Text.Trim()
        Dim taxPrc  = EmptyToZero(tTaxPrc.Text)
        Dim taxAmt  = EmptyToZero(tTaxAmt.Text)
        Dim rofAmt  = EmptyToZero(tRofAmt.Text)
        Dim totAmt  = CDec(tTotAmt.Text)
        Dim cashAmt = EmptyToZero(tCashAmt.Text)
        Dim cardAmt = EmptyToZero(tCardAmt.Text)
        Dim chqAmt  = EmptyToZero(tChqAmt.Text)
        Dim billOs  = CDec(tBillOs.Text)
        Dim igst    = EmptyToZero(tIgstTax.Text)
        Dim cgst    = EmptyToZero(tCgstTax.Text)
        Dim sgst    = EmptyToZero(tSgstTax.Text)
        Dim acName  = tAcName.Text.Trim().Replace("'","''")
        Dim mob     = tMobile.Text.Trim()

        If _isNew Then
            ExecNonQuery(
                $"INSERT INTO SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME," &
                $"AC_CODE,AC_NAME,NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT," &
                $"CASH_AMT,CARD_AMT,CHQ_AMT,BILL_OS,IGST_TAX,CGST_TAX,SGST_TAX," &
                $"DATA_TRFR,MAIN_USER,MOBILE,USER_UPDATE,USER_DELETE) VALUES " &
                $"('{gCoCode}','{gLcCode}','{gCoYear}','{_coBook}','{vn}','{vd}',GETDATE()," &
                $"'{acCode}','{acName}',{netAmt},{discPrc},{discAmt},'{taxCode}',{taxPrc},{taxAmt},{rofAmt},{totAmt}," &
                $"{cashAmt},{cardAmt},{chqAmt},{billOs},{igst},{cgst},{sgst}," &
                $"'N','{gMainUser}','{mob}','N','N')")
        Else
            ExecNonQuery(
                $"UPDATE SL_DATA SET VCH_DATE='{vd}',AC_CODE='{acCode}',AC_NAME='{acName}'," &
                $"NET_AMT={netAmt},DISC_PRC={discPrc},DISC_AMT={discAmt},TAX_CODE='{taxCode}'," &
                $"TAX_PRC={taxPrc},TAX_AMT={taxAmt},ROF_AMT={rofAmt},TOT_AMT={totAmt}," &
                $"CASH_AMT={cashAmt},CARD_AMT={cardAmt},CHQ_AMT={chqAmt},BILL_OS={billOs}," &
                $"IGST_TAX={igst},CGST_TAX={cgst},SGST_TAX={sgst},MAIN_USER='{gMainUser}'" &
                $" WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
        End If
    End Sub

    Private Sub SaveDetails()
        Dim vn = tVchNo.Text.Trim()
        If Not _isNew Then
            ExecNonQuery($"DELETE FROM SL_DETL WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
        End If
        Dim sr As Integer = 1
        For Each r As DataRow In _dtItems.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            ExecNonQuery(
                $"INSERT INTO SL_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE," &
                $"IT_CODE,TAG_NO,DESIGN_NO,ITM_SIZE,ITM_PCS,ITM_GWT,ITM_NWT," &
                $"ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_RATE,ITM_AMT," &
                $"LBR_TYPE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT," &
                $"TAX_PRC,IT_TAX_AMT,DISC_PRC,DISC_AMT,TOT_AMT,RATE_TYPE,IT_TYPE,MAIN_USER) VALUES (" &
                $"'{gCoCode}','{gLcCode}','{gCoYear}','{_coBook}','{vn}',{sr},'{tVchDate.Value:MM/dd/yyyy}'," &
                $"'{r("IT_CODE")}','{r("TAG_NO")}','{r("DESIGN_NO")}','{r("ITM_SIZE")}'," &
                $"{r("ITM_PCS")},{r("ITM_GWT")},{r("ITM_NWT")}," &
                $"{r("ITM_TOUCH")},{r("ITM_WEST")},{r("ITM_FINE")},{r("ITM_RATE")},{r("ITM_AMT")}," &
                $"'{r("LBR_TYPE")}',{r("LBR_PRC")},{r("LBR_RATE")},{r("LBR_AMT")},{r("OTH_AMT")},{r("NET_AMT")}," &
                $"{r("TAX_PRC")},{r("IT_TAX_AMT")},{r("DISC_PRC")},{r("DISC_AMT")},{r("TOT_AMT")}," &
                $"'{r("RATE_TYPE")}','{r("IT_TYPE")}','{gMainUser}')")
            sr += 1
        Next
    End Sub

    Private Sub SaveAccountEntry()
        Dim vn   = tVchNo.Text.Trim()
        Dim acCode = cboAcCode.Text.Trim()
        Dim totAmt = CDec(tTotAmt.Text)
        Dim vd = tVchDate.Value.ToString("MM/dd/yyyy")
        ExecNonQuery($"DELETE FROM AC_DATA WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
        ' Debit customer, Credit Sales ledger
        ExecNonQuery(
            $"INSERT INTO AC_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,AC_CODE,LD_CODE,DR_AMT,CR_AMT,VCH_TYPE,SIGN,MAIN_USER) VALUES " &
            $"('{gCoCode}','{gLcCode}','{gCoYear}','{_coBook}','{vn}','{vd}','{acCode}','{acCode}',{totAmt},0,'SALES','+','{gMainUser}')")
    End Sub

    Private Sub SaveStockEntry()
        Dim vn = tVchNo.Text.Trim()
        Dim vd = tVchDate.Value.ToString("MM/dd/yyyy")
        ExecNonQuery($"DELETE FROM MAIN_STOCK WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
        For Each r As DataRow In _dtItems.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            ExecNonQuery(
                $"INSERT INTO MAIN_STOCK(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,IT_CODE,TAG_NO," &
                $"ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,ITM_SIGN,IT_TYPE,MAIN_USER) VALUES " &
                $"('{gCoCode}','{gLcCode}','{gCoYear}','{_coBook}','{vn}','{vd}','{r("IT_CODE")}','{r("TAG_NO")}'," &
                $"{r("ITM_PCS")},{r("ITM_GWT")},{r("ITM_NWT")},{r("ITM_FINE")},'-','{r("IT_TYPE")}','{gMainUser}')")
            ' Remove from TAG_STOCK
            ExecNonQuery($"DELETE FROM TAG_STOCK WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND TAG_NO='{r("TAG_NO")}'")
        Next
    End Sub

    Private Sub SaveTaxEntry()
        Dim vn     = tVchNo.Text.Trim()
        Dim acCode = cboAcCode.Text.Trim()
        Dim vd     = tVchDate.Value.ToString("MM/dd/yyyy")
        Dim netAmt = CDec(tNetAmt.Text)
        Dim taxCode= tTaxCode.Text.Trim()
        Dim taxPrc = EmptyToZero(tTaxPrc.Text)
        Dim taxAmt = EmptyToZero(tTaxAmt.Text)
        Dim totAmt = CDec(tTotAmt.Text)
        Dim igst   = EmptyToZero(tIgstTax.Text)
        Dim cgst   = EmptyToZero(tCgstTax.Text)
        Dim sgst   = EmptyToZero(tSgstTax.Text)
        ExecNonQuery($"DELETE FROM TAX_DATA WHERE CO_CODE='{gCoCode}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
        If taxAmt <> 0 Then
            ExecNonQuery(
                $"INSERT INTO TAX_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE," &
                $"AC_CODE,NET_AMT,TAX_CODE,TAX_PRC,TAX_AMT,TOT_AMT,IGST_TAX,CGST_TAX,SGST_TAX,BOOK_NAME,TAX_SIGN) VALUES " &
                $"('{gCoCode}','{gLcCode}','{gCoYear}','{_coBook}','{vn}','{vd}'," &
                $"'{acCode}',{netAmt},'{taxCode}',{taxPrc},{taxAmt},{totAmt},{igst},{cgst},{sgst},'SALES','+')")
        End If
    End Sub

    ' ── DELETE ────────────────────────────────────────────
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _isNew Then MsgBox("Nothing to delete.") : Exit Sub
        If MsgBox("Delete this voucher?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim vn = tVchNo.Text.Trim()
        Try
            BeginTransaction()
            ' Restore TAG_STOCK from deleted SL_DETL items
            Dim dtRestk = FillTable($"SELECT * FROM SL_DETL WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
            ' Log to DELETE_DATA
            ExecNonQuery($"INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,BOOK_NAME,AC_CODE,DELETE_USER) " &
                         $"SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,GETDATE(),'SL','SALES',AC_CODE,'{gMainUser}' FROM SL_DATA " &
                         $"WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
            ExecNonQuery($"DELETE FROM SL_DATA  WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
            ExecNonQuery($"DELETE FROM SL_DETL  WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
            ExecNonQuery($"DELETE FROM AC_DATA  WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
            ExecNonQuery($"DELETE FROM MAIN_STOCK WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
            ExecNonQuery($"DELETE FROM TAX_DATA WHERE CO_CODE='{gCoCode}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vn}'")
            CommitTransaction()
            MsgBox("Deleted successfully.")
            LoadNewVoucher()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ── LOAD existing voucher ─────────────────────────────
    Public Sub LoadVoucher(vchNo As String)
        Dim dt = FillTable($"SELECT * FROM SL_DATA WHERE CO_CODE='{gCoCode}' AND LC_CODE='{gLcCode}' AND CO_YEAR='{gCoYear}' AND CO_BOOK='{_coBook}' AND VCH_NO='{vchNo}'")
        If dt.Rows.Count = 0 Then MsgBox("Voucher not found.") : Return
        Dim r = dt.Rows(0)
        _isNew = False
        tVchNo.Text    = vchNo
        tVchDate.Value = CDate(r("VCH_DATE"))
        cboAcCode.Text = r("AC_CODE").ToString().Trim()
        tAcName.Text   = r("AC_NAME").ToString().Trim()
        tNetAmt.Text   = Fmt3(r("NET_AMT"))
        tDiscPrc.Text  = Fmt2(r("DISC_PRC"))
        tDiscAmt.Text  = Fmt2(r("DISC_AMT"))
        tTaxCode.Text  = r("TAX_CODE").ToString().Trim()
        tTaxPrc.Text   = Fmt2(r("TAX_PRC"))
        tTaxAmt.Text   = Fmt2(r("TAX_AMT"))
        tRofAmt.Text   = Fmt2(r("ROF_AMT"))
        tTotAmt.Text   = Fmt2(r("TOT_AMT"))
        tCashAmt.Text  = Fmt2(r("CASH_AMT"))
        tCardAmt.Text  = Fmt2(r("CARD_AMT"))
        tChqAmt.Text   = Fmt2(r("CHQ_AMT"))
        tBillOs.Text   = Fmt2(r("BILL_OS"))
        tIgstTax.Text  = Fmt2(r("IGST_TAX"))
        tCgstTax.Text  = Fmt2(r("CGST_TAX"))
        tSgstTax.Text  = Fmt2(r("SGST_TAX"))
        If dt.Columns.Contains("IRN_NO") Then tIrnNo.Text = r("IRN_NO").ToString().Trim()
        If dt.Columns.Contains("ACK_NO") Then tAckNo.Text = r("ACK_NO").ToString().Trim()
        ' Load detail lines
        Dim dtd = FillTable($"SELECT D.*,M.IT_NAME FROM SL_DETL D LEFT JOIN ITEM_MAST M ON D.CO_CODE=M.CO_CODE AND D.IT_CODE=M.IT_CODE WHERE D.CO_CODE='{gCoCode}' AND D.LC_CODE='{gLcCode}' AND D.CO_YEAR='{gCoYear}' AND D.CO_BOOK='{_coBook}' AND D.VCH_NO='{vchNo}' ORDER BY D.SR_NO")
        _dtItems.Clear()
        For Each dr As DataRow In dtd.Rows
            Dim nr = _dtItems.NewRow()
            For Each dc As DataColumn In _dtItems.Columns
                If dtd.Columns.Contains(dc.ColumnName) Then nr(dc.ColumnName) = dr(dc.ColumnName)
            Next
            _dtItems.Rows.Add(nr)
        Next
    End Sub

    ' ── Print ─────────────────────────────────────────────
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        ' Launch Crystal Report: ItemSalesVch.rpt
        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        rpt.Load(Application.StartupPath & "\Reports\ItemSalesVch.rpt")
        rpt.SetDatabaseLogon("", "", My.Settings.ServerName, My.Settings.DatabaseName)
        rpt.SetParameterValue("CO_CODE", gCoCode)
        rpt.SetParameterValue("LC_CODE", gLcCode)
        rpt.SetParameterValue("CO_YEAR", gCoYear)
        rpt.SetParameterValue("CO_BOOK", _coBook)
        rpt.SetParameterValue("VCH_NO",  tVchNo.Text.Trim())
        Dim viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        viewer.ReportSource = rpt
        Dim frmPrint As New Form() With {.Text="Sales Bill Print", .Width=900, .Height=700}
        viewer.Dock = DockStyle.Fill
        frmPrint.Controls.Add(viewer)
        frmPrint.ShowDialog()
    End Sub

    ' ── KeyDown shortcuts ──────────────────────────────────
    Private Sub TR_SALE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2    : BtnSave.PerformClick()
            Case Keys.F3    : BtnDelete.PerformClick()
            Case Keys.F5    : BtnPrint.PerformClick()
            Case Keys.Escape: Me.Close()
        End Select
    End Sub

    Private Sub InitGrid()
        DgvItems = New DataGridView() With {.Dock = DockStyle.Bottom, .Height = 300, .AllowUserToAddRows = True}
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        LoadNewVoucher()
    End Sub
End Class
