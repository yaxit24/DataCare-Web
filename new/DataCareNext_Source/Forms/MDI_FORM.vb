' ==============================================================
' DataCareNext - MDI_FORM : Main Application Shell
' ==============================================================
Public Class MDI_FORM
    Inherits Form

    ' ── Menu strip ────────────────────────────────────────
    Private WithEvents mnuMain   As New MenuStrip()

    ' ── Master menu ───────────────────────────────────────
    Private mnuMaster    As ToolStripMenuItem
    Private mnuAcMast    As ToolStripMenuItem
    Private mnuItemMast  As ToolStripMenuItem
    Private mnuGroupMast As ToolStripMenuItem
    Private mnuRateMast  As ToolStripMenuItem
    Private mnuEmpMast   As ToolStripMenuItem
    Private mnuCompany   As ToolStripMenuItem
    Private mnuUser      As ToolStripMenuItem
    Private mnuBookMast  As ToolStripMenuItem

    ' ── Transaction menu ──────────────────────────────────
    Private mnuTrans     As ToolStripMenuItem
    Private mnuSale      As ToolStripMenuItem
    Private mnuSaleRtn   As ToolStripMenuItem
    Private mnuPurc      As ToolStripMenuItem
    Private mnuCash      As ToolStripMenuItem
    Private mnuContra    As ToolStripMenuItem
    Private mnuKrIsu     As ToolStripMenuItem
    Private mnuKrRec     As ToolStripMenuItem
    Private mnuAprIsu    As ToolStripMenuItem
    Private mnuInOut     As ToolStripMenuItem
    Private mnuMfgTag    As ToolStripMenuItem
    Private mnuDhrnIsu   As ToolStripMenuItem
    Private mnuDhrnRec   As ToolStripMenuItem
    Private mnuSaleOrd   As ToolStripMenuItem
    Private mnuBulSale   As ToolStripMenuItem
    Private mnuFineSlPr  As ToolStripMenuItem
    Private mnuRepRec    As ToolStripMenuItem
    Private mnuLedrAdj   As ToolStripMenuItem
    Private mnuMembEnt   As ToolStripMenuItem
    Private mnuPhyStkEntr As ToolStripMenuItem
    Private mnuTagGen    As ToolStripMenuItem
    Private mnuTagCancel As ToolStripMenuItem
    Private mnuTagSplit  As ToolStripMenuItem
    Private mnuWhSale    As ToolStripMenuItem
    Private mnuEInvoice  As ToolStripMenuItem
    Private mnuCardRec   As ToolStripMenuItem
    Private mnuUpiRec    As ToolStripMenuItem

    ' ── Report menu ───────────────────────────────────────
    Private mnuReports   As ToolStripMenuItem
    Private mnuRojmel    As ToolStripMenuItem
    Private mnuLedr      As ToolStripMenuItem
    Private mnuOS        As ToolStripMenuItem
    Private mnuStock     As ToolStripMenuItem
    Private mnuTagStock  As ToolStripMenuItem
    Private mnuSaleRpt   As ToolStripMenuItem
    Private mnuPurcRpt   As ToolStripMenuItem
    Private mnuGST       As ToolStripMenuItem
    Private mnuBalance   As ToolStripMenuItem
    Private mnuMfgRpt    As ToolStripMenuItem
    Private mnuDhrnRpt   As ToolStripMenuItem
    Private mnuCashBank  As ToolStripMenuItem
    Private mnuMovement  As ToolStripMenuItem
    Private mnuTagRpt    As ToolStripMenuItem
    Private mnuOrderRpt  As ToolStripMenuItem
    Private mnuPhyStkRpt As ToolStripMenuItem
    Private mnuConsiApr  As ToolStripMenuItem
    Private mnuBillProfit As ToolStripMenuItem
    Private mnuEmpRpt    As ToolStripMenuItem

    ' ── Utility menu ──────────────────────────────────────
    Private mnuUtil      As ToolStripMenuItem
    Private mnuBackup    As ToolStripMenuItem
    Private mnuSetting   As ToolStripMenuItem
    Private mnuImport    As ToolStripMenuItem
    Private mnuExport    As ToolStripMenuItem
    Private mnuTagPrint  As ToolStripMenuItem
    Private mnuEInvUtil  As ToolStripMenuItem
    Private mnuSmsSetup  As ToolStripMenuItem
    Private mnuWappUtil  As ToolStripMenuItem
    Private mnuReminder  As ToolStripMenuItem
    Private mnuTasting   As ToolStripMenuItem
    Private mnuVchReNum  As ToolStripMenuItem
    Private mnuBankRec   As ToolStripMenuItem
    Private mnuExit      As ToolStripMenuItem

    ' ── Status bar ─────────────────────────────────────────
    Private WithEvents sBar As New StatusStrip()
    Private lblUser    As New ToolStripStatusLabel()
    Private lblLoc     As New ToolStripStatusLabel()
    Private lblDate    As New ToolStripStatusLabel()
    Private lblGoldRt  As New ToolStripStatusLabel()
    Private lblSilvRt  As New ToolStripStatusLabel()

    Public Sub New()
        Me.Text            = "DataCareNext – Jewelry Management System"
        Me.IsMdiContainer  = True
        Me.WindowState     = FormWindowState.Maximized
        Me.KeyPreview      = True
        BuildMenus()
        BuildStatusBar()
    End Sub

    Private Sub BuildMenus()
        ' ── Master ─────────────────────────────────────────
        mnuMaster    = New ToolStripMenuItem("Master")
        mnuAcMast    = New ToolStripMenuItem("Account Master",      Nothing, AddressOf OpenMS_ACCT)
        mnuItemMast  = New ToolStripMenuItem("Item Master",         Nothing, AddressOf OpenMS_ITEM)
        mnuGroupMast = New ToolStripMenuItem("Group Master",        Nothing, AddressOf OpenMS_GROUP)
        mnuRateMast  = New ToolStripMenuItem("Rate Master",         Nothing, AddressOf OpenMS_RATE)
        mnuEmpMast   = New ToolStripMenuItem("Employee Master",     Nothing, AddressOf OpenMS_EMP)
        mnuBookMast  = New ToolStripMenuItem("Book Master",         Nothing, AddressOf OpenMS_BOOK)
        mnuCompany   = New ToolStripMenuItem("Company Settings",    Nothing, AddressOf OpenMS_COMPANY)
        mnuUser      = New ToolStripMenuItem("User Management",     Nothing, AddressOf OpenMS_USER)
        mnuMaster.DropDownItems.AddRange({mnuAcMast, mnuItemMast, mnuGroupMast, mnuRateMast,
                                          mnuEmpMast, mnuBookMast, New ToolStripSeparator(), mnuCompany, mnuUser})

        ' ── Transactions ───────────────────────────────────
        mnuTrans    = New ToolStripMenuItem("Transactions")
        mnuSale     = New ToolStripMenuItem("Sales Bill",          Nothing, AddressOf OpenTR_SALE)
        mnuSaleRtn  = New ToolStripMenuItem("Sales Return",        Nothing, AddressOf OpenTR_SALE_RTN)
        mnuPurc     = New ToolStripMenuItem("Purchase Bill",       Nothing, AddressOf OpenTR_PURC)
        mnuCash     = New ToolStripMenuItem("Cash Voucher",        Nothing, AddressOf OpenTR_CASH)
        mnuContra   = New ToolStripMenuItem("Contra Voucher",      Nothing, AddressOf OpenTR_CONTRA)
        mnuKrIsu    = New ToolStripMenuItem("Karigar Issue",       Nothing, AddressOf OpenTR_KR_ISU)
        mnuAprIsu   = New ToolStripMenuItem("Approval Issue",      Nothing, AddressOf OpenTR_APR_ISU)
        mnuInOut    = New ToolStripMenuItem("Stock In/Out",        Nothing, AddressOf OpenTR_INOUT)
        mnuTagGen   = New ToolStripMenuItem("Tag Generation",      Nothing, AddressOf OpenTR_MFG_ITEM)
        mnuTagCancel= New ToolStripMenuItem("Tag Cancellation",    Nothing, AddressOf OpenTR_TAG_CAN)
        mnuTagSplit = New ToolStripMenuItem("Tag Split",           Nothing, AddressOf OpenTR_TAG_SPLIT)
        mnuDhrnIsu  = New ToolStripMenuItem("Dhiran Issue (Loan)", Nothing, AddressOf OpenTR_DHRN_ISU)
        mnuDhrnRec  = New ToolStripMenuItem("Dhiran Receipt",      Nothing, AddressOf OpenTR_DHRN_REC)
        mnuSaleOrd  = New ToolStripMenuItem("Sales Order",         Nothing, AddressOf OpenTR_SALE_ORD)
        mnuBulSale  = New ToolStripMenuItem("Bullion Sale",        Nothing, AddressOf OpenTR_BUL_SALE)
        mnuFineSlPr = New ToolStripMenuItem("Fine Sale/Purchase",  Nothing, AddressOf OpenTR_FINE_SL_PR)
        mnuRepRec   = New ToolStripMenuItem("Repair Receipt",      Nothing, AddressOf OpenTR_REP_REC)
        mnuLedrAdj  = New ToolStripMenuItem("Ledger Adjustment",   Nothing, AddressOf OpenTR_LEDR_ADJ)
        mnuMembEnt  = New ToolStripMenuItem("Member Entry",        Nothing, AddressOf OpenTR_MEMB_ENT)
        mnuPhyStkEntr=New ToolStripMenuItem("Physical Stock",      Nothing, AddressOf OpenTR_PHYSTK)
        mnuWhSale   = New ToolStripMenuItem("Wholesale Sale",      Nothing, AddressOf OpenTR_WH_SALE)
        mnuEInvoice = New ToolStripMenuItem("E-Invoice Bill",      Nothing, AddressOf OpenTR_SL_EBILL)
        mnuCardRec  = New ToolStripMenuItem("Card Receipt",        Nothing, AddressOf OpenTR_CARD_REC)
        mnuUpiRec   = New ToolStripMenuItem("UPI Receipt",         Nothing, AddressOf OpenTR_UPI_REC)
        mnuTrans.DropDownItems.AddRange({mnuSale, mnuSaleRtn, mnuPurc, New ToolStripSeparator(),
                                         mnuCash, mnuContra, mnuCardRec, mnuUpiRec, New ToolStripSeparator(),
                                         mnuKrIsu, mnuAprIsu, mnuInOut, New ToolStripSeparator(),
                                         mnuTagGen, mnuTagCancel, mnuTagSplit, New ToolStripSeparator(),
                                         mnuDhrnIsu, mnuDhrnRec, New ToolStripSeparator(),
                                         mnuSaleOrd, mnuBulSale, mnuFineSlPr, mnuRepRec,
                                         mnuLedrAdj, mnuMembEnt, mnuPhyStkEntr,
                                         mnuWhSale, mnuEInvoice})

        ' ── Reports ────────────────────────────────────────
        mnuReports  = New ToolStripMenuItem("Reports")
        mnuRojmel   = New ToolStripMenuItem("Day Book (Rojmel)",   Nothing, AddressOf OpenRP_ROJMEL)
        mnuLedr     = New ToolStripMenuItem("Ledger Report",       Nothing, AddressOf OpenRP_LEDR)
        mnuOS       = New ToolStripMenuItem("Outstanding Report",  Nothing, AddressOf OpenRP_OS)
        mnuStock    = New ToolStripMenuItem("Stock Report",        Nothing, AddressOf OpenRP_STOCK)
        mnuTagStock = New ToolStripMenuItem("Tag Stock",           Nothing, AddressOf OpenRP_TAG)
        mnuSaleRpt  = New ToolStripMenuItem("Sales Report",        Nothing, AddressOf OpenRP_ALL)
        mnuPurcRpt  = New ToolStripMenuItem("Purchase Report",     Nothing, AddressOf OpenRP_ALL)
        mnuGST      = New ToolStripMenuItem("GST Report",          Nothing, AddressOf OpenRP_GST)
        mnuBalance  = New ToolStripMenuItem("Trial Balance",       Nothing, AddressOf OpenRP_BALANCE)
        mnuMfgRpt   = New ToolStripMenuItem("Mfg Report",          Nothing, AddressOf OpenRP_MFG)
        mnuDhrnRpt  = New ToolStripMenuItem("Dhiran Loan Rpt",     Nothing, AddressOf OpenRP_DHRN_LOAN)
        mnuCashBank = New ToolStripMenuItem("Cash & Bank Book",    Nothing, AddressOf OpenRP_CASH_BANK)
        mnuMovement = New ToolStripMenuItem("Stock Movement",      Nothing, AddressOf OpenRP_MOVEMENT)
        mnuTagRpt   = New ToolStripMenuItem("Tag Report",          Nothing, AddressOf OpenRP_TAG)
        mnuOrderRpt = New ToolStripMenuItem("Order Report",        Nothing, AddressOf OpenRP_ORDER)
        mnuBillProfit=New ToolStripMenuItem("Bill Profit",         Nothing, AddressOf OpenRP_BILL_PROFIT)
        mnuReports.DropDownItems.AddRange({mnuRojmel, mnuLedr, mnuOS, New ToolStripSeparator(),
                                           mnuStock, mnuTagStock, mnuMovement, New ToolStripSeparator(),
                                           mnuSaleRpt, mnuPurcRpt, mnuGST, New ToolStripSeparator(),
                                           mnuBalance, mnuMfgRpt, mnuDhrnRpt, mnuCashBank,
                                           mnuOrderRpt, mnuBillProfit})

        ' ── Utilities ──────────────────────────────────────
        mnuUtil     = New ToolStripMenuItem("Utilities")
        mnuBackup   = New ToolStripMenuItem("Backup Database",     Nothing, AddressOf OpenUT_BKP)
        mnuSetting  = New ToolStripMenuItem("Settings",            Nothing, AddressOf OpenUT_SETTING)
        mnuTagPrint = New ToolStripMenuItem("Tag Label Print",     Nothing, AddressOf OpenUT_TAG_PRINT)
        mnuEInvUtil = New ToolStripMenuItem("E-Invoice Portal",    Nothing, AddressOf OpenUT_E_INVOICE)
        mnuSmsSetup = New ToolStripMenuItem("SMS Settings",        Nothing, AddressOf OpenUT_SMS)
        mnuWappUtil = New ToolStripMenuItem("WhatsApp Setup",      Nothing, AddressOf OpenUT_WAPP)
        mnuReminder = New ToolStripMenuItem("Reminders",           Nothing, AddressOf OpenUT_REMINDER)
        mnuBankRec  = New ToolStripMenuItem("Bank Reconciliation", Nothing, AddressOf OpenUT_BANK)
        mnuVchReNum = New ToolStripMenuItem("Voucher Renumber",    Nothing, AddressOf OpenUT_VCH_RENUM)
        mnuExport   = New ToolStripMenuItem("Export Data",         Nothing, AddressOf OpenUT_EXPORT)
        mnuImport   = New ToolStripMenuItem("Import Data",         Nothing, AddressOf OpenUT_IMPORT)
        mnuExit     = New ToolStripMenuItem("Exit",                Nothing, AddressOf AppExit)
        mnuUtil.DropDownItems.AddRange({mnuBackup, mnuSetting, New ToolStripSeparator(),
                                        mnuTagPrint, mnuEInvUtil, New ToolStripSeparator(),
                                        mnuSmsSetup, mnuWappUtil, mnuReminder, mnuBankRec,
                                        mnuVchReNum, mnuExport, mnuImport, New ToolStripSeparator(), mnuExit})

        mnuMain.Items.AddRange({mnuMaster, mnuTrans, mnuReports, mnuUtil})
        Me.Controls.Add(mnuMain)
        Me.MainMenuStrip = mnuMain
    End Sub

    Private Sub BuildStatusBar()
        lblUser   = New ToolStripStatusLabel($"User: {gMainUser}")
        lblLoc    = New ToolStripStatusLabel($"Loc: {gLcCode}")
        lblDate   = New ToolStripStatusLabel($"Year: {gCoYear}")
        lblGoldRt = New ToolStripStatusLabel("Gold: --")
        lblSilvRt = New ToolStripStatusLabel("Silver: --")
        sBar.Items.AddRange({lblUser, New ToolStripSeparator(), lblLoc,
                              New ToolStripSeparator(), lblDate,
                              New ToolStripSeparator(), lblGoldRt,
                              New ToolStripSeparator(), lblSilvRt})
        Me.Controls.Add(sBar)
    End Sub

    Private Sub MDI_FORM_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshRates()
        lblUser.Text = $"User: {gMainUser}  |  {gCoName}"
        lblLoc.Text  = $"Loc: {gLcCode}"
        lblDate.Text = $"Year: {gCoYear}"
    End Sub

    Private Sub RefreshRates()
        Dim gr As Decimal = GetCurrentRate(gCoCode, gLcCode, "001")
        Dim sr As Decimal = GetCurrentRate(gCoCode, gLcCode, "002")
        gGoldRate   = gr : gSilverRate = sr
        lblGoldRt.Text = $"Gold: ₹{gr:N2}/g"
        lblSilvRt.Text = $"Silver: ₹{sr:N2}/g"
    End Sub

    ' ── MDI child opener helper ─────────────────────────────
    Private Sub OpenChild(frm As Form)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    ' ── Master openers ─────────────────────────────────────
    Private Sub OpenMS_ACCT(s As Object, e As EventArgs)    : OpenChild(New MS_ACCT())    : End Sub
    Private Sub OpenMS_ITEM(s As Object, e As EventArgs)    : OpenChild(New MS_ITEM())    : End Sub
    Private Sub OpenMS_GROUP(s As Object, e As EventArgs)   : OpenChild(New MS_GROUP())   : End Sub
    Private Sub OpenMS_RATE(s As Object, e As EventArgs)    : OpenChild(New MS_RATE())    : End Sub
    Private Sub OpenMS_EMP(s As Object, e As EventArgs)     : OpenChild(New MS_EMP())     : End Sub
    Private Sub OpenMS_BOOK(s As Object, e As EventArgs)    : OpenChild(New MS_BOOK())    : End Sub
    Private Sub OpenMS_COMPANY(s As Object, e As EventArgs) : OpenChild(New MS_COMPANY()) : End Sub
    Private Sub OpenMS_USER(s As Object, e As EventArgs)    : OpenChild(New MS_USER())    : End Sub

    ' ── Transaction openers ─────────────────────────────────
    Private Sub OpenTR_SALE(s As Object, e As EventArgs)       : OpenChild(New TR_SALE())       : End Sub
    Private Sub OpenTR_SALE_RTN(s As Object, e As EventArgs)   : OpenChild(New TR_SALE_RTN())   : End Sub
    Private Sub OpenTR_PURC(s As Object, e As EventArgs)       : OpenChild(New TR_PURC())       : End Sub
    Private Sub OpenTR_CASH(s As Object, e As EventArgs)       : OpenChild(New TR_CASH())       : End Sub
    Private Sub OpenTR_CONTRA(s As Object, e As EventArgs)     : OpenChild(New TR_CONTRA())     : End Sub
    Private Sub OpenTR_KR_ISU(s As Object, e As EventArgs)     : OpenChild(New TR_KR_ISU())     : End Sub
    Private Sub OpenTR_APR_ISU(s As Object, e As EventArgs)    : OpenChild(New TR_APR_ISU())    : End Sub
    Private Sub OpenTR_INOUT(s As Object, e As EventArgs)      : OpenChild(New TR_INOUT())      : End Sub
    Private Sub OpenTR_MFG_ITEM(s As Object, e As EventArgs)   : OpenChild(New TR_MFG_ITEM())   : End Sub
    Private Sub OpenTR_TAG_CAN(s As Object, e As EventArgs)    : OpenChild(New TR_TAG_CAN())    : End Sub
    Private Sub OpenTR_TAG_SPLIT(s As Object, e As EventArgs)  : OpenChild(New TR_TAG_SPLIT())  : End Sub
    Private Sub OpenTR_DHRN_ISU(s As Object, e As EventArgs)   : OpenChild(New TR_DHRN_ISU())   : End Sub
    Private Sub OpenTR_DHRN_REC(s As Object, e As EventArgs)   : OpenChild(New TR_DHRN_REC())   : End Sub
    Private Sub OpenTR_SALE_ORD(s As Object, e As EventArgs)   : OpenChild(New TR_SALE_ORD())   : End Sub
    Private Sub OpenTR_BUL_SALE(s As Object, e As EventArgs)   : OpenChild(New TR_BUL_SALE())   : End Sub
    Private Sub OpenTR_FINE_SL_PR(s As Object, e As EventArgs) : OpenChild(New TR_FINE_SL_PR()) : End Sub
    Private Sub OpenTR_REP_REC(s As Object, e As EventArgs)    : OpenChild(New TR_REP_REC())    : End Sub
    Private Sub OpenTR_LEDR_ADJ(s As Object, e As EventArgs)   : OpenChild(New TR_LEDR_ADJ())   : End Sub
    Private Sub OpenTR_MEMB_ENT(s As Object, e As EventArgs)   : OpenChild(New TR_MEMB_ENT())   : End Sub
    Private Sub OpenTR_PHYSTK(s As Object, e As EventArgs)     : OpenChild(New TR_PHYSTK())     : End Sub
    Private Sub OpenTR_WH_SALE(s As Object, e As EventArgs)    : OpenChild(New TR_WH_SALE())    : End Sub
    Private Sub OpenTR_SL_EBILL(s As Object, e As EventArgs)   : OpenChild(New TR_SL_EBILL())   : End Sub
    Private Sub OpenTR_CARD_REC(s As Object, e As EventArgs)   : OpenChild(New TR_CARD_REC())   : End Sub
    Private Sub OpenTR_UPI_REC(s As Object, e As EventArgs)    : OpenChild(New TR_UPI_REC())    : End Sub

    ' ── Report openers ─────────────────────────────────────
    Private Sub OpenRP_ROJMEL(s As Object, e As EventArgs)     : OpenChild(New RP_ROJMEL())     : End Sub
    Private Sub OpenRP_LEDR(s As Object, e As EventArgs)       : OpenChild(New RP_LEDR())       : End Sub
    Private Sub OpenRP_OS(s As Object, e As EventArgs)         : OpenChild(New RP_OS())         : End Sub
    Private Sub OpenRP_STOCK(s As Object, e As EventArgs)      : OpenChild(New RP_STOCK())      : End Sub
    Private Sub OpenRP_ALL(s As Object, e As EventArgs)        : OpenChild(New RP_ALL())        : End Sub
    Private Sub OpenRP_GST(s As Object, e As EventArgs)        : OpenChild(New RP_GST())        : End Sub
    Private Sub OpenRP_BALANCE(s As Object, e As EventArgs)    : OpenChild(New RP_BALANCE())    : End Sub
    Private Sub OpenRP_MFG(s As Object, e As EventArgs)        : OpenChild(New RP_MFG())        : End Sub
    Private Sub OpenRP_DHRN_LOAN(s As Object, e As EventArgs)  : OpenChild(New RP_DHRN_LOAN())  : End Sub
    Private Sub OpenRP_CASH_BANK(s As Object, e As EventArgs)  : OpenChild(New RP_CASH_BANK())  : End Sub
    Private Sub OpenRP_MOVEMENT(s As Object, e As EventArgs)   : OpenChild(New RP_MOVEMENT())   : End Sub
    Private Sub OpenRP_TAG(s As Object, e As EventArgs)        : OpenChild(New RP_TAG())        : End Sub
    Private Sub OpenRP_ORDER(s As Object, e As EventArgs)      : OpenChild(New RP_ORDER())      : End Sub
    Private Sub OpenRP_BILL_PROFIT(s As Object, e As EventArgs): OpenChild(New RP_BILL_PROFIT()): End Sub

    ' ── Utility openers ─────────────────────────────────────
    Private Sub OpenUT_BKP(s As Object, e As EventArgs)       : OpenChild(New UT_BKP())       : End Sub
    Private Sub OpenUT_SETTING(s As Object, e As EventArgs)   : OpenChild(New UT_SETTING())   : End Sub
    Private Sub OpenUT_TAG_PRINT(s As Object, e As EventArgs) : OpenChild(New UT_TAG_PRINT()) : End Sub
    Private Sub OpenUT_E_INVOICE(s As Object, e As EventArgs) : OpenChild(New UT_E_INVOICE()) : End Sub
    Private Sub OpenUT_SMS(s As Object, e As EventArgs)       : OpenChild(New UT_SMS())       : End Sub
    Private Sub OpenUT_WAPP(s As Object, e As EventArgs)      : OpenChild(New UT_WAPP_WITH_API()) : End Sub
    Private Sub OpenUT_REMINDER(s As Object, e As EventArgs)  : OpenChild(New UT_REMINDER())  : End Sub
    Private Sub OpenUT_BANK(s As Object, e As EventArgs)      : OpenChild(New UT_BANK())      : End Sub
    Private Sub OpenUT_VCH_RENUM(s As Object, e As EventArgs) : OpenChild(New UT_VCH_RE_NUMBR()): End Sub
    Private Sub OpenUT_EXPORT(s As Object, e As EventArgs)    : OpenChild(New UT_EXPORT())    : End Sub
    Private Sub OpenUT_IMPORT(s As Object, e As EventArgs)    : OpenChild(New UT_IMPORT())    : End Sub
    Private Sub AppExit(s As Object, e As EventArgs)          : Application.Exit()            : End Sub
End Class
