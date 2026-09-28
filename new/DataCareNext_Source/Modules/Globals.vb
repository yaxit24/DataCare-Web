' =============================================================
' DataCareNext Jewelry ERP - Global Variables & Constants
' =============================================================
Module Globals
    ' ── Connection ─────────────────────────────────────────
    Public gConStr As String = ""
    Public gCon As System.Data.SqlClient.SqlConnection

    ' ── Company / Session ──────────────────────────────────
    Public gCoCode   As String = "01"
    Public gLcCode   As String = "00"
    Public gCoYear   As String = "2025-2026"
    Public gMainUser As String = ""
    Public gCoName   As String = ""
    Public gCoSname  As String = ""
    Public gCoAdd1   As String = ""
    Public gCoAdd2   As String = ""
    Public gCoAdd3   As String = ""
    Public gCoCity   As String = ""
    Public gCoState  As String = ""
    Public gCoPin    As String = ""
    Public gCoPhone  As String = ""
    Public gCoMobile As String = ""
    Public gCoGstNo  As String = ""
    Public gCoPanNo  As String = ""
    Public gCoMail   As String = ""
    Public gCoMsg    As String = ""

    ' ── Metal Types ────────────────────────────────────────
    Public Const METAL_GOLD   As String = "G"
    Public Const METAL_SILVER As String = "S"
    Public Const METAL_OTHER  As String = "O"

    ' ── Rate Types ─────────────────────────────────────────
    Public Const RATE_WEIGHT As String = "W"   ' per gram
    Public Const RATE_PIECE  As String = "P"   ' per piece

    ' ── Labour Types ───────────────────────────────────────
    Public Const LBR_PER_GRAM  As String = "G"
    Public Const LBR_PER_PIECE As String = "P"
    Public Const LBR_FIXED     As String = "F"

    ' ── GST Types ──────────────────────────────────────────
    Public Const GST_IGST  As String = "I"   ' Inter-state
    Public Const GST_CGST  As String = "C"   ' Intra-state (CGST+SGST)

    ' ── Sign ───────────────────────────────────────────────
    Public Const SIGN_IN  As String = "+"
    Public Const SIGN_OUT As String = "-"

    ' ── Inout Types ────────────────────────────────────────
    Public Const INOUT_IN  As String = "I"
    Public Const INOUT_OUT As String = "O"

    ' ── Settings (CO_SET) ──────────────────────────────────
    Public gTagRpt          As String = "N"
    Public gFineStockType   As String = "N"   ' F=fine based stock
    Public gSlAmtType       As String = "N"
    Public gDupPrint        As String = "N"
    Public gTaxCode         As String = "10"
    Public gDhrnIntType     As String = "M"   ' M=monthly, D=daily
    Public gSlRowChange     As String = "N"
    Public gGridScroll      As String = "N"
    Public gLdrSumm         As String = "N"
    Public gSmsLink         As String = ""
    Public gAdminSms        As String = "N"
    Public gCustSms         As String = "N"
    Public gWeightPort      As String = ""
    Public gCashLimit       As Decimal = 200000
    Public gPanCardVal      As String = "N"
    Public gWappApi         As String = "N"
    Public gWappApiMobile   As String = ""
    Public gTileMenu        As String = "N"
    Public gCrystalRpt      As String = "N"
    Public gFontSize        As Integer = 9
    Public gFontName        As String = "Tahoma"

    ' ── Current Rate ───────────────────────────────────────
    Public gGoldRate   As Decimal = 0
    Public gSilverRate As Decimal = 0

    ' ── Lock Date ──────────────────────────────────────────
    Public gLockDate As Date = Date.MinValue

    ' ── User Rights ────────────────────────────────────────
    Public gUserCanUpdate As Boolean = True
    Public gUserCanDelete As Boolean = True
    Public gUserCanPrint  As Boolean = True

    ' ── Book Codes (loaded from BOOK_DATA) ─────────────────
    Public gSaleBookCode  As String = ""
    Public gPurcBookCode  As String = ""
    Public gCashPayCode   As String = ""
    Public gCashRecCode   As String = ""

    ' ── Financial Year Boundaries ──────────────────────────
    Public gYearFrom As Date
    Public gYearTo   As Date

    ' ── Format helpers ─────────────────────────────────────
    Public Function Fmt3(v As Object) As String
        Return CDec(v).ToString("N3")
    End Function
    Public Function Fmt2(v As Object) As String
        Return CDec(v).ToString("N2")
    End Function
    Public Function FmtDate(d As Date) As String
        Return d.ToString("dd/MM/yyyy")
    End Function
    Public Function SqlDate(d As Date) As String
        Return d.ToString("MM/dd/yyyy")
    End Function
    Public Function EmptyToZero(v As String) As Decimal
        If String.IsNullOrEmpty(v.Trim) Then Return 0
        Dim r As Decimal = 0
        Decimal.TryParse(v, r)
        Return r
    End Function
End Module
