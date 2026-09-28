' =============================================================
' DataCareNext - Database Helper Module
' =============================================================
Imports System.Data.SqlClient

Module Database

    Private _con As SqlConnection

    ' ── Open connection ────────────────────────────────────
    Public Function GetConnection() As SqlConnection
        If _con Is Nothing OrElse _con.State <> ConnectionState.Open Then
            _con = New SqlConnection(My.Settings.ConnectionString)
            _con.Open()
        End If
        Return _con
    End Function

    Public Sub CloseConnection()
        If _con IsNot Nothing AndAlso _con.State = ConnectionState.Open Then
            _con.Close()
        End If
    End Sub

    ' ── Execute scalar ─────────────────────────────────────
    Public Function ExecScalar(sql As String) As Object
        Using cmd As New SqlCommand(sql, GetConnection())
            If _tx IsNot Nothing Then cmd.Transaction = _tx
            Return cmd.ExecuteScalar()
        End Using
    End Function

    ' ── Execute non-query ──────────────────────────────────
    Public Function ExecNonQuery(sql As String) As Integer
        Using cmd As New SqlCommand(sql, GetConnection())
            If _tx IsNot Nothing Then cmd.Transaction = _tx
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    ' ── Fill DataTable ─────────────────────────────────────
    Public Function FillTable(sql As String) As DataTable
        Dim dt As New DataTable()
        Using cmd As New SqlCommand(sql, GetConnection())
            If _tx IsNot Nothing Then cmd.Transaction = _tx
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' ── Fill DataTable with parameters ─────────────────────
    Public Function FillTableParm(sql As String, parms As Dictionary(Of String, Object)) As DataTable
        Dim dt As New DataTable()
        Using cmd As New SqlCommand(sql, GetConnection())
            If _tx IsNot Nothing Then cmd.Transaction = _tx
            For Each kv In parms
                cmd.Parameters.AddWithValue(kv.Key, If(kv.Value Is Nothing, DBNull.Value, kv.Value))
            Next
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' ── Get next voucher number ─────────────────────────────
    Public Function GetNextVchNo(coCode As String, lcCode As String, coYear As String, coBook As String) As String
        Dim sql As String = $"SELECT MAX(CAST(VCH_NO AS INT)) FROM AC_DATA WHERE CO_CODE='{coCode}' AND LC_CODE='{lcCode}' AND CO_YEAR='{coYear}' AND CO_BOOK='{coBook}'"
        Dim v As Object = ExecScalar(sql)
        Dim n As Integer = If(v Is DBNull.Value OrElse v Is Nothing, 0, CInt(v))
        Return (n + 1).ToString("D8")
    End Function

    ' ── Check if record exists ─────────────────────────────
    Public Function RecordExists(sql As String) As Boolean
        Dim v As Object = ExecScalar(sql)
        Return v IsNot Nothing AndAlso v IsNot DBNull.Value
    End Function

    ' ── Get lookup value ───────────────────────────────────
    Public Function GetValue(table As String, col As String, where As String) As String
        Dim sql As String = $"SELECT {col} FROM {table} WHERE {where}"
        Dim v As Object = ExecScalar(sql)
        Return If(v Is Nothing OrElse v Is DBNull.Value, "", v.ToString().Trim())
    End Function

    ' ── Get gold rate ──────────────────────────────────────
    Public Function GetCurrentRate(coCode As String, lcCode As String, grCode As String) As Decimal
        Dim sql As String = $"SELECT TOP 1 GR_RATE FROM RATE_MAST WHERE CO_CODE='{coCode}' AND LC_CODE='{lcCode}' AND GR_CODE='{grCode}' ORDER BY VCH_DATE DESC, SR_NO DESC"
        Dim v As Object = ExecScalar(sql)
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return CDec(v)
    End Function

    ' ── Get account name ───────────────────────────────────
    Public Function GetAcName(coCode As String, acCode As String) As String
        Return GetValue("AC_MAST", "AC_NAME", $"CO_CODE='{coCode}' AND AC_CODE='{acCode}'")
    End Function

    ' ── Get item name ──────────────────────────────────────
    Public Function GetItemName(coCode As String, itCode As String) As String
        Return GetValue("ITEM_MAST", "IT_NAME", $"CO_CODE='{coCode}' AND IT_CODE='{itCode}'")
    End Function

    ' ── Transaction helpers ────────────────────────────────
    Private _tx As SqlTransaction

    Public Sub BeginTransaction()
        _tx = GetConnection().BeginTransaction()
    End Sub
    Public Sub CommitTransaction()
        _tx?.Commit()
        _tx = Nothing
    End Sub
    Public Sub RollbackTransaction()
        _tx?.Rollback()
        _tx = Nothing
    End Sub

    ' ── Load company settings ──────────────────────────────
    Public Sub LoadCompanySettings(coCode As String)
        Dim dt = FillTable($"SELECT * FROM CO_MAST WHERE CO_CODE='{coCode}'")
        If dt.Rows.Count = 0 Then Return
        Dim r = dt.Rows(0)
        gCoName   = r("CO_NAME").ToString().Trim()
        gCoSname  = r("CO_SNAME").ToString().Trim()
        gCoAdd1   = r("CO_ADD1").ToString().Trim()
        gCoAdd2   = r("CO_ADD2").ToString().Trim()
        gCoCity   = r("CO_CITY").ToString().Trim()
        gCoState  = r("CO_STATE").ToString().Trim()
        gCoGstNo  = r("CO_GST_NO").ToString().Trim()
        gCoPanNo  = r("CO_PAN_NO").ToString().Trim()
        gCoMail   = r("CO_MAIL").ToString().Trim()
        gCoMsg    = r("CO_MSG").ToString().Trim()

        Dim ds = FillTable($"SELECT * FROM CO_SET WHERE CO_CODE='{coCode}'")
        If ds.Rows.Count > 0 Then
            Dim s = ds.Rows(0)
            If ds.Columns.Contains("TAG_RPT")        Then gTagRpt        = s("TAG_RPT").ToString()
            If ds.Columns.Contains("FINE_STK_TYPE")  Then gFineStockType = s("FINE_STK_TYPE").ToString()
            If ds.Columns.Contains("CASH_LIMIT")     Then
                Dim cl As Decimal = 0
                Decimal.TryParse(s("CASH_LIMIT").ToString(), cl)
                gCashLimit = cl
            End If
            If ds.Columns.Contains("TAX_CODE")       Then gTaxCode      = s("TAX_CODE").ToString()
            If ds.Columns.Contains("SMS_LINK")        Then gSmsLink      = s("SMS_LINK").ToString()
            If ds.Columns.Contains("ADMIN_SMS")       Then gAdminSms     = s("ADMIN_SMS").ToString()
            If ds.Columns.Contains("CUST_SMS")        Then gCustSms      = s("CUST_SMS").ToString()
            If ds.Columns.Contains("WEIGHT_PORT")     Then gWeightPort   = s("WEIGHT_PORT").ToString()
        End If

        Dim dn = FillTable($"SELECT * FROM CO_SET_NEW WHERE CO_CODE='{coCode}'")
        If dn.Rows.Count > 0 Then
            Dim n = dn.Rows(0)
            If dn.Columns.Contains("WAPP_API")        Then gWappApi       = n("WAPP_API").ToString()
            If dn.Columns.Contains("WAPP_API_MOBILE") Then gWappApiMobile = n("WAPP_API_MOBILE").ToString()
            If dn.Columns.Contains("TILE_MENU")       Then gTileMenu      = n("TILE_MENU").ToString()
            If dn.Columns.Contains("CRYSTAL_RPT")     Then gCrystalRpt    = n("CRYSTAL_RPT").ToString()
            If dn.Columns.Contains("FONT_SIZE") Then
                Dim fs As Integer = 9
                Integer.TryParse(n("FONT_SIZE").ToString(), fs)
                gFontSize = fs
            End If
            If dn.Columns.Contains("FONT_NAME")       Then gFontName = n("FONT_NAME").ToString()
        End If
    End Sub
End Module
