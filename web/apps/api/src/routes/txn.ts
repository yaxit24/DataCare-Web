import { SessionReadSnapshotError } from '../modules/auth/sessionContextReadSnapshot.js';
import { isTransactionTimeout, withTxBudget } from '../modules/shared/txBudget.js';
import {
  getSaleReturnLabourReplayState,
  observeSaleReturnLabourReplayCode,
  previewSaleReturnLabourReplay,
  SaleReturnLabourReplayError,
} from '../modules/sales/saleReturnLabourReplay.js';
import { SessionCommandError } from '../modules/auth/sessionContextCommand.js';
import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { loadPrincipal, authorizeForm, FormForbiddenError } from '../modules/rbac/authorization.js';
import { requireImageVersion, ImageVersionConflictError } from '../modules/images/imageState.js';
import {
  getOrderImage,
  changeOrderImage,
  OrderImageError,
  type OrderImageFamily,
  type OrderImageScope,
} from '../modules/images/orderImage.js';
import {
  getMfgLotSettings,
  listMfgLots,
  getMfgLot,
  listMfgLotSources,
} from '../modules/manufacturing/mfgLot.js';
import { PasswordChangeError, resetUserPassword } from '../modules/auth/passwordAccount.js';
import { PasswordPolicyError } from '../modules/auth/password.js';
import {
  createSale,
  createSalesQuotation,
  deleteSale,
  deleteSalesQuotation,
  editSale,
  editSalesQuotation,
  getSale,
  getSalesQuotation,
} from '../modules/sales/sales.js';
import { computeLine as computeSaleLine } from '../modules/sales/sales.js';
import { billTotals } from '@datacare/core';
import {
  parityContainmentProblem,
  type ParityContainmentOperation,
} from '@datacare/core/containment';
import {
  createSaleReturn,
  deleteSaleReturn,
  getSaleReturn,
  saleForReturn,
} from '../modules/sales/salesReturn.js';
import {
  getSavedSaleReturnIncoming,
  listSavedSaleReturnIncoming,
  updateSavedSaleReturnMetadata,
  SavedSaleReturnError,
} from '../modules/sales/savedSaleReturn.js';
import { updateSaleReturnNumeric } from '../modules/sales/saleReturnNumericUpdate.js';
import {
  listSaleReturnSourceVouchers,
  getSaleReturnSourceItems,
  SaleReturnSourceError,
} from '../modules/sales/saleReturnSource.js';
import {
  getSaleReturnIncomingConfiguration,
  SaleReturnIncomingConfigurationError,
} from '../modules/sales/saleReturnIncomingConfiguration.js';
import {
  getSaleReturnIncomingReplayState,
  previewSaleReturnIncomingReplay,
  SaleReturnIncomingReplayError,
} from '../modules/sales/saleReturnIncomingReplay.js';
import {
  getSaleReturnBillReplayState,
  previewSaleReturnBillReplay,
  SaleReturnBillReplayError,
} from '../modules/sales/saleReturnBillReplay.js';
import {
  cancelSalesOrderInSession,
  cancelSalesOrderAdjust,
  cancelTourOrderInSession,
  getTourOrderConfiguration,
  getSalesOrderConfiguration,
  editSalesOrderInSession,
  createSalesOrderInSession,
  createTourOrderInSession,
  editTourOrderInSession,
  getSalesOrder,
  getSalesOrderAdjustment,
  getTourOrder,
  listSalesOrders,
  listTourOrders,
} from '../modules/sales/salesOrder.js';
import {
  createLabourInvoice,
  deleteLabourInvoice,
  getLabourInvoice,
} from '../modules/sales/labourInvoice.js';
import { invoiceData, invoiceHtml } from '../modules/sales/invoice.js';
import { orderData } from '../modules/sales/orderDoc.js';
import { SalesOrderWorkflowUnavailableError } from '../modules/sales/orderLifecyclePolicy.js';
import {
  listSalesOrderDesigns,
  getSalesOrderDesignImage,
  SalesOrderDesignError,
} from '../modules/sales/orderDesignSelection.js';
import { ORDER_REPORT_COPIES, type OrderReportCopy } from '../modules/reports/orderReportValues.js';
import { purchaseBillData, purchaseBillHtml } from '../modules/purchase/purchaseBill.js';
import { salesBillData, salesBillHtml } from '../modules/sales/salesBill.js';
import { sendVoucherDocument, resolvePrintScope } from '../modules/documents/voucherPrint.js';
import { karigarIssueData, karigarIssueHtml } from '../modules/manufacturing/karigarVoucher.js';
import { financeVoucherData, financeVoucherHtml } from '../modules/finance/financeVoucher.js';
import { dhrnIssueData, dhrnIssueHtml } from '../modules/dhrn/dhrnReceipt.js';
import {
  DocumentScopeError,
  documentCompanyTx,
  requireVoucherDocumentScope,
} from '../modules/documents/voucherDocument.js';
import { schemePassbookData, schemePassbookHtml } from '../modules/scheme/passbook.js';
import { renderGstr1Doc } from '../modules/gst/gstr1Doc.js';
import {
  renderTrialBalanceDoc,
  renderGstr3bDoc,
  renderBalanceSheetDoc,
  renderGstr2Doc,
} from '../modules/reports/statementDocs.js';
import {
  loadReportSpec,
  renderReportLayout,
  listReportSpecs,
} from '../modules/reports/reportEngine.js';
import { bindReport, UnsupportedReportBindingError } from '../modules/reports/reportBind.js';
import {
  loadFormLayout,
  renderFormLayout,
  listFormLayouts,
} from '../modules/forms/formLayoutEngine.js';
import { dhrnKhataData, dhrnKhataHtml } from '../modules/dhrn/dhrnKhata.js';
import { getSettings, saveSettings, SETTING_FIELDS } from '../modules/settings/settings.js';
import {
  createPurchase,
  createPurchaseQuotation,
  getPurchase,
  getPurchaseQuotation,
  editPurchase,
  editPurchaseQuotation,
  deletePurchase,
  deletePurchaseQuotation,
  listOpenConsignmentPurchaseReceipts,
} from '../modules/purchase/purchase.js';
import {
  createPurchaseReturn,
  purchaseReturnInputFromBody,
} from '../modules/purchase/purchaseReturn.js';
import {
  deletePurchaseReturn,
  editPurchaseReturn,
  getPurchaseReturn,
} from '../modules/purchase/purchaseReturnLifecycle.js';
import {
  postReceipt,
  postPayment,
  postContra,
  deleteContra,
  getContra,
  editContra,
  getReceipt,
  getPayment,
  deleteReceipt,
  deleteFinance,
  postReceiptLines,
  postPaymentLines,
  deleteReceiptLines,
  deletePaymentLines,
} from '../modules/finance/finance.js';
import { renderCheque } from '../modules/finance/chequePrint.js';
import {
  issueDhrn,
  receiveDhrn,
  receiveLoan,
  issueLoan,
  outstanding,
  receiveDhrnInterest,
} from '../modules/dhrn/dhrn.js';
import { fineInout, deleteFineInout } from '../modules/inout/fineInout.js';
import { listUsers, createUser, setUserRights } from '../modules/rbac/users.js';
import { getFormCatalog } from '../modules/rbac/formCatalog.js';
import { restoreCompany } from '../modules/ops/backup.js';
import type { MetricsRegistry } from '../modules/ops/metrics.js';
import { getUserFormRights, setUserFormRights } from '../modules/rbac/formRights.js';
import { partyBalance } from '../modules/finance/partyBalance.js';
import { bankReconList, bankReconClear } from '../modules/finance/bankRecon.js';
import { postDailyRate, getDailyRate, dailyRateDates } from '../modules/masters/dailyRate.js';
import { bulkAutoItem } from '../modules/masters/autoItem.js';
import {
  deleteDesignBook,
  getDesignCalculationConfig,
  getDesignComponentDefaults,
  listDesignBook,
  saveDesignBook,
} from '../modules/masters/designBook.js';
import {
  getCreditNote,
  getEInvoice,
  listCreditNotes,
  listEInvoices,
} from '../modules/einvoice/creditNote.js';
import {
  assertEBillNotRegistered,
  deleteEBill,
  eBillPrintData,
  eInvoiceTcsBasis,
  getEBillEntry,
  getEBillEntryConfig,
  saveEBill,
  type EBillFamily,
} from '../modules/einvoice/eBillWriter.js';
import {
  deleteDiamondSizes,
  deleteItemStockLimits,
  getDiamondSizes,
  getItemStockLimits,
  listDiamondSizeSummary,
  listItemStockLimitSummary,
  saveDiamondSizes,
  saveItemStockLimits,
} from '../modules/masters/stockLimit.js';
import {
  integrationReadiness,
  readinessSummary,
  verifyIntegrationCredentials,
} from '../modules/integrations/readiness.js';
import {
  parseScaleFrame,
  SCALE_DECIMAL_PLACES,
  SCALE_EXCLUDED_CHARACTERS,
  SCALE_FRAME_SCAN_LIMIT,
  SCALE_PORT_FRIENDLY_NAME,
  SCALE_PORT_PROFILES,
  SCALE_TARGET_GRID_COLUMN,
  scaleCaptureEnabled,
} from '../modules/integrations/scaleProtocol.js';
import {
  listPrintableTags,
  renderTagLabels,
  stageTagPrintRowsTx,
} from '../modules/stock/tagPrint.js';
import { tagStockReport, tagStockCsv } from '../modules/reports/tagStock.js';
import { recentVouchers } from '../modules/vouchers/list.js';
import { listYears, createYear, carryForwardOpenings } from '../modules/masters/year.js';
import { reminders } from '../modules/finance/reminders.js';
import { getOpeningBalance, setOpeningBalance } from '../modules/masters/openingBalance.js';
import { getPartyPhoto, setPartyPhoto, familyMembers } from '../modules/masters/party.js';
import {
  listLabourItems,
  applyLabourUpdate,
  getLabourSlabs,
  setLabourSlabs,
} from '../modules/masters/labourUpdate.js';
import { seedCompany } from '../modules/ops/seedCompany.js';
import { inferSheet, renderXlsx } from '../modules/reports/xlsx.js';
import {
  deleteEntityImage,
  getEntityImage,
  getEntityImageState,
  listEntityImageKeys,
  saveEntityImage,
} from '../modules/images/entityImage.js';
import {
  applyRepair,
  listRepairs,
  previewRepair,
  repairHistory,
} from '../modules/utilities/dataRepair.js';
import '../modules/utilities/dataRepairOps.js';
import {
  createReminderEntry,
  listReminderEntries,
  deleteReminderEntry,
} from '../modules/utilities/reminderEntry.js';
import { previewRenumber, applyRenumber } from '../modules/utilities/voucherRenumber.js';
import { dataRefresh } from '../modules/utilities/dataRefresh.js';
import {
  dataExportPackage,
  dataExportPendingOnly,
  dataExportPreview,
  markDataTransferFlags,
  resetDataTransferFlags,
} from '../modules/utilities/dataExport.js';
import { applyEstimateReset, estimateResetPreview } from '../modules/utilities/estimateReset.js';
import {
  deleteHddRegistry,
  getHddRegistry,
  listHddRegistry,
  saveHddRegistry,
} from '../modules/utilities/hddRegistry.js';
import {
  deleteUserRequest,
  getUserRequest,
  listUserRequests,
  saveUserRequest,
} from '../modules/utilities/userRequest.js';
import {
  getWindowTile,
  listWindowTiles,
  saveWindowTile,
} from '../modules/utilities/windowTiles.js';
import {
  monthlyPurchase,
  purchaseByParty,
  groupSummary,
  gstr2Purchase,
} from '../modules/reports/reports3.js';
import { postAcOpening, deleteAcOpening } from '../modules/finance/acOpening.js';
import { deleteFineJv, getFineJv, postFineJv } from '../modules/finance/fineJv.js';
import { deleteBillSettlement, listOpenBills, settleBills } from '../modules/finance/billToBill.js';
import {
  deleteBullionSale,
  deleteRateCut,
  deleteWholesaleSale,
  deleteWholesaleQuotation,
  editBullionSale,
  editRateCut,
  editWholesaleSale,
  editWholesaleQuotation,
  getBullionSale,
  getRateCut,
  getWholesaleSale,
  getWholesaleQuotation,
  postBullionSale,
  postRateCut,
  postWholesaleSale,
  postWholesaleQuotation,
} from '../modules/sales/rateCut.js';
import { wholesaleQuotationHtml } from '../modules/sales/wholesaleQuotationDocument.js';
import {
  issueKarigar,
  receiveKarigar,
  karigarMetalBalance,
  getKarigar,
  editKarigar,
  deleteKarigar,
  createOldItemSale,
  getOldItemSale,
  editOldItemSale,
  deleteOldItemSale,
} from '../modules/manufacturing/karigar.js';
import {
  issueMfg,
  receiveMfg,
  getMfg,
  editMfg,
  deleteMfg,
  requireMfgMainBook,
} from '../modules/manufacturing/mfg.js';
import {
  deleteMeltingPro,
  getMeltingPro,
  saveMeltingPro,
} from '../modules/manufacturing/meltingPro.js';
import {
  deleteCustomerRepairReceipt,
  getCustomerRepairReceipt,
  listCustomerRepairReceipts,
  saveCustomerRepairReceipt,
} from '../modules/repair/repairReceipt.js';
import {
  deleteKarigarRepairIssue,
  getKarigarRepairIssue,
  listKarigarRepairIssues,
  listOpenCustomerRepairLines,
  saveKarigarRepairIssue,
} from '../modules/repair/repairKarigarIssue.js';
import {
  customerRepairReceiptDocumentData,
  customerRepairReceiptHtml,
} from '../modules/repair/repairReceiptDoc.js';
import {
  karigarRepairIssueDocumentData,
  karigarRepairIssueHtml,
} from '../modules/repair/repairKarigarIssueDoc.js';
import {
  deleteKarigarRepairReceipt,
  getKarigarRepairReceipt,
  listKarigarRepairReceipts,
  listOpenKarigarRepairIssueLines,
  saveKarigarRepairReceipt,
} from '../modules/repair/repairKarigarReceipt.js';
import {
  karigarRepairReceiptDocumentData,
  karigarRepairReceiptHtml,
} from '../modules/repair/repairKarigarReceiptDoc.js';
import {
  deleteCustomerRepairIssue,
  getCustomerRepairIssue,
  listCustomerRepairIssues,
  listOpenCustomerRepairDeliveries,
  saveCustomerRepairIssue,
} from '../modules/repair/repairCustomerIssue.js';
import {
  customerRepairIssueDocumentData,
  customerRepairIssueHtml,
} from '../modules/repair/repairCustomerIssueDoc.js';
import {
  deleteRepairImage,
  getRepairImage,
  getRepairImageState,
  listRepairImageKeys,
  saveRepairImage,
} from '../modules/repair/repairImage.js';
import {
  createTag,
  onHand as tagOnHand,
  onHandNet,
  listTags,
  physicalReconcile,
  physicalStockList,
  tagOpening,
  getTagOpening,
  editTagOpening,
  deleteTagOpening,
  itemOpening,
  getItemOpening,
  editItemOpening,
  deleteItemOpening,
  itemLot,
  getItemLot,
  editItemLot,
  deleteItemLot,
  stockAdjust,
  deleteStockAdjust,
  counterTransfer,
  deleteCounterTransfer,
  StockVoucherValidationError,
} from '../modules/stock/stock.js';
import {
  createStockIn,
  createStockOut,
  deleteStockIn,
  deleteStockOut,
  editStockIn,
  editStockOut,
  getStockIn,
  getStockOut,
} from '../modules/stock/stockInout.js';
import {
  deletePhysicalStock,
  getPhysicalStock,
  savePhysicalStock,
} from '../modules/stock/physicalStock.js';
import {
  deleteStoneDmCf,
  getStoneDmCf,
  listStoneDmCfSources,
  saveStoneDmCf,
} from '../modules/stock/stoneDmCf.js';
import { deleteGoldBook, getGoldBook, saveGoldBook } from '../modules/finance/goldBook.js';
import {
  deleteVpAdjustment,
  getVpAdjustment,
  saveVpAdjustment,
} from '../modules/finance/vpAdjustment.js';
import { deleteVpParcel, getVpParcel, saveVpParcel } from '../modules/sales/vpParcel.js';
import {
  deleteWholesaleSaleReturn,
  getWholesaleSaleReturn,
  saveWholesaleSaleReturn,
} from '../modules/sales/wholesaleSaleReturn.js';
import {
  deleteLocationAmount,
  getLocationAmount,
  saveLocationAmount,
} from '../modules/finance/locationAmount.js';
import {
  deleteOtherCommission,
  getOtherCommission,
  saveOtherCommission,
} from '../modules/purchase/otherCommission.js';
import {
  deleteOtherPurc,
  getOtherPurc,
  saveOtherPurc,
  type OtherPurcMode,
} from '../modules/purchase/otherIncome.js';
import { tagWeightDiff, deleteTagWeightDiff } from '../modules/stock/tagOps.js';
import {
  deleteTagCancel,
  getTagCancel,
  listTagCancel,
  saveTagCancel,
  tagCancelSource,
  type TagCancelMode,
} from '../modules/stock/tagCancel.js';
import { deleteTagAdjust, getTagAdjust, saveTagAdjust } from '../modules/stock/tagAdjust.js';
import {
  saveTagSplit,
  deleteTagSplit,
  getTagSplit,
  listTagSplit,
  tagSplitSource,
  TagSplitConflictError,
} from '../modules/stock/tagSplit.js';
import { lookup } from '../modules/masters/lookup.js';
import { postJournal, deleteJournal } from '../modules/finance/journal.js';
import { postLedgerAdjust, deleteLedgerAdjust } from '../modules/finance/ledgerAdjust.js';
import { postEmployeeJv, deleteEmployeeJv } from '../modules/finance/employeeJv.js';
import {
  cashBook,
  partyStatement,
  hsnSummary,
  schemeAdjustments,
  itemStockLedger,
} from '../modules/reports/reports2.js';
import { fetchRate, rateGroups } from '../modules/masters/rate.js';
import { enrollMember, postPoints, listMembers } from '../modules/membership/membership.js';
import { fetchLiveRates } from '../modules/integrations/rates.js';
import {
  messageDeliveryEnabled,
  resolveSettingsBehaviorTx,
} from '../modules/shared/settingsBehavior.js';
import * as messaging from '../modules/integrations/messaging.js';
import {
  renderToPdf,
  PlaywrightPdfRenderer,
  pdfRenderFailure,
  type PdfRenderer,
} from '../modules/reports/render.js';
import {
  estimatePdfHtml,
  reportPdfHtml,
  ReportTooLargeForPdfError,
} from '../modules/reports/reportPdf.js';
import { code39Svg, qrSvg } from '../modules/integrations/barcode.js';
import {
  salesRegister,
  purchaseRegister,
  dayBook,
  trialBalance,
  accountLedger,
  gstr1,
  dhrnOutstandingList,
  karigarBalances,
  accountBalances,
  stockValuation,
  gstr3b,
  salesByParty,
  salesByItem,
  balanceSheet,
  profitAndLoss,
  finalReports,
  outstandingReport,
  monthlySales,
  oldGoldRegister,
  billOutstanding,
} from '../modules/reports/reports.js';
import {
  buildIrnPayload,
  submitIrn,
  irnTransportFromEnv,
  submitIrnForSale,
  submitIrnForCreditNote,
  gspStatus,
  testGspAuth,
  cancelIrnForSale,
} from '../modules/einvoice/einvoice.js';
import { eInvoiceExportData, eInvoiceExportSheets } from '../modules/einvoice/einvoiceExport.js';
import { bullionBooking, deleteBullionBooking } from '../modules/bullion/bullion.js';
import {
  createFineSalePurchase,
  deleteFineSalePurchase,
} from '../modules/bullion/fineSalePurchase.js';
import {
  tourIssue,
  deleteTour,
  tourReturn,
  deleteTourReturn,
  tourLines,
  markApprovalBilled,
} from '../modules/tour/tour.js';
import { yearEndPreview, yearEndClose } from '../modules/ops/yearEnd.js';
import {
  enrollScheme,
  schemeInstallment,
  schemeOpening,
  schemeMaturity,
  schemeGoldAdjust,
  deleteSchemeInstallment,
  getSchemeInstallment,
  getSchemeMaturity,
  getSchemeGoldAdjust,
  deleteEnrollment,
  deleteSchemeMaturity,
  deleteSchemeGoldAdjust,
} from '../modules/membership/scheme.js';
import {
  salesReturnRegister,
  karigarStatement,
  rateList,
  karigarLedger,
  renderKarigarLedgerHtml,
} from '../modules/reports/reports4.js';
import { dailySalesSummary, topItems, employeeSales } from '../modules/reports/reports5.js';
import { overdueReminders, birthdayReminders, sendReminder } from '../modules/ops/reminders.js';
import { postBatchReceipt } from '../modules/finance/batchReceipt.js';
import {
  purchaseReturnRegister,
  contraRegister,
  areaOutstanding,
  itemGroupStock,
} from '../modules/reports/reports6.js';
import {
  salesGstMonthly,
  billAging,
  stockByLocation,
  purchaseByItem,
} from '../modules/reports/reports7.js';
import { voucherRegister } from '../modules/reports/voucherRegister.js';
import { trialBalanceFull, salesByGroup, cashDaySummary } from '../modules/reports/reports8.js';
import { customerCrm, areaWiseSales, locationWiseSales } from '../modules/reports/reports9.js';
import { gstInputRegister } from '../modules/reports/reports10.js';
import { graphReport } from '../modules/reports/graphReport.js';
import {
  deleteDataReport,
  orderLotZoom,
  orderTrackReport,
  pointReport,
  pointReportDetail,
  tagEstimate,
} from '../modules/reports/orderTagReports.js';
import { toCsv } from '../modules/reports/reportCsv.js';
import { rojmel } from '../modules/reports/rojmelReport.js';
import {
  readFilters,
  REPORT_FILTER_BINDINGS,
  supportedFilters,
} from '../modules/reports/reportFilters.js';
import {
  isReportSlug,
  REPORT_FORM_BY_SLUG,
  type ReportSlug,
} from '../modules/reports/reportAuthorization.js';
import { huidReport } from '../modules/reports/huid.js';
import { schemeMonthlyReport, stockLevelReport } from '../modules/reports/stockLevel.js';
import { billProfitReport } from '../modules/reports/billProfitReport.js';
import { physicalStockReport } from '../modules/reports/physicalStock.js';
import { movementReport } from '../modules/reports/movement.js';
import { branchInoutReport } from '../modules/reports/branchInoutReport.js';
import { otherItemReport } from '../modules/reports/otherItemReport.js';
import { designMoveDetailReport, designMoveReport } from '../modules/reports/designMoveReport.js';
import { consiDetailReport, consiReport } from '../modules/reports/consiReport.js';
import { oldStockReport } from '../modules/reports/oldStockReport.js';
import { tradingReport } from '../modules/reports/tradingReport.js';
import { tourReport, tourTagReport } from '../modules/reports/tourReports.js';
import {
  mfgInoutReport,
  mfgLedgerDetailReport,
  mfgLedgerReport,
  mfgLotIsuRecReport,
} from '../modules/reports/manufacturingReports.js';
import { addressPrintReport, lastVisitReport } from '../modules/reports/customerAccountReports.js';
import { dhrnLoanReport } from '../modules/reports/dhrnLoanReports.js';
import { gstLauncherReport } from '../modules/reports/gstLauncherReport.js';
import {
  approvalReport,
  bullionReport,
  karigarReport,
  repairReport,
  vpReport,
} from '../modules/reports/reportFamilyReports.js';
import {
  entryCheckDetailReport,
  entryCheckReport,
  markEntryChecked,
  userWorkReport,
} from '../modules/reports/userAuditReports.js';

/**
 * HTTP/REST exposure of the verified backend modules for the mobile app to consume. Every route is
 * auth-guarded (requireAuth preHandler) and RBAC-guarded (assertRight) for mutations; domain errors
 * map to HTTP status. The service functions are unchanged — this is a thin JSON adapter.
 */
export interface TxnDeps {
  prisma: any;
  /** Renderer for server-built PDFs (reports, estimate). Tests inject a capturing renderer. */
  pdfRenderer?: PdfRenderer;
  requireAuth: (req: FastifyRequest, reply: FastifyReply) => Promise<void>;
  sess: (req: FastifyRequest) => {
    tenantId: string;
    sub: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
    loginCoCode: string;
    // Optional in this shared dependency for unrelated legacy route harnesses; the guarded PUT
    // validates both as required authority and refuses missing values without a fallback.
    sid?: string;
    contextEpoch?: string;
    rights: any;
  };
  scopeOfRequest: (req: FastifyRequest) => {
    tenantId: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
    coBook?: string;
  };
  routeAuthorized: (req: FastifyRequest) => boolean;
  metrics: MetricsRegistry;
}

/** Fields the estimate screen sends (txn/estimate/page.tsx). Anything else is refused, not ignored. */
const ESTIMATE_FIELDS = new Set([
  'acCode',
  'acName',
  'taxRatePct',
  'discountAmount',
  'interState',
  'lines',
]);
/** Line fields the estimate screen sends: text cells, and numeric cells (including its extended grid). */
const ESTIMATE_LINE_TEXT = new Set([
  'designImageId',
  'hallmarkId2',
  'hallmarkId3',
  'hallmarkId4',
  'itCode',
  'labourType',
  'tagNo',
  'ordNo',
  'ordYrcd',
  'ordDbcd',
  'isuNo',
  'isuYrcd',
  'isuDbcd',
  'huid',
  'designNo',
  'itmSize',
  'tblCode',
  'itemLot',
  'remark',
  'rateWith',
  'rateType',
  'karigarName',
  'employeeCode',
  'prCode',
]);
const ESTIMATE_LINE_NUMBERS = new Set([
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
  'pcs',
  'grossWt',
  'netWt',
  'touch',
  'rate',
  'labourRate',
  'labourFixed',
  'mrp',
  'ordSrno',
  'isuSrno',
  'ghtWt',
  'westPct',
  'fineWt',
  'metalAmount',
  'labourPct',
  'otherAmount',
  'lessWt',
  'bagWt',
  'tagGrossWt',
  'tagNetWt',
  'ghtPct',
  'discountPct',
  'ghatAmount',
  'tagCost',
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
]);
const ESTIMATE_NUMBERS = new Set(['taxRatePct', 'discountAmount']);

/** Field paths of an estimate PDF request that are unknown or mistyped; empty when the request is valid. */
export function estimatePdfInputErrors(b: Record<string, unknown>): string[] {
  const errors: string[] = [];
  const finite = (v: unknown) => v === undefined || v === null || Number.isFinite(Number(v));
  for (const key of Object.keys(b)) {
    if (!ESTIMATE_FIELDS.has(key)) errors.push(key);
    else if (ESTIMATE_NUMBERS.has(key) && !finite(b[key])) errors.push(key);
    else if ((key === 'acCode' || key === 'acName') && b[key] != null && typeof b[key] !== 'string')
      errors.push(key);
  }
  if (!Array.isArray(b.lines) || b.lines.length > 200) return [...errors, 'lines'];
  b.lines.forEach((line, i) => {
    if (!line || typeof line !== 'object' || Array.isArray(line)) {
      errors.push(`lines[${i}]`);
      return;
    }
    for (const [key, value] of Object.entries(line as Record<string, unknown>)) {
      if (ESTIMATE_LINE_NUMBERS.has(key)) {
        if (!finite(value)) errors.push(`lines[${i}].${key}`);
      } else if (ESTIMATE_LINE_TEXT.has(key)) {
        if (value != null && typeof value !== 'string') errors.push(`lines[${i}].${key}`);
      } else errors.push(`lines[${i}].${key}`);
    }
  });
  return errors;
}

export function registerTxnRoutes(app: FastifyInstance, deps: TxnDeps): void {
  const { prisma, requireAuth, sess, scopeOfRequest, routeAuthorized, metrics } = deps;
  const auth = { preHandler: requireAuth };

  const scopeOf = (req: FastifyRequest) => ({ ...scopeOfRequest(req) });
  const readScope = (req: FastifyRequest) => {
    const scope = scopeOfRequest(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const iso = (v?: string): string | undefined =>
      v && /^\d{4}-\d{2}-\d{2}$/.test(v) ? v : undefined;
    return {
      tenantId: scope.tenantId,
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear: scope.coYear,
      coBook: scope.coBook,
      // Carried on the scope so a report gains date filtering without changing its signature. Only a
      // well-formed ISO date is accepted; anything else is ignored rather than reaching SQL.
      fromDate: iso(q.fromDate),
      toDate: iso(q.toDate),
      // Shared RP_ALL panel dimensions. Bounded and trimmed here; whether a given report honours one is
      // decided by its registered FilterBinding, and an unsupported one is refused rather than dropped.
      filters: readFilters(q),
      // HUID has desktop-specific controls outside the shared RP_ALL dimensions. Both the literal screen
      // and generic exports receive this same object, so a filtered export cannot silently widen the report.
      huidOptions: {
        tab: q.tab,
        itCode: q.itCode,
        tblCode: q.tblCode,
        hallmark: q.hallmark,
      },
    };
  };
  // Printable documents read by the complete desktop voucher key (modules/documents/voucherDocument.ts):
  // company, location and year from the authenticated scope, book and voucher from the request. There is
  // deliberately no default book. A missing one is a 400, never another book's voucher with the same number.
  const documentScope = (req: FastifyRequest, reply: FastifyReply) => {
    const s = readScope(req);
    const q = (req.query ?? {}) as Record<string, unknown>;
    try {
      return requireVoucherDocumentScope({
        tenantId: s.tenantId,
        coCode: s.coCode,
        lcCode: s.lcCode,
        coYear: s.coYear,
        coBook: s.coBook,
        vchNo: String(q.vchNo ?? ''),
      });
    } catch (e) {
      if (e instanceof DocumentScopeError) {
        void reply.code(400).send({ error: e.name, field: e.field, message: e.message });
        return null;
      }
      throw e;
    }
  };
  const standardDocumentCopy = (raw: unknown, reply: FastifyReply): string | null | undefined => {
    const code = String(raw ?? '')
      .trim()
      .toUpperCase();
    if (!code) return undefined;
    if (code !== 'O' && code !== 'D' && code !== 'T') {
      void reply.code(400).send({
        error: 'DocumentCopyError',
        message: 'copy must be O (original), D (duplicate supplier), or T (triplicate transporter)',
      });
      return null;
    }
    return ORDER_REPORT_COPIES[code];
  };
  // Operator inputs of the two fixed report screens whose exports are also slug-driven. They are shared
  // so a CSV/XLSX export can never be built from different inputs than the screen it came from.
  const balanceSheetOptions = (query: unknown) => {
    // Desktop RP_BALANCE passes an operator-entered closing date and gold/silver rates into
    // Ac_Final.Trading_Stock; without a rate the metal pass cannot value stock at all.
    const q = (query ?? {}) as Record<string, string | undefined>;
    const n = (v: string | undefined): number | undefined =>
      v == null || v === '' ? undefined : Number(v);
    return {
      closingDate: q.closingDate || undefined,
      goldRate: n(q.goldRate),
      silverRate: n(q.silverRate),
      ledgerFineGold: n(q.ledgerFineGold),
      ledgerFineSilver: n(q.ledgerFineSilver),
    };
  };
  const gstr1Options = (query: unknown) => ({
    threshold: Number((query as Record<string, unknown> | undefined)?.threshold) || undefined,
  });
  const guard = (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ): boolean => {
    if (routeAuthorized(req)) return true;
    reply.code(403).send({ error: 'forbidden', action });
    return false;
  };
  const containMutation = (reply: FastifyReply, operation: ParityContainmentOperation): boolean => {
    const problem = parityContainmentProblem(operation);
    if (!problem) return false;
    reply.code(problem.statusCode).send(problem.body);
    return true;
  };
  // Map domain errors → HTTP status (validation/balance/tag → 400; everything else rethrows → 500).
  const run = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      const out = await fn();
      return reply.code(okCode).send(out as any);
    } catch (e: any) {
      // A rolled-back budget failure is a retryable 503 (app.ts), never a 400 "invalid-data" below.
      if (isTransactionTimeout(e)) throw e;
      const n: string = e?.name ?? '';
      if (e instanceof SessionCommandError || e instanceof SessionReadSnapshotError)
        return reply.code(e.statusCode).send({
          error: e.code,
          message: e.message,
          ...(e.form === undefined ? {} : { form: e.form, action: e.action }),
        });
      if (e instanceof SavedSaleReturnError)
        return reply.code(e.statusCode).send({ error: e.code, message: e.message });
      if (e instanceof SaleReturnSourceError)
        return reply.code(e.statusCode).send({ error: e.code, message: e.message });
      if (e instanceof SaleReturnIncomingConfigurationError)
        return reply.code(e.statusCode).send({ error: e.code, message: e.message });
      if (
        e instanceof SaleReturnIncomingReplayError ||
        e instanceof SaleReturnBillReplayError ||
        e instanceof SaleReturnLabourReplayError
      )
        return reply.code(e.statusCode).send({
          error: e.code,
          message: e.message,
          ...(e.details === undefined ? {} : { details: e.details }),
        });
      if (e instanceof ImageVersionConflictError)
        return reply.code(409).send({ error: 'image-version-conflict', message: e.message });
      // N54 step 4 / G33: no messaging provider, so nothing was sent or recorded.
      if (e instanceof messaging.MessagingUnconfiguredError)
        return reply.code(e.statusCode).send({ error: e.code, message: e.message });
      if (e instanceof SalesOrderDesignError)
        return reply.code(e.statusCode).send({ error: e.name, message: e.message });
      if (e instanceof SalesOrderWorkflowUnavailableError)
        return reply.code(422).send({ error: e.name, code: e.code, message: e.message });
      if (e instanceof OrderImageError)
        return reply.code(422).send({ error: e.name, code: e.code, message: e.message });
      if (
        n === 'DesignBookConflictError' ||
        n === 'SalesOrderConflictError' ||
        n === 'EBillConflictError' ||
        n === 'TagCancelConflictError' ||
        n === 'TagSplitConflictError'
      ) {
        return reply.code(409).send({ error: n, message: e?.message });
      }
      if (n === 'PeriodLockValidationError') metrics.recordPeriodLockRejection();
      if (
        /(ValidationError|NumberingConfigurationError|UnbalancedError|TagExistsError|TagNotAvailableError|EInvoiceValidationError|BarcodeError|DhrnValidationError|KarigarValidationError|SaleValidationError|PurchaseValidationError|MembershipError|SettingsError|EntityImageError|RepairError|MeltingError|SchemeError|FineInoutError|StockInoutValidationError|PasswordPolicyError|PasswordChangeError|FormRightsValidationError|ReportFilterError|StockLimitValidationError|EstimateResetValidationError|TagAdjustError|StoneDmCfValidationError)/.test(
          n,
        )
      ) {
        // Forward per-field reasons when the error carries them (e.g. SettingsError.details), so the
        // client can mark the offending inputs instead of showing one opaque banner.
        const details = e?.details;
        return reply
          .code(400)
          .send({ error: n, message: e?.message, ...(details ? { details } : {}) });
      }
      const msg: string = e?.message ?? '';
      if (
        e?.code === 'P2010' ||
        e?.code === 'P2002' ||
        /Raw query failed|value too long|violates|not-null|duplicate key/i.test(msg)
      ) {
        const m = msg.match(/Message: `([^`]+)`/);
        return reply.code(400).send({
          error: 'invalid-data',
          detail: (m?.[1] ?? msg).replace(/^ERROR:\s*/, '').slice(0, 200),
        });
      }
      throw e;
    }
  };
  const formMutationCapabilities = async (req: FastifyRequest, form: string) => {
    const s = sess(req);
    const principal = await loadPrincipal(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      loginCoCode: s.loginCoCode,
      loginName: s.sub,
    });
    const may = async (action: 'update' | 'delete') => {
      try {
        await authorizeForm(prisma, {
          tenantId: s.tenantId,
          lcCode: s.lcCode,
          principal,
          form,
          action,
        });
        return true;
      } catch (error) {
        if (error instanceof FormForbiddenError) return false;
        throw error;
      }
    };
    const [canUpdate, canDelete] = await Promise.all([may('update'), may('delete')]);
    return { canUpdate, canDelete };
  };
  const body = (req: FastifyRequest) => (req.body ?? {}) as Record<string, any>;
  /** The renderer for server-built documents; injectable for tests. */
  const pdfRenderer = (): PdfRenderer => deps.pdfRenderer ?? new PlaywrightPdfRenderer();
  /** Render server-built HTML, mapping limits to 413/422 and a busy or slow renderer to a retryable 503. */
  const sendPdf = async (reply: FastifyReply, html: string, filename: string) => {
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, pdfRenderer());
    } catch (error) {
      const failure = pdfRenderFailure(error);
      if (failure.retryAfter) reply.header('Retry-After', String(failure.retryAfter));
      return reply.code(failure.status).send(failure.body);
    }
    const name = filename.replace(/[^\w.-]/g, '') || 'document';
    return reply
      .header('content-type', 'application/pdf')
      .header('content-disposition', `inline; filename="${name}.pdf"`)
      .send(pdf);
  };
  /** The session company's name for a letterhead (CO_MAST.CO_NAME), blank when the master has none. */
  const sessionCompanyName = async (req: FastifyRequest): Promise<string> => {
    const s = readScope(req);
    const company = await withTxBudget(prisma, s.tenantId, 'read', (tx: any) =>
      documentCompanyTx(tx, { tenantId: s.tenantId, coCode: s.coCode } as any),
    );
    return String(company?.CO_NAME ?? '').trim();
  };
  const salesOrderInput = (req: FastifyRequest, b = body(req)) => ({
    scope: scopeOf(req),
    requireDesignSelection: true,
    expectedVersion: b.expectedVersion,
    dirtyFields: b.dirtyFields,
    acCode: b.acCode,
    acName: b.acName,
    billNo: b.billNo,
    netAmount: b.netAmount,
    lines: b.lines,
    taxRatePct: b.taxRatePct ?? 0,
    interState: !!b.interState,
    advanceAmount: b.advanceAmount ?? 0,
    vchDate: b.vchDate,
    vchTime: b.vchTime,
    vchDesc: b.vchDesc,
    cashAc: b.cashAc,
    mainUser: sess(req).sub,
    taxCode: b.taxCode,
    upiAmount: b.upiAmount,
    bankAc: b.bankAc,
    chequeNo: b.chequeNo,
    bankName: b.bankName,
    cardAc: b.cardAc,
    cardAdj: b.cardAdj,
    oldGoldFine: b.oldGoldFine,
    oldGoldAmount: b.oldGoldAmount,
    oldSilverFine: b.oldSilverFine,
    oldSilverAmount: b.oldSilverAmount,
    schemeAmount: b.schemeAmount,
    rateCutRate: b.rateCutRate,
    rateCutFine: b.rateCutFine,
    rateCutAmount: b.rateCutAmount,
    adjustGold: b.adjustGold,
    adjustSilver: b.adjustSilver,
    orderAdjustAmount: b.orderAdjustAmount,
    deliveryDate: b.deliveryDate,
    functionDate: b.functionDate,
    address1: b.address1,
    address2: b.address2,
    address3: b.address3,
    city: b.city,
    mobile: b.mobile,
    empCode: b.empCode,
  });
  const rateCutInput = (req: FastifyRequest, b: Record<string, any>) => ({
    scope: scopeOf(req),
    // MAIN_USER is the signed-in user (TR_WH_SALE.cs:12004), never a body field.
    mainUser: sess(req).sub,
    vchDate: b.vchDate,
    acCode: b.acCode,
    acName: b.acName,
    itType: b.itType,
    lines: b.lines ?? [],
    receivedLines: b.receivedLines ?? [],
    pay: b.pay,
    receivedPay: b.receivedPay,
    accounts: b.accounts,
    // These desktop header fields are operator inputs. HD_VCH_NO is deliberately absent: the writer
    // allocates it server-side from TEMP_BOOK_DATA and preserves it on edit.
    billNo: b.billNo,
    empCode: b.empCode,
    vchDesc: b.vchDesc,
    convRate: b.convRate,
    convPct: b.convPct,
    fineRate: b.fineRate,
    settleDrAmt: b.settleDrAmt,
    settleCrAmt: b.settleCrAmt,
    settleDrFine: b.settleDrFine,
    settleCrFine: b.settleCrFine,
    // Party contact snapshot (RATE_CUT_DATA carries its own copy, as the desktop form does).
    add1: b.add1,
    add2: b.add2,
    add3: b.add3,
    city: b.city,
    mobile: b.mobile,
    bankName: b.bankName,
  });

  // ---- Desktop utilities (server-derived tenant/company/location/year only) ----
  app.get('/utilities/data-export/preview', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => dataExportPreview(prisma, readScope(req)));
  });
  app.get('/utilities/data-export/download', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const q = (req.query ?? {}) as Record<string, unknown>;
    const doc = await dataExportPackage(prisma, readScope(req), {
      pendingOnly: dataExportPendingOnly(q.pendingOnly),
    });
    return reply
      .type('application/json')
      .header(
        'content-disposition',
        `attachment; filename="data-export-${sess(req).coCode}-${sess(req).coYear}.json"`,
      )
      .send(Buffer.from(JSON.stringify(doc, null, 2)));
  });
  app.post('/utilities/data-export/mark-exported', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      markDataTransferFlags(prisma, readScope(req), {
        state: 'Y',
        pendingOnly: b.pendingOnly == null ? true : !!b.pendingOnly,
      }),
    );
  });
  app.post('/utilities/data-export/reset-flags', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => resetDataTransferFlags(prisma, readScope(req)));
  });
  app.post('/utilities/estimate-reset/preview', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const b = body(req);
    return run(reply, 200, () => estimateResetPreview(prisma, readScope(req), b.asOfDate));
  });
  app.post('/utilities/estimate-reset/apply', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const b = body(req);
    return run(reply, 200, () =>
      applyEstimateReset(prisma, readScope(req), {
        asOfDate: b.asOfDate,
        confirmed: b.confirmed === true,
        confirmation: b.confirmation,
      }),
    );
  });
  app.get('/utilities/hdd-registry', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => listHddRegistry(prisma, readScope(req)));
  });
  app.get('/utilities/hdd-registry/:refNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getHddRegistry(prisma, readScope(req), String((req.params as any).refNo)),
    );
  });
  app.post('/utilities/hdd-registry', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => saveHddRegistry(prisma, readScope(req), body(req).refNo));
  });
  app.put('/utilities/hdd-registry/:refNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => saveHddRegistry(prisma, readScope(req), body(req).refNo));
  });
  app.delete('/utilities/hdd-registry/:refNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteHddRegistry(prisma, readScope(req), String((req.params as any).refNo)),
    );
  });

  const userRequestInput = (req: FastifyRequest, values: Record<string, any>) => ({
    scope: readScope(req),
    coBook: String(values.coBook ?? ''),
    vchNo: String(values.vchNo ?? ''),
    acCode: values.acCode == null ? undefined : String(values.acCode),
    editUser: sess(req).sub,
    remark: String(values.remark ?? ''),
    requestType: values.requestType as 'E' | 'D',
  });
  app.get('/utilities/user-requests', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => listUserRequests(prisma, readScope(req)));
  });
  app.get('/utilities/user-requests/:coBook/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const p = req.params as any;
    return run(reply, 200, () => getUserRequest(prisma, readScope(req), p.coBook, p.vchNo));
  });
  app.post('/utilities/user-requests', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => saveUserRequest(prisma, userRequestInput(req, body(req))));
  });
  app.put('/utilities/user-requests/:coBook/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const p = req.params as any;
    return run(reply, 200, () =>
      saveUserRequest(prisma, userRequestInput(req, { ...body(req), ...p })),
    );
  });
  app.delete('/utilities/user-requests/:coBook/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const p = req.params as any;
    return run(reply, 200, () =>
      deleteUserRequest(prisma, readScope(req), String(p.coBook), String(p.vchNo)),
    );
  });

  app.get('/utilities/window-tiles', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => listWindowTiles(prisma, readScope(req), sess(req).sub));
  });
  app.post('/utilities/window-tiles', auth, async (req) => {
    // MS_USER seeds and renames tiles; MS_WINDOW_SET reassigns the owning main menu. TILE_DATA is
    // tenant-global dashboard configuration with no company or location column.
    const s = scopeOf(req);
    const body = (req.body as any) || {};
    return saveWindowTile(prisma, s.tenantId, {
      tileName: String(body.tileName ?? ''),
      mainName: body.mainName,
      srNo: body.srNo,
      displayName: body.displayName,
      shortName: body.shortName,
      show: body.show,
    });
  });
  app.get('/utilities/window-tiles/:tileName', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getWindowTile(prisma, readScope(req), sess(req).sub, String((req.params as any).tileName)),
    );
  });

  // ---- Sales ----
  const saleInput = (req: FastifyRequest, b: Record<string, any>) => ({
    scope: scopeOf(req),
    mainUser: sess(req).sub,
    acCode: b.acCode,
    acName: b.acName,
    billNo: b.billNo,
    vchDate: b.vchDate,
    discountAmount: b.discountAmount,
    discountPct: b.discountPct,
    taxRatePct: b.taxRatePct,
    taxCode: b.taxCode,
    interState: !!b.interState,
    rateUnfix: !!b.rateUnfix,
    cashAmt: b.cashAmt,
    cardAmt: b.cardAmt,
    upiAmt: b.upiAmt,
    chequeAmt: b.chequeAmt,
    cashAc: b.cashAc,
    bankAc: b.bankAc,
    oldGoldAc: b.oldGoldAc,
    oldGold: b.oldGold,
    hallmarkAmount: b.hallmarkAmount != null ? Number(b.hallmarkAmount) : undefined,
    hmChargeAc: b.hmChargeAc,
    hmTaxPct: b.hmTaxPct != null ? Number(b.hmTaxPct) : undefined,
    tcsAmount: b.tcsAmount != null ? Number(b.tcsAmount) : undefined,
    tcsPct: b.tcsPct != null ? Number(b.tcsPct) : undefined,
    tcsAc: b.tcsAc,
    tcsCode: b.tcsCode,
    tdsCode: b.tdsCode,
    tdsPct: b.tdsPct != null ? Number(b.tdsPct) : undefined,
    tdsAmount: b.tdsAmount != null ? Number(b.tdsAmount) : undefined,
    kasarAmount: b.kasarAmount != null ? Number(b.kasarAmount) : undefined,
    kasarAc: b.kasarAc,
    orderRef: b.orderRef,
    crDays: b.crDays != null ? Number(b.crDays) : undefined,
    empCode: b.empCode,
    cardAc: b.cardAc,
    chequeNo: b.chequeNo,
    bankName: b.bankName,
    cardCommissionAmount:
      b.cardCommissionAmount != null ? Number(b.cardCommissionAmount) : undefined,
    cashPaid: b.cashPaid != null ? Number(b.cashPaid) : undefined,
    currentAdjustmentAmount:
      b.currentAdjustmentAmount != null ? Number(b.currentAdjustmentAmount) : undefined,
    schemeAc: b.schemeAc,
    schemeAmount: b.schemeAmount != null ? Number(b.schemeAmount) : undefined,
    pointValue: b.pointValue != null ? Number(b.pointValue) : undefined,
    address1: b.address1,
    address2: b.address2,
    address3: b.address3,
    city: b.city,
    mobile: b.mobile,
    issueNo: b.issueNo,
    issueYear: b.issueYear,
    issueBook: b.issueBook,
    description: b.description,
    ornamentIssued: b.ornamentIssued == null ? undefined : !!b.ornamentIssued,
  });
  app.post('/sales', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createSale(prisma, saleInput(req, b), b.lines ?? []));
  });
  app.get('/sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getSale(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  // G125 (Stage E): the retail Tax Invoice print (desktop SaleBillA4Gst.rpt). Every sale needs a
  // printable bill; builds the shared GST-bill HTML and renders it to PDF (or returns raw HTML).
  app.get('/sales/:vchNo/print', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = req.query as any;
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    const scope = resolvePrintScope(reply, readScope(req), (req.params as any).vchNo);
    if (!scope) return reply;
    await getSale(prisma, scope, scope.vchNo);
    const data = await salesBillData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'sale-not-found' });
    const html = salesBillHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      copy: copyLabel,
    });
    return sendVoucherDocument(reply, html, { format: q.format, filename: `sale-${scope.vchNo}` });
  });
  app.put('/sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editSale(prisma, saleInput(req, b), b.lines ?? [], (req.params as any).vchNo),
    );
  });
  app.delete('/sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteSale(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  app.post('/sales-quotations', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createSalesQuotation(prisma, saleInput(req, b), b.lines ?? []));
  });
  app.get('/sales-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getSalesQuotation(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  app.put('/sales-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editSalesQuotation(prisma, saleInput(req, b), b.lines ?? [], (req.params as any).vchNo),
    );
  });
  app.delete('/sales-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteSalesQuotation(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Estimate / quotation (compute only — no ledger, no voucher) ----
  app.post('/estimate', auth, async (req) => estimateOf(body(req)));
  // N54: the estimate PDF is built here from typed estimate input; no client HTML. Unknown fields are
  // refused (an \`html\` field included), and the body is capped at 64 KB.
  app.post('/estimate/pdf', { ...auth, bodyLimit: 64 * 1024 }, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const b = body(req);
    const invalid = estimatePdfInputErrors(b);
    if (invalid.length) return reply.code(400).send({ error: 'invalid-request', fields: invalid });
    const estimate = estimateOf(b);
    const html = estimatePdfHtml({
      company: await sessionCompanyName(req),
      customer: String(b.acName || b.acCode || ''),
      printedAt: new Date(),
      lines: estimate.lines,
      totals: estimate.totals,
    });
    return sendPdf(reply, html, 'estimate');
  });
  function estimateOf(b: Record<string, any>) {
    const computed = ((b.lines ?? []) as any[]).map((l) => ({ in: l, calc: computeSaleLine(l) }));
    const lineNetTotal = computed.reduce((s, c) => s + c.calc.net, 0);
    const totals = billTotals({
      lineNetTotal,
      discountAmount: Number(b.discountAmount || 0),
      taxRatePct: Number(b.taxRatePct || 0),
      interState: !!b.interState,
    });
    return {
      acCode: b.acCode ?? null,
      lines: computed.map((c, i) => ({
        sr: i + 1,
        itCode: c.in.itCode,
        metal: c.calc.metal,
        labour: c.calc.labour,
        net: c.calc.net,
      })),
      totals,
    };
  }

  // ---- Sales return ----
  // Saved incoming metadata is a bounded patch, separate from the legacy numerical writer.
  // Query identity is mandatory, so an old editor cannot silently adopt a different session scope.
  const savedReturnScope = (req: FastifyRequest) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    for (const key of ['coCode', 'lcCode', 'coYear', 'coBook'])
      if (typeof q[key] !== 'string' || !String(q[key]).trim())
        throw new SavedSaleReturnError(
          400,
          'sale-return-identity-required',
          'Select the company, branch, year and return book before loading this saved return.',
        );
    const scope = scopeOf(req);
    if (!scope.coYear || !scope.coBook)
      throw new SavedSaleReturnError(
        400,
        'sale-return-identity-required',
        'The selected return year and book are unavailable. Reload the business scope.',
      );
    return { ...scope, coYear: scope.coYear, coBook: scope.coBook };
  };
  app.get('/sales-returns/incoming-recent', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, () => listSavedSaleReturnIncoming(prisma, savedReturnScope(req)));
  });
  app.get('/sales-returns/incoming-calculation-configuration', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => {
      const query = (req.query ?? {}) as Record<string, unknown>;
      const scopeFields = new Set(['coCode', 'lcCode', 'coYear', 'coBook']);
      if (
        Object.entries(query).some(
          ([key, value]) => !scopeFields.has(key) || typeof value !== 'string',
        )
      )
        throw new SaleReturnIncomingConfigurationError(
          400,
          'sale-return-configuration-query',
          'Use only the selected company, branch, year and Return book to load calculation settings.',
        );
      return getSaleReturnIncomingConfiguration(prisma, savedReturnScope(req));
    });
  });
  const returnSourceQuery = (
    req: FastifyRequest,
    fields: string[],
    required: string[] = [],
  ): Record<string, string> => {
    const query = (req.query ?? {}) as Record<string, unknown>;
    const allowed = new Set(['coCode', 'lcCode', 'coYear', 'coBook', ...fields]);
    for (const [key, value] of Object.entries(query))
      if (!allowed.has(key) || typeof value !== 'string')
        throw new SaleReturnSourceError(
          400,
          'sale-return-source-query',
          'Use the selected Return scope and explicit original-sale search fields.',
        );
    for (const key of required)
      if (typeof query[key] !== 'string' || !String(query[key]).trim())
        throw new SaleReturnSourceError(
          400,
          'sale-return-source-query',
          'Select the original sale year, book and voucher before loading its items.',
        );
    return query as Record<string, string>;
  };
  app.get('/sales-returns/source-vouchers', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => {
      const scope = savedReturnScope(req);
      const q = returnSourceQuery(req, ['sourceYear', 'sourceBook', 'search', 'offset', 'limit']);
      return listSaleReturnSourceVouchers(prisma, scope, {
        sourceYear: q.sourceYear,
        sourceBook: q.sourceBook,
        search: q.search,
        offset: q.offset,
        limit: q.limit,
      });
    });
  });
  app.get('/sales-returns/source-items', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => {
      const scope = savedReturnScope(req);
      const fields = ['sourceYear', 'sourceBook', 'sourceVchNo'];
      const q = returnSourceQuery(req, fields, fields);
      return getSaleReturnSourceItems(prisma, scope, {
        sourceYear: q.sourceYear!,
        sourceBook: q.sourceBook!,
        sourceVchNo: q.sourceVchNo!,
      });
    });
  });
  app.get('/sales-returns/:vchNo/incoming', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => ({
      ...(await getSavedSaleReturnIncoming(
        prisma,
        savedReturnScope(req),
        (req.params as any).vchNo,
      )),
      canUpdate: (await formMutationCapabilities(req, 'Sales/Sales Return')).canUpdate,
    }));
  });
  const incomingReplayScope = (req: FastifyRequest) => {
    const query = (req.query ?? {}) as Record<string, unknown>;
    const allowed = new Set(['coCode', 'lcCode', 'coYear', 'coBook']);
    if (
      Object.entries(query).some(
        ([key, value]) => !allowed.has(key) || typeof value !== 'string' || value !== value.trim(),
      )
    )
      throw new SaleReturnIncomingReplayError(
        400,
        'sale-return-replay-query',
        'Use only the selected company, branch, year and Return book to preview this saved return.',
      );
    return savedReturnScope(req);
  };
  app.get('/sales-returns/:vchNo/incoming-replay-state', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, () =>
      getSaleReturnIncomingReplayState(
        prisma,
        incomingReplayScope(req),
        (req.params as { vchNo: string }).vchNo,
      ),
    );
  });
  // This POST replays a journal against a fresh read snapshot. It cannot persist a Return.
  app.post('/sales-returns/:vchNo/incoming-replay', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, () =>
      previewSaleReturnIncomingReplay(
        prisma,
        incomingReplayScope(req),
        (req.params as { vchNo: string }).vchNo,
        req.body,
      ),
    );
  });
  app.get('/sales-returns/:vchNo/incoming-bill-replay-state', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, () =>
      getSaleReturnBillReplayState(
        prisma,
        incomingReplayScope(req),
        (req.params as { vchNo: string }).vchNo,
      ),
    );
  });
  // Read-only whole-grid/header simulation; it cannot persist a Return.
  app.post('/sales-returns/:vchNo/incoming-bill-replay', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, () =>
      previewSaleReturnBillReplay(
        prisma,
        incomingReplayScope(req),
        (req.params as { vchNo: string }).vchNo,
        req.body,
      ),
    );
  });
  // New profile requires an explicitly retained page pair, even though old bootstrap reads allow omission.
  const labourReplayAuth = {
    ...auth,
    onRequest: async (_req: FastifyRequest, reply: FastifyReply) => {
      reply.header('cache-control', 'no-store');
    },
  };
  const labourReplayIdentity = (req: FastifyRequest) => {
    const s = sess(req);
    if (
      req.headers['x-session-context-id'] !== s.sid ||
      req.headers['x-session-context-epoch'] !== s.contextEpoch
    )
      throw new SaleReturnLabourReplayError(
        409,
        'context-stale',
        'Reload the page context before previewing labour selections.',
      );
    return {
      tenantId: s.tenantId,
      sessionId: s.sid,
      loginName: s.sub,
      loginCoCode: s.loginCoCode,
      coCode: s.coCode,
      lcCode: s.lcCode,
      coYear: s.coYear,
      contextEpoch: s.contextEpoch,
    };
  };
  app.get(
    '/sales-returns/:vchNo/incoming-labour-replay-state',
    labourReplayAuth,
    async (req, reply) => {
      reply.header('cache-control', 'no-store');
      if (!guard(req, reply, 'view')) return;
      return run(reply, 200, () =>
        getSaleReturnLabourReplayState(
          prisma,
          labourReplayIdentity(req),
          incomingReplayScope(req),
          (req.params as { vchNo: string }).vchNo,
        ),
      );
    },
  );
  app.post(
    '/sales-returns/:vchNo/incoming-labour-observation',
    { ...labourReplayAuth, bodyLimit: 65536 },
    async (req, reply) => {
      reply.header('cache-control', 'no-store');
      if (!guard(req, reply, 'view')) return;
      return run(reply, 200, () =>
        observeSaleReturnLabourReplayCode(
          prisma,
          labourReplayIdentity(req),
          incomingReplayScope(req),
          (req.params as { vchNo: string }).vchNo,
          req.body,
        ),
      );
    },
  );
  app.post(
    '/sales-returns/:vchNo/incoming-labour-replay',
    { ...labourReplayAuth, bodyLimit: 65536 },
    async (req, reply) => {
      reply.header('cache-control', 'no-store');
      if (!guard(req, reply, 'view')) return;
      return run(reply, 200, () =>
        previewSaleReturnLabourReplay(
          prisma,
          labourReplayIdentity(req),
          incomingReplayScope(req),
          (req.params as { vchNo: string }).vchNo,
          req.body,
        ),
      );
    },
  );
  app.put('/sales-returns/:vchNo/incoming-metadata', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => ({
      ...(await updateSavedSaleReturnMetadata(
        prisma,
        savedReturnScope(req),
        (req.params as any).vchNo,
        body(req),
      )),
      canUpdate: (await formMutationCapabilities(req, 'Sales/Sales Return')).canUpdate,
    }));
  });
  // Strict numeric Sale Return update (card X13, steps 8-9). This routes through the
  // separately versioned updateSaleReturnNumeric coordinator (NOT the generic editSaleReturn
  // and NOT the metadata-only path). RBAC is enforced by guard(...,'update') and the coordinator
  // re-observes every trusted dependency inside its Serializable transaction; the caller's
  // supplied fields grant no authority by themselves. The authenticated operator identity is
  // taken from the session (never trusted from the body), and an explicit whole-second audit
  // time is derived server-side. A stale document/context/master/guard version, a real
  // Serializable (SSI) conflict, an ambiguous ledger key or a cross-year/alias/phantom row all
  // map to a 4xx via SavedSaleReturnError; a fresh saved version is returned on success so the
  // UI can adopt it and preserve draft/conflict state.
  app.put('/sales-returns/:vchNo/incoming-numeric', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => {
      const s = sess(req);
      const b = body(req);
      // Endpoint-side gate is a SUPERSET-safe convenience only: it checks the two body fields
      // are present strings and rejects unknown keys so an obviously malformed request fails
      // fast with a clear message. It intentionally does NOT re-implement the hex/length/charset
      // BOUNDS — those live once in the coordinator's validateRequest, which is the single
      // authoritative validator and denies fail-closed. Because the endpoint's checks are a
      // strict subset of the coordinator's, they cannot drift into ACCEPTING anything the
      // coordinator would reject (at worst the error message differs), so the split is safe.
      if (typeof b.version !== 'string')
        throw new SavedSaleReturnError(
          400,
          'invalid-input',
          'Reload the saved Return and submit its version.',
        );
      if (typeof b.otherAmount !== 'string')
        throw new SavedSaleReturnError(
          400,
          'invalid-input',
          'An explicit c27 Other value is required.',
        );
      if (Object.keys(b).some((key) => !['version', 'otherAmount'].includes(key)))
        throw new SavedSaleReturnError(
          400,
          'invalid-input',
          'The numeric-update request contains unsupported fields.',
        );
      const auditTime = new Date().toISOString().slice(0, 19);
      const result = await updateSaleReturnNumeric(
        prisma,
        savedReturnScope(req),
        (req.params as { vchNo: string }).vchNo,
        {
          version: b.version,
          otherAmount: b.otherAmount,
          actor: { mainUser: s.sub, auditUser: s.sub, auditTime },
        },
      );
      return {
        ...result,
        canUpdate: (await formMutationCapabilities(req, 'Sales/Sales Return')).canUpdate,
      };
    });
  });
  app.post('/sales-returns', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      createSaleReturn(
        prisma,
        {
          scope: scopeOf(req),
          acCode: b.acCode,
          acName: b.acName,
          billNo: b.billNo,
          origVchNo: b.origVchNo,
          origBook: b.origBook,
          vchDate: b.vchDate,
          discountAmount: b.discountAmount,
          taxRatePct: b.taxRatePct,
          taxCode: b.taxCode,
          interState: !!b.interState,
          cashAmt: b.cashAmt != null ? Number(b.cashAmt) : undefined,
          chequeAmt: b.chequeAmt != null ? Number(b.chequeAmt) : undefined,
          cardAmt: b.cardAmt != null ? Number(b.cardAmt) : undefined,
          upiAmt: b.upiAmt != null ? Number(b.upiAmt) : undefined,
          kasar: b.kasar != null ? Number(b.kasar) : undefined,
          cashAc: b.cashAc,
          bankAc: b.bankAc,
          kasarAc: b.kasarAc,
        },
        b.lines ?? [],
      ),
    );
  });
  // G05: the original SALE book is the request's validated book. The page sends it as `coBook`; this
  // route used to ignore that and read `qs.book ?? 'SAL'`, so every import came from a book named SAL.
  app.get('/sales-returns/import', auth, async (req, reply) => {
    const qs = (req.query as any) || {};
    const scope = scopeOf(req);
    if (!scope.coBook) {
      return reply.code(400).send({
        error: 'SaleValidationError',
        message: 'Select the book of the original sale before importing it.',
      });
    }
    return run(reply, 200, () =>
      saleForReturn(prisma, { scope, origVchNo: qs.vchNo, origBook: scope.coBook }),
    );
  });
  app.delete('/sales-returns/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteSaleReturn(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).tenantId,
      }),
    );
  });

  // ---- Sales order ----
  // Retained authenticated request context, never body/query authority or a later cookie.
  const orderCommandIdentity = (req: FastifyRequest) => ({
    tenantId: sess(req).tenantId,
    sessionId: sess(req).sid,
    loginName: sess(req).sub,
    loginCoCode: sess(req).loginCoCode,
    coCode: sess(req).coCode,
    lcCode: sess(req).lcCode,
    coYear: sess(req).coYear,
    contextEpoch: sess(req).contextEpoch,
  });
  const requireOrderVersion = (value: unknown): string => {
    if (typeof value !== 'string' || !/^[a-f0-9]{64}$/.test(value)) {
      const error = new Error(
        'Reload the saved order and submit its version before editing or deleting.',
      );
      error.name = 'SalesOrderValidationError';
      throw error;
    }
    return value;
  };
  const completeSalesOrderInput = (req: FastifyRequest) => {
    const input = salesOrderInput(req);
    if (
      !Array.isArray(input.lines) ||
      input.lines.some(
        (line: any) =>
          !line ||
          typeof line !== 'object' ||
          !Array.isArray(line.components) ||
          line.components.some((child: any) => !child || typeof child !== 'object'),
      )
    ) {
      const error = new Error(
        'Submit the complete Sales Order lines and a components array for every item; use an empty array when there are none.',
      );
      error.name = 'SalesOrderValidationError';
      throw error;
    }
    return input;
  };
  app.get('/sales-orders/configuration', auth, async (req, reply) =>
    run(reply, 200, () => getSalesOrderConfiguration(prisma, scopeOf(req))),
  );
  app.get('/sales-orders/designs', auth, async (req, reply) =>
    run(reply, 200, () => {
      const q = req.query as Record<string, string>;
      return listSalesOrderDesigns(prisma, scopeOf(req) as any, {
        itCode: q.itCode ?? '',
        search: q.search,
        offset: q.offset == null ? undefined : Number(q.offset),
        limit: q.limit == null ? undefined : Number(q.limit),
      });
    }),
  );
  app.get('/sales-orders/design-image', auth, async (req, reply) =>
    run(reply, 200, async () => {
      const q = req.query as Record<string, string>;
      const result = await getSalesOrderDesignImage(prisma, scopeOf(req) as any, {
        itCode: q.itCode ?? '',
        source: {
          prCode: q.prCode ?? '',
          bookName: q.bookName ?? '',
          srNo: Number(q.srNo),
          oldSrNo: q.oldSrNo === '' || q.oldSrNo == null ? null : Number(q.oldSrNo),
          version: q.version ?? '',
        },
      });
      return result.state === 'absent'
        ? result
        : {
            state: 'present',
            mimeType: result.mimeType,
            data: result.bytes.toString('base64'),
            source: result.source,
          };
    }),
  );
  app.post('/sales-orders', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () =>
      createSalesOrderInSession(prisma, {
        identity: orderCommandIdentity(req),
        input: completeSalesOrderInput(req),
      }),
    );
  });
  app.get('/sales-orders', auth, async (req, reply) =>
    run(reply, 200, () => listSalesOrders(prisma, readScope(req) as any)),
  );
  app.put('/sales-orders/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () =>
      editSalesOrderInSession(prisma, {
        identity: {
          tenantId: sess(req).tenantId,
          sessionId: sess(req).sid,
          loginName: sess(req).sub,
          loginCoCode: sess(req).loginCoCode,
          coCode: sess(req).coCode,
          lcCode: sess(req).lcCode,
          coYear: sess(req).coYear,
          contextEpoch: sess(req).contextEpoch,
        },
        input: {
          ...completeSalesOrderInput(req),
          expectedVersion: requireOrderVersion(body(req).expectedVersion),
        },
        voucherNo: (req.params as any).vchNo,
      }),
    );
  });
  app.delete('/sales-orders/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      cancelSalesOrderInSession(prisma, {
        identity: orderCommandIdentity(req),
        input: {
          scope: scopeOf(req),
          expectedVersion: requireOrderVersion(body(req).expectedVersion),
          vchNo: (req.params as any).vchNo,
          deleteUser: sess(req).sub,
        },
      }),
    );
  });
  app.post('/sales-orders/:vchNo/cancel-refund', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const b = body(req);
    return run(reply, 200, () =>
      cancelSalesOrderAdjust(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        paidAc: b.paidAc,
        paidAmt: b.paidAmt != null ? Number(b.paidAmt) : undefined,
        kasarAmt: b.kasarAmt != null ? Number(b.kasarAmt) : undefined,
        kasarAc: b.kasarAc,
        itDesc: b.itDesc,
      }),
    );
  });

  // ---- Tour Order (TR_SALE_ORD.cs with MAIN_BOOK='TOUR ORDER') ----
  app.get('/tour-orders/configuration', auth, async (req, reply) => {
    return run(reply, 200, () => getTourOrderConfiguration(prisma, scopeOf(req)));
  });
  app.post('/tour-orders', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () =>
      createTourOrderInSession(prisma, {
        identity: orderCommandIdentity(req),
        input: salesOrderInput(req),
      }),
    );
  });
  app.get('/tour-orders', auth, async (req, reply) =>
    run(reply, 200, () => listTourOrders(prisma, readScope(req) as any)),
  );
  app.get('/tour-orders/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getTourOrder(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/tour-orders/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () =>
      editTourOrderInSession(prisma, {
        identity: orderCommandIdentity(req),
        input: {
          ...salesOrderInput(req),
          expectedVersion: requireOrderVersion(body(req).expectedVersion),
        },
        voucherNo: (req.params as any).vchNo,
      }),
    );
  });
  app.delete('/tour-orders/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      cancelTourOrderInSession(prisma, {
        identity: orderCommandIdentity(req),
        input: {
          scope: scopeOf(req),
          expectedVersion: requireOrderVersion(body(req).expectedVersion),
          vchNo: (req.params as any).vchNo,
          deleteUser: sess(req).sub,
        },
      }),
    );
  });
  app.post('/labour-invoice', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      createLabourInvoice(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        billNo: b.billNo,
        vchDate: b.vchDate,
        interState: !!b.interState,
        metalTaxPct: b.metalTaxPct != null ? Number(b.metalTaxPct) : undefined,
        labourTaxPct: b.labourTaxPct != null ? Number(b.labourTaxPct) : undefined,
        orderGoldFine: b.orderGoldFine != null ? Number(b.orderGoldFine) : undefined,
        lines: b.lines ?? [],
        cashAmt: b.cashAmt != null ? Number(b.cashAmt) : undefined,
        chequeAmt: b.chequeAmt != null ? Number(b.chequeAmt) : undefined,
        cardAmt: b.cardAmt != null ? Number(b.cardAmt) : undefined,
        upiAmt: b.upiAmt != null ? Number(b.upiAmt) : undefined,
        kasar: b.kasar != null ? Number(b.kasar) : undefined,
        cashAc: b.cashAc,
        bankAc: b.bankAc,
        kasarAc: b.kasarAc,
      }),
    );
  });
  app.delete('/labour-invoice/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteLabourInvoice(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).tenantId,
      }),
    );
  });

  // ---- Invoice (HTML preview or PDF) for a sale ----
  app.get('/sales/invoice', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const data = await invoiceData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'invoice-not-found' });
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    const html = invoiceHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      copy: copyLabel,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="invoice-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  // ---- Purchase ----
  app.get('/purchases/invoice', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    const data = await purchaseBillData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'bill-not-found' });
    const html = purchaseBillHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      copy: copyLabel,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="purchase-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/purchase-quotations/quotation', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    await getPurchaseQuotation(prisma, scope, scope.vchNo);
    const data = await purchaseBillData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'quotation-not-found' });
    const html = purchaseBillHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      title: 'Purchase Quotation',
      partyCaption: 'Supplier',
      footerText:
        'Purchase quotation — subject to confirmation, rate finalisation, and stock receipt.',
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="purchase-quotation-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/karigar/issue-voucher', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    const data = await karigarIssueData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'voucher-not-found' });
    const html = karigarIssueHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      copy: copyLabel,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="karigar-issue-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/sales/credit-note', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const data = await invoiceData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'credit-note-not-found' });
    const html = invoiceHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      title: 'Credit Note — Sales Return',
      copy: q.copy,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="creditnote-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  const orderConfirmation =
    (family: 'SALES ORDER' | 'TOUR ORDER') => async (req: FastifyRequest, reply: FastifyReply) => {
      const q = req.query as any;
      const s = readScope(req);
      if (!s.coYear || !s.coBook || !String(q.vchNo ?? '').trim()) {
        return reply.code(400).send({
          error: 'OrderDocumentValidationError',
          message: 'Order confirmation requires year, book and voucher number',
        });
      }
      let data: Awaited<ReturnType<typeof orderData>>;
      try {
        data = await orderData(prisma, {
          family,
          tenantId: s.tenantId,
          coCode: s.coCode,
          lcCode: s.lcCode,
          coYear: s.coYear ?? '',
          coBook: String(s.coBook ?? ''),
          vchNo: String(q.vchNo ?? ''),
        });
      } catch (error: any) {
        if (/ValidationError|NumberingConfigurationError/.test(error?.name ?? '')) {
          return reply.code(400).send({ error: error.name, message: error.message });
        }
        throw error;
      }
      if (!data) return reply.code(404).send({ error: 'order-not-found' });
      const name = data.lines.length
        ? family === 'TOUR ORDER'
          ? data.imagePrint
            ? 'TourOrdImg'
            : 'TourOrdVch'
          : data.imagePrint
            ? 'OrdVchImg'
            : 'OrderBill'
        : 'OrderVch';
      const spec = loadReportSpec(name);
      if (!spec) return reply.code(503).send({ error: 'order-report-spec-unavailable' });
      if (q.copy != null && !Object.hasOwn(ORDER_REPORT_COPIES, String(q.copy))) {
        return reply
          .code(400)
          .send({ error: 'OrderDocumentValidationError', message: 'Invalid order document copy.' });
      }
      let bound: Awaited<ReturnType<typeof bindReport>>;
      try {
        bound = await bindReport(prisma, spec, {
          tenantId: s.tenantId,
          coCode: s.coCode,
          lcCode: s.lcCode,
          coYear: s.coYear,
          coBook: String(s.coBook),
          vchNo: String(q.vchNo),
          orderFamily: family,
          copy: q.copy as OrderReportCopy | undefined,
        });
      } catch (error) {
        if (error instanceof UnsupportedReportBindingError) {
          return reply
            .code(422)
            .send({ error: error.code, report: error.report, reason: error.reason });
        }
        if (/ValidationError|NumberingConfigurationError/.test((error as Error).name)) {
          return reply
            .code(400)
            .send({ error: (error as Error).name, message: (error as Error).message });
        }
        throw error;
      }
      if (!bound) return reply.code(404).send({ error: 'order-not-found' });
      let html: string;
      try {
        html = renderReportLayout(spec, {
          header: bound.header,
          detailRows: bound.detailRows,
          parentChild: bound.parentChild,
          subreports: bound.subreports,
          company: bound.company,
          orderImages: bound.orderImages,
        });
      } catch (error) {
        if (error instanceof UnsupportedReportBindingError) {
          return reply
            .code(422)
            .send({ error: error.code, report: error.report, reason: error.reason });
        }
        throw error;
      }
      if (q.format === 'html') return reply.type('text/html').send(html);
      let pdf: Buffer;
      try {
        pdf = await renderToPdf(html, new PlaywrightPdfRenderer({ preferCSSPageSize: true }));
      } catch {
        return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
      }
      return reply
        .header('content-type', 'application/pdf')
        .header(
          'content-disposition',
          `inline; filename="order-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
        )
        .send(pdf);
    };
  app.get('/sales/order-confirmation', auth, orderConfirmation('SALES ORDER'));
  app.get('/tour-orders/confirmation', auth, orderConfirmation('TOUR ORDER'));

  const savedOrderImage =
    (family: OrderImageFamily) => async (req: FastifyRequest, reply: FastifyReply) =>
      run(reply, 200, async () => {
        const result = await getOrderImage(
          prisma,
          scopeOf(req) as OrderImageScope,
          family,
          String((req.params as any).vchNo),
          Number((req.query as any).srNo),
        );
        const s = sess(req);
        const principal = await loadPrincipal(prisma, {
          tenantId: s.tenantId,
          coCode: s.coCode,
          loginCoCode: s.loginCoCode,
          loginName: s.sub,
        });
        const may = async (action: 'update' | 'delete') => {
          try {
            await authorizeForm(prisma, {
              tenantId: s.tenantId,
              lcCode: s.lcCode,
              principal,
              form: family === 'SALES ORDER' ? 'Sales/Sales Order' : 'Karigar/Tour Order',
              action,
            });
            return true;
          } catch (error) {
            if (error instanceof FormForbiddenError) return false;
            throw error;
          }
        };
        const [mayUpdate, mayDelete] = await Promise.all([may('update'), may('delete')]);
        return {
          ...result,
          canUpdate: result.editable && mayUpdate,
          canDelete: result.editable && result.targetHasImage && mayDelete,
          image:
            result.image.state === 'present'
              ? {
                  state: 'present',
                  mimeType: result.image.mimeType,
                  source: result.image.source,
                  data: result.image.bytes.toString('base64'),
                }
              : result.image,
        };
      });
  const writeOrderImage =
    (family: OrderImageFamily, remove = false) =>
    async (req: FastifyRequest, reply: FastifyReply) =>
      run(reply, 200, () => {
        const input = remove ? (req.query as any) : (req.body as any);
        return changeOrderImage(
          prisma,
          scopeOf(req) as OrderImageScope,
          family,
          String((req.params as any).vchNo),
          Number((req.query as any).srNo),
          {
            version: String(input?.version ?? ''),
            data: input?.data,
            mimeType: input?.mimeType,
            remove,
            user: sess(req).sub,
          },
        );
      });
  app.get('/sales-orders/:vchNo/image', auth, savedOrderImage('SALES ORDER'));
  app.post(
    '/sales-orders/:vchNo/image',
    { ...auth, bodyLimit: 6 * 1024 * 1024 },
    writeOrderImage('SALES ORDER'),
  );
  app.delete('/sales-orders/:vchNo/image', auth, writeOrderImage('SALES ORDER', true));
  app.get('/tour-orders/:vchNo/image', auth, savedOrderImage('TOUR ORDER'));
  app.post(
    '/tour-orders/:vchNo/image',
    { ...auth, bodyLimit: 6 * 1024 * 1024 },
    writeOrderImage('TOUR ORDER'),
  );
  app.delete('/tour-orders/:vchNo/image', auth, writeOrderImage('TOUR ORDER', true));

  const lotSettings =
    (kind: 'issue' | 'receive') => async (req: FastifyRequest, reply: FastifyReply) =>
      run(reply, 200, () => getMfgLotSettings(prisma, scopeOf(req), kind));
  const lotList = (kind: 'issue' | 'receive') => async (req: FastifyRequest, reply: FastifyReply) =>
    run(reply, 200, () => listMfgLots(prisma, scopeOf(req), kind, req.query as any));
  const lotSources =
    (kind: 'issue' | 'receive') => async (req: FastifyRequest, reply: FastifyReply) =>
      run(reply, 200, () => listMfgLotSources(prisma, scopeOf(req), kind, req.query as any));
  const lotDocument =
    (kind: 'issue' | 'receive') => async (req: FastifyRequest, reply: FastifyReply) => {
      try {
        const document = await getMfgLot(
          prisma,
          scopeOf(req),
          kind,
          String((req.params as any).vchNo),
        );
        if (!document) return reply.code(404).send({ error: 'lot-voucher-not-found' });
        return reply.code(200).send(document);
      } catch (error) {
        return run(reply, 200, async () => {
          throw error;
        });
      }
    };
  app.get('/mfg/lot/issue/settings', auth, lotSettings('issue'));
  app.get('/mfg/lot/issue/list', auth, lotList('issue'));
  app.get('/mfg/lot/issue/sources', auth, lotSources('issue'));
  app.get('/mfg/lot/issue/:vchNo', auth, lotDocument('issue'));
  app.get('/mfg/lot/receive/settings', auth, lotSettings('receive'));
  app.get('/mfg/lot/receive/list', auth, lotList('receive'));
  app.get('/mfg/lot/receive/sources', auth, lotSources('receive'));
  app.get('/mfg/lot/receive/:vchNo', auth, lotDocument('receive'));

  app.get('/sales/quotation', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const data = await invoiceData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'quotation-not-found' });
    const html = invoiceHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      title: 'Estimate / Quotation',
      copy: 'PROFORMA — NOT A TAX INVOICE',
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="quotation-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/sales-quotations/quotation', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    await getSalesQuotation(prisma, scope, scope.vchNo);
    const data = await invoiceData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'quotation-not-found' });
    const html = invoiceHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      title: 'Sales Quotation',
      copy: 'PROFORMA — NOT A TAX INVOICE',
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="sales-quotation-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/finance/receipt-voucher', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const data = await financeVoucherData(prisma, 'receipt', scope);
    if (!data) return reply.code(404).send({ error: 'voucher-not-found' });
    const html = financeVoucherHtml('receipt', data.header, data.lines, {
      company: data.company,
      party: data.party,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="receipt-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/finance/payment-voucher', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const data = await financeVoucherData(prisma, 'payment', scope);
    if (!data) return reply.code(404).send({ error: 'voucher-not-found' });
    const html = financeVoucherHtml('payment', data.header, data.lines, {
      company: data.company,
      party: data.party,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="payment-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  const purchaseInput = (req: FastifyRequest, b: Record<string, any>) => ({
    scope: scopeOf(req),
    mainUser: sess(req).sub,
    acCode: b.acCode,
    acName: b.acName,
    billNo: b.billNo,
    vchDate: b.vchDate,
    address1: b.address1,
    address2: b.address2,
    address3: b.address3,
    city: b.city,
    mobile: b.mobile,
    bankName: b.bankName,
    chequeNo: b.chequeNo,
    cardAc: b.cardAc,
    creditDays: b.creditDays != null ? Number(b.creditDays) : undefined,
    discountPct: b.discountPct != null ? Number(b.discountPct) : undefined,
    tcsCode: b.tcsCode,
    tcsPct: b.tcsPct != null ? Number(b.tcsPct) : undefined,
    tcsAmount: b.tcsAmount != null ? Number(b.tcsAmount) : undefined,
    tdsCode: b.tdsCode,
    tdsPct: b.tdsPct != null ? Number(b.tdsPct) : undefined,
    tdsAmount: b.tdsAmount != null ? Number(b.tdsAmount) : undefined,
    saleBillNo: b.saleBillNo,
    saleBillLc: b.saleBillLc,
    saleBillYear: b.saleBillYear,
    saleBillBook: b.saleBillBook,
    consiNo: b.consiNo,
    consiLcCode: b.consiLcCode,
    consiYrcd: b.consiYrcd,
    consiDbcd: b.consiDbcd,
    discountAmount: b.discountAmount,
    taxRatePct: b.taxRatePct,
    taxCode: b.taxCode,
    interState: !!b.interState,
    urd: !!b.urd,
    rateUnfix: !!b.rateUnfix,
    purchaseAc: b.purchaseAc,
    taxAc: b.taxAc,
    roundAc: b.roundAc,
    hmAmount: b.hmAmount != null ? Number(b.hmAmount) : undefined,
    hmChargeAc: b.hmChargeAc,
    hmTaxPct: b.hmTaxPct != null ? Number(b.hmTaxPct) : undefined,
    cashAmt: b.cashAmt != null ? Number(b.cashAmt) : undefined,
    chequeAmt: b.chequeAmt != null ? Number(b.chequeAmt) : undefined,
    cardAmt: b.cardAmt != null ? Number(b.cardAmt) : undefined,
    upiAmt: b.upiAmt != null ? Number(b.upiAmt) : undefined,
    kasar: b.kasar != null ? Number(b.kasar) : undefined,
    cashAc: b.cashAc,
    bankAc: b.bankAc,
    kasarAc: b.kasarAc,
  });
  app.post('/purchases', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createPurchase(prisma, purchaseInput(req, b), b.lines ?? []));
  });
  app.get('/purchases/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getPurchase(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/purchases/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editPurchase(prisma, purchaseInput(req, b), b.lines ?? [], (req.params as any).vchNo),
    );
  });
  app.delete('/purchases/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePurchase(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  app.get('/consignment-purchases/open-receipts', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      listOpenConsignmentPurchaseReceipts(prisma, scopeOf(req), {
        sourceVchNo: q.sourceVchNo,
        sourceCoYear: q.sourceCoYear,
        sourceCoBook: q.sourceCoBook,
      }),
    );
  });
  app.post('/consignment-purchases', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createPurchase(prisma, purchaseInput(req, b), b.lines ?? []));
  });
  app.get('/consignment-purchases/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getPurchase(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/consignment-purchases/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editPurchase(prisma, purchaseInput(req, b), b.lines ?? [], (req.params as any).vchNo),
    );
  });
  app.delete('/consignment-purchases/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePurchase(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  app.post('/purchase-quotations', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      createPurchaseQuotation(prisma, purchaseInput(req, b), b.lines ?? []),
    );
  });
  app.get('/purchase-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getPurchaseQuotation(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  app.put('/purchase-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editPurchaseQuotation(
        prisma,
        purchaseInput(req, b),
        b.lines ?? [],
        (req.params as any).vchNo,
      ),
    );
  });
  app.delete('/purchase-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePurchaseQuotation(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  const otherIncomeInput = (req: FastifyRequest, b: Record<string, any>) => ({
    scope: scopeOf(req),
    vchDate: b.vchDate,
    partyCode: b.partyCode ?? b.acCode,
    billNo: b.billNo,
    billDate: b.billDate,
    ledgerCode: b.ledgerCode ?? b.ledrCode,
    chequeAmount: b.chequeAmount != null ? Number(b.chequeAmount) : undefined,
    chequeAccount: b.chequeAccount,
    chequeNo: b.chequeNo,
    cardAmount: b.cardAmount != null ? Number(b.cardAmount) : undefined,
    cardAccount: b.cardAccount,
    cashAmount: b.cashAmount != null ? Number(b.cashAmount) : undefined,
    cashAccount: b.cashAccount,
    kasarAmount: b.kasarAmount != null ? Number(b.kasarAmount) : undefined,
    kasarAccount: b.kasarAccount,
    tdsCode: b.tdsCode,
    employeeCode: b.employeeCode,
    bankName: b.bankName,
    description: b.description,
    lines: b.lines ?? [],
    mainUser: sess(req).sub,
  });
  // Desktop TR_OTH_PURC in both modes (MDI_FORM.cs:8372-8394): "Other Expenses" on an OTH EXP book and
  // "Other Income" on an OTH INC book. One writer posts both through the desktop's mirrored
  // Oth_Purc_Ledr / Oth_Purc_Rojmel / Oth_Purc_GST routines; each menu keeps its own route and right.
  const otherPurcHandlers = (mode: OtherPurcMode) => ({
    create: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'create')) return;
      const b = body(req);
      return run(reply, 201, () => saveOtherPurc(prisma, mode, otherIncomeInput(req, b)));
    },
    read: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'view')) return;
      return run(reply, 200, () =>
        getOtherPurc(prisma, mode, readScope(req), String((req.params as any).vchNo)),
      );
    },
    update: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'update')) return;
      const b = body(req);
      return run(reply, 200, () =>
        saveOtherPurc(prisma, mode, otherIncomeInput(req, b), String((req.params as any).vchNo)),
      );
    },
    remove: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'delete')) return;
      return run(reply, 200, () =>
        deleteOtherPurc(
          prisma,
          mode,
          scopeOf(req),
          String((req.params as any).vchNo),
          sess(req).sub,
        ),
      );
    },
    // TR_OTH_PURC prints PaymentVch.RPT for both modes (TR_OTH_PURC.cs BtnPrint_Click): the same PAY_DATA /
    // PAY_DETL voucher the payment screen prints. The book is validated against the mode before printing.
    print: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'view')) return;
      const q = req.query as any;
      // The voucher number is a PATH param here (/other-purchase/:vchNo/print), not a query param, so
      // build the document scope from it rather than the query-based documentScope() helper.
      const s = readScope(req);
      let scope;
      try {
        scope = requireVoucherDocumentScope({
          tenantId: s.tenantId,
          coCode: s.coCode,
          lcCode: s.lcCode,
          coYear: s.coYear,
          coBook: s.coBook,
          vchNo: String((req.params as any).vchNo ?? ''),
        });
      } catch (e: any) {
        if (e instanceof DocumentScopeError)
          return reply.code(400).send({ error: e.name, field: e.field, message: e.message });
        throw e;
      }
      const vchNo = String(scope.vchNo);
      try {
        await getOtherPurc(prisma, mode, scope, vchNo);
      } catch (e: any) {
        if (e?.name !== 'OtherIncomeValidationError') throw e;
        return reply.code(404).send({ error: e.name, message: e.message });
      }
      const data = await financeVoucherData(prisma, 'payment', { ...scope, vchNo });
      if (!data) return reply.code(404).send({ error: 'voucher-not-found' });
      const html = financeVoucherHtml('payment', data.header, data.lines, {
        company: data.company,
        party: data.party,
      });
      if (q.format === 'html') return reply.type('text/html').send(html);
      let pdf: Buffer;
      try {
        pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
      } catch {
        return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
      }
      return reply
        .header('content-type', 'application/pdf')
        .header(
          'content-disposition',
          `inline; filename="voucher-${vchNo.replace(/[^\w.-]/g, '')}.pdf"`,
        )
        .send(pdf);
    },
  });
  const otherExpense = otherPurcHandlers('OTH EXP');
  app.post('/other-purchase', auth, otherExpense.create);
  app.get('/other-purchase/:vchNo', auth, otherExpense.read);
  app.put('/other-purchase/:vchNo', auth, otherExpense.update);
  app.delete('/other-purchase/:vchNo', auth, otherExpense.remove);
  app.get('/other-purchase/:vchNo/print', auth, otherExpense.print);
  const otherIncome = otherPurcHandlers('OTH INC');
  app.post('/other-income', auth, otherIncome.create);
  app.get('/other-income/:vchNo', auth, otherIncome.read);
  app.put('/other-income/:vchNo', auth, otherIncome.update);
  app.delete('/other-income/:vchNo', auth, otherIncome.remove);
  app.get('/other-income/:vchNo/print', auth, otherIncome.print);

  // ---- Purchase return ----
  // No JSON Schema yet: no route in this file has one until decision D16 is accepted (N50).
  app.post('/purchase-returns', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    const input = purchaseReturnInputFromBody(scopeOf(req), sess(req).sub, b);
    return run(reply, 201, () => createPurchaseReturn(prisma, input, b.lines ?? []));
  });
  app.put('/purchase-returns/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    const input = purchaseReturnInputFromBody(scopeOf(req), sess(req).sub, b);
    return run(reply, 200, () =>
      editPurchaseReturn(prisma, input, b.lines ?? [], (req.params as any).vchNo),
    );
  });
  app.get('/purchase-returns/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getPurchaseReturn(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  app.get('/purchase-returns/:vchNo/print', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = req.query as any;
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    const scope = resolvePrintScope(reply, readScope(req), (req.params as any).vchNo);
    if (!scope) return reply;
    await getPurchaseReturn(prisma, scope, scope.vchNo);
    const data = await purchaseBillData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'purchase-return-not-found' });
    const html = purchaseBillHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      copy: copyLabel,
      title: 'Purchase Return',
      partyCaption: 'Supplier',
      footerText: 'Purchase return — goods and value returned to supplier.',
    });
    return sendVoucherDocument(reply, html, {
      format: q.format,
      filename: `purchase-return-${scope.vchNo}`,
    });
  });
  app.delete('/purchase-returns/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePurchaseReturn(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Finance (receipt / payment / contra) ----
  app.post('/receipts', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postReceipt(prisma, {
        scope: scopeOf(req),
        partyAc: b.partyAc,
        partyName: b.partyName,
        amount: b.amount,
        mode: b.mode,
        bankAc: b.bankAc,
        chqNo: b.chqNo,
        // The operator's voucher date (TR_CASH mVchDate); the writers default to today when absent.
        vchDate: b.vchDate,
        cardCommissionPct: b.cardCommissionPct != null ? Number(b.cardCommissionPct) : undefined,
        bankName: b.bankName,
        upiId: b.upiId,
        kasar: b.kasar != null ? Number(b.kasar) : undefined,
        kasarAc: b.kasarAc,
      }),
    );
  });
  app.post('/payments', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postPayment(prisma, {
        scope: scopeOf(req),
        partyAc: b.partyAc,
        partyName: b.partyName,
        amount: b.amount,
        mode: b.mode,
        bankAc: b.bankAc,
        chqNo: b.chqNo,
        vchDate: b.vchDate,
        kasar: b.kasar != null ? Number(b.kasar) : undefined,
        kasarAc: b.kasarAc,
      }),
    );
  });
  app.post('/contra', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postContra(prisma, {
        scope: scopeOf(req),
        fromAc: b.fromAc,
        toAc: b.toAc,
        amount: b.amount,
        vchDate: b.vchDate,
        itDesc: b.itDesc,
      }),
    );
  });
  app.get('/finance/cheque-print', auth, async (req, reply) => {
    const qy = (req.query as any) || {};
    return reply.type('text/html').send(
      renderCheque({
        payee: String(qy.payee ?? ''),
        amount: Number(qy.amount ?? 0),
        date: qy.date,
        chqNo: qy.chqNo,
        acPayee: qy.acPayee === 'true' || qy.acPayee === '1',
        autoPrint: qy.autoPrint === 'true' || qy.autoPrint === '1',
      }),
    );
  });
  app.post('/receipts/multi', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postReceiptLines(prisma, {
        scope: scopeOf(req),
        mode: b.mode,
        bankAc: b.bankAc,
        chqNo: b.chqNo,
        vchDate: b.vchDate,
        kasarAc: b.kasarAc,
        empCode: b.empCode,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/receipts/multi/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteReceiptLines(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).tenantId,
      }),
    );
  });
  /**
   * Single receipt / payment deletion — plan item F1.3.
   *
   * WHY THESE EXIST
   * ===============
   * Reversal existed only for the MULTI variants above, yet the single voucher is the common case and the one
   * the business actually deletes. From `DELETE_DATA` on the real database: **CASH REC 4, CASH PAY 3,
   * BANK PAY 5, BANK REC 1 — 13 deletions**, against zero rows in `USER_DATA`, the edit audit. Correction here
   * is delete-and-re-enter, and it was impossible.
   *
   * THE TWO SIDES USE DIFFERENT HEADER TABLES — this is easy to get wrong.
   *   `postReceipt` writes CASH_DATA (finance.ts:249)
   *   `postPayment` writes PAY_DATA  (finance.ts:512)
   * A receipt-shaped delete pointed at a payment would silently reverse nothing and still report success.
   *
   * The receipt side has a purpose-built `deleteReceipt` (finance.ts:1286) that reads the persisted header
   * through `editIdentityTx` and reverses RECEIPT_WRITE_TABLES, so it needs no VCH_TYPE from the caller.
   * The payment side has no equivalent, so it goes through the generic `deleteFinance` and must state both
   * the header table and the audit classification.
   */
  app.delete('/receipts/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteReceipt(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
        book: body(req).book,
      }),
    );
  });
  app.post('/payments/multi', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postPaymentLines(prisma, {
        scope: scopeOf(req),
        mode: b.mode,
        bankAc: b.bankAc,
        chqNo: b.chqNo,
        vchDate: b.vchDate,
        kasarAc: b.kasarAc,
        empCode: b.empCode,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/payments/multi/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePaymentLines(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).tenantId,
      }),
    );
  });
  /**
   * Single payment deletion — plan item F1.3. See the receipt delete above for why the two differ.
   *
   * `headerTable: 'PAY_DATA'` is not interchangeable with the receipt's CASH_DATA: `postPayment` writes
   * PAY_DATA (finance.ts:512). `mode` is required rather than defaulted because the audit's VCH_TYPE is how
   * the desktop classifies the deletion — CPAY for cash, BPAY for bank (finance.ts:523) — and BANK PAY has
   * MORE real deletions than CASH PAY (5 against 3), so there is no safe majority to assume.
   */
  app.delete('/payments/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const b = body(req);
    const mode = String(b.mode ?? '')
      .trim()
      .toLowerCase();
    if (mode !== 'cash' && mode !== 'bank') {
      return reply.code(400).send({ error: "mode must be 'cash' or 'bank'" });
    }
    return run(reply, 200, () =>
      deleteFinance(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        headerTable: 'PAY_DATA',
        book: String(b.book ?? 'PAY'),
        vchType: mode === 'cash' ? 'CPAY' : 'BPAY',
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Dhrn (pledge loans) ----
  app.get('/dhrn/issue-receipt', auth, async (req, reply) => {
    const q = req.query as any;
    const scope = documentScope(req, reply);
    if (!scope) return reply;
    const data = await dhrnIssueData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'dhrn-not-found' });
    const html = dhrnIssueHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="dhrn-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/scheme/passbook', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await schemePassbookData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      schmCode: String(q.schmCode ?? ''),
      membCode: String(q.membCode ?? ''),
    });
    if (!data) return reply.code(404).send({ error: 'member-not-found' });
    const html = schemePassbookHtml(data.member, data.scheme, data.installments, {
      company: data.company,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="passbook-${String(q.membCode ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/dhrn/khata', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await dhrnKhataData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      acCode: String(q.acCode ?? ''),
    });
    const html = dhrnKhataHtml(data.rows, data.party, {
      company: data.company,
      period: [q.fromDate, q.toDate].filter(Boolean).join(' — '),
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="khata-${String(q.acCode ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  const dhrnIssuePayload = (req: any, b: any) => ({
    scope: scopeOf(req),
    borrowerAc: b.borrowerAc,
    borrowerName: b.borrowerName,
    principal: Number(b.principal),
    intPrc: b.intPrc != null ? Number(b.intPrc) : undefined,
    intMonths: b.intMonths != null ? Number(b.intMonths) : undefined,
    loanType: b.loanType,
    packetNo: b.packetNo,
    otherCharges: b.otherCharges != null ? Number(b.otherCharges) : undefined,
    goldWt: b.goldWt != null ? Number(b.goldWt) : undefined,
    goldAmt: b.goldAmt != null ? Number(b.goldAmt) : undefined,
    vchDate: b.vchDate,
    fromDate: b.fromDate,
    toDate: b.toDate,
    loanAc: b.loanAc,
    cashAc: b.cashAc,
    licenceNo: b.licenceNo,
    remarks: b.remarks,
    adjustedDhrn: b.adjustedDhrn != null ? Number(b.adjustedDhrn) : undefined,
    uncheckedReceipts: b.uncheckedReceipts != null ? Number(b.uncheckedReceipts) : undefined,
    collateral: b.collateral,
  });
  const dhrnReceiptPayload = (req: any, b: any) => ({
    scope: scopeOf(req),
    isuNo: b.isuNo,
    borrowerAc: b.borrowerAc,
    borrowerName: b.borrowerName,
    principalRepaid: Number(b.principalRepaid),
    interest: b.interest != null ? Number(b.interest) : undefined,
    intPrc: b.intPrc != null ? Number(b.intPrc) : undefined,
    loanAc: b.loanAc,
    cashAc: b.cashAc,
    intIncAc: b.intIncAc,
    vchDate: b.vchDate,
    billNo: b.billNo,
    fromDate: b.fromDate,
    toDate: b.toDate,
    packetNo: b.packetNo,
    dhrnDate: b.dhrnDate,
    loanType: b.loanType,
    dhrnAdjustAmount: b.dhrnAdjustAmount != null ? Number(b.dhrnAdjustAmount) : undefined,
    advanceDhiranReceipt:
      b.advanceDhiranReceipt != null ? Number(b.advanceDhiranReceipt) : undefined,
    dhrnMonths: b.dhrnMonths != null ? Number(b.dhrnMonths) : undefined,
    interestKasar: b.interestKasar != null ? Number(b.interestKasar) : undefined,
    interestDays: b.interestDays != null ? Number(b.interestDays) : undefined,
    interestMonths: b.interestMonths != null ? Number(b.interestMonths) : undefined,
    empCode: b.empCode,
    goldAmount: b.goldAmount != null ? Number(b.goldAmount) : undefined,
    goldWeight: b.goldWeight != null ? Number(b.goldWeight) : undefined,
    vchDesc: b.vchDesc,
    panAdjustAmount: b.panAdjustAmount != null ? Number(b.panAdjustAmount) : undefined,
    adjustInterest: b.adjustInterest != null ? Number(b.adjustInterest) : undefined,
    adjustDhiran: b.adjustDhiran != null ? Number(b.adjustDhiran) : undefined,
    rateCutRate: b.rateCutRate != null ? Number(b.rateCutRate) : undefined,
    rateCutAmount: b.rateCutAmount != null ? Number(b.rateCutAmount) : undefined,
    rateCutPayAmount: b.rateCutPayAmount != null ? Number(b.rateCutPayAmount) : undefined,
    rateCutOsAmount: b.rateCutOsAmount != null ? Number(b.rateCutOsAmount) : undefined,
    items: b.items,
    isuBook: b.isuBook,
    isuYear: b.isuYear,
  });

  app.post('/dhrn/issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => issueDhrn(prisma, dhrnIssuePayload(req, b)));
  });
  app.post('/dhrn/receipt', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => receiveDhrn(prisma, dhrnReceiptPayload(req, b)));
  });
  app.post('/loan/received', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => receiveLoan(prisma, dhrnIssuePayload(req, b)));
  });
  app.post('/loan/issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => issueLoan(prisma, dhrnReceiptPayload(req, b)));
  });
  app.get('/dhrn/:isuNo/outstanding', auth, async (req) => ({
    isuNo: (req.params as any).isuNo,
    outstanding: await outstanding(prisma, readScope(req) as any, (req.params as any).isuNo),
  }));
  app.get('/loan/:isuNo/outstanding', auth, async (req) => ({
    isuNo: (req.params as any).isuNo,
    outstanding: await outstanding(prisma, readScope(req) as any, (req.params as any).isuNo),
  }));
  app.post('/dhrn/interest', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      receiveDhrnInterest(prisma, {
        scope: scopeOf(req),
        isuNo: b.isuNo,
        borrowerAc: b.borrowerAc,
        borrowerName: b.borrowerName,
        interest: b.interest != null ? Number(b.interest) : undefined,
        intPrc: b.intPrc,
        vchDate: b.vchDate,
      }),
    );
  });
  app.post('/inout/fine', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      fineInout(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        direction: b.direction,
        partyAc: b.partyAc,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/inout/fine/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteFineInout(prisma, scopeOf(req) as any, (req.params as any).vchNo, body(req).book),
    );
  });

  // ---- Customer repair receipt (TR_REP_REC / CUSTREP RECEIPT only) ----
  app.post('/repair-receipts', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveCustomerRepairReceipt(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/repair-receipts', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listCustomerRepairReceipts(prisma, readScope(req), Number(q.limit ?? 50)),
    );
  });
  app.get('/repair-receipts/:vchNo/print', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    const data = await customerRepairReceiptDocumentData(
      prisma,
      readScope(req),
      (req.params as any).vchNo,
    );
    if (!data) return reply.code(404).send({ error: 'repair-receipt-not-found' });
    const html = customerRepairReceiptHtml(data.receipt, {
      company: data.company,
      party: data.party,
      copy: q.copy ? String(q.copy) : undefined,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="repair-receipt-${String((req.params as any).vchNo).replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });
  app.get('/repair-receipts/:vchNo', auth, async (req, reply) => {
    const data = await getCustomerRepairReceipt(prisma, readScope(req), (req.params as any).vchNo);
    return data
      ? reply.code(200).send(data)
      : reply.code(404).send({ error: 'repair-receipt-not-found' });
  });
  app.put('/repair-receipts/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveCustomerRepairReceipt(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/repair-receipts/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteCustomerRepairReceipt(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Repair workflow stage 2 (TR_REP_REC / KRREP ISSUE only) ----
  app.post('/repair-karigar-issues', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveKarigarRepairIssue(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/repair-karigar-issues', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listKarigarRepairIssues(prisma, readScope(req), Number(q.limit ?? 50)),
    );
  });
  app.get('/repair-karigar-issues/open-lines', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listOpenCustomerRepairLines(prisma, readScope(req), String(q.q ?? ''), Number(q.limit ?? 50)),
    );
  });
  app.get('/repair-karigar-issues/:vchNo/print', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    const data = await karigarRepairIssueDocumentData(
      prisma,
      readScope(req),
      (req.params as any).vchNo,
    );
    if (!data) return reply.code(404).send({ error: 'repair-karigar-issue-not-found' });
    const html = karigarRepairIssueHtml(data.issue, {
      company: data.company,
      party: data.party,
      copy: q.copy ? String(q.copy) : undefined,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="repair-karigar-issue-${String((req.params as any).vchNo).replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });
  app.get('/repair-karigar-issues/:vchNo', auth, async (req, reply) => {
    const data = await getKarigarRepairIssue(prisma, readScope(req), (req.params as any).vchNo);
    return data
      ? reply.code(200).send(data)
      : reply.code(404).send({ error: 'repair-karigar-issue-not-found' });
  });
  app.put('/repair-karigar-issues/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveKarigarRepairIssue(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/repair-karigar-issues/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteKarigarRepairIssue(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Repair workflow stage 3 (TR_REP_REC / KRREP RECEIPT only) ----
  app.post('/repair-karigar-receipts', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveKarigarRepairReceipt(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        discountPct: b.discountPct,
        taxCode: b.taxCode,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        kasarAmount: b.kasarAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/repair-karigar-receipts', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listKarigarRepairReceipts(prisma, readScope(req), Number(q.limit ?? 50)),
    );
  });
  app.get('/repair-karigar-receipts/open-lines', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listOpenKarigarRepairIssueLines(
        prisma,
        readScope(req),
        String(q.acCode ?? ''),
        String(q.q ?? ''),
        Number(q.limit ?? 50),
      ),
    );
  });
  app.get('/repair-karigar-receipts/:vchNo/print', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    const data = await karigarRepairReceiptDocumentData(
      prisma,
      readScope(req),
      (req.params as any).vchNo,
    );
    if (!data) return reply.code(404).send({ error: 'repair-karigar-receipt-not-found' });
    const html = karigarRepairReceiptHtml(data.receipt, {
      company: data.company,
      party: data.party,
      copy: q.copy ? String(q.copy) : undefined,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="repair-karigar-receipt-${String((req.params as any).vchNo).replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });
  app.get('/repair-karigar-receipts/:vchNo', auth, async (req, reply) => {
    const data = await getKarigarRepairReceipt(prisma, readScope(req), (req.params as any).vchNo);
    return data
      ? reply.code(200).send(data)
      : reply.code(404).send({ error: 'repair-karigar-receipt-not-found' });
  });
  app.put('/repair-karigar-receipts/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveKarigarRepairReceipt(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        discountPct: b.discountPct,
        taxCode: b.taxCode,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        kasarAmount: b.kasarAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/repair-karigar-receipts/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteKarigarRepairReceipt(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Repair workflow stage 4 (TR_REP_REC / CUSTREP ISSUE only) ----
  app.post('/repair-customer-issues', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveCustomerRepairIssue(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        discountPct: b.discountPct,
        taxCode: b.taxCode,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        kasarAmount: b.kasarAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/repair-customer-issues', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listCustomerRepairIssues(prisma, readScope(req), Number(q.limit ?? 50)),
    );
  });
  app.get('/repair-customer-issues/open-lines', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listOpenCustomerRepairDeliveries(
        prisma,
        readScope(req),
        String(q.acCode ?? ''),
        String(q.q ?? ''),
        Number(q.limit ?? 50),
      ),
    );
  });
  app.get('/repair-customer-issues/:vchNo/print', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    const data = await customerRepairIssueDocumentData(
      prisma,
      readScope(req),
      (req.params as any).vchNo,
    );
    if (!data) return reply.code(404).send({ error: 'repair-customer-issue-not-found' });
    const html = customerRepairIssueHtml(data.issue, {
      company: data.company,
      party: data.party,
      copy: q.copy ? String(q.copy) : undefined,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="repair-customer-issue-${String((req.params as any).vchNo).replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });
  app.get('/repair-customer-issues/:vchNo', auth, async (req, reply) => {
    const data = await getCustomerRepairIssue(prisma, readScope(req), (req.params as any).vchNo);
    return data
      ? reply.code(200).send(data)
      : reply.code(404).send({ error: 'repair-customer-issue-not-found' });
  });
  app.put('/repair-customer-issues/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveCustomerRepairIssue(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        acCode: b.acCode,
        acName: b.acName,
        vchDate: b.vchDate,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        bankName: b.bankName,
        description: b.description,
        discountPct: b.discountPct,
        taxCode: b.taxCode,
        chequeAmount: b.chequeAmount,
        chequeAccount: b.chequeAccount,
        chequeNo: b.chequeNo,
        cardAmount: b.cardAmount,
        cardAccount: b.cardAccount,
        cashAmount: b.cashAmount,
        kasarAmount: b.kasarAmount,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/repair-customer-issues/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteCustomerRepairIssue(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Repair line images (desktop TR_REP_REC "ReparingImage" attachments) ----
  app.get('/repair-images/state', auth, async (req, reply) => {
    reply.header('cache-control', 'no-store');
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, async () => ({
      ...(await getRepairImageState(prisma, readScope(req), {
        coBook: String(q.imageBook ?? q.coBook ?? ''),
        vchNo: String(q.vchNo ?? ''),
        srNo: String(q.srNo ?? ''),
        coYear: q.imageYear ? String(q.imageYear) : undefined,
      })),
      ...(await formMutationCapabilities(req, 'Manufacturing/Repair Receipt')),
    }));
  });
  app.get('/repair-images', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listRepairImageKeys(prisma, readScope(req), {
        coBook: String(q.imageBook ?? q.coBook ?? ''),
        vchNo: String(q.vchNo ?? ''),
        coYear: q.imageYear ? String(q.imageYear) : undefined,
      }),
    );
  });
  app.get('/repair-images/line', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    const image = await getRepairImage(prisma, readScope(req), {
      coBook: String(q.imageBook ?? q.coBook ?? ''),
      vchNo: String(q.vchNo ?? ''),
      srNo: String(q.srNo ?? ''),
      coYear: q.imageYear ? String(q.imageYear) : undefined,
    });
    if (!image) return reply.code(404).send({ error: 'repair-image-not-found' });
    if (q.format === 'json') {
      return reply.code(200).send({
        imageNo: image.imageNo,
        imageType: image.imageType,
        mimeType: image.mimeType,
        size: image.size,
        entryTime: image.entryTime,
        data: image.data.toString('base64'),
      });
    }
    const extension = image.mimeType === 'image/png' ? 'png' : 'jpg';
    return reply
      .header('content-type', image.mimeType)
      .header('cache-control', 'no-store')
      .header('content-disposition', `inline; filename="${image.imageNo}.${extension}"`)
      .send(image.data);
  });
  app.post('/repair-images', { ...auth, bodyLimit: 6 * 1024 * 1024 }, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveRepairImage(prisma, {
        version: requireImageVersion(b.version),
        scope: scopeOf(req),
        key: {
          coBook: b.imageBook ?? b.coBook,
          vchNo: b.vchNo,
          srNo: b.srNo,
          coYear: b.imageYear,
        },
        data: b.data,
        mimeType: b.mimeType,
        mainUser: sess(req).sub,
      }),
    );
  });
  app.delete('/repair-images', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const b = body(req);
    return run(reply, 200, () =>
      deleteRepairImage(prisma, {
        version: requireImageVersion(b.version),
        scope: scopeOf(req),
        key: {
          coBook: b.imageBook ?? b.coBook,
          vchNo: b.vchNo,
          srNo: b.srNo,
          coYear: b.imageYear,
        },
      }),
    );
  });

  // ---- Karigar (manufacturing) ----
  const karigarInput = (req: FastifyRequest, b: Record<string, any>) => ({
    scope: scopeOf(req),
    karigarAc: b.karigarAc,
    karigarName: b.karigarName,
    vchDate: b.vchDate,
    mainUser: sess(req).sub,
    lines: b.lines ?? [],
    billNo: b.billNo,
    itemType: b.itemType,
    vchDesc: b.vchDesc,
    empCode: b.empCode,
    address1: b.address1,
    address2: b.address2,
    address3: b.address3,
    city: b.city,
    mobile: b.mobile,
    bankName: b.bankName,
    bankAc: b.bankAc,
    chequeNo: b.chequeNo,
    chequeAmount: b.chequeAmount != null ? Number(b.chequeAmount) : undefined,
    cardAc: b.cardAc,
    cardAmount: b.cardAmount != null ? Number(b.cardAmount) : undefined,
    cashAmount: b.cashAmount != null ? Number(b.cashAmount) : undefined,
    kasarAmount: b.kasarAmount != null ? Number(b.kasarAmount) : undefined,
    billOutstanding: b.billOutstanding != null ? Number(b.billOutstanding) : undefined,
    creditDays: b.creditDays != null ? Number(b.creditDays) : undefined,
    discountPct: b.discountPct != null ? Number(b.discountPct) : undefined,
    discountAmount: b.discountAmount != null ? Number(b.discountAmount) : undefined,
    otherAmount: b.otherAmount != null ? Number(b.otherAmount) : undefined,
    taxCode: b.taxCode,
    taxRatePct: b.taxRatePct != null ? Number(b.taxRatePct) : undefined,
    taxAmount: b.taxAmount != null ? Number(b.taxAmount) : undefined,
    tcsCode: b.tcsCode,
    tcsPct: b.tcsPct != null ? Number(b.tcsPct) : undefined,
    tcsAmount: b.tcsAmount != null ? Number(b.tcsAmount) : undefined,
    accountGstType: b.accountGstType,
    saleBillNo: b.saleBillNo,
    saleBillBook: b.saleBillBook,
    partyFine: b.partyFine != null ? Number(b.partyFine) : undefined,
    labourAmt: b.labourAmt != null ? Number(b.labourAmt) : undefined,
    labourGstPct: b.labourGstPct != null ? Number(b.labourGstPct) : undefined,
    gstAc: b.gstAc,
    interState: !!b.interState,
    labourAc: b.labourAc,
    tagPrefix: b.tagPrefix,
  });
  app.post('/karigar/issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => issueKarigar(prisma, karigarInput(req, b)));
  });
  app.post('/karigar/receive', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => receiveKarigar(prisma, karigarInput(req, b)));
  });
  app.post('/old-item-sales', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createOldItemSale(prisma, karigarInput(req, b)));
  });
  app.get('/old-item-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getOldItemSale(prisma, readScope(req), (req.params as any).vchNo));
  });
  app.put('/old-item-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editOldItemSale(prisma, {
        ...karigarInput(req, b),
        vchNo: (req.params as any).vchNo,
      }),
    );
  });
  app.delete('/old-item-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteOldItemSale(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.get('/karigar/:ac/balance', auth, async (req) => ({
    karigarAc: (req.params as any).ac,
    balance: await karigarMetalBalance(prisma, readScope(req) as any, (req.params as any).ac),
  }));
  app.post('/mfg/issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      issueMfg(prisma, {
        scope: scopeOf(req),
        partyAc: b.partyAc,
        karigarAc: b.karigarAc,
        vchDate: b.vchDate,
        irType: b.irType,
        empCode: b.empCode,
        billNo: b.billNo,
        vchDesc: b.vchDesc,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.post('/mfg/receive', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      receiveMfg(prisma, {
        scope: scopeOf(req),
        partyAc: b.partyAc,
        karigarAc: b.karigarAc,
        vchDate: b.vchDate,
        lines: b.lines ?? [],
        labourAmt: b.labourAmt,
        labourAc: b.labourAc,
        mainUser: sess(req).sub,
      }),
    );
  });
  // ---- Design issue against a sales order (TR_MFG_ORD_ISU): book DIS, IR_TYPE 'D' ----
  app.post('/mfg/order-issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      issueMfg(prisma, {
        scope: { ...scopeOf(req), coBook: 'DIS' },
        partyAc: b.partyAc,
        karigarAc: b.karigarAc,
        vchDate: b.vchDate,
        irType: 'D',
        bookName: 'DESIGN ISU',
        vchType: 'DISU',
        empCode: b.empCode,
        billNo: b.billNo,
        vchDesc: b.vchDesc,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/mfg/order-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteMfg(prisma, {
        scope: { ...scopeOf(req), coBook: 'DIS' },
        vchNo: (req.params as any).vchNo,
        book: 'DIS',
        vchType: 'DISU',
        deleteUser: sess(req).tenantId,
      }),
    );
  });
  app.delete('/mfg/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const b = body(req);
    return run(reply, 200, () =>
      deleteMfg(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: b.book,
        vchType: b.vchType ?? 'MISU',
        deleteUser: sess(req).tenantId,
      }),
    );
  });

  // Desktop voucher lifecycle: server-derived scope; authenticated user supplies MAIN_USER/DELETE_USER.
  app.get('/karigar/issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getKarigar(prisma, readScope(req), (req.params as any).vchNo));
  });
  app.put('/karigar/issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editKarigar(prisma, {
        ...karigarInput(req, b),
        vchNo: (req.params as any).vchNo,
        mode: 'issue',
        karigarAc: String(b.karigarAc ?? ''),
      }),
    );
  });
  app.delete('/karigar/issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteKarigar(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.get('/karigar/receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getKarigar(prisma, readScope(req), (req.params as any).vchNo));
  });
  app.put('/karigar/receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editKarigar(prisma, {
        ...karigarInput(req, b),
        vchNo: (req.params as any).vchNo,
        mode: 'receive',
        karigarAc: String(b.karigarAc ?? ''),
      }),
    );
  });
  app.delete('/karigar/receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteKarigar(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  app.get('/mfg/issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getMfg(prisma, readScope(req), (req.params as any).vchNo));
  });
  app.put('/mfg/issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editMfg(prisma, {
        ...b,
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        mode: 'issue',
        mainUser: sess(req).sub,
        karigarAc: String(b.karigarAc ?? ''),
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/mfg/issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteMfg(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.get('/mfg/receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getMfg(prisma, readScope(req), (req.params as any).vchNo));
  });
  app.put('/mfg/receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editMfg(prisma, {
        ...b,
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        mode: 'receive',
        mainUser: sess(req).sub,
        karigarAc: String(b.karigarAc ?? ''),
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/mfg/receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteMfg(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.get('/mfg/order-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getMfg(prisma, { ...readScope(req), coBook: 'DIS' }, (req.params as any).vchNo),
    );
  });
  app.put('/mfg/order-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editMfg(prisma, {
        ...b,
        scope: { ...scopeOf(req), coBook: 'DIS' },
        vchNo: (req.params as any).vchNo,
        mode: 'issue',
        irType: 'D',
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });

  const checkedJobworkScope = async (req: FastifyRequest, mainBook: 'JDTR ISU' | 'JDTR REC') => {
    const scope = scopeOf(req);
    await requireMfgMainBook(prisma, scope, mainBook);
    return scope;
  };

  // Desktop jobwork issue (TR_JDT_REC). Routes are declared explicitly: the RBAC route
  // inventory and apps/api/test/routePolicy.test.ts are static analyses of these literals.
  app.post('/mfg/jobwork-issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, async () =>
      issueMfg(prisma, {
        ...b,
        scope: await checkedJobworkScope(req, 'JDTR ISU'),
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/mfg/jobwork-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () =>
      getMfg(prisma, await checkedJobworkScope(req, 'JDTR ISU'), (req.params as any).vchNo),
    );
  });
  app.put('/mfg/jobwork-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, async () =>
      editMfg(prisma, {
        ...b,
        scope: await checkedJobworkScope(req, 'JDTR ISU'),
        vchNo: (req.params as any).vchNo,
        mode: 'issue',
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/mfg/jobwork-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, async () =>
      deleteMfg(prisma, {
        scope: await checkedJobworkScope(req, 'JDTR ISU'),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // Desktop jobwork receive (TR_JDT_REC). Routes are declared explicitly: the RBAC route
  // inventory and apps/api/test/routePolicy.test.ts are static analyses of these literals.
  app.post('/mfg/jobwork-receive', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, async () =>
      receiveMfg(prisma, {
        ...b,
        scope: await checkedJobworkScope(req, 'JDTR REC'),
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/mfg/jobwork-receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () =>
      getMfg(prisma, await checkedJobworkScope(req, 'JDTR REC'), (req.params as any).vchNo),
    );
  });
  app.put('/mfg/jobwork-receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, async () =>
      editMfg(prisma, {
        ...b,
        scope: await checkedJobworkScope(req, 'JDTR REC'),
        vchNo: (req.params as any).vchNo,
        mode: 'receive',
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/mfg/jobwork-receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, async () =>
      deleteMfg(prisma, {
        scope: await checkedJobworkScope(req, 'JDTR REC'),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });

  // ---- Desktop melting process (TR_MLT_PRO) ----
  app.post('/melting', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveMeltingPro(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        acCode: b.acCode,
        acName: b.acName,
        employeeCode: b.employeeCode,
        description: b.description,
        lotNo: b.lotNo,
        outLines: b.outLines ?? [],
        resultLines: b.resultLines ?? [],
        mainUser: sess(req).sub,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.get('/melting/:vchNo', auth, async (req, reply) =>
    run(reply, 200, () => getMeltingPro(prisma, readScope(req), String((req.params as any).vchNo))),
  );
  app.put('/melting/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveMeltingPro(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          acCode: b.acCode,
          acName: b.acName,
          employeeCode: b.employeeCode,
          description: b.description,
          lotNo: b.lotNo,
          outLines: b.outLines ?? [],
          resultLines: b.resultLines ?? [],
          mainUser: sess(req).sub,
          deleteUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/melting/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteMeltingPro(prisma, scopeOf(req), String((req.params as any).vchNo), sess(req).sub),
    );
  });

  // ---- Stock / tags (inventory) ----
  app.post('/stock/tags', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    const s = scopeOf(req);
    return run(reply, 201, () =>
      createTag(prisma, s.tenantId, {
        CO_CODE: s.coCode,
        LC_CODE: s.lcCode,
        TAG_NO: String(b.tagNo ?? ''),
        GR_CODE: b.grCode ?? null,
        PR_CODE: b.prCode ?? null,
        ITM_PCS: Number(b.pcs || 0),
        ITM_GWT: Number(b.gwt || 0),
        ITM_NWT: Number(b.nwt || 0),
        ITM_MRP: Number(b.mrp || 0),
      }),
    );
  });
  app.get('/stock/on-hand', auth, async (req) => {
    const s = readScope(req);
    const scope = { CO_CODE: s.coCode, LC_CODE: s.lcCode };
    const [tags, net] = await Promise.all([
      tagOnHand(prisma, s.tenantId, scope),
      onHandNet(prisma, s.tenantId, scope),
    ]);
    return { ...tags, net }; // tags = in-stock BAR_DETL (incl. fine); net = full signed MAIN_STOCK net (Req 14.4)
  });
  app.get('/lookup/:entity', auth, async (req) => {
    const s = readScope(req);
    const { entity } = req.params as any;
    const qy = (req.query as any) || {};
    return lookup(
      prisma,
      s.tenantId,
      String(entity),
      String(qy.q ?? ''),
      s.coCode,
      Number(qy.limit) || 20,
      {
        lcCode: s.lcCode,
        coYear: s.coYear,
        acCode: qy.acCode == null ? undefined : String(qy.acCode),
        itType: qy.itType == null ? undefined : String(qy.itType),
      },
    );
  });
  app.get('/admin/users', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate (admins hold all rights)
    const s = sess(req);
    return run(reply, 200, () => listUsers(prisma, s.tenantId, s.coCode));
  });
  app.post('/admin/users', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const s = sess(req);
    const b = body(req);
    return run(reply, 201, () =>
      createUser(prisma, s.tenantId, {
        coCode: s.coCode,
        lcCode: s.lcCode,
        loginName: b.loginName,
        password: b.password,
        role: b.role,
      }),
    );
  });

  // ---- One XLSX export for every report (desktop BtnExel, present on 38 forms, absent from the web) ----
  // The registry reuses the SAME builder each report route calls, so an export can never disagree with what
  // the report shows on screen. Rows are re-derived server-side; the client cannot supply them.
  type ReportBuilder = (prisma: unknown, scope: unknown, range?: unknown) => Promise<unknown>;

  const REPORT_BUILDERS = {
    'last-visit': lastVisitReport as ReportBuilder,
    'address-print': addressPrintReport as ReportBuilder,
    'entry-check': ((prisma: any, scope: any) =>
      entryCheckReport(prisma, scope, {
        pendingOnly: true,
      })) as ReportBuilder,
    'user-report': ((prisma: any, scope: any) => userWorkReport(prisma, scope)) as ReportBuilder,
    'dhiran-report': ((prisma: any, scope: any) =>
      dhrnLoanReport(prisma, scope, { entryType: 'D' })) as ReportBuilder,
    'loan-report': ((prisma: any, scope: any) =>
      dhrnLoanReport(prisma, scope, { entryType: 'L' })) as ReportBuilder,
    'gst-report': gstLauncherReport as ReportBuilder,
    'delete-data': deleteDataReport as ReportBuilder,
    'point-report': pointReport as ReportBuilder,
    'approval-report': ((prisma: any, scope: any) =>
      approvalReport(prisma, scope)) as ReportBuilder,
    'vp-report': ((prisma: any, scope: any) => vpReport(prisma, scope)) as ReportBuilder,
    'bullion-report': ((prisma: any, scope: any) => bullionReport(prisma, scope)) as ReportBuilder,
    'karigar-report': ((prisma: any, scope: any) => karigarReport(prisma, scope)) as ReportBuilder,
    'repair-report': ((prisma: any, scope: any) => repairReport(prisma, scope)) as ReportBuilder,
    // Registered so the slug is recognised rather than 404. Their real filters cannot be expressed in the
    // shared builder signature, so the export route below reads them from the query and calls the SAME
    // builder with them — otherwise a lot-zoom export would always be empty, which looks like "no data"
    // instead of "no lot given".
    'tag-estimate': (prisma: any, scope: any) => tagEstimate(prisma, scope, { direction: 'In' }),
    'order-lot-zoom': (prisma: any, scope: any) => orderLotZoom(prisma, scope, ''),
    // The HUID register needs a tenant + scope shape, so it is adapted to the shared signature here.
    huid: ((prisma: any, scope: any) =>
      huidReport(
        prisma,
        scope.tenantId,
        {
          CO_CODE: scope.coCode,
          LC_CODE: scope.lcCode,
        },
        scope.huidOptions,
      )) as ReportBuilder,
    'item-weight-levels': ((prisma: any, scope: any) =>
      stockLevelReport(prisma, scope.tenantId, { CO_CODE: scope.coCode })) as ReportBuilder,
    'scheme-monthly': ((prisma: any, scope: any) =>
      schemeMonthlyReport(prisma, scope)) as ReportBuilder,
    // The report page's date range reaches the builder, which filters VCH_DATE by it (billProfitReport).
    // readScope has already dropped anything that is not an ISO date.
    'bill-profit': ((prisma: any, scope: any) =>
      billProfitReport(
        prisma,
        scope.tenantId,
        { CO_CODE: scope.coCode, LC_CODE: scope.lcCode },
        { from: scope.fromDate, to: scope.toDate },
      )) as ReportBuilder,
    'physical-stock-verify': ((prisma: any, scope: any) =>
      physicalStockReport(prisma, scope.tenantId, {
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
      })) as ReportBuilder,
    'size-movement': ((prisma: any, scope: any) =>
      movementReport(prisma, scope.tenantId, {
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
      })) as ReportBuilder,
    'branch-inout': ((prisma: any, scope: any) =>
      branchInoutReport(prisma, scope)) as ReportBuilder,
    'other-item-report': ((prisma: any, scope: any) =>
      otherItemReport(prisma, scope)) as ReportBuilder,
    'design-move': ((prisma: any, scope: any) => designMoveReport(prisma, scope)) as ReportBuilder,
    'consi-report': consiReport as ReportBuilder,
    'old-stock': ((prisma: any, scope: any) => oldStockReport(prisma, scope)) as ReportBuilder,
    'trading-report': ((prisma: any, scope: any) => tradingReport(prisma, scope)) as ReportBuilder,
    'tour-report': ((prisma: any, scope: any) => tourReport(prisma, scope)) as ReportBuilder,
    'tour-tag': ((prisma: any, scope: any) => tourTagReport(prisma, scope)) as ReportBuilder,
    'order-track': ((prisma: any, scope: any) => orderTrackReport(prisma, scope)) as ReportBuilder,
    'graph-report': ((prisma: any, scope: any) => graphReport(prisma, scope)) as ReportBuilder,
    'profit-loss': ((prisma: any, scope: any) => profitAndLoss(prisma, scope)) as ReportBuilder,
    'final-reports': ((prisma: any, scope: any) => finalReports(prisma, scope)) as ReportBuilder,
    'mfg-inout': ((prisma: any, scope: any) => mfgInoutReport(prisma, scope)) as ReportBuilder,
    'mfg-lot-isurec': ((prisma: any, scope: any) =>
      mfgLotIsuRecReport(prisma, scope)) as ReportBuilder,
    'mfg-ledger': ((prisma: any, scope: any) => mfgLedgerReport(prisma, scope)) as ReportBuilder,
    'account-balances': accountBalances as ReportBuilder,
    'area-outstanding': areaOutstanding as ReportBuilder,
    'area-wise-sales': areaWiseSales as ReportBuilder,
    'bill-aging': billAging as ReportBuilder,
    'bill-outstanding': billOutstanding as ReportBuilder,
    'cash-book': cashBook as ReportBuilder,
    'cash-day-summary': cashDaySummary as ReportBuilder,
    'contra-register': contraRegister as ReportBuilder,
    'customer-crm': customerCrm as ReportBuilder,
    'daily-sales': dailySalesSummary as ReportBuilder,
    'day-book': dayBook as ReportBuilder,
    'dhrn-outstanding': dhrnOutstandingList as ReportBuilder,
    // The day book the desktop binds to F11: metal weights beside money, which AC_DATA cannot carry.
    rojmel: rojmel as ReportBuilder,
    'employee-sales': employeeSales as ReportBuilder,
    'group-summary': groupSummary as ReportBuilder,
    'gst-input-register': gstInputRegister as ReportBuilder,
    gstr2: gstr2Purchase as ReportBuilder,
    gstr3b: gstr3b as ReportBuilder,
    'hsn-summary': hsnSummary as ReportBuilder,
    'item-group-stock': itemGroupStock as ReportBuilder,
    'item-stock-ledger': itemStockLedger as ReportBuilder,
    'karigar-balances': karigarBalances as ReportBuilder,
    'karigar-statement': karigarStatement as ReportBuilder,
    'location-wise-sales': locationWiseSales as ReportBuilder,
    'monthly-purchase': monthlyPurchase as ReportBuilder,
    'monthly-sales': monthlySales as ReportBuilder,
    'old-gold-register': oldGoldRegister as ReportBuilder,
    outstanding: outstandingReport as ReportBuilder,
    'party-statement': partyStatement as ReportBuilder,
    'purchase-by-item': purchaseByItem as ReportBuilder,
    'purchase-by-party': purchaseByParty as ReportBuilder,
    'purchase-register': purchaseRegister as ReportBuilder,
    'purchase-return-register': purchaseReturnRegister as ReportBuilder,
    'rate-list': rateList as ReportBuilder,
    'sales-by-group': salesByGroup as ReportBuilder,
    'sales-by-item': salesByItem as ReportBuilder,
    'sales-by-party': salesByParty as ReportBuilder,
    'sales-gst-monthly': salesGstMonthly as ReportBuilder,
    'sales-register': salesRegister as ReportBuilder,
    'sales-return-register': salesReturnRegister as ReportBuilder,
    'scheme-adjustments': schemeAdjustments as ReportBuilder,
    'stock-by-location': stockByLocation as ReportBuilder,
    'stock-valuation': stockValuation as ReportBuilder,
    'top-items': topItems as ReportBuilder,
    'trial-balance': trialBalance as ReportBuilder,
    'trial-balance-full': trialBalanceFull as ReportBuilder,
    // Their operator inputs (closing date and rates; the B2CL threshold) come from the query, so
    // resolveReport passes them exactly as the screen routes do.
    'balance-sheet': ((prisma: any, scope: any) =>
      balanceSheet(prisma, scope, {})) as ReportBuilder,
    gstr1: ((prisma: any, scope: any) => gstr1(prisma, scope, {})) as ReportBuilder,
  } satisfies Record<ReportSlug, ReportBuilder>;

  const REPORT_FAMILY_BUILDERS = {
    'approval-report': approvalReport,
    'vp-report': vpReport,
    'bullion-report': bullionReport,
    'karigar-report': karigarReport,
    'repair-report': repairReport,
  } as const;
  const isReportFamilySlug = (slug: ReportSlug): slug is keyof typeof REPORT_FAMILY_BUILDERS =>
    Object.prototype.hasOwnProperty.call(REPORT_FAMILY_BUILDERS, slug);
  /**
   * Resolve a report to its rows and totals.
   *
   * Shared by the XLSX and CSV exports so the two cannot disagree about what a report contains. Keeping the
   * resolution in one place also means the filter handling below — which the shared builder signature cannot
   * express — is applied identically to both formats.
   */
  const resolveReport = async (
    slug: ReportSlug,
    req: FastifyRequest,
  ): Promise<{
    rows: Record<string, unknown>[];
    totals?: Record<string, unknown>;
    /** The builder's own result, as the report screen receives it. */
    result: unknown;
  }> => {
    const build = REPORT_BUILDERS[slug]!;
    const scope = readScope(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const result: any =
      slug === 'order-lot-zoom'
        ? await orderLotZoom(prisma, scope, q.lotNo ?? '')
        : slug === 'entry-check'
          ? await entryCheckReport(prisma, scope, {
              pendingOnly: q.pendingOnly,
              userName: q.userName,
            })
          : slug === 'user-report'
            ? await userWorkReport(prisma, scope, {
                userName: q.userName,
                itemCodes: q.itemCodes,
              })
            : slug === 'dhiran-report' || slug === 'loan-report'
              ? await dhrnLoanReport(prisma, scope, {
                  entryType: slug === 'loan-report' ? 'L' : 'D',
                  mode: q.mode === 'pending' ? 'pending' : 'register',
                  loanType: q.loanType,
                  packetNo: q.packetNo,
                  refNo: q.refNo,
                  refAc: q.refAc,
                })
              : isReportFamilySlug(slug)
                ? await REPORT_FAMILY_BUILDERS[slug](prisma, scope, { mode: q.mode })
                : slug === 'branch-inout'
                  ? await branchInoutReport(prisma, scope, { mode: q.mode })
                  : slug === 'other-item-report'
                    ? await otherItemReport(prisma, scope, { mode: q.mode, itemCode: q.itemCode })
                    : slug === 'design-move'
                      ? await designMoveReport(prisma, scope, {
                          mode: q.mode,
                          tagNo: q.tagNo,
                          designNo: q.designNo,
                        })
                      : slug === 'old-stock'
                        ? await oldStockReport(prisma, scope, { karigarCode: q.karigarCode })
                        : slug === 'trading-report'
                          ? await tradingReport(prisma, scope, {
                              mode: q.mode,
                              salesAc: q.salesAc,
                              purchaseAc: q.purchaseAc,
                              bookCodes: q.bookCodes,
                            })
                          : slug === 'tour-report'
                            ? await tourReport(prisma, scope, {
                                mode: q.mode,
                                status: q.status,
                                employeeCode: q.employeeCode,
                                onlyTagged: q.onlyTagged,
                              })
                            : slug === 'tour-tag'
                              ? await tourTagReport(prisma, scope, {
                                  status: q.status,
                                  employeeCode: q.employeeCode,
                                  onlyTagged: q.onlyTagged,
                                  tagNo: q.tagNo,
                                  issueYear: q.issueYear,
                                  issueBook: q.issueBook,
                                  issueNo: q.issueNo,
                                })
                              : slug === 'graph-report'
                                ? await graphReport(prisma, scope, {
                                    mode: q.mode,
                                    metric: q.metric,
                                    transactionType: q.transactionType,
                                    bookType: q.bookType,
                                    itemType: q.itemType,
                                    grCode: q.grCode,
                                    lcCode: q.lcCode,
                                    dataType: q.dataType,
                                  })
                                : slug === 'order-track'
                                  ? await orderTrackReport(prisma, scope, {
                                      orderNo: q.orderNo,
                                      employeeCode: q.employeeCode,
                                      lcCode: q.lcCode,
                                      onlyOrderTagStock: q.onlyOrderTagStock,
                                      designNo: q.designNo,
                                      karigarCode: q.karigarCode,
                                      status: q.status,
                                    })
                                  : slug === 'mfg-inout'
                                    ? await mfgInoutReport(prisma, scope, {
                                        karigarCode: q.karigarCode,
                                      })
                                    : slug === 'mfg-lot-isurec'
                                      ? await mfgLotIsuRecReport(prisma, scope, {
                                          partyCode: q.partyCode,
                                          karigarCode: q.karigarCode,
                                          lotNo: q.lotNo,
                                          useItemLot: q.useItemLot,
                                        })
                                      : slug === 'mfg-ledger'
                                        ? await mfgLedgerReport(prisma, scope, {
                                            lcCode: q.lcCode,
                                            acGroup: q.acGroup,
                                            khataNo: q.khataNo,
                                            includeZero: q.includeZero,
                                          })
                                        : slug === 'scheme-monthly'
                                          ? await schemeMonthlyReport(prisma, scope, {
                                              schemeCode: q.schemeCode,
                                              lcCode: q.lcCode,
                                              withAdjScheme: q.withAdjScheme,
                                            })
                                          : slug === 'tag-estimate'
                                            ? await tagEstimate(prisma, scope, {
                                                ...readFilters(q),
                                                tagNo: q.tagNo || undefined,
                                                direction: q.direction === 'Out' ? 'Out' : 'In',
                                              })
                                            : slug === 'balance-sheet'
                                              ? await balanceSheet(
                                                  prisma,
                                                  scope,
                                                  balanceSheetOptions(q),
                                                )
                                              : slug === 'gstr1'
                                                ? await gstr1(prisma, scope, gstr1Options(q))
                                                : await build(prisma, scope, range(req));
    const rows: Record<string, unknown>[] = Array.isArray(result)
      ? result
      : Array.isArray(result?.rows)
        ? result.rows
        : [result];
    const totals =
      !Array.isArray(result) && result?.totals && typeof result.totals === 'object'
        ? (result.totals as Record<string, unknown>)
        : undefined;
    return { rows, totals, result };
  };

  /**
   * CSV export for every report.
   *
   * The desktop exports CSV from every report and the web previously had exactly one such route, so this is a
   * real capability gap as well as the input the parity comparison needs: Crystal exports CSV, the web exports
   * CSV, and the two files can then be compared on rows and totals rather than on layout.
   */
  app.get('/reports/:report/export.csv', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const slug = String((req.params as any).report ?? '');
    if (!isReportSlug(slug)) {
      return reply.code(404).send({ error: 'unknown-report', report: slug });
    }
    const { rows, totals } = await resolveReport(slug, req);
    return reply
      .header('content-type', 'text/csv; charset=utf-8')
      .header('content-disposition', `attachment; filename="${slug}.csv"`)
      .send(toCsv(rows, { totals }));
  });

  app.get('/reports/:report/export.xlsx', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const slug = String((req.params as any).report ?? '');
    if (!isReportSlug(slug)) {
      return reply.code(404).send({ error: 'unknown-report', report: slug });
    }
    const { rows, totals } = await resolveReport(slug, req);
    const out = await renderXlsx([inferSheet(slug, rows, totals)], slug);
    return reply
      .header('content-type', out.contentType)
      .header('content-disposition', `attachment; filename="${out.fileName}"`)
      .send(out.buffer);
  });

  /**
   * N54: report PDF built on the server from the report builder's own result, with the screen's former layout
   * (reports/reportPdf.ts). Print right on the report's own form. Replaces the client-HTML POST /render/pdf.
   */
  app.get('/reports/:report/export.pdf', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const slug = String((req.params as any).report ?? '');
    if (!isReportSlug(slug)) {
      return reply.code(404).send({ error: 'unknown-report', report: slug });
    }
    const { result } = await resolveReport(slug, req);
    return sendReportPdf(req, reply, slug, REPORT_FORM_BY_SLUG[slug], result);
  });
  // The account ledger's screen carries the account in the path, so its PDF does too.
  app.get('/reports/account-ledger/:acCode/export.pdf', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const acCode = String((req.params as any).acCode ?? '');
    const result = await accountLedger(prisma, readScope(req), acCode, range(req));
    return sendReportPdf(req, reply, 'account-ledger', 'Reports/Account Ledger', result);
  });
  const sendReportPdf = async (
    req: FastifyRequest,
    reply: FastifyReply,
    slug: string,
    form: string,
    result: unknown,
  ) => {
    let html: string;
    try {
      html = reportPdfHtml({
        company: await sessionCompanyName(req),
        title: form.replace(/^Reports\//, ''),
        coYear: readScope(req).coYear ?? '',
        result,
        printedAt: new Date(),
      });
    } catch (error) {
      if (error instanceof ReportTooLargeForPdfError)
        return reply
          .code(422)
          .send({ error: 'report-too-large-for-pdf', rows: error.rows, limit: error.limit });
      throw error;
    }
    return sendPdf(reply, html, slug);
  };

  // Screens for five reports that were registered only in REPORT_BUILDERS. Their exports worked and the
  // screens answered 404 (PARITY-EVALUATION-2026-09-28 D3).
  // - Each screen calls the export's own builder with the export's own inputs, so the two cannot
  //   disagree.
  // - Their policies already existed (routePolicy.ts, 'Reports/HuId Report' and the four after it).
  // - Literal paths, because routePolicy.test.ts reads them.
  app.get('/reports/huid', auth, async (req) =>
    REPORT_BUILDERS.huid(prisma, readScope(req), range(req)),
  );
  app.get('/reports/item-weight-levels', auth, async (req) =>
    REPORT_BUILDERS['item-weight-levels'](prisma, readScope(req), range(req)),
  );
  app.get('/reports/bill-profit', auth, async (req) =>
    REPORT_BUILDERS['bill-profit'](prisma, readScope(req), range(req)),
  );
  app.get('/reports/physical-stock-verify', auth, async (req) =>
    REPORT_BUILDERS['physical-stock-verify'](prisma, readScope(req), range(req)),
  );
  app.get('/reports/size-movement', auth, async (req) =>
    REPORT_BUILDERS['size-movement'](prisma, readScope(req), range(req)),
  );
  // ---- Tag images (desktop BtnImgS / BtnImgC / BtnImgD, 24 forms) ----
  // One shared surface keyed on the tag instance, so every form that shows a tag can attach, replace,
  // enlarge and delete its photograph without repeating the plumbing.
  app.get('/stock/tag-image/state', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => ({
      ...(await getEntityImageState(prisma, {
        ...scopeOf(req),
        entityType: q.entityType ?? 'TAG',
        entityKey: String(q.entityKey ?? q.tagNo ?? ''),
        instance: Number(q.instance ?? q.vchSrno ?? 0),
        imageType: q.imageType,
      })),
      ...(await formMutationCapabilities(req, 'Inventory/Tag Print')),
    }));
  });
  app.get('/stock/tag-image', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = scopeOf(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const rec = await getEntityImage(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      lcCode: s.lcCode,
      // `tagNo`/`vchSrno` remain accepted so a tag surface needs no special case.
      entityType: q.entityType ?? 'TAG',
      entityKey: String(q.entityKey ?? q.tagNo ?? ''),
      instance: Number(q.instance ?? q.vchSrno ?? 0),
      imageType: q.imageType,
    });
    if (!rec) return reply.code(404).send({ error: 'tag-image-not-found' });
    return reply
      .header('content-type', rec.mimeType)
      .header('cache-control', 'private, max-age=60')
      .header('x-content-type-options', 'nosniff')
      .send(rec.bytes);
  });
  app.get('/stock/tag-image/list', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = scopeOf(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const tags = q.tags
      ? String(q.tags)
          .split(',')
          .map((t) => t.trim())
          .filter(Boolean)
      : undefined;
    return {
      images: await listEntityImageKeys(
        prisma,
        {
          tenantId: s.tenantId,
          coCode: s.coCode,
          lcCode: s.lcCode,
          entityType: q.entityType ?? 'TAG',
        },
        tags,
      ),
    };
  });
  app.post('/stock/tag-image', { ...auth, bodyLimit: 6 * 1024 * 1024 }, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = scopeOf(req);
    const b = body(req);
    return run(reply, 200, () =>
      saveEntityImage(
        prisma,
        {
          tenantId: s.tenantId,
          coCode: s.coCode,
          lcCode: s.lcCode,
          entityType: b.entityType ? String(b.entityType) : 'TAG',
          entityKey: String(b.entityKey ?? b.tagNo ?? ''),
          instance: Number(b.instance ?? b.vchSrno ?? 0),
          imageType: b.imageType ? String(b.imageType) : undefined,
        },
        {
          data: b.data,
          mimeType: b.mimeType,
          user: sess(req).sub,
          version: requireImageVersion(b.version),
        },
      ),
    );
  });
  app.delete('/stock/tag-image', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const s = scopeOf(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      deleteEntityImage(
        prisma,
        {
          tenantId: s.tenantId,
          coCode: s.coCode,
          lcCode: s.lcCode,
          entityType: q.entityType ?? 'TAG',
          entityKey: String(q.entityKey ?? q.tagNo ?? ''),
          instance: Number(q.instance ?? q.vchSrno ?? 0),
          imageType: q.imageType,
        },
        requireImageVersion(q.version ?? (req.body as any)?.version),
      ),
    );
  });

  // ---- Data repair console (desktop MS_UPDATE) ----
  // The whole console is admin-only in routePolicy.ts (ADMIN_ONLY + SCOPED_ADMIN_ONLY), so central
  // authorization has already refused a non-administrator before any handler here runs. `guard` re-asserts
  // that the central hook authorized this request; a destructive apply additionally requires a reason,
  // re-authentication and a verified recent backup, all enforced inside applyRepair.
  app.get('/utilities/data-repair/operations', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return {
      operations: listRepairs().map((o) => ({
        id: o.id,
        title: o.title,
        description: o.description,
        desktopSource: o.desktopSource,
        risk: o.risk,
        tables: o.tables,
      })),
    };
  });
  app.post('/utilities/data-repair/:id/preview', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = sess(req);
    return run(reply, 200, () =>
      previewRepair(
        prisma,
        String((req.params as any).id),
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear },
        s.sub ?? 'unknown',
      ),
    );
  });
  app.post('/utilities/data-repair/:id/apply', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const s = sess(req);
    const b = body(req);
    try {
      const applied = await applyRepair(
        prisma,
        String((req.params as any).id),
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear },
        {
          previewHash: String(b.previewHash ?? ''),
          confirmation: b.confirmation ? String(b.confirmation) : undefined,
          operator: s.sub ?? 'unknown',
          loginCoCode: s.loginCoCode,
          reason: b.reason ? String(b.reason) : undefined,
          operatorPassword: b.operatorPassword ? String(b.operatorPassword) : undefined,
          backupReference: b.backupReference ? String(b.backupReference) : undefined,
        },
      );
      return reply.code(200).send(applied);
    } catch (e: any) {
      // A failed or missing re-authentication is an authorization outcome, not a bad request: the operator
      // has not proved they may act, so it must not read as "fix your payload".
      if (
        e?.name === 'RepairError' &&
        (e.code === 'reauthentication-required' || e.code === 'reauthentication-failed')
      ) {
        return reply.code(403).send({ error: 'RepairError', code: e.code, message: e.message });
      }
      if (e?.name === 'RepairError') {
        return reply.code(400).send({ error: 'RepairError', code: e.code, message: e.message });
      }
      throw e;
    }
  });
  app.get('/utilities/data-repair/runs', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = sess(req);
    return { runs: await repairHistory(prisma, { tenantId: s.tenantId, coCode: s.coCode }) };
  });
  app.post('/admin/companies/:coCode/provision', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate
    const s = sess(req);
    const b = body(req);
    return run(reply, 201, () =>
      seedCompany(prisma, s.tenantId, String((req.params as any).coCode), {
        coName: b.coName,
        lcCode: b.lcCode ?? s.lcCode,
      }),
    );
  });
  app.post('/admin/users/:loginName/rights', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate
    const s = sess(req);
    const b = body(req);
    const { loginName } = req.params as any;
    return run(reply, 200, () =>
      setUserRights(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        {
          loginName: String(loginName),
          catg: b.catg,
          userUpdate: !!b.userUpdate,
          userDelete: !!b.userDelete,
          userPrint: !!b.userPrint,
        },
      ),
    );
  });
  // Per-form RBAC (USER_SET): read/replace a user's per-menu FRM_VIEW/EDIT/DELETE/PRINT rows.
  app.get('/admin/form-catalog', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate
    return run(reply, 200, async () => getFormCatalog());
  });
  app.post('/backup/restore', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate — HIGH-RISK: replaces this tenant's company data
    if (containMutation(reply, 'logical-restore')) return;
    const b = body(req);
    return run(reply, 200, () =>
      restoreCompany(
        prisma,
        { tenantId: sess(req).tenantId, companyCode: sess(req).coCode },
        b.doc ?? b,
        { mode: 'replace' },
      ),
    );
  });
  app.get('/admin/users/:loginName/form-rights', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate
    const s = sess(req);
    return run(reply, 200, () =>
      getUserFormRights(
        prisma,
        { tenantId: s.tenantId, lcCode: s.lcCode },
        String((req.params as any).loginName),
      ),
    );
  });
  app.post('/admin/users/:loginName/form-rights', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate
    const s = sess(req);
    const b = body(req);
    return run(reply, 200, () =>
      setUserFormRights(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode },
        String((req.params as any).loginName),
        b.rows ?? [],
      ),
    );
  });
  app.post('/admin/users/:loginName/password-reset', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = sess(req);
    const b = body(req);
    try {
      await resetUserPassword(prisma, {
        tenantId: s.tenantId,
        coCode: s.coCode,
        loginName: String((req.params as any).loginName),
        newPassword: String(b.newPassword ?? ''),
      });
      return { reset: true, forcedChange: true };
    } catch (error) {
      if (error instanceof PasswordPolicyError) {
        return reply.code(400).send({ error: 'weak-password', reasons: error.reasons });
      }
      if (error instanceof PasswordChangeError) {
        return reply.code(404).send({ error: error.code });
      }
      throw error;
    }
  });
  app.get('/utilities/vch-renumber/preview', auth, async (req) => {
    const sc = readScope(req);
    return previewRenumber(
      prisma,
      {
        tenantId: sc.tenantId,
        coCode: sc.coCode,
        coYear: sc.coYear ?? '',
        lcCode: sc.lcCode ?? '',
      },
      { book: String((req.query as any).book ?? '') },
    );
  });
  app.post('/utilities/vch-renumber/apply', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate (mutates voucher numbers)
    const sc = scopeOf(req);
    const b = body(req);
    return run(reply, 200, () =>
      applyRenumber(
        prisma,
        {
          tenantId: sc.tenantId,
          coCode: sc.coCode,
          coYear: sc.coYear ?? '',
          lcCode: sc.lcCode,
        },
        { book: String(b.book ?? ''), tables: b.tables, confirm: b.confirm === true },
      ),
    );
  });
  app.get('/rate', auth, async (req) => {
    const s = readScope(req);
    const qy = (req.query as any) || {};
    return fetchRate(
      prisma,
      s.tenantId,
      s.coCode,
      String(qy.group ?? ''),
      qy.date ? String(qy.date) : undefined,
    );
  });
  app.get('/rate-groups', auth, async (req) => {
    const s = readScope(req);
    return rateGroups(prisma, s.tenantId, s.coCode);
  });
  app.get('/party/:acCode/balance', auth, async (req) => {
    const s = readScope(req);
    return partyBalance(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String((req.params as any).acCode),
    );
  });
  app.get('/accounts/:acCode/opening', auth, async (req) => {
    const s = readScope(req);
    return getOpeningBalance(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String((req.params as any).acCode),
    );
  });
  app.post('/accounts/:acCode/opening', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 200, () =>
      setOpeningBalance(prisma, {
        scope: { tenantId: s.tenantId, coCode: s.coCode, coYear: s.coYear, lcCode: s.lcCode },
        acCode: String((req.params as any).acCode),
        amount: Number(b.amount || 0),
        sign: b.sign === 'C' ? 'C' : 'D',
        gold: Number(b.gold || 0),
        goldSign: b.goldSign === '-' ? '-' : '+',
        silver: Number(b.silver || 0),
        silverSign: b.silverSign === '-' ? '-' : '+',
      }),
    );
  });
  app.post('/daily-rate', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 201, () =>
      postDailyRate(prisma, {
        scope: { tenantId: s.tenantId, coCode: s.coCode, coYear: s.coYear, lcCode: s.lcCode },
        date: String(b.date ?? ''),
        goldRate: Number(b.goldRate || 0),
        silverRate: Number(b.silverRate || 0),
        taxPct: b.taxPct != null ? Number(b.taxPct) : undefined,
        empCode: b.empCode,
        overrides: b.overrides,
      }),
    );
  });
  app.get('/daily-rate', auth, async (req) => {
    const s = readScope(req);
    const qy = (req.query as any) || {};
    return getDailyRate(prisma, { tenantId: s.tenantId, coCode: s.coCode }, String(qy.date ?? ''));
  });
  app.get('/daily-rate/dates', auth, async (req) => {
    const s = readScope(req);
    return dailyRateDates(prisma, { tenantId: s.tenantId, coCode: s.coCode }, 30);
  });
  app.post('/masters/auto-item', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 201, () =>
      bulkAutoItem(prisma, {
        scope: { tenantId: s.tenantId, coCode: s.coCode },
        grCode: b.grCode,
        grName: b.grName,
        itType: b.itType,
        hsnCode: b.hsnCode,
        products: b.products ?? [],
      }),
    );
  });
  app.get('/reminders', auth, async (req) => {
    const s = readScope(req);
    const qy = (req.query as any) || {};
    return reminders(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      { dueWindowDays: qy.window ? Number(qy.window) : undefined },
    );
  });
  app.get('/labour-update', auth, async (req) => {
    const s = readScope(req);
    return listLabourItems(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String((req.query as any).grCode ?? ''),
    );
  });
  app.post('/labour-update', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 200, () =>
      applyLabourUpdate(prisma, { tenantId: s.tenantId, coCode: s.coCode }, b.rows ?? []),
    );
  });
  app.get('/labour-slabs', auth, async (req) => {
    const s = readScope(req);
    return getLabourSlabs(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String((req.query as any).itCode ?? ''),
    );
  });
  app.post('/labour-slabs', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 200, () =>
      setLabourSlabs(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(b.itCode ?? ''),
        b.slabs ?? [],
      ),
    );
  });
  app.get('/masters/diamond-sizes', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = readScope(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      q.itCode
        ? getDiamondSizes(prisma, { tenantId: s.tenantId, coCode: s.coCode }, q.itCode)
        : listDiamondSizeSummary(prisma, { tenantId: s.tenantId, coCode: s.coCode }),
    );
  });
  app.post('/masters/diamond-sizes', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 200, () =>
      saveDiamondSizes(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(b.itCode ?? ''),
        Array.isArray(b.rows) ? b.rows : [],
        sess(req).sub,
      ),
    );
  });
  app.delete('/masters/diamond-sizes', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const s = readScope(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      deleteDiamondSizes(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(q.itCode ?? ''),
      ),
    );
  });
  app.get('/masters/item-stock-limits', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = readScope(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      q.itCode
        ? getItemStockLimits(
            prisma,
            { tenantId: s.tenantId, coCode: s.coCode },
            q.itCode,
            q.itDesign ?? 'N',
          )
        : listItemStockLimitSummary(prisma, { tenantId: s.tenantId, coCode: s.coCode }),
    );
  });
  app.post('/masters/item-stock-limits', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 200, () =>
      saveItemStockLimits(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(b.itCode ?? ''),
        String(b.itDesign ?? 'N'),
        Array.isArray(b.rows) ? b.rows : [],
      ),
    );
  });
  app.delete('/masters/item-stock-limits', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const s = readScope(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      deleteItemStockLimits(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(q.itCode ?? ''),
        String(q.itDesign ?? 'N'),
      ),
    );
  });
  app.get('/reminder-entries', auth, async (req) => {
    const s = readScope(req);
    return listReminderEntries(prisma, { tenantId: s.tenantId, coCode: s.coCode });
  });
  app.post('/reminder-entries', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      createReminderEntry(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        remark: b.remark,
        remindDate: b.remindDate,
        entDate: b.entDate,
      }),
    );
  });
  app.delete('/reminder-entries/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const s = readScope(req);
    return run(reply, 200, () =>
      deleteReminderEntry(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode },
        (req.params as any).vchNo,
      ),
    );
  });
  app.get('/stock/tags', auth, async (req) => {
    const s = readScope(req);
    return listTags(prisma, s.tenantId, { CO_CODE: s.coCode, LC_CODE: s.lcCode });
  });
  app.post('/stock/tag-opening', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      tagOpening(prisma, {
        scope: scopeOf(req),
        mainUser: sess(req).sub,
        vchDate: b.vchDate,
        stockItCode: b.stockItCode,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/stock/tag-opening/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getTagOpening(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/stock/tag-opening/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    // Containment DISCHARGED: the P0-06/WP-08 exit gate is satisfied by
    // tagOpeningRoundTrip.db.test.ts (symmetric create/get/update across BAR_DETL, BAR_IDTL, tag
    // identity and stock movement) plus the HUID text fix on the page. See containment.mjs.
    const b = body(req);
    return run(reply, 200, () =>
      editTagOpening(
        prisma,
        {
          scope: scopeOf(req),
          mainUser: sess(req).sub,
          vchDate: b.vchDate,
          stockItCode: b.stockItCode,
          lines: b.lines ?? [],
        },
        (req.params as any).vchNo,
      ),
    );
  });
  app.delete('/stock/tag-opening/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTagOpening(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  // Item (non-tag) opening balance (desktop TR_ITM_OPBL → ITM_OPBL + MAIN_STOCK 'ITOBL').
  app.post('/stock/item-opening', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      itemOpening(prisma, {
        scope: scopeOf(req),
        mainUser: sess(req).sub,
        vchDate: b.vchDate,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/stock/item-opening/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getItemOpening(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/stock/item-opening/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editItemOpening(
        prisma,
        {
          scope: scopeOf(req),
          mainUser: sess(req).sub,
          vchDate: b.vchDate,
          lines: b.lines ?? [],
        },
        (req.params as any).vchNo,
      ),
    );
  });
  app.delete('/stock/item-opening/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteItemOpening(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.post('/stock/item-lot', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      itemLot(prisma, {
        scope: scopeOf(req),
        mainUser: sess(req).sub,
        vchDate: b.vchDate,
        acCode: b.acCode,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/stock/item-lot/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getItemLot(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/stock/item-lot/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editItemLot(
        prisma,
        {
          scope: scopeOf(req),
          mainUser: sess(req).sub,
          vchDate: b.vchDate,
          acCode: b.acCode,
          lines: b.lines ?? [],
        },
        (req.params as any).vchNo,
      ),
    );
  });
  app.delete('/stock/item-lot/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteItemLot(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  const stockInoutInput = (req: FastifyRequest, b: any) => ({
    scope: scopeOf(req),
    mainUser: sess(req).sub,
    vchDate: b.vchDate,
    employeeCode: b.employeeCode,
    description: b.description,
    fromLcCode: b.fromLcCode,
    toLcCode: b.toLcCode,
    fromBook: b.fromBook,
    fromVchNo: b.fromVchNo,
    toBook: b.toBook,
    toVchNo: b.toVchNo,
    stockTransferred: b.stockTransferred,
    lines: b.lines ?? [],
  });
  app.post('/stock/out', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createStockOut(prisma, stockInoutInput(req, b)));
  });
  app.get('/stock/out/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getStockOut(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/stock/out/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editStockOut(prisma, stockInoutInput(req, b), (req.params as any).vchNo),
    );
  });
  app.delete('/stock/out/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteStockOut(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.post('/stock/in', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createStockIn(prisma, stockInoutInput(req, b)));
  });
  app.get('/stock/in/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getStockIn(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/stock/in/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editStockIn(prisma, stockInoutInput(req, b), (req.params as any).vchNo),
    );
  });
  app.delete('/stock/in/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteStockIn(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.post('/stock/adjust', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      stockAdjust(prisma, { scope: scopeOf(req), vchDate: b.vchDate, lines: b.lines ?? [] }),
    );
  });
  app.delete('/stock/adjust/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteStockAdjust(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
      }),
    );
  });
  // Tag Cancel (X19) and Tag Transfer (X18): desktop TR_TAG_CAN on a TAG CANCEL / TAG TRFR book. One writer
  // (modules/stock/tagCancel.ts), one route family per menu, so each keeps its own form right.
  const tagCancelInput = (req: FastifyRequest, b = body(req)) => ({
    scope: scopeOf(req),
    vchDate: b.vchDate,
    empCode: b.empCode,
    vchDesc: b.vchDesc,
    mainUser: sess(req).sub,
    lines: Array.isArray(b.lines) ? b.lines : [],
  });
  const tagCancelHandlers = (mode: TagCancelMode) => ({
    list: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'view')) return;
      return run(reply, 200, () => listTagCancel(prisma, mode, scopeOf(req)));
    },
    source: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'view')) return;
      const q = (req.query ?? {}) as Record<string, string | undefined>;
      return run(reply, 200, () =>
        tagCancelSource(prisma, scopeOf(req), {
          tagNo: q.tagNo,
          vchSrno: q.vchSrno,
          itCode: q.itCode,
        }),
      );
    },
    read: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'view')) return;
      return run(reply, 200, () =>
        getTagCancel(prisma, mode, scopeOf(req), (req.params as any).vchNo),
      );
    },
    create: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'create')) return;
      return run(reply, 201, () => saveTagCancel(prisma, mode, tagCancelInput(req)));
    },
    update: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'update')) return;
      return run(reply, 200, () =>
        saveTagCancel(prisma, mode, tagCancelInput(req), (req.params as any).vchNo),
      );
    },
    remove: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'delete')) return;
      return run(reply, 200, () =>
        deleteTagCancel(prisma, mode, scopeOf(req), (req.params as any).vchNo, sess(req).sub),
      );
    },
  });
  const tagTransferRoute = tagCancelHandlers('transfer');
  app.get('/stock/tag-transfer', auth, tagTransferRoute.list);
  app.get('/stock/tag-transfer/source', auth, tagTransferRoute.source);
  app.get('/stock/tag-transfer/:vchNo', auth, tagTransferRoute.read);
  app.post('/stock/tag-transfer', auth, tagTransferRoute.create);
  app.put('/stock/tag-transfer/:vchNo', auth, tagTransferRoute.update);
  app.delete('/stock/tag-transfer/:vchNo', auth, tagTransferRoute.remove);
  const tagCancelRoute = tagCancelHandlers('cancel');
  app.get('/stock/tag-cancel', auth, tagCancelRoute.list);
  app.get('/stock/tag-cancel/source', auth, tagCancelRoute.source);
  app.get('/stock/tag-cancel/:vchNo', auth, tagCancelRoute.read);
  app.post('/stock/tag-cancel', auth, tagCancelRoute.create);
  app.put('/stock/tag-cancel/:vchNo', auth, tagCancelRoute.update);
  app.delete('/stock/tag-cancel/:vchNo', auth, tagCancelRoute.remove);
  app.post('/stock/counter-transfer', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      counterTransfer(prisma, { scope: scopeOf(req), vchDate: b.vchDate, lines: b.lines ?? [] }),
    );
  });
  app.delete('/stock/counter-transfer/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteCounterTransfer(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
      }),
    );
  });
  app.post('/stock/tag-adjust', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveTagAdjust(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        book: b.book,
        acCode: b.acCode,
        empCode: b.empCode,
        vchDesc: b.vchDesc,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/stock/tag-adjust/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getTagAdjust(prisma, scopeOf(req), (req.params as any).vchNo, (req.query as any)?.book),
    );
  });
  app.put('/stock/tag-adjust/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveTagAdjust(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        vchDate: b.vchDate,
        book: b.book,
        acCode: b.acCode,
        empCode: b.empCode,
        vchDesc: b.vchDesc,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/stock/tag-adjust/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTagAdjust(prisma, scopeOf(req), (req.params as any).vchNo, body(req).book),
    );
  });
  app.post('/stock/tag-weight-diff', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    if (containMutation(reply, 'tag-weight-difference')) return;
    const b = body(req);
    return run(reply, 201, () =>
      tagWeightDiff(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        stockAdjAc: b.stockAdjAc,
        diffAc: b.diffAc,
        partyAc: b.partyAc,
        absorbItCode: b.absorbItCode,
        absorbSign: b.absorbSign,
        payAc: b.payAc,
        payAmt: b.payAmt != null ? Number(b.payAmt) : undefined,
        labourAc: b.labourAc,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/stock/tag-weight-diff/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    if (containMutation(reply, 'tag-weight-difference')) return;
    return run(reply, 200, () =>
      deleteTagWeightDiff(prisma, scopeOf(req) as any, (req.params as any).vchNo, body(req).book),
    );
  });
  app.post('/finance/gold-book', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveGoldBook(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        employeeCode: b.employeeCode,
        remark: b.remark,
        lines: b.lines ?? [],
        mainUser: sess(req).sub,
      }),
    );
  });
  app.get('/finance/gold-book/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getGoldBook(prisma, readScope(req), String((req.params as any).vchNo)),
    );
  });
  app.put('/finance/gold-book/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveGoldBook(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          employeeCode: b.employeeCode,
          remark: b.remark,
          lines: b.lines ?? [],
          mainUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/finance/gold-book/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteGoldBook(prisma, scopeOf(req), String((req.params as any).vchNo), sess(req).sub),
    );
  });
  app.post('/finance/vp-adjustment', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveVpAdjustment(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        employeeCode: b.employeeCode,
        lines: b.lines ?? [],
        mainUser: sess(req).sub,
      }),
    );
  });
  app.get('/finance/vp-adjustment/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getVpAdjustment(prisma, readScope(req), String((req.params as any).vchNo)),
    );
  });
  app.put('/finance/vp-adjustment/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveVpAdjustment(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          employeeCode: b.employeeCode,
          lines: b.lines ?? [],
          mainUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/finance/vp-adjustment/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteVpAdjustment(prisma, scopeOf(req), String((req.params as any).vchNo), sess(req).sub),
    );
  });
  app.post('/sales/wholesale-sale-return', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveWholesaleSaleReturn(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        partyCode: b.partyCode,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        description: b.description,
        cashAmount: b.cashAmount,
        chequeAmount: b.chequeAmount,
        cardAmount: b.cardAmount,
        kasarAmount: b.kasarAmount,
        bankAccount: b.bankAccount,
        cardAccount: b.cardAccount,
        lines: b.lines ?? [],
        mainUser: sess(req).sub,
      }),
    );
  });
  app.get('/sales/wholesale-sale-return/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getWholesaleSaleReturn(prisma, readScope(req), String((req.params as any).vchNo)),
    );
  });
  app.put('/sales/wholesale-sale-return/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveWholesaleSaleReturn(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          partyCode: b.partyCode,
          billNo: b.billNo,
          employeeCode: b.employeeCode,
          description: b.description,
          cashAmount: b.cashAmount,
          chequeAmount: b.chequeAmount,
          cardAmount: b.cardAmount,
          kasarAmount: b.kasarAmount,
          bankAccount: b.bankAccount,
          cardAccount: b.cardAccount,
          lines: b.lines ?? [],
          mainUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/sales/wholesale-sale-return/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteWholesaleSaleReturn(
        prisma,
        scopeOf(req),
        String((req.params as any).vchNo),
        sess(req).sub,
      ),
    );
  });
  app.post('/sales/vp-parcel', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveVpParcel(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        partyCode: b.partyCode,
        angdiyaCode: b.angdiyaCode,
        billNo: b.billNo,
        employeeCode: b.employeeCode,
        description: b.description,
        lines: b.lines ?? [],
        mainUser: sess(req).sub,
      }),
    );
  });
  app.get('/sales/vp-parcel/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getVpParcel(prisma, readScope(req), String((req.params as any).vchNo)),
    );
  });
  app.put('/sales/vp-parcel/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveVpParcel(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          partyCode: b.partyCode,
          angdiyaCode: b.angdiyaCode,
          billNo: b.billNo,
          employeeCode: b.employeeCode,
          description: b.description,
          lines: b.lines ?? [],
          mainUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/sales/vp-parcel/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteVpParcel(prisma, scopeOf(req), String((req.params as any).vchNo), sess(req).sub),
    );
  });
  app.post('/finance/location-amount', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveLocationAmount(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        employeeCode: b.employeeCode,
        remark: b.remark,
        toLocation: b.toLocation,
        fromLocation: b.fromLocation,
        fromBook: b.fromBook,
        fromVoucherNo: b.fromVoucherNo,
        lines: b.lines ?? [],
        mainUser: sess(req).sub,
      }),
    );
  });
  app.get('/finance/location-amount/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getLocationAmount(prisma, readScope(req), String((req.params as any).vchNo)),
    );
  });
  app.put('/finance/location-amount/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveLocationAmount(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          employeeCode: b.employeeCode,
          remark: b.remark,
          toLocation: b.toLocation,
          fromLocation: b.fromLocation,
          fromBook: b.fromBook,
          fromVoucherNo: b.fromVoucherNo,
          lines: b.lines ?? [],
          mainUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/finance/location-amount/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteLocationAmount(prisma, scopeOf(req), String((req.params as any).vchNo), sess(req).sub),
    );
  });

  const otherCommissionInput = (req: FastifyRequest, b: Record<string, any>) => ({
    scope: scopeOf(req),
    vchDate: b.vchDate,
    partyCode: b.partyCode,
    billNo: b.billNo,
    billDate: b.billDate,
    chequeAmount: b.chequeAmount != null ? Number(b.chequeAmount) : undefined,
    chequeAccount: b.chequeAccount,
    chequeNo: b.chequeNo,
    cardAmount: b.cardAmount != null ? Number(b.cardAmount) : undefined,
    cardAccount: b.cardAccount,
    cashAmount: b.cashAmount != null ? Number(b.cashAmount) : undefined,
    kasarAmount: b.kasarAmount != null ? Number(b.kasarAmount) : undefined,
    tdsCode: b.tdsCode,
    employeeCode: b.employeeCode,
    bankName: b.bankName,
    description: b.description,
    lines: b.lines ?? [],
    mainUser: sess(req).sub,
  });
  app.post('/other-commission', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => saveOtherCommission(prisma, otherCommissionInput(req, b)));
  });
  app.get('/other-commission/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getOtherCommission(prisma, readScope(req), String((req.params as any).vchNo)),
    );
  });
  app.put('/other-commission/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveOtherCommission(prisma, otherCommissionInput(req, b), String((req.params as any).vchNo)),
    );
  });
  app.delete('/other-commission/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteOtherCommission(prisma, scopeOf(req), String((req.params as any).vchNo), sess(req).sub),
    );
  });

  app.post('/stock/physical-stock', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      savePhysicalStock(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        employeeCode: b.employeeCode,
        description: b.description,
        lines: b.lines ?? [],
        mainUser: sess(req).sub,
      }),
    );
  });
  app.get('/stock/physical-stock/:vchNo', auth, async (req, reply) =>
    run(reply, 200, () =>
      getPhysicalStock(prisma, readScope(req), String((req.params as any).vchNo)),
    ),
  );
  app.put('/stock/physical-stock/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      savePhysicalStock(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          employeeCode: b.employeeCode,
          description: b.description,
          lines: b.lines ?? [],
          mainUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/stock/physical-stock/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePhysicalStock(prisma, scopeOf(req), String((req.params as any).vchNo)),
    );
  });
  app.post('/stock/stone-dm-cf', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      saveStoneDmCf(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        employeeCode: b.employeeCode,
        description: b.description,
        lines: b.lines ?? [],
        mainUser: sess(req).sub,
      }),
    );
  });
  app.get('/stock/stone-dm-cf/source-list', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return run(reply, 200, () =>
      listStoneDmCfSources(
        prisma,
        s.tenantId,
        { CO_CODE: s.coCode, LC_CODE: s.lcCode },
        {
          tblCode: qy.tblCode || undefined,
          itCode: qy.itCode || undefined,
          tagNo: qy.tagNo || undefined,
          vchSrno: qy.vchSrno ? Number(qy.vchSrno) : undefined,
          limit: qy.limit ? Number(qy.limit) : undefined,
          offset: qy.offset ? Number(qy.offset) : undefined,
        },
      ),
    );
  });
  app.get('/stock/stone-dm-cf/:vchNo', auth, async (req, reply) =>
    run(reply, 200, () => getStoneDmCf(prisma, readScope(req), String((req.params as any).vchNo))),
  );
  app.put('/stock/stone-dm-cf/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveStoneDmCf(
        prisma,
        {
          scope: scopeOf(req),
          vchDate: b.vchDate,
          employeeCode: b.employeeCode,
          description: b.description,
          lines: b.lines ?? [],
          mainUser: sess(req).sub,
        },
        String((req.params as any).vchNo),
      ),
    );
  });
  app.delete('/stock/stone-dm-cf/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteStoneDmCf(prisma, scopeOf(req), String((req.params as any).vchNo)),
    );
  });
  app.post('/stock/physical-reconcile', auth, async (req) => {
    const s = scopeOf(req);
    const b = body(req);
    return physicalReconcile(
      prisma,
      s.tenantId,
      { CO_CODE: s.coCode, LC_CODE: s.lcCode },
      (b.counts ?? b.tags ?? []) as any,
    );
  });
  app.get('/stock/physical-list', auth, async (req) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return physicalStockList(
      prisma,
      s.tenantId,
      { CO_CODE: s.coCode, LC_CODE: s.lcCode },
      {
        tblCode: qy.tblCode || undefined,
        itCode: qy.itCode || undefined,
        tagNo: qy.tagNo || undefined,
        vchSrno: qy.vchSrno ? Number(qy.vchSrno) : undefined,
        limit: qy.limit ? Number(qy.limit) : undefined,
        offset: qy.offset ? Number(qy.offset) : undefined,
      },
    );
  });
  app.get('/stock/tag-print', auth, async (req) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return listPrintableTags(
      prisma,
      s.tenantId,
      { CO_CODE: s.coCode, LC_CODE: s.lcCode },
      {
        tblCode: qy.tblCode || undefined,
        itCode: qy.itCode || undefined,
        tagFrom: qy.tagFrom || undefined,
        tagTo: qy.tagTo || undefined,
      },
    );
  });
  app.get('/masters/design-book/component-defaults', auth, async (req, reply) => {
    const s = scopeOf(req);
    return run(reply, 200, () =>
      getDesignComponentDefaults(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String((req.query as any).itCode ?? ''),
      ),
    );
  });
  app.get('/masters/design-book/calculation-config', auth, async (req, reply) => {
    const s = scopeOf(req);
    return run(reply, 200, () =>
      getDesignCalculationConfig(prisma, { tenantId: s.tenantId, coCode: s.coCode }),
    );
  });
  app.get('/masters/design-book', auth, async (req, reply) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return run(reply, 200, () =>
      listDesignBook(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(qy.bookName ?? ''),
        String(qy.prCode ?? ''),
      ),
    );
  });
  const saveDesignBookRequest = async (req: FastifyRequest, reply: FastifyReply) => {
    const s = scopeOf(req);
    const body = (req.body as any) || {};
    if (req.method === 'PUT' && (!body.expectedVersion || body.expectedVersion === 'new')) {
      return reply.code(400).send({
        error: 'DesignBookValidationError',
        message: 'Load the design book before editing it',
      });
    }
    return run(reply, 200, async () => ({
      written: await saveDesignBook(prisma, {
        scope: { tenantId: s.tenantId, coCode: s.coCode },
        bookName: String(body.bookName ?? ''),
        prCode: String(body.prCode ?? ''),
        vchDate: body.vchDate,
        mainUser: sess(req).sub,
        expectedVersion: req.method === 'POST' ? 'new' : body.expectedVersion,
        lines: Array.isArray(body.lines) ? body.lines : [],
      }),
    }));
  };
  app.post('/masters/design-book', auth, saveDesignBookRequest);
  app.put('/masters/design-book', auth, saveDesignBookRequest);
  app.delete('/masters/design-book', auth, async (req, reply) => {
    const s = scopeOf(req);
    const b = { ...((req.query ?? {}) as Record<string, unknown>), ...body(req) };
    if (!b.expectedVersion || b.expectedVersion === 'new') {
      return reply.code(400).send({
        error: 'DesignBookValidationError',
        message: 'Load the design book before deleting it',
      });
    }
    return run(reply, 200, async () => ({
      deleted: await deleteDesignBook(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(b.bookName ?? ''),
        String(b.prCode ?? ''),
        b.expectedVersion == null ? undefined : String(b.expectedVersion),
      ),
    }));
  });
  const designImageKey = (req: FastifyRequest, entityKey: unknown) => {
    const s = scopeOf(req);
    return {
      tenantId: s.tenantId,
      coCode: s.coCode,
      lcCode: '',
      entityType: 'DESIGN',
      entityKey: String(entityKey ?? ''),
      instance: 0,
      imageType: 'D',
      requireDesignParent: true,
    };
  };
  app.get('/masters/design-book/image/state', auth, async (req, reply) => {
    reply.header('cache-control', 'no-store');
    return run(reply, 200, async () => ({
      ...(await getEntityImageState(prisma, designImageKey(req, (req.query as any)?.entityKey))),
      ...(await formMutationCapabilities(req, 'Masters/Design Book')),
    }));
  });
  app.get('/masters/design-book/image', auth, async (req, reply) => {
    const key = designImageKey(req, (req.query as any)?.entityKey);
    if (!key.entityKey.trim()) return reply.code(400).send({ error: 'design-image-key-required' });
    const rec = await getEntityImage(prisma, key);
    if (!rec) return reply.code(404).send({ error: 'design-image-not-found' });
    return reply
      .type(rec.mimeType)
      .header('cache-control', 'private, no-cache')
      .header('x-content-type-options', 'nosniff')
      .send(rec.bytes);
  });
  app.post(
    '/masters/design-book/image',
    { ...auth, bodyLimit: 6 * 1024 * 1024 },
    async (req, reply) => {
      const b = body(req);
      return run(reply, 200, () =>
        saveEntityImage(prisma, designImageKey(req, b.entityKey), {
          version: requireImageVersion(b.version),
          data: b.data,
          mimeType: b.mimeType,
          user: sess(req).sub,
        }),
      );
    },
  );
  app.delete('/masters/design-book/image', auth, async (req, reply) => {
    return run(reply, 200, () =>
      deleteEntityImage(
        prisma,
        designImageKey(req, (req.query as any)?.entityKey),
        requireImageVersion((req.query as any)?.version ?? (req.body as any)?.version),
      ),
    );
  });
  app.post('/stock/tag-print/stage', auth, async (req) => {
    const s = scopeOf(req);
    const body = (req.body as any) || {};
    const vchNo = String(body.vchNo ?? '').trim();
    if (!vchNo) throw new StockVoucherValidationError('vchNo is required');
    const srNos = Array.isArray(body.srNos)
      ? body.srNos.map((v: unknown) => Number(v)).filter((v: number) => Number.isFinite(v))
      : undefined;
    // Staging copies one voucher's BAR_DETL rows, so the full book scope is mandatory. Fail closed
    // rather than staging against a partial scope.
    const coYear = s.coYear;
    const coBook = s.coBook;
    if (!coYear || !coBook) {
      throw new StockVoucherValidationError('scope-incomplete: company year and book are required');
    }
    const staged = await withTxBudget(prisma, s.tenantId, 'voucher', (tx: any) =>
      stageTagPrintRowsTx(
        tx,
        s.tenantId,
        { coCode: s.coCode, lcCode: s.lcCode, coYear, coBook },
        vchNo,
        srNos,
        // Blank stickers to leave before the first real label (desktop nLableSkip).
        Number(body.labelSkip ?? 0),
      ),
    );
    return { staged };
  });
  app.get('/stock/tag-print/label', auth, async (req, reply) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    const all = await listPrintableTags(
      prisma,
      s.tenantId,
      { CO_CODE: s.coCode, LC_CODE: s.lcCode },
      {
        tblCode: qy.tblCode || undefined,
        itCode: qy.itCode || undefined,
        tagFrom: qy.tagFrom || undefined,
        tagTo: qy.tagTo || undefined,
      },
    );
    const wanted = qy.tags
      ? String(qy.tags)
          .split(',')
          .map((t) => t.trim())
          .filter(Boolean)
      : null;
    const tags = wanted ? all.filter((t) => wanted.includes(t.tagNo)) : all;
    return reply.type('text/html').send(renderTagLabels(tags, Number(qy.labelSkip ?? 0)));
  });

  // ---- Membership / loyalty ----
  app.post('/members', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      enrollMember(prisma, scopeOf(req) as any, {
        pointCode: b.pointCode,
        membCode: b.membCode,
        membName: b.membName,
        mobile: b.mobile,
        cardNo: b.cardNo,
      }),
    );
  });
  app.post('/members/points', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postPoints(prisma, scopeOf(req) as any, {
        pointCode: b.pointCode,
        membCode: b.membCode,
        points: Number(b.points),
        type: b.type === 'redeem' ? 'redeem' : 'earn',
        amount: Number(b.amount || 0),
      }),
    );
  });
  app.get('/members', auth, async (req) => listMembers(prisma, scopeOf(req) as any));

  // ---- Company settings (CO_SET) ----
  app.get('/settings', auth, async (req) => ({
    fields: SETTING_FIELDS,
    values: await getSettings(prisma, scopeOf(req) as any),
  }));
  app.post('/settings', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => saveSettings(prisma, scopeOf(req) as any, body(req)));
  });
  app.get('/integrations/device-settings', auth, async (req) => {
    const scope = scopeOf(req);
    const behavior = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
      resolveSettingsBehaviorTx(tx, scope),
    );
    // The browser must open the port with the desktop's own parameters, so they are published here
    // rather than hardcoded client-side. `TR_TAG_OPBL.cs` tries CH340 at 9600/8/N/1 and falls back to the
    // configured port at 2400/7/N/1 — the data-bit change matters, 7-bit data read as 8-bit is garbage.
    return {
      companyCode: scope.coCode,
      locationCode: scope.lcCode,
      weightPort: behavior.weightPort,
      enabled: scaleCaptureEnabled(behavior.weightPort),
      scale: {
        friendlyNameFragment: SCALE_PORT_FRIENDLY_NAME,
        profiles: SCALE_PORT_PROFILES,
        decimalPlaces: SCALE_DECIMAL_PLACES,
        frameScanLimit: SCALE_FRAME_SCAN_LIMIT,
        excludedCharacters: SCALE_EXCLUDED_CHARACTERS,
        targetGridColumn: SCALE_TARGET_GRID_COLUMN,
        /** The desktop drops '-' from its keep-set, so a tare-negative reading arrives positive. */
        signIsDropped: true,
      },
    };
  });

  /**
   * Parse a raw scale frame server-side using the desktop's own extractor.
   *
   * Offered so a device client never has to reimplement the filter: it forwards the bytes it read and
   * receives the exact text the desktop would have placed in the cell. The endpoint is pure — it touches
   * no tenant data — but stays behind `auth` because it is part of the authenticated device surface.
   */
  /**
   * Integration readiness: what works now, and exactly what each remaining integration is waiting for.
   * Returns variable PRESENCE only, never values, and never reports an integration ready on the strength
   * of code alone — a missing credential is always `awaiting-credentials`.
   */
  app.get('/integrations/readiness', auth, async (req) => {
    const scope = scopeOf(req);
    const behavior = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
      resolveSettingsBehaviorTx(tx, scope),
    );
    const companyMail = await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
      const rows: Array<{ n: number }> = await tx.$queryRawUnsafe(
        // Module_Save.cs reads CO_MAIL and MAIL_API for the SMTP credentials. Note MAIL_API is absent
        // from the extracted desktop schema snapshot while present here, so the desktop references a
        // column its own database lacks — the same class of stale reference as the Crystal bindings.
        `SELECT count(*)::int n FROM "CO_MAST"
          WHERE "CO_CODE"=$1 AND coalesce("CO_MAIL",'') <> '' AND coalesce("MAIL_API",'') <> ''`,
        scope.coCode,
      );
      return Number(rows[0]?.n ?? 0) > 0;
    });
    const report = integrationReadiness({
      weightPort: behavior.weightPort,
      companyMailConfigured: companyMail,
    });
    return { summary: readinessSummary(report), integrations: report };
  });

  /**
   * Verify the configured integration credentials with a real round-trip. Admin-gated because it
   * contacts external providers. Returns no secret values, only a per-provider verdict — and reports SMS
   * as unverifiable rather than guessing, because those gateways have no authentication endpoint.
   */
  app.post('/integrations/verify-credentials', auth, async () => ({
    checks: await verifyIntegrationCredentials(),
  }));

  app.post('/integrations/scale-reading', auth, async (req) => {
    const body = (req.body as any) || {};
    const parsed = parseScaleFrame(body.frame);
    return {
      frame: typeof body.frame === 'string' ? body.frame : '',
      extracted: parsed.extracted,
      value: parsed.value,
      text: parsed.text,
      signDropped: parsed.signDropped,
      /** No digits at all means "no reading", which is not the same as a genuine 0.000. */
      hasReading: parsed.extracted !== '',
    };
  });

  // ---- Integrations (third-party) ----
  // Live gold/silver/forex rates (free APIs, no creds) — desktop MDI_FORM live-rate feed.
  app.get('/integrations/live-rates', auth, async (req) => {
    const scope = scopeOf(req);
    const behavior = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
      resolveSettingsBehaviorTx(tx, scope),
    );
    // MS_OPNCOMP.cs:718,933-935 and TR_PR_SL_UAE.cs:10846: OZ_CON_VAL is company-owned and is
    // the divisor for ounce spot × FX. It is never accepted from this request.
    const live = await fetchLiveRates({ ounceConversion: behavior.ounceConversion });
    // TR_PR_SL_UAE.cs:7404-7405: validated company FX defaults are server-owned.
    return { ...live, companyFx: { rate: behavior.fxRate, code: behavior.fxCode } };
  });
  // Send WhatsApp/SMS via the configured provider (real when creds set, else fake) — desktop UT_WHATSAPP/UT_SMS.
  app.post('/integrations/notify', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const b = body(req);
    const scope = scopeOf(req);
    const behavior = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
      resolveSettingsBehaviorTx(tx, scope),
    );
    const gate =
      b.channel === 'sms'
        ? b.audience === 'admin'
          ? 'admin-sms'
          : 'customer-sms'
        : b.context === 'scheme'
          ? 'scheme-whatsapp'
          : 'dhrn-whatsapp';
    if (!messageDeliveryEnabled(gate, behavior))
      return reply.code(409).send({ error: `integration-disabled:${gate}` });
    const idempotencyKey = String(b.idempotencyKey ?? '').trim();
    const templateKind = String(b.templateKind ?? '').trim();
    if (!idempotencyKey || idempotencyKey.length > 128)
      return reply.code(400).send({ error: 'invalid-idempotency-key' });
    if (!templateKind || templateKind.length > 64)
      return reply.code(400).send({ error: 'invalid-template-kind' });
    const { sender, mode } = messaging.senderFromEnv();
    // N54 step 4 / G33: no provider means no send. Refuse BEFORE recording an attempt, so the log never shows
    // a message that was not handed to a provider. The fake is only used in explicit test mode (MESSAGING_FAKE_MODE).
    if (!sender) return reply.code(503).send({ error: 'messaging-unconfigured', mode });
    // MS_OPNCOMP.cs:687,694-695,714-715: flags and gateway are loaded, never body-supplied.
    const r = await messaging.notifyWithAttemptLog(
      prisma,
      sender,
      scope,
      {
        to: String(b.to ?? '').trim(),
        channel: b.channel === 'sms' ? 'sms' : 'whatsapp',
        body: b.body ?? '',
      },
      { idempotencyKey, templateKind },
    );
    return { ...r, mode };
  });
  // What's configured/live vs pending-credentials.
  app.get('/integrations/status', auth, async (req) => {
    const scope = scopeOf(req);
    const behavior = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
      resolveSettingsBehaviorTx(tx, scope),
    );
    return {
      liveRates: { provider: 'gold-api.com + frankfurter.app', status: 'live (no key required)' },
      messaging: messaging.messagingStatus(),
      einvoice: {
        provider: 'Chartered Info GSP (charteredinfo.com)',
        // gspStatus() computes the mode from the environment WITHOUT constructing a transport. Calling
        // irnTransportFromEnv() here would throw in production once credentials are absent, taking down the
        // readiness endpoint precisely when an operator needs it to explain why e-invoicing is refusing.
        status: !gspStatus().configured
          ? 'wired (Fake) — set GSP_ASPID/GSP_PASSWORD/GSP_GSTIN/GSP_USER/GSP_EINV_PWD and GSP_SANDBOX to go live'
          : `live (${gspStatus().mode})`,
      },
      weighingScale: {
        port: behavior.weightPort,
        status:
          behavior.weightPort && behavior.weightPort !== '0'
            ? 'configured — device bridge pending'
            : 'disabled',
      },
      operationsPolicy: {
        cardCommissionAdjustment: behavior.cardCommissionAdjustment,
        exportDatabaseTarget: behavior.exportDatabaseTarget,
        openingDhrn: behavior.openingDhrn,
        openingLoan: behavior.openingLoan,
      },
      messagingPolicy: {
        gateway: behavior.smsGateway,
        adminSms: behavior.adminSms,
        customerSms: behavior.customerSms,
        dhrnWhatsapp: behavior.dhrnWhatsapp,
        schemeWhatsapp: behavior.schemeWhatsapp,
      },
      barcode: { provider: 'Code39/QR (server-rendered)', status: 'live' },
      pdf: { provider: 'Chromium/Playwright', status: 'wired' },
    };
  });

  // Barcode (Code39) + QR as SVG — tag printing / UPI / IRN QR.
  app.get('/integrations/barcode', auth, async (req, reply) =>
    reply
      .header('content-type', 'image/svg+xml')
      .send(code39Svg(String((req.query as any).data ?? ''))),
  );
  app.get('/integrations/qr', auth, async (req, reply) =>
    reply
      .header('content-type', 'image/svg+xml')
      .send(await qrSvg(String((req.query as any).data ?? 'DHAKAN'))),
  );

  // ---- Reports (read) ----
  const range = (req: FastifyRequest) => ({
    fromDate: (req.query as any).fromDate,
    toDate: (req.query as any).toDate,
  });
  app.get('/reports/sales-register', auth, async (req) =>
    salesRegister(prisma, readScope(req), range(req)),
  );
  app.get('/reports/purchase-register', auth, async (req) =>
    purchaseRegister(prisma, readScope(req), range(req)),
  );
  app.get('/reports/day-book', auth, async (req) => dayBook(prisma, readScope(req), range(req)));
  // The Rojmel: the desktop's F11 day book, metal weights beside money. Registered as its own literal
  // route because route-policy analysis reads literal path strings - a loop would be invisible to it.
  app.get('/reports/rojmel', auth, async (req) => rojmel(prisma, readScope(req)));
  app.get('/reports/trial-balance', auth, async (req) => trialBalance(prisma, readScope(req)));
  app.get('/reports/account-ledger/:acCode', auth, async (req) =>
    accountLedger(prisma, readScope(req), (req.params as any).acCode, range(req)),
  );
  app.get('/reports/dhrn-outstanding', auth, async (req) =>
    dhrnOutstandingList(prisma, readScope(req)),
  );
  app.get('/reports/last-visit', auth, async (req) => lastVisitReport(prisma, readScope(req)));
  app.get('/reports/address-print', auth, async (req) =>
    addressPrintReport(prisma, readScope(req)),
  );
  app.get('/reports/entry-check', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      entryCheckReport(prisma, readScope(req), {
        pendingOnly: q.pendingOnly,
        userName: q.userName,
      }),
    );
  });
  app.get('/reports/entry-check/detail', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      entryCheckDetailReport(prisma, readScope(req), {
        coBook: q.coBook ?? '',
        vchNo: q.vchNo ?? '',
      }),
    );
  });
  app.post('/reports/entry-check/mark-checked', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    const rows = Array.isArray(b.rows) ? b.rows : [b];
    return run(reply, 200, () => markEntryChecked(prisma, readScope(req), rows));
  });
  app.get('/reports/user-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      userWorkReport(prisma, readScope(req), {
        userName: q.userName,
        itemCodes: q.itemCodes,
      }),
    );
  });
  app.get('/reports/dhiran-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      dhrnLoanReport(prisma, readScope(req), {
        entryType: 'D',
        mode: q.mode === 'pending' ? 'pending' : 'register',
        loanType: q.loanType,
        packetNo: q.packetNo,
        refNo: q.refNo,
        refAc: q.refAc,
      }),
    );
  });
  app.get('/reports/loan-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      dhrnLoanReport(prisma, readScope(req), {
        entryType: 'L',
        mode: q.mode === 'pending' ? 'pending' : 'register',
        loanType: q.loanType,
        packetNo: q.packetNo,
        refNo: q.refNo,
        refAc: q.refAc,
      }),
    );
  });
  app.get('/reports/gst-report', auth, async (req) => gstLauncherReport(prisma, readScope(req)));
  app.get('/reports/delete-data', auth, async (req, reply) => {
    return run(reply, 200, () => deleteDataReport(prisma, readScope(req)));
  });
  app.get('/reports/point-report', auth, async (req, reply) => {
    return run(reply, 200, () => pointReport(prisma, readScope(req)));
  });
  app.get('/reports/point-report/detail', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      pointReportDetail(prisma, readScope(req), String(q.memberCode ?? '')),
    );
  });
  app.get('/reports/approval-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => approvalReport(prisma, readScope(req), { mode: q.mode }));
  });
  app.get('/reports/vp-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => vpReport(prisma, readScope(req), { mode: q.mode }));
  });
  app.get('/reports/bullion-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => bullionReport(prisma, readScope(req), { mode: q.mode }));
  });
  app.get('/reports/karigar-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => karigarReport(prisma, readScope(req), { mode: q.mode }));
  });
  app.get('/reports/repair-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => repairReport(prisma, readScope(req), { mode: q.mode }));
  });
  app.get('/reports/branch-inout', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => branchInoutReport(prisma, readScope(req), { mode: q.mode }));
  });
  app.get('/reports/other-item-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      otherItemReport(prisma, readScope(req), { mode: q.mode, itemCode: q.itemCode }),
    );
  });
  app.get('/reports/design-move', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      designMoveReport(prisma, readScope(req), {
        mode: q.mode,
        tagNo: q.tagNo,
        designNo: q.designNo,
      }),
    );
  });
  app.get('/reports/design-move/detail', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      designMoveDetailReport(prisma, readScope(req), {
        mode: q.mode,
        key: q.key,
        size: q.size,
        designNo: q.designNo,
      }),
    );
  });
  app.get('/reports/consi-report', auth, async (req, reply) => {
    return run(reply, 200, () => consiReport(prisma, readScope(req)));
  });
  app.get('/reports/old-stock', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      oldStockReport(prisma, readScope(req), { karigarCode: q.karigarCode }),
    );
  });
  app.get('/reports/trading-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      tradingReport(prisma, readScope(req), {
        mode: q.mode,
        salesAc: q.salesAc,
        purchaseAc: q.purchaseAc,
        bookCodes: q.bookCodes,
      }),
    );
  });
  app.get('/reports/tour-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      tourReport(prisma, readScope(req), {
        mode: q.mode,
        status: q.status,
        employeeCode: q.employeeCode,
        onlyTagged: q.onlyTagged,
      }),
    );
  });
  app.get('/reports/tour-tag', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      tourTagReport(prisma, readScope(req), {
        status: q.status,
        employeeCode: q.employeeCode,
        onlyTagged: q.onlyTagged,
        tagNo: q.tagNo,
        issueYear: q.issueYear,
        issueBook: q.issueBook,
        issueNo: q.issueNo,
      }),
    );
  });
  app.get('/reports/mfg-inout', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      mfgInoutReport(prisma, readScope(req), { karigarCode: q.karigarCode }),
    );
  });
  app.get('/reports/mfg-lot-isurec', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      mfgLotIsuRecReport(prisma, readScope(req), {
        partyCode: q.partyCode,
        karigarCode: q.karigarCode,
        lotNo: q.lotNo,
        useItemLot: q.useItemLot,
      }),
    );
  });
  app.get('/reports/mfg-ledger', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      mfgLedgerReport(prisma, readScope(req), {
        lcCode: q.lcCode,
        acGroup: q.acGroup,
        khataNo: q.khataNo,
        includeZero: q.includeZero,
      }),
    );
  });
  app.get('/reports/mfg-ledger/detail', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      mfgLedgerDetailReport(prisma, readScope(req), {
        acCode: q.acCode,
        coBook: q.coBook,
        lcCode: q.lcCode,
      }),
    );
  });
  app.get('/reports/consi-report/detail', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => consiDetailReport(prisma, readScope(req), q.acCode));
  });
  app.get('/vouchers/recent', auth, async (req) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return recentVouchers(
      prisma,
      // A session without a year lists nothing (fail closed) rather than every year's vouchers.
      { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear ?? '' },
      String(qy.table ?? ''),
      String(qy.book ?? ''),
      qy.limit ? Number(qy.limit) : 50,
    );
  });
  app.get('/years', auth, async (req) => {
    const s = readScope(req);
    return listYears(prisma, { tenantId: s.tenantId, coCode: s.coCode });
  });
  app.post('/years', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 201, () =>
      createYear(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        {
          coYear: b.coYear,
          opDate: b.opDate,
          clDate: b.clDate,
          yearMonth: b.yearMonth,
          oldMethod: b.oldMethod,
          mainUser: sess(req).sub,
        },
      ),
    );
  });
  // There is deliberately no year close/reopen here: CL_DATE is the year's closing date, not a flag
  // (MS_YEAR.cs:1035-1040, 1196). Period locking is CO_SET.LOCK_DATE / LAST_DAY_LOCK; carry-forward is
  // /years/carry-forward and Utilities → Year-End Close.
  app.post('/years/carry-forward', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 200, () =>
      carryForwardOpenings(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode },
        String(b.fromYear),
        String(b.toYear),
      ),
    );
  });
  app.post('/utilities/data-refresh', auth, async (req, reply) => {
    const s = readScope(req);
    return run(reply, 200, () =>
      dataRefresh(prisma, { tenantId: s.tenantId, coCode: s.coCode, coYear: sess(req).coYear }),
    );
  });
  app.get('/party/:acCode/photo', auth, async (req) => {
    const s = readScope(req);
    return getPartyPhoto(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String((req.params as any).acCode),
    );
  });
  app.post('/party/:acCode/photo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    return run(reply, 200, () =>
      setPartyPhoto(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode },
        String((req.params as any).acCode),
        body(req).dataUrl,
      ),
    );
  });
  app.get('/party/:acCode/family', auth, async (req) => {
    const s = readScope(req);
    return familyMembers(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String((req.params as any).acCode),
    );
  });
  // RP_TAG_ESTMATE — tag estimate listing. `direction` selects the desktop's In/Out source switch.
  app.get('/reports/tag-estimate', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      tagEstimate(prisma, readScope(req), {
        // The eleven shared RP_ALL panel dimensions, plus this form's own tag filter.
        ...readFilters(q),
        tagNo: q.tagNo || undefined,
        direction: q.direction === 'Out' ? 'Out' : 'In',
      }),
    );
  });
  // RP_GRAPH — seven desktop graph buttons exposed as one mode-selected report.
  app.get('/reports/graph-report', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      graphReport(prisma, readScope(req), {
        mode: q.mode,
        metric: q.metric,
        transactionType: q.transactionType,
        bookType: q.bookType,
        itemType: q.itemType,
        grCode: q.grCode,
        lcCode: q.lcCode,
        dataType: q.dataType,
      }),
    );
  });
  // RP_ORD_TRACK — order tracking report with pending/all status filters.
  app.get('/reports/order-track', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      orderTrackReport(prisma, readScope(req), {
        orderNo: q.orderNo,
        employeeCode: q.employeeCode,
        lcCode: q.lcCode,
        onlyOrderTagStock: q.onlyOrderTagStock,
        designNo: q.designNo,
        karigarCode: q.karigarCode,
        status: q.status,
      }),
    );
  });
  // Which of the eleven RP_ALL panel dimensions a report can honour. Exposed so the screen does not offer a
  // filter that would have to be refused, and so a filter is never silently dropped.
  app.get('/reports/:report/filters', auth, async (req, reply) => {
    const slug = String((req.params as any).report ?? '');
    const binding = REPORT_FILTER_BINDINGS[slug];
    if (!binding) return reply.code(404).send({ error: 'unknown-report', report: slug });
    return { report: slug, supported: supportedFilters(binding) };
  });
  // RP_ORDER — lot movement drill-down. `lotNo` is required; without it the desktop offers no view.
  app.get('/reports/order-lot-zoom', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () => orderLotZoom(prisma, readScope(req), q.lotNo ?? ''));
  });
  app.get('/reports/tag-stock', auth, async (req) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return tagStockReport(
      prisma,
      s.tenantId,
      { CO_CODE: s.coCode, LC_CODE: s.lcCode },
      (qy.tab || 'stock') as any,
      { tblCode: qy.tblCode || undefined, itCode: qy.itCode || undefined },
    );
  });
  app.get('/reports/tag-stock.csv', auth, async (req, reply) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    const rep = await tagStockReport(
      prisma,
      s.tenantId,
      { CO_CODE: s.coCode, LC_CODE: s.lcCode },
      (qy.tab || 'stock') as any,
      { tblCode: qy.tblCode || undefined, itCode: qy.itCode || undefined },
    );
    return reply
      .type('text/csv')
      .header('content-disposition', `attachment; filename="tag-stock-${qy.tab || 'stock'}.csv"`)
      .send(tagStockCsv(rep));
  });
  app.get('/reports/karigar-balances', auth, async (req) =>
    karigarBalances(prisma, readScope(req)),
  );
  app.get('/reports/account-balances', auth, async (req) =>
    accountBalances(prisma, readScope(req)),
  );
  app.get('/reports/stock-valuation', auth, async (req) => stockValuation(prisma, readScope(req)));
  app.get('/reports/old-gold-register', auth, async (req) =>
    oldGoldRegister(prisma, readScope(req)),
  );
  app.get('/reports/sales-by-party', auth, async (req) => salesByParty(prisma, readScope(req)));
  app.get('/reports/sales-by-item', auth, async (req) => salesByItem(prisma, readScope(req)));
  app.get('/reports/profit-loss', auth, async (req) => profitAndLoss(prisma, readScope(req)));
  app.get('/reports/final-reports', auth, async (req) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const n = (v: string | undefined): number | undefined =>
      v == null || v === '' ? undefined : Number(v);
    return finalReports(prisma, readScope(req), {
      closingDate: q.closingDate || undefined,
      goldRate: n(q.goldRate),
      silverRate: n(q.silverRate),
      ledgerFineGold: n(q.ledgerFineGold),
      ledgerFineSilver: n(q.ledgerFineSilver),
    });
  });
  app.get('/reports/balance-sheet', auth, async (req) =>
    balanceSheet(prisma, readScope(req), balanceSheetOptions(req.query)),
  );
  app.get('/reports/outstanding', auth, async (req) => outstandingReport(prisma, readScope(req)));
  app.get('/reports/bill-outstanding', auth, async (req) =>
    billOutstanding(prisma, readScope(req)),
  );
  app.get('/reports/cash-book', auth, async (req) => cashBook(prisma, readScope(req)));
  app.get('/reports/scheme-adjustments', auth, async (req) =>
    schemeAdjustments(prisma, readScope(req)),
  );
  app.get('/reports/scheme-monthly', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      schemeMonthlyReport(prisma, readScope(req), {
        schemeCode: q.schemeCode,
        lcCode: q.lcCode,
        withAdjScheme: q.withAdjScheme,
      }),
    );
  });
  app.get('/reports/item-stock-ledger', auth, async (req) =>
    itemStockLedger(prisma, readScope(req)),
  );
  app.get('/reports/monthly-purchase', auth, async (req) =>
    monthlyPurchase(prisma, readScope(req)),
  );
  app.get('/reports/purchase-by-party', auth, async (req) =>
    purchaseByParty(prisma, readScope(req)),
  );
  app.get('/reports/group-summary', auth, async (req) => groupSummary(prisma, readScope(req)));
  app.get('/reports/gstr2', auth, async (req) => gstr2Purchase(prisma, readScope(req)));
  app.get('/forms/layouts', auth, async () => listFormLayouts());
  app.get('/forms/layout', auth, async (req, reply) => {
    const q = req.query as any;
    const spec = loadFormLayout(String(q.name ?? ''));
    if (!spec) return reply.code(404).send({ error: 'form-layout-not-found' });
    return reply.type('text/html').send(renderFormLayout(spec));
  });
  app.get('/reports/layouts', auth, async () => listReportSpecs());
  app.get('/reports/layout', auth, async (req, reply) => {
    const q = req.query as any;
    const spec = loadReportSpec(String(q.name ?? ''));
    if (!spec) return reply.code(404).send({ error: 'report-spec-not-found' });
    const html = renderReportLayout(spec, {});
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="${String(q.name ?? 'report').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });
  app.get('/reports/render', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const spec = loadReportSpec(String(q.name ?? ''));
    if (!spec) return reply.code(404).send({ error: 'report-spec-not-found' });
    const missing = [
      !s.coYear && 'coYear',
      !s.coBook && 'coBook',
      !String(q.vchNo ?? '').trim() && 'vchNo',
    ].filter(Boolean);
    if (missing.length) return reply.code(400).send({ error: 'scope-required', fields: missing });
    if (q.orderFamily != null && !['SALES ORDER', 'TOUR ORDER'].includes(String(q.orderFamily))) {
      return reply.code(400).send({ error: 'invalid-order-family' });
    }
    if (q.copy != null && !Object.hasOwn(ORDER_REPORT_COPIES, String(q.copy))) {
      return reply.code(400).send({ error: 'invalid-order-copy' });
    }
    let bound: Awaited<ReturnType<typeof bindReport>>;
    try {
      bound = await bindReport(prisma, spec, {
        tenantId: s.tenantId,
        coCode: s.coCode,
        lcCode: s.lcCode,
        coYear: s.coYear!,
        coBook: String(s.coBook),
        vchNo: String(q.vchNo ?? ''),
        orderFamily: q.orderFamily,
        copy: q.copy,
      });
    } catch (err) {
      if (err instanceof UnsupportedReportBindingError) {
        return reply.code(422).send({ error: err.code, report: err.report, reason: err.reason });
      }
      if (/ValidationError|NumberingConfigurationError/.test((err as Error)?.name ?? '')) {
        return reply
          .code(400)
          .send({ error: (err as Error).name, message: (err as Error).message });
      }
      throw err;
    }
    if (!bound) return reply.code(404).send({ error: 'voucher-not-found' });
    let html: string;
    try {
      html = renderReportLayout(spec, {
        header: bound.header,
        detailRows: bound.detailRows,
        parentChild: bound.parentChild,
        subreports: bound.subreports,
        company: bound.company,
        orderImages: bound.orderImages,
      });
    } catch (error) {
      if (error instanceof UnsupportedReportBindingError) {
        return reply
          .code(422)
          .send({ error: error.code, report: error.report, reason: error.reason });
      }
      throw error;
    }
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(
        html,
        new PlaywrightPdfRenderer({
          preferCSSPageSize: [
            'OrderVch',
            'OrderBill',
            'TourOrdVch',
            'OrdVchImg',
            'TourOrdImg',
          ].includes(spec.report),
        }),
      );
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="${String(q.name ?? 'report').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });
  app.get('/reports/gstr2-doc', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const html = await renderGstr2Doc(prisma, s as any, {
      period: s.coYear ? `FY ${s.coYear}` : '',
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header('content-disposition', 'inline; filename="gstr2.pdf"')
      .send(pdf);
  });
  app.get('/reports/sales-return-register', auth, async (req) =>
    salesReturnRegister(prisma, readScope(req)),
  );
  app.get('/reports/karigar-statement', auth, async (req) =>
    karigarStatement(prisma, readScope(req)),
  );
  app.get('/reports/karigar-ledger', auth, async (req) => {
    const s = readScope(req);
    const ac = String((req.query as any).ac ?? '');
    return karigarLedger(prisma, s as any, ac);
  });
  app.get('/reports/karigar-ledger.print', auth, async (req, reply) => {
    const s = readScope(req);
    const ac = String((req.query as any).ac ?? '');
    const rep = await karigarLedger(prisma, s as any, ac);
    // G09: the letterhead is the active company's own name, not a hard-coded shop. Fall back to the
    // renderer's default only when the company master carries no name.
    const companyRows = (await withTxBudget(prisma, s.tenantId, 'read', (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_NAME" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
        s.tenantId,
        s.coCode,
      ),
    )) as Array<{ CO_NAME: string | null }>;
    const coName = String(companyRows[0]?.CO_NAME ?? '').trim();
    return reply
      .type('text/html')
      .send(coName ? renderKarigarLedgerHtml(ac, rep, coName) : renderKarigarLedgerHtml(ac, rep));
  });
  app.get('/reports/rate-list', auth, async (req) => rateList(prisma, readScope(req)));
  app.get('/reports/daily-sales', auth, async (req) => dailySalesSummary(prisma, readScope(req)));
  app.get('/reports/top-items', auth, async (req) => topItems(prisma, readScope(req)));
  app.get('/reports/employee-sales', auth, async (req) => employeeSales(prisma, readScope(req)));
  app.get('/reports/purchase-return-register', auth, async (req) =>
    purchaseReturnRegister(prisma, readScope(req)),
  );
  app.get('/reports/contra-register', auth, async (req) => contraRegister(prisma, readScope(req)));
  app.get('/reports/area-outstanding', auth, async (req) =>
    areaOutstanding(prisma, readScope(req)),
  );
  app.get('/reports/item-group-stock', auth, async (req) => itemGroupStock(prisma, readScope(req)));
  app.get('/reports/sales-gst-monthly', auth, async (req) =>
    salesGstMonthly(prisma, readScope(req)),
  );
  app.get('/reports/bill-aging', auth, async (req) => billAging(prisma, readScope(req)));
  app.get('/reports/stock-by-location', auth, async (req) =>
    stockByLocation(prisma, readScope(req)),
  );
  app.get('/reports/purchase-by-item', auth, async (req) => purchaseByItem(prisma, readScope(req)));
  app.get('/reports/voucher-register', auth, async (req) => {
    const s = readScope(req);
    const q = (req.query as any) || {};
    return voucherRegister(prisma, {
      ...s,
      book: q.book || undefined,
      fromDate: q.fromDate || undefined,
      toDate: q.toDate || undefined,
    } as any);
  });
  app.get('/reports/trial-balance-full', auth, async (req) =>
    trialBalanceFull(prisma, readScope(req)),
  );
  app.get('/reports/sales-by-group', auth, async (req) => salesByGroup(prisma, readScope(req)));
  app.get('/reports/cash-day-summary', auth, async (req) => cashDaySummary(prisma, readScope(req)));
  app.get('/reports/customer-crm', auth, async (req) => customerCrm(prisma, readScope(req)));
  app.get('/reports/area-wise-sales', auth, async (req) => areaWiseSales(prisma, readScope(req)));
  app.get('/reports/location-wise-sales', auth, async (req) =>
    locationWiseSales(prisma, readScope(req)),
  );
  app.get('/reports/gst-input-register', auth, async (req) =>
    gstInputRegister(prisma, readScope(req)),
  );
  app.post('/receipts/batch', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postBatchReceipt(prisma, { scope: scopeOf(req), vchDate: b.vchDate, lines: b.lines ?? [] }),
    );
  });
  app.get('/reminders/overdue', auth, async (req) => overdueReminders(prisma, readScope(req)));
  app.get('/reminders/birthdays', auth, async (req) =>
    birthdayReminders(prisma, readScope(req) as any, (req.query as any).onDate),
  );
  app.post('/reminders/send', auth, async (req, reply) => {
    const b = body(req);
    return run(reply, 200, () =>
      sendReminder(prisma, scopeOf(req), {
        mobile: b.mobile,
        message: b.message,
        channel: b.channel,
        idempotencyKey: b.idempotencyKey,
        templateKind: b.templateKind,
      }),
    );
  });
  app.post('/scheme/enroll', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      enrollScheme(prisma, {
        scope: scopeOf(req),
        schmCode: b.schmCode,
        membCode: b.membCode,
        membName: b.membName,
        monthlyAmt: Number(b.monthlyAmt),
        months: b.months ? Number(b.months) : undefined,
      }),
    );
  });
  app.post('/scheme/installment', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      schemeInstallment(prisma, {
        scope: scopeOf(req),
        schmCode: b.schmCode,
        membCode: b.membCode,
        amount: Number(b.amount),
        mode: b.mode,
        chqNo: b.chqNo,
        vchDate: b.vchDate,
        // The desktop's TR_MEMB_ENT grid also captures the settling bank, the collecting employee, the
        // scheme month, UPI settlement and the two account overrides. Without these the AD_DATA
        // columns BANK_NAME / EMP_CODE / MONTH_CODE / WITH_UPI could never be populated over the API.
        liabAc: b.liabAc,
        bankAc: b.bankAc,
        bankName: b.bankName,
        empCode: b.empCode,
        monthCode: b.monthCode,
        withUpi: b.withUpi === true || b.withUpi === 'Y',
        upiAcCode: b.upiAcCode,
        upiAcName: b.upiAcName,
        upiType: b.upiType,
        upiId: b.upiId,
        upiAmount: b.upiAmount != null ? Number(b.upiAmount) : undefined,
        upiLines: Array.isArray(b.upiLines)
          ? b.upiLines.map((u: Record<string, unknown>) => ({
              srNo: u.srNo != null ? Number(u.srNo) : undefined,
              upiAcCode: u.upiAcCode as string | undefined,
              upiAcName: u.upiAcName as string | undefined,
              upiType: u.upiType as string | undefined,
              upiId: u.upiId as string | undefined,
              amount: Number(u.amount),
            }))
          : undefined,
        // The desktop enters a whole collection round as one voucher (812 of 1428 real member-entry
        // vouchers carry more than one member). Amounts are coerced here; the module validates each
        // line and rejects a non-positive one naming its index.
        lines: Array.isArray(b.lines)
          ? b.lines.map((l: Record<string, unknown>) => ({
              schmCode: l.schmCode as string,
              membCode: l.membCode as string,
              amount: Number(l.amount),
              liabAc: l.liabAc as string | undefined,
              chqNo: l.chqNo as string | undefined,
              bankName: l.bankName as string | undefined,
              empCode: l.empCode as string | undefined,
              monthCode: l.monthCode as string | undefined,
              withUpi: l.withUpi === true || l.withUpi === 'Y',
              upiAcCode: l.upiAcCode as string | undefined,
              upiAcName: l.upiAcName as string | undefined,
              upiType: l.upiType as string | undefined,
              upiId: l.upiId as string | undefined,
              upiAmount: l.upiAmount != null ? Number(l.upiAmount) : undefined,
              upiLines: Array.isArray(l.upiLines)
                ? l.upiLines.map((u: Record<string, unknown>) => ({
                    srNo: u.srNo != null ? Number(u.srNo) : undefined,
                    upiAcCode: u.upiAcCode as string | undefined,
                    upiAcName: u.upiAcName as string | undefined,
                    upiType: u.upiType as string | undefined,
                    upiId: u.upiId as string | undefined,
                    amount: Number(u.amount),
                  }))
                : undefined,
            }))
          : undefined,
      }),
    );
  });
  // Member opening balance (desktop 075 MEMB OPENING → AD_DATA ENT_TYPE='O' + AD_OS + balanced AC_DATA).
  app.post('/scheme/opening', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      schemeOpening(prisma, {
        scope: scopeOf(req),
        schmCode: b.schmCode,
        membCode: b.membCode,
        amount: Number(b.amount),
        mode: b.mode,
        chqNo: b.chqNo,
        vchDate: b.vchDate,
        // The desktop's TR_MEMB_ENT grid also captures the settling bank, the collecting employee, the
        // scheme month, UPI settlement and the two account overrides. Without these the AD_DATA
        // columns BANK_NAME / EMP_CODE / MONTH_CODE / WITH_UPI could never be populated over the API.
        liabAc: b.liabAc,
        bankAc: b.bankAc,
        bankName: b.bankName,
        empCode: b.empCode,
        monthCode: b.monthCode,
        withUpi: b.withUpi === true || b.withUpi === 'Y',
        upiAcCode: b.upiAcCode,
        upiAcName: b.upiAcName,
        upiType: b.upiType,
        upiId: b.upiId,
        upiAmount: b.upiAmount != null ? Number(b.upiAmount) : undefined,
        upiLines: Array.isArray(b.upiLines)
          ? b.upiLines.map((u: Record<string, unknown>) => ({
              srNo: u.srNo != null ? Number(u.srNo) : undefined,
              upiAcCode: u.upiAcCode as string | undefined,
              upiAcName: u.upiAcName as string | undefined,
              upiType: u.upiType as string | undefined,
              upiId: u.upiId as string | undefined,
              amount: Number(u.amount),
            }))
          : undefined,
        // The desktop enters a whole collection round as one voucher (812 of 1428 real member-entry
        // vouchers carry more than one member). Amounts are coerced here; the module validates each
        // line and rejects a non-positive one naming its index.
        lines: Array.isArray(b.lines)
          ? b.lines.map((l: Record<string, unknown>) => ({
              schmCode: l.schmCode as string,
              membCode: l.membCode as string,
              amount: Number(l.amount),
              liabAc: l.liabAc as string | undefined,
              chqNo: l.chqNo as string | undefined,
              bankName: l.bankName as string | undefined,
              empCode: l.empCode as string | undefined,
              monthCode: l.monthCode as string | undefined,
              withUpi: l.withUpi === true || l.withUpi === 'Y',
              upiAcCode: l.upiAcCode as string | undefined,
              upiAcName: l.upiAcName as string | undefined,
              upiType: l.upiType as string | undefined,
              upiId: l.upiId as string | undefined,
              upiAmount: l.upiAmount != null ? Number(l.upiAmount) : undefined,
              upiLines: Array.isArray(l.upiLines)
                ? l.upiLines.map((u: Record<string, unknown>) => ({
                    srNo: u.srNo != null ? Number(u.srNo) : undefined,
                    upiAcCode: u.upiAcCode as string | undefined,
                    upiAcName: u.upiAcName as string | undefined,
                    upiType: u.upiType as string | undefined,
                    upiId: u.upiId as string | undefined,
                    amount: Number(u.amount),
                  }))
                : undefined,
            }))
          : undefined,
      }),
    );
  });
  app.delete('/scheme/opening/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteSchemeInstallment(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: '075',
        vchType: 'MBOP',
      }),
    );
  });
  /**
   * Scheme instalment deletion — plan item F1.2.
   *
   * WHY THIS IS THE MOST IMPORTANT DELETE IN PHASE F1
   * ================================================
   * Scheme is the **highest-volume workflow in the business**: 841 vouchers and 1635 day-book rows in the
   * reference year — more than sales (189 vouchers, 556 day-book rows). It had no reversal at all, so an
   * operator who took a wrong instalment could not undo it.
   *
   * `deleteSchemeInstallment` already existed (scheme.ts:673) and was already routed — but only for book
   * **075** (MEMB OPENING, `MBOP`) above. The live instalment book is **074** (MEMB ENTRY, `MBENT`), which
   * carries all 841 vouchers. Both write AD_DATA (`BOOK_TBL_NAME='AD_DATA'` on both books), so the same
   * reversal is correct; only the book and the audit's VCH_TYPE differ.
   *
   * Book and short name are taken from the real BOOK_DATA rows:
   *     074 | Member Monthly Entry | MBENT | AD_DATA | MEMB ENTRY
   *     075 | Member Opening Entry | MBOP  | AD_DATA | MEMB OPENING
   * VCH_TYPE equals BOOK_SNAME on 39 of 40 real books, which is why 'MBENT' is the audit classification.
   */
  app.delete('/scheme/installment/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteSchemeInstallment(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: String(body(req).book ?? '074'),
        vchType: 'MBENT',
      }),
    );
  });
  /**
   * Scheme enrolment removal — plan item F1.2.
   *
   * Enrolment is keyed by scheme + member, not by a voucher number: `enrollScheme` creates the AD_MEMB
   * membership record, and the instalments that follow are the vouchers. So this takes the member identity
   * rather than a `:vchNo`, and `deleteEnrollment` (scheme.ts:738) removes the AD_MEMB row.
   *
   * The desktop shows 3 MEMB ENTRY deletions in DELETE_DATA. Removing an enrolment that still has instalments
   * would orphan them, so the module guards that; the route surfaces the guard rather than working around it.
   */
  app.delete('/scheme/enroll', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const b = body(req);
    return run(reply, 200, () =>
      deleteEnrollment(prisma, {
        scope: scopeOf(req),
        schmCode: b.schmCode,
        membCode: b.membCode,
      }),
    );
  });
  // Scheme maturity / redemption (desktop 076 MEMB ADJUST → AC_DATA + AD_ADJ + AD_OS '-').
  app.post('/scheme/maturity', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      schemeMaturity(prisma, {
        scope: scopeOf(req),
        schmCode: b.schmCode,
        membCode: b.membCode,
        amount: Number(b.amount),
        bonus: b.bonus != null ? Number(b.bonus) : undefined,
        less: b.less != null ? Number(b.less) : undefined,
        mode: b.mode,
        bankAc: b.bankAc,
        acName: b.acName,
        vchDesc: b.vchDesc,
        chqNo: b.chqNo,
        vchDate: b.vchDate,
      }),
    );
  });
  app.delete('/scheme/maturity/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteSchemeMaturity(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
      }),
    );
  });
  app.post('/scheme/gold-adjust', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    const mapLine = (l: Record<string, unknown>) => ({
      srNo: l.srNo != null ? Number(l.srNo) : undefined,
      schmCode: l.schmCode as string,
      membCode: l.membCode as string,
      acCode: l.acCode as string | undefined,
      acName: l.acName as string | undefined,
      goldWt: l.goldWt != null ? Number(l.goldWt) : undefined,
      goldRate: l.goldRate != null ? Number(l.goldRate) : undefined,
      goldAmt: l.goldAmt != null ? Number(l.goldAmt) : undefined,
      memberAmount: l.memberAmount != null ? Number(l.memberAmount) : undefined,
      adjustAmount: l.adjustAmount != null ? Number(l.adjustAmount) : undefined,
      bonus: l.bonus != null ? Number(l.bonus) : undefined,
      less: l.less != null ? Number(l.less) : undefined,
      saleBillNo: l.saleBillNo as string | undefined,
      saleBillLcCode: l.saleBillLcCode as string | undefined,
      saleBillYear: l.saleBillYear as string | undefined,
      saleBillBook: l.saleBillBook as string | undefined,
      saleBillAmount: l.saleBillAmount != null ? Number(l.saleBillAmount) : undefined,
      saleBillHeaderVoucherNo: l.saleBillHeaderVoucherNo as string | undefined,
      empCode: l.empCode as string | undefined,
      vchDesc: l.vchDesc as string | undefined,
    });
    return run(reply, 201, () =>
      schemeGoldAdjust(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        mainUser: sess(req).sub,
        updateExpiry: b.updateExpiry === true || b.updateExpiry === 'Y',
        ...(Array.isArray(b.lines) && b.lines.length
          ? { lines: b.lines.map((l: Record<string, unknown>) => mapLine(l)) }
          : mapLine(b)),
      }),
    );
  });
  app.delete('/scheme/gold-adjust/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteSchemeGoldAdjust(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.post('/ac-opbl', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postAcOpening(prisma, { scope: scopeOf(req), vchDate: b.vchDate, lines: b.lines ?? [] }),
    );
  });
  app.post('/fine-jv', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postFineJv(prisma, {
        scope: scopeOf(req),
        fromAc: b.fromAc,
        toAc: b.toAc,
        fineWt: Number(b.fineWt),
        metal: b.metal,
        vchDate: b.vchDate,
      }),
    );
  });
  app.delete('/fine-jv/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteFineJv(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
      }),
    );
  });
  app.get('/bill-to-bill/open', auth, async (req) => {
    const s = readScope(req);
    return listOpenBills(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode, coYear: s.coYear, lcCode: s.lcCode },
      String((req.query as any).acCode ?? ''),
    );
  });
  /**
   * Reverse a bill-to-bill settlement — plan item F1.4, previously blocked as decision D-4.
   *
   * Matches the desktop exactly: it removes the voucher's own rows across BILL_OS_DATA, AC_DATA,
   * ROJ_MEL_DATA, REMARK_DATA, CASH_DATA and TEMP_BOOK_DATA and writes a DELETE_DATA audit row, and it does
   * NOT restore the REC_AMT it applied to the bills it paid — `UPDATE BILL_OS_DATA` appears zero times in
   * TR_BILL_TO.cs's delete path. See deleteBillSettlement for why replicating that is deliberate.
   */
  app.delete('/bill-to-bill/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const b = body(req);
    return run(reply, 200, () =>
      deleteBillSettlement(prisma, {
        scope: scopeOf(req) as any,
        vchNo: (req.params as any).vchNo,
        book: b.book,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.post('/bill-to-bill/settle', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 200, () =>
      settleBills(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        allocations: b.allocations ?? [],
        mode: b.mode,
        bankAc: b.bankAc,
        cashAc: b.cashAc,
        kasarAc: b.kasarAc,
        partyName: b.partyName,
        vchDate: b.vchDate,
        tenders: b.tenders,
      }),
    );
  });
  // ---- Bank Reconciliation ----
  app.get('/bank-recon', auth, async (req) => {
    const s = readScope(req);
    const qy = (req.query as any) || {};
    return bankReconList(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String(qy.bankAc ?? ''),
      { from: qy.from ? String(qy.from) : undefined, to: qy.to ? String(qy.to) : undefined },
    );
  });
  app.post('/bank-recon/clear', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = sess(req);
    const b = body(req);
    return run(reply, 200, () =>
      bankReconClear(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String(b.bankAc ?? ''),
        b.items ?? [],
      ),
    );
  });
  app.post('/rate-cut', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => postRateCut(prisma, rateCutInput(req, b)));
  });
  app.put('/rate-cut/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editRateCut(prisma, rateCutInput(req, b), (req.params as any).vchNo),
    );
  });
  app.post('/bullion-sales', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => postBullionSale(prisma, rateCutInput(req, b)));
  });
  app.put('/bullion-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editBullionSale(prisma, rateCutInput(req, b), (req.params as any).vchNo),
    );
  });
  app.delete('/rate-cut/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteRateCut(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
        // DELETE_DATA.DELETE_USER is the signed-in user (TR_WH_SALE.cs:13569 `MCo_User`).
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.delete('/bullion-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteBullionSale(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
        deleteUser: sess(req).sub,
      }),
    );
  });
  // Desktop "Wh Sales" (TR_WH_SALE on a WH SALES book). Same voucher family as the rate cut; its own right.
  app.post('/wholesale-sales', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => postWholesaleSale(prisma, rateCutInput(req, b)));
  });
  app.get('/wholesale-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getWholesaleSale(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/wholesale-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editWholesaleSale(prisma, rateCutInput(req, b), (req.params as any).vchNo),
    );
  });
  app.delete('/wholesale-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteWholesaleSale(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
        deleteUser: sess(req).sub,
      }),
    );
  });
  // Desktop WH QUOT: same TR_WH_SALE document grids, but no financial or inventory posting.
  app.post('/wholesale-quotations', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => postWholesaleQuotation(prisma, rateCutInput(req, b)));
  });
  app.get('/wholesale-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getWholesaleQuotation(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  app.get('/wholesale-quotations/:vchNo/print', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = req.query as any;
    const copy = standardDocumentCopy(q.copy, reply);
    if (copy === null) return reply;
    const scope = scopeOf(req);
    const voucher = await getWholesaleQuotation(prisma, scope, (req.params as any).vchNo);
    const context = await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
      const companies: any[] = await tx.$queryRawUnsafe(
        `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
      );
      const parties: any[] = await tx.$queryRawUnsafe(
        `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
          ORDER BY ("LC_CODE"=$4) DESC,row_id LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        String(voucher.acCode ?? ''),
        scope.lcCode,
      );
      return { company: companies[0], party: parties[0] };
    });
    const html = wholesaleQuotationHtml(voucher, { ...context, copy });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header(
        'content-disposition',
        `inline; filename="wholesale-quotation-${String((req.params as any).vchNo).replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });
  app.put('/wholesale-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editWholesaleQuotation(prisma, rateCutInput(req, b), (req.params as any).vchNo),
    );
  });
  app.delete('/wholesale-quotations/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteWholesaleQuotation(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
        deleteUser: sess(req).sub,
      }),
    );
  });
  app.delete('/ac-opbl/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteAcOpening(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
      }),
    );
  });
  // Tag Split (X20): desktop TR_TAG_SPLIT on a TAG SPLIT book. One writer (modules/stock/tagSplit.ts): the parent
  // tags are consumed and child tags created, conserving metal. Literal routes so the route-count test can scan them.
  const tagSplitInput = (req: FastifyRequest, b = body(req)) => ({
    scope: scopeOf(req),
    vchDate: b.vchDate,
    empCode: b.empCode,
    vchDesc: b.vchDesc,
    acCode: b.acCode,
    itType: b.itType,
    drTouch: b.drTouch,
    crTouch: b.crTouch,
    crLbr: b.crLbr,
    mainUser: sess(req).sub,
    parents: Array.isArray(b.parents) ? b.parents : [],
    children: Array.isArray(b.children) ? b.children : [],
  });
  app.get('/stock/tag-split', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => listTagSplit(prisma, scopeOf(req)));
  });
  app.get('/stock/tag-split/source', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      tagSplitSource(prisma, scopeOf(req), {
        tagNo: q.tagNo,
        vchSrno: q.vchSrno,
        itCode: q.itCode,
      }),
    );
  });
  app.get('/stock/tag-split/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getTagSplit(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.post('/stock/tag-split', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => saveTagSplit(prisma, tagSplitInput(req)));
  });
  app.put('/stock/tag-split/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () =>
      saveTagSplit(prisma, tagSplitInput(req), (req.params as any).vchNo),
    );
  });
  app.delete('/stock/tag-split/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTagSplit(prisma, scopeOf(req), (req.params as any).vchNo, sess(req).sub),
    );
  });
  app.get('/reports/party-statement', auth, async (req) =>
    partyStatement(prisma, readScope(req) as any),
  );
  app.get('/reports/hsn-summary', auth, async (req) => hsnSummary(prisma, readScope(req)));
  app.post('/journal', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postJournal(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        narration: b.narration,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/journal/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteJournal(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
      }),
    );
  });
  /**
   * Contra deletion (desktop TR_CONTRA).
   *
   * WHY THIS EXISTS
   * ===============
   * `POST /contra` had no reversal, so a contra voucher could be created and never undone. That matters
   * because deleting and re-entering is how this business actually corrects a voucher: `USER_DATA` — the
   * per-column edit audit — holds ZERO rows for the year, while `DELETE_DATA` holds 72 across 17 families,
   * of which **6 are CONTRA**. It is the fourth most-deleted family in the company's real data.
   *
   * `deleteContra` (finance.ts:1409) is the purpose-built reversal: it reads the full CONTRA_DATA detail set
   * through `editIdentityTx` with the header's `extraColumns`, so the delete audit carries the voucher's own
   * amounts rather than zeros. An earlier revision of this route delegated to `deleteJournal`, which reverses
   * the same three tables but does not read those columns.
   */
  /**
   * REOPENING A SAVED VOUCHER — plan item F2.1.
   *
   * WHY THESE EXIST
   * ===============
   * 13 of the 19 voucher families this business actually uses could be POSTED but never REOPENED. A voucher
   * became unreachable the moment it was saved: it could not be viewed to check what was entered, and it could
   * not be reprinted. In the desktop, opening a saved voucher by number is a core interaction — it is what the
   * F-key lookup is for — so this is the difference between a data-entry screen and an ERP.
   *
   * Nothing new was implemented for these. Every `get*` function below already existed in its module and was
   * simply never routed; a scan of `export async function (get|edit|delete)*` against the route file found
   * **34 of 120 lifecycle functions unrouted**. The pattern followed is `GET /purchases/:vchNo`
   * (`getPurchase`, line 1117 above) and every one of these shares its signature:
   * `(prisma, scope, voucherNo)`.
   *
   * Ordered by how much the business uses them, from the AC_DATA/BOOK_DATA census:
   *   scheme instalment 841 · cash receipt 56 · sales order 39 · contra 37 · scheme maturity 17 ·
   *   fine JV 14 · labour invoice 3 · sales return 1 · order cancel 1
   *
   * Two live families are NOT here because they have no `get*` function to route — `payments` (133 vouchers,
   * whose header is PAY_DATA rather than the CASH_DATA `getReceipt` reads) and `rate-cut` (40). Those need a
   * function written, not a route, and are recorded as still-open in the plan rather than faked here.
   */
  app.get('/contra/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getContra(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/contra/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editContra(
        prisma,
        {
          scope: scopeOf(req),
          fromAc: b.fromAc,
          toAc: b.toAc,
          amount: Number(b.amount),
          vchDate: b.vchDate,
          itDesc: b.itDesc,
          toAcName: b.toAcName,
          empCode: b.empCode,
          itemType: b.itemType,
          mainUser: sess(req).sub,
        },
        (req.params as any).vchNo,
      ),
    );
  });
  app.get('/receipts/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getReceipt(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  /**
   * A payment needs its OWN reader: its header is PAY_DATA, not the CASH_DATA a receipt writes, so
   * `getReceipt` would report every payment as missing. 133 live vouchers — the second most-used family.
   */
  app.get('/payments/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getPayment(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  /**
   * One reader serves rate-cut AND wholesale sale: BOOK_DATA for MAIN_BOOK='WH SALES' carries
   * BOOK_TBL_NAME='RATE_CUT_DATA', so both families share the header table. 40 live vouchers between them.
   */
  app.get('/rate-cut/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getRateCut(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.get('/bullion-sales/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getBullionSale(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.get('/fine-jv/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getFineJv(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.get('/labour-invoice/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getLabourInvoice(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.get('/sales-returns/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getSaleReturn(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.get('/sales-orders/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getSalesOrder(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  /**
   * The order-cancel / order-adjustment voucher is a SEPARATE family from the order itself (desktop
   * TR_SL_ORD_ADJ, book 081 ORDER CANCEL), so it gets its own path rather than overloading `/sales-orders`.
   */
  app.get('/sales-orders/:vchNo/adjustment', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getSalesOrderAdjustment(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  /**
   * Scheme reads take the BOOK because one desktop routine serves several books that all write AD_DATA:
   * 074 MEMB ENTRY (`MBENT`, the 841 live instalments), 075 MEMB OPENING (`MBOP`) and 076 MEMB ADJUST
   * (`MBADJ`). Defaulting to the module's own default keeps the common call short.
   */
  app.get('/scheme/installment/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const book = (req.query as any)?.book;
    return run(reply, 200, () =>
      book
        ? getSchemeInstallment(prisma, scopeOf(req), (req.params as any).vchNo, String(book))
        : getSchemeInstallment(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  /**
   * Maturity takes no book override: `MEMB_ADJUST` is a single book (076 `MBADJ`), and the module types the
   * parameter as that literal. Only the instalment read spans books.
   */
  app.get('/scheme/maturity/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getSchemeMaturity(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  app.get('/scheme/gold-adjust/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const book = (req.query as any)?.book;
    return run(reply, 200, () =>
      getSchemeGoldAdjust(
        prisma,
        scopeOf(req),
        (req.params as any).vchNo,
        book ? String(book) : undefined,
      ),
    );
  });
  app.delete('/contra/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteContra(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).sub,
        book: body(req).book,
      }),
    );
  });
  // Ledger adjustment (desktop TR_LEDR_ADJ → LDR_ADJ_DATA + balanced AC_DATA).
  app.post('/ledger-adjust', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postLedgerAdjust(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        adjAc: b.adjAc,
        amount: Number(b.amount),
        direction: b.direction === 'credit' ? 'credit' : 'debit',
        remark: b.remark,
        vchDate: b.vchDate,
      }),
    );
  });
  app.delete('/ledger-adjust/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteLedgerAdjust(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
      }),
    );
  });
  // Employee salary JV (desktop TR_EMP_JV → EMP_DATA + balanced AC_DATA with TDS/PF deductions).
  app.post('/employee-jv', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      postEmployeeJv(prisma, {
        scope: scopeOf(req),
        empAc: b.empAc,
        empName: b.empName,
        empCode: b.empCode,
        paidAc: b.paidAc,
        salaryAmt: Number(b.salaryAmt),
        tdsAmt: b.tdsAmt != null ? Number(b.tdsAmt) : undefined,
        pfAmt: b.pfAmt != null ? Number(b.pfAmt) : undefined,
        tdsAc: b.tdsAc,
        pfAc: b.pfAc,
        chqNo: b.chqNo,
        desc: b.desc,
        vchDate: b.vchDate,
      }),
    );
  });
  app.delete('/employee-jv/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteEmployeeJv(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
      }),
    );
  });
  app.get('/reports/monthly-sales', auth, async (req) => monthlySales(prisma, readScope(req)));
  app.get('/gst/gstr1', auth, async (req) =>
    gstr1(prisma, readScope(req), gstr1Options(req.query)),
  );
  // The same screen at the slug path every other generic report uses, so `gstr1` has a fixed route on
  // the same form as its slug policy (reportAuthorization.test.ts) and the report page needs no special case.
  app.get('/reports/gstr1', auth, async (req) =>
    gstr1(prisma, readScope(req), gstr1Options(req.query)),
  );
  app.get('/reports/gstr1-doc', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const period =
      [q.fromDate, q.toDate].filter(Boolean).join(' — ') || (s.coYear ? `FY ${s.coYear}` : '');
    const html = await renderGstr1Doc(prisma, s as any, {
      threshold: Number(q.threshold) || undefined,
      period,
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header('content-disposition', 'inline; filename="gstr1.pdf"')
      .send(pdf);
  });
  app.get('/reports/gstr3b', auth, async (req) => gstr3b(prisma, readScope(req)));
  app.get('/reports/trial-balance-doc', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const html = await renderTrialBalanceDoc(prisma, s as any, {
      period: s.coYear ? `FY ${s.coYear}` : '',
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header('content-disposition', 'inline; filename="trial-balance.pdf"')
      .send(pdf);
  });
  app.get('/reports/gstr3b-doc', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const html = await renderGstr3bDoc(prisma, s as any, {
      period: s.coYear ? `FY ${s.coYear}` : '',
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header('content-disposition', 'inline; filename="gstr3b.pdf"')
      .send(pdf);
  });
  app.get('/reports/balance-sheet-doc', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const html = await renderBalanceSheetDoc(prisma, s as any, {
      period: s.coYear ? `FY ${s.coYear}` : '',
    });
    if (q.format === 'html') return reply.type('text/html').send(html);
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    return reply
      .header('content-type', 'application/pdf')
      .header('content-disposition', 'inline; filename="balance-sheet.pdf"')
      .send(pdf);
  });

  // ---- E-invoice (IRN via Fake transport until GSP creds provided) ----
  app.get('/einvoice/export.xlsx', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    try {
      const data = await eInvoiceExportData(prisma, readScope(req), {
        coBook: q.coBook,
        fromDate: q.fromDate,
        toDate: q.toDate,
      });
      const out = await renderXlsx(eInvoiceExportSheets(data), 'e-invoice');
      return reply
        .header('content-type', out.contentType)
        .header('content-disposition', `attachment; filename="${out.fileName}"`)
        .send(out.buffer);
    } catch (e: any) {
      if (e?.name === 'EInvoiceValidationError') {
        return reply.code(400).send({ error: e.name, message: e.message });
      }
      throw e;
    }
  });

  app.post('/einvoice/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const b = body(req);
    return run(reply, 201, async () => {
      const payload = buildIrnPayload({
        seller: b.seller,
        buyer: b.buyer,
        sale: b.sale,
        items: b.items ?? [],
      });
      const { transport, mode } = irnTransportFromEnv();
      const res = await submitIrn(prisma, scopeOf(req) as any, {
        vchNo: (req.params as any).vchNo,
        payload,
        transport,
      });
      return { irn: res.Irn, ackNo: res.AckNo, mode };
    });
  });
  app.post('/einvoice/irn', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const b = body(req);
    return run(reply, 201, async () => {
      const res = await submitIrnForSale(prisma, scopeOf(req) as any, {
        coBook: scopeOf(req).coBook ?? 'SAL',
        vchNo: b.vchNo,
      });
      return { irn: res.Irn, ackNo: res.AckNo, mode: res.mode };
    });
  });
  app.get('/e-credit-notes/provider', auth, async () => gspStatus());
  // ---- TR_SL_EBILL entry lifecycle: E CRNT (/e-credit-notes) and E INVOICE (/e-invoices), card X15 ----
  const eBillInput = (req: FastifyRequest, b: Record<string, any>) => ({
    scope: scopeOf(req),
    vchDate: b.vchDate,
    partyCode: b.partyCode,
    billNo: b.billNo,
    ledgerCode: b.ledgerCode,
    employeeCode: b.employeeCode,
    description: b.description,
    cashAmount: b.cashAmount,
    chequeAmount: b.chequeAmount,
    chequeAccount: b.chequeAccount,
    chequeNo: b.chequeNo,
    cardAmount: b.cardAmount,
    cardAccount: b.cardAccount,
    cardCommission: b.cardCommission,
    kasarAmount: b.kasarAmount,
    tdsCode: b.tdsCode,
    tcsCode: b.tcsCode,
    tcsAmount: b.tcsAmount,
    lines: Array.isArray(b.lines) ? b.lines : [],
    mainUser: sess(req).sub,
    expectedRevision: b.expectedRevision,
  });
  // TR_SL_EBILL BtnPrint_Click prints "ORIGINAL FOR RECIPIENT" and/or "DUPLICATE FOR SUPPLIER".
  const EBILL_COPIES: Record<string, string> = {
    O: 'ORIGINAL FOR RECIPIENT',
    D: 'DUPLICATE FOR SUPPLIER',
  };
  const eBillHandlers = (family: EBillFamily, title: string, file: string) => ({
    entryConfig: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'view')) return;
      return run(reply, 200, () => getEBillEntryConfig(prisma, family, scopeOf(req)));
    },
    entry: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'view')) return;
      const vchNo = String((req.params as any).vchNo);
      const notFound = Symbol('not-found');
      const outcome = await run(reply, 200, async () => {
        const result = await getEBillEntry(prisma, family, scopeOf(req), vchNo);
        if (!result) throw notFound;
        return result;
      }).catch((error: unknown) => {
        if (error === notFound) return reply.code(404).send({ error: 'voucher-not-found' });
        throw error;
      });
      return outcome;
    },
    create: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'create')) return;
      return run(reply, 201, () => saveEBill(prisma, family, eBillInput(req, body(req))));
    },
    update: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'update')) return;
      return run(reply, 200, () =>
        saveEBill(prisma, family, eBillInput(req, body(req)), String((req.params as any).vchNo)),
      );
    },
    remove: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'delete')) return;
      const q = (req.query ?? {}) as Record<string, string | undefined>;
      const b = body(req);
      return run(reply, 200, () =>
        deleteEBill(prisma, family, scopeOf(req), String((req.params as any).vchNo), {
          deleteUser: sess(req).sub,
          expectedRevision: b.expectedRevision ?? q.expectedRevision,
        }),
      );
    },
    print: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'print')) return;
      const q = req.query as any;
      if (q.copy != null && q.copy !== '' && !EBILL_COPIES[String(q.copy)])
        return reply.code(400).send({ error: 'invalid-copy', message: 'copy must be O or D' });
      let data: Awaited<ReturnType<typeof eBillPrintData>> | undefined;
      try {
        data = await eBillPrintData(
          prisma,
          family,
          scopeOf(req),
          String((req.params as any).vchNo),
        );
      } catch (error: any) {
        if (/ValidationError|NumberingConfigurationError/.test(error?.name ?? ''))
          return reply.code(400).send({ error: error.name, message: error.message });
        throw error;
      }
      if (!data) return reply.code(404).send({ error: 'voucher-not-found' });
      const html = invoiceHtml(data.header, data.lines, {
        company: data.company,
        party: data.party,
        title,
        copy: q.copy ? EBILL_COPIES[String(q.copy)] : undefined,
      });
      if (q.format === 'html') return reply.type('text/html').send(html);
      let pdf: Buffer;
      try {
        pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
      } catch {
        return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
      }
      return reply
        .header('content-type', 'application/pdf')
        .header(
          'content-disposition',
          `inline; filename="${file}-${String((req.params as any).vchNo).replace(/[^\w.-]/g, '')}.pdf"`,
        )
        .send(pdf);
    },
    cancelIrn: async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'print')) return;
      const b = body(req);
      const scope = scopeOf(req);
      return run(reply, 200, () =>
        cancelIrnForSale(prisma, scope as any, {
          coBook: String(scope.coBook ?? ''),
          vchNo: (req.params as any).vchNo,
          reason: b.reason,
          remark: b.remark,
          expectedMainBook: family,
        }),
      );
    },
  });
  const crnt = eBillHandlers('E CRNT', 'Credit Note', 'ecrnt');
  const inv = eBillHandlers('E INVOICE', 'Tax Invoice', 'einvoice');
  app.get('/e-credit-notes/entry-config', auth, crnt.entryConfig);
  app.get('/e-credit-notes/:vchNo/entry', auth, crnt.entry);
  app.post('/e-credit-notes', auth, crnt.create);
  app.put('/e-credit-notes/:vchNo', auth, crnt.update);
  app.delete('/e-credit-notes/:vchNo', auth, crnt.remove);
  app.get('/e-credit-notes/:vchNo/print', auth, crnt.print);
  app.post('/e-credit-notes/:vchNo/irn/cancel', auth, crnt.cancelIrn);
  app.get('/e-invoices/entry-config', auth, inv.entryConfig);
  app.get('/e-invoices/:vchNo/entry', auth, inv.entry);
  app.post('/e-invoices', auth, inv.create);
  app.put('/e-invoices/:vchNo', auth, inv.update);
  app.delete('/e-invoices/:vchNo', auth, inv.remove);
  app.get('/e-invoices/:vchNo/print', auth, inv.print);
  app.post('/e-invoices/:vchNo/irn/cancel', auth, inv.cancelIrn);
  app.get('/e-invoices', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = req.query as any;
    return run(reply, 200, () =>
      listEInvoices(prisma, scopeOf(req), {
        search: q.search,
        offset: q.offset == null ? undefined : Number(q.offset),
        limit: q.limit == null ? undefined : Number(q.limit),
      }),
    );
  });
  app.get('/e-invoices/tcs-basis', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = req.query as any;
    return run(reply, 200, () => eInvoiceTcsBasis(prisma, scopeOf(req), String(q.partyCode ?? '')));
  });
  app.get('/e-invoices/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const notFound = Symbol('not-found');
    const outcome = await run(reply, 200, async () => {
      const result = await getEInvoice(prisma, scopeOf(req), (req.params as any).vchNo);
      if (!result) throw notFound;
      return result;
    }).catch((error: unknown) => {
      if (error === notFound) return reply.code(404).send({ error: 'voucher-not-found' });
      throw error;
    });
    return outcome;
  });
  app.post('/e-invoices/:vchNo/irn', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const scope = scopeOf(req);
    const vchNo = String((req.params as any).vchNo);
    return run(reply, 201, async () => {
      await assertEBillNotRegistered(prisma, 'E INVOICE', scope, vchNo);
      const res = await submitIrnForSale(prisma, scope as any, {
        coBook: String(scope.coBook ?? ''),
        vchNo,
        docType: 'INV',
        expectedMainBook: 'E INVOICE',
      });
      return { irn: res.Irn, ackNo: res.AckNo, mode: res.mode };
    });
  });
  app.get('/e-credit-notes', auth, async (req, reply) => {
    const q = req.query as any;
    return run(reply, 200, () =>
      listCreditNotes(prisma, scopeOf(req), {
        search: q.search,
        offset: q.offset == null ? undefined : Number(q.offset),
        limit: q.limit == null ? undefined : Number(q.limit),
      }),
    );
  });
  app.get('/e-credit-notes/:vchNo', auth, async (req, reply) => {
    const result = await getCreditNote(prisma, scopeOf(req), (req.params as any).vchNo).catch(
      (error: Error) => {
        if (/ValidationError|NumberingConfigurationError/.test(error.name)) {
          reply.code(400).send({ error: error.name, message: error.message });
          return undefined;
        }
        throw error;
      },
    );
    if (result === undefined) return reply;
    if (!result) return reply.code(404).send({ error: 'credit-note-not-found' });
    return result;
  });
  app.post('/einvoice/credit-note/irn', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const b = body(req);
    return run(reply, 201, async () => {
      const coBook = scopeOf(req).coBook ?? '146';
      await assertEBillNotRegistered(prisma, 'E CRNT', { ...scopeOf(req), coBook }, b.vchNo);
      const res = await submitIrnForCreditNote(prisma, scopeOf(req) as any, {
        coBook,
        vchNo: b.vchNo,
      });
      return { irn: res.Irn, ackNo: res.AckNo, mode: res.mode };
    });
  });
  app.get('/einvoice/gsp-config', auth, async () => gspStatus());
  app.post('/einvoice/gsp-test', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return; // admin-gate
    return run(reply, 200, () => testGspAuth());
  });
  app.post('/einvoice/:vchNo/cancel', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const b = body(req);
    return run(reply, 200, () =>
      cancelIrnForSale(prisma, scopeOf(req) as any, {
        coBook: scopeOf(req).coBook ?? 'SAL',
        vchNo: (req.params as any).vchNo,
        reason: b.reason,
        remark: b.remark,
      }),
    );
  });
  app.post('/bullion/booking', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      bullionBooking(prisma, {
        scope: scopeOf(req),
        partyAc: b.partyAc,
        fineWt: Number(b.fineWt),
        rate: Number(b.rate),
        advanceAmt: Number(b.advanceAmt || 0),
        vchDate: b.vchDate,
      }),
    );
  });
  app.delete('/bullion/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteBullionBooking(prisma, { scope: scopeOf(req), vchNo: (req.params as any).vchNo }),
    );
  });
  // ---- Fine sale / purchase (TR_FINE_SL_PR): pure-metal trade on fine weight + rate-cut ----
  app.post('/fine-sale', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    const side = String(b.side || 'SALE').toUpperCase() === 'PURC' ? 'PURC' : 'SALE';
    return run(reply, 201, () =>
      createFineSalePurchase(prisma, {
        scope: { ...scopeOf(req), coBook: side === 'PURC' ? 'FPR' : 'FSL' },
        side,
        partyAc: b.partyAc,
        partyName: b.partyName,
        itType: b.itType,
        taxPct: b.taxPct != null ? Number(b.taxPct) : undefined,
        interState: !!b.interState,
        vchDate: b.vchDate,
        lines: b.lines ?? [],
        cuts: b.cuts ?? [],
        cashAc: b.cashAc,
      }),
    );
  });
  app.delete('/fine-sale/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const side = String(body(req).side || 'SALE').toUpperCase() === 'PURC' ? 'PURC' : 'SALE';
    return run(reply, 200, () =>
      deleteFineSalePurchase(prisma, {
        scope: { ...scopeOf(req), coBook: side === 'PURC' ? 'FPR' : 'FSL' },
        vchNo: (req.params as any).vchNo,
        side,
        deleteUser: sess(req).tenantId,
      }),
    );
  });
  app.post('/tour/issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      tourIssue(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        salesmanAc: b.salesmanAc,
        salesmanName: b.salesmanName,
        vchDesc: b.vchDesc,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.post('/year-end/preview', auth, async (req) =>
    yearEndPreview(prisma, {
      scope: scopeOf(req) as any,
      fromYear: body(req).fromYear ?? sess(req).coYear,
    }),
  );
  app.post('/year-end/close', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    const s = sess(req);
    return run(reply, 201, () =>
      yearEndClose(prisma, {
        scope: scopeOf(req) as any,
        fromYear: b.fromYear ?? s.coYear,
        toYear: b.toYear,
      }),
    );
  });
  app.post('/balance-transfer/preview', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const b = body(req);
    const s = sess(req);
    return run(reply, 200, () =>
      yearEndPreview(prisma, {
        scope: scopeOf(req) as any,
        fromYear: b.fromYear ?? s.coYear,
      }),
    );
  });
  app.post('/balance-transfer/year-close', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    const s = sess(req);
    return run(reply, 201, () =>
      yearEndClose(prisma, {
        scope: scopeOf(req) as any,
        fromYear: b.fromYear ?? s.coYear,
        toYear: b.toYear,
      }),
    );
  });
  app.post('/balance-transfer/openings', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    const b = body(req);
    return run(reply, 200, () =>
      carryForwardOpenings(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode },
        String(b.fromYear),
        String(b.toYear),
      ),
    );
  });
  app.delete('/tour/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTour(prisma, { scope: scopeOf(req), vchNo: (req.params as any).vchNo }),
    );
  });
  app.post('/tour/return', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      tourReturn(prisma, {
        scope: scopeOf(req),
        origVchNo: b.origVchNo,
        vchDate: b.vchDate,
        salesmanAc: b.salesmanAc,
        salesmanName: b.salesmanName,
        vchDesc: b.vchDesc,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/tour/:vchNo/lines', auth, async (req) =>
    tourLines(prisma, scopeOf(req), (req.params as any).vchNo),
  );
  app.post('/tour/:vchNo/bill', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    const aprVchNo = (req.params as any).vchNo;
    return run(reply, 201, async () => {
      const sale = await createSale(
        prisma,
        {
          scope: scopeOf(req),
          acCode: b.acCode,
          acName: b.acName,
          taxRatePct: Number(b.taxRatePct ?? 3),
          interState: !!b.interState,
          empCode: b.empCode,
          cashAmt: b.cashAmt != null ? Number(b.cashAmt) : undefined,
          cardAmt: b.cardAmt != null ? Number(b.cardAmt) : undefined,
          chequeAmt: b.chequeAmt != null ? Number(b.chequeAmt) : undefined,
          cashAc: b.cashAc,
          bankAc: b.bankAc,
        },
        b.lines ?? [],
      );
      const m = await markApprovalBilled(prisma, scopeOf(req), aprVchNo, String(sale.vchNo));
      return { ...sale, approvalBilled: m.marked };
    });
  });
  app.delete('/tour/return/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTourReturn(prisma, { scope: scopeOf(req), vchNo: (req.params as any).vchNo }),
    );
  });
}
