import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { withTenant } from '@datacare/db';
import { PasswordChangeError, resetUserPassword } from '../modules/auth/passwordAccount.js';
import { PasswordPolicyError } from '../modules/auth/password.js';
import { createSale, deleteSale, editSale, getSale } from '../modules/sales/sales.js';
import { computeLine as computeSaleLine } from '../modules/sales/sales.js';
import { billTotals } from '@datacare/core';
import { createSaleReturn, deleteSaleReturn, saleForReturn } from '../modules/sales/salesReturn.js';
import {
  createSalesOrder,
  listSalesOrders,
  cancelSalesOrder,
  cancelSalesOrderAdjust,
} from '../modules/sales/salesOrder.js';
import { createLabourInvoice, deleteLabourInvoice } from '../modules/sales/labourInvoice.js';
import { invoiceData, invoiceHtml } from '../modules/sales/invoice.js';
import { orderData, orderHtml } from '../modules/sales/orderDoc.js';
import { purchaseBillData, purchaseBillHtml } from '../modules/purchase/purchaseBill.js';
import { karigarIssueData, karigarIssueHtml } from '../modules/manufacturing/karigarVoucher.js';
import { financeVoucherData, financeVoucherHtml } from '../modules/finance/financeVoucher.js';
import { dhrnIssueData, dhrnIssueHtml } from '../modules/dhrn/dhrnReceipt.js';
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
import { bindReport } from '../modules/reports/reportBind.js';
import {
  loadFormLayout,
  renderFormLayout,
  listFormLayouts,
} from '../modules/forms/formLayoutEngine.js';
import { dhrnKhataData, dhrnKhataHtml } from '../modules/dhrn/dhrnKhata.js';
import { getSettings, saveSettings, SETTING_FIELDS } from '../modules/settings/settings.js';
import {
  createPurchase,
  getPurchase,
  editPurchase,
  deletePurchase,
  createOtherPurchase,
  deleteOtherPurchase,
} from '../modules/purchase/purchase.js';
import { createPurchaseReturn, deletePurchaseReturn } from '../modules/purchase/purchaseReturn.js';
import {
  postReceipt,
  postPayment,
  postContra,
  postReceiptLines,
  postPaymentLines,
  deleteReceiptLines,
  deletePaymentLines,
} from '../modules/finance/finance.js';
import { renderCheque } from '../modules/finance/chequePrint.js';
import { issueDhrn, receiveDhrn, outstanding, receiveDhrnInterest } from '../modules/dhrn/dhrn.js';
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
import { listDesignBook, saveDesignBook } from '../modules/masters/designBook.js';
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
import {
  listYears,
  createYear,
  closeYear,
  reopenYear,
  carryForwardOpenings,
} from '../modules/masters/year.js';
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
import { postFineJv, deleteFineJv } from '../modules/finance/fineJv.js';
import { listOpenBills, settleBills } from '../modules/finance/billToBill.js';
import { postRateCut, deleteRateCut } from '../modules/sales/rateCut.js';
import {
  issueKarigar,
  receiveKarigar,
  karigarMetalBalance,
  getKarigar,
  editKarigar,
  deleteKarigar,
} from '../modules/manufacturing/karigar.js';
import { issueMfg, receiveMfg, getMfg, editMfg, deleteMfg } from '../modules/manufacturing/mfg.js';
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
  tagTransfer,
  deleteTagTransfer,
  counterTransfer,
  deleteCounterTransfer,
  StockVoucherValidationError,
} from '../modules/stock/stock.js';
import {
  deletePhysicalStock,
  getPhysicalStock,
  savePhysicalStock,
} from '../modules/stock/physicalStock.js';
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
  tagCancel,
  tagWeightDiff,
  deleteTagCancel,
  deleteTagWeightDiff,
} from '../modules/stock/tagOps.js';
import { splitTag, deleteTagSplit } from '../modules/stock/tagSplit.js';
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
import { senderFromEnv, notifyWithAttemptLog } from '../modules/integrations/messaging.js';
import { renderToPdf, PlaywrightPdfRenderer } from '../modules/reports/render.js';
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
  gspStatus,
  testGspAuth,
  cancelIrnForSale,
} from '../modules/einvoice/einvoice.js';
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
  deleteSchemeInstallment,
  deleteSchemeMaturity,
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
import { orderLotZoom, tagEstimate } from '../modules/reports/orderTagReports.js';
import { toCsv } from '../modules/reports/reportCsv.js';
import {
  readFilters,
  REPORT_FILTER_BINDINGS,
  supportedFilters,
} from '../modules/reports/reportFilters.js';

/**
 * HTTP/REST exposure of the verified backend modules for the mobile app to consume. Every route is
 * auth-guarded (requireAuth preHandler) and RBAC-guarded (assertRight) for mutations; domain errors
 * map to HTTP status. The service functions are unchanged — this is a thin JSON adapter.
 */
export interface TxnDeps {
  prisma: any;
  requireAuth: (req: FastifyRequest, reply: FastifyReply) => Promise<void>;
  sess: (req: FastifyRequest) => {
    tenantId: string;
    sub: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
    loginCoCode: string;
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
    };
  };
  const guard = (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ): boolean => {
    if (routeAuthorized(req)) return true;
    reply.code(403).send({ error: 'forbidden', action });
    return false;
  };
  // Map domain errors → HTTP status (validation/balance/tag → 400; everything else rethrows → 500).
  const run = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      const out = await fn();
      return reply.code(okCode).send(out as any);
    } catch (e: any) {
      const n: string = e?.name ?? '';
      if (n === 'PeriodLockValidationError') metrics.recordPeriodLockRejection();
      if (
        /(ValidationError|UnbalancedError|TagExistsError|TagNotAvailableError|EInvoiceValidationError|BarcodeError|DhrnValidationError|KarigarValidationError|SaleValidationError|PurchaseValidationError|MembershipError|SettingsError|EntityImageError|RepairError|MeltingError|SchemeError|FineInoutError|PasswordPolicyError|PasswordChangeError|FormRightsValidationError|ReportFilterError)/.test(
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
  const body = (req: FastifyRequest) => (req.body ?? {}) as Record<string, any>;

  // ---- Desktop utilities (server-derived tenant/company/location/year only) ----
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

  // ---- Estimate / quotation (compute only — no ledger, no voucher) ----
  app.post('/estimate', auth, async (req) => {
    const b = body(req);
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
  });

  // ---- Sales return ----
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
  app.get('/sales-returns/import', auth, async (req, reply) => {
    const qs = (req.query as any) || {};
    return run(reply, 200, () =>
      saleForReturn(prisma, {
        scope: scopeOf(req),
        origVchNo: qs.vchNo,
        origBook: qs.book ?? 'SAL',
      }),
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
  app.post('/sales-orders', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      createSalesOrder(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        billNo: b.billNo,
        netAmount: b.netAmount != null ? Number(b.netAmount) : undefined,
        lines: b.lines,
        taxRatePct: Number(b.taxRatePct || 0),
        interState: !!b.interState,
        advanceAmount: Number(b.advanceAmount || 0),
      }),
    );
  });
  app.get('/sales-orders', auth, async (req) => listSalesOrders(prisma, readScope(req) as any));
  app.delete('/sales-orders/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      cancelSalesOrder(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).tenantId,
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
    const s = readScope(req);
    const data = await invoiceData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'SAL'),
      vchNo: String(q.vchNo ?? ''),
    });
    if (!data) return reply.code(404).send({ error: 'invoice-not-found' });
    const copyLabel =
      (
        {
          O: 'ORIGINAL FOR RECIPIENT',
          D: 'DUPLICATE FOR TRANSPORTER',
          T: 'TRIPLICATE FOR SUPPLIER',
        } as Record<string, string>
      )[String(q.copy ?? '').toUpperCase()] ?? (q.copy ? String(q.copy) : undefined);
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
    const s = readScope(req);
    const data = await purchaseBillData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'PUR'),
      vchNo: String(q.vchNo ?? ''),
    });
    if (!data) return reply.code(404).send({ error: 'bill-not-found' });
    const html = purchaseBillHtml(data.header, data.lines, {
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
        `inline; filename="purchase-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/karigar/issue-voucher', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await karigarIssueData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'KIS'),
      vchNo: String(q.vchNo ?? ''),
    });
    if (!data) return reply.code(404).send({ error: 'voucher-not-found' });
    const html = karigarIssueHtml(data.header, data.lines, {
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
        `inline; filename="karigar-issue-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/sales/credit-note', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await invoiceData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'SRT'),
      vchNo: String(q.vchNo ?? ''),
    });
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

  app.get('/sales/order-confirmation', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await orderData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'SOR'),
      vchNo: String(q.vchNo ?? ''),
    });
    if (!data) return reply.code(404).send({ error: 'order-not-found' });
    const html = orderHtml(data.header, data.lines, { company: data.company, party: data.party });
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
        `inline; filename="order-${String(q.vchNo ?? '').replace(/[^\w.-]/g, '')}.pdf"`,
      )
      .send(pdf);
  });

  app.get('/sales/quotation', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await invoiceData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'SAL'),
      vchNo: String(q.vchNo ?? ''),
    });
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

  app.get('/finance/receipt-voucher', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await financeVoucherData(prisma, 'receipt', {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'RCT'),
      vchNo: String(q.vchNo ?? ''),
    });
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
    const s = readScope(req);
    const data = await financeVoucherData(prisma, 'payment', {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'PAY'),
      vchNo: String(q.vchNo ?? ''),
    });
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
    discountAmount: b.discountAmount,
    taxRatePct: b.taxRatePct,
    taxCode: b.taxCode,
    interState: !!b.interState,
    urd: !!b.urd,
    rateUnfix: !!b.rateUnfix,
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

  // ---- Other / expense purchase (TR_OTH_PURC): non-stock purchase with GST input ----
  app.post('/other-purchase', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      createOtherPurchase(prisma, {
        scope: scopeOf(req),
        acCode: b.acCode,
        acName: b.acName,
        billNo: b.billNo,
        vchDate: b.vchDate,
        taxRatePct: Number(b.taxRatePct || 0),
        interState: !!b.interState,
        taxAc: b.taxAc,
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
  app.delete('/other-purchase/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteOtherPurchase(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).tenantId,
      }),
    );
  });

  // ---- Purchase return ----
  app.post('/purchase-returns', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      createPurchaseReturn(
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
  app.delete('/purchase-returns/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePurchaseReturn(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: sess(req).tenantId,
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

  // ---- Dhrn (pledge loans) ----
  app.get('/dhrn/issue-receipt', auth, async (req, reply) => {
    const q = req.query as any;
    const s = readScope(req);
    const data = await dhrnIssueData(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coYear: s.coYear,
      coBook: String(s.coBook ?? 'DIS'),
      vchNo: String(q.vchNo ?? ''),
    });
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

  app.post('/dhrn/issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      issueDhrn(prisma, {
        scope: scopeOf(req),
        borrowerAc: b.borrowerAc,
        borrowerName: b.borrowerName,
        principal: b.principal,
        intPrc: b.intPrc,
        intMonths: b.intMonths,
        loanType: b.loanType,
        packetNo: b.packetNo,
        otherCharges: b.otherCharges,
        goldWt: b.goldWt,
        goldAmt: b.goldAmt,
        fromDate: b.fromDate,
        toDate: b.toDate,
        collateral: b.collateral,
      }),
    );
  });
  app.post('/dhrn/receipt', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      receiveDhrn(prisma, {
        scope: scopeOf(req),
        isuNo: b.isuNo,
        borrowerAc: b.borrowerAc,
        principalRepaid: Number(b.principalRepaid),
        interest: b.interest != null ? Number(b.interest) : undefined,
        intPrc: b.intPrc,
        vchDate: b.vchDate,
      }),
    );
  });
  app.get('/dhrn/:isuNo/outstanding', auth, async (req) => ({
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
  app.get('/repair-images', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return run(reply, 200, () =>
      listRepairImageKeys(prisma, readScope(req), {
        coBook: String(q.coBook ?? ''),
        vchNo: String(q.vchNo ?? ''),
        coYear: q.imageYear ? String(q.imageYear) : undefined,
      }),
    );
  });
  app.get('/repair-images/line', auth, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    const image = await getRepairImage(prisma, readScope(req), {
      coBook: String(q.coBook ?? ''),
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
  app.post('/repair-images', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveRepairImage(prisma, {
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
  app.post('/karigar/issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      issueKarigar(prisma, {
        scope: scopeOf(req),
        karigarAc: b.karigarAc,
        karigarName: b.karigarName,
        vchDate: b.vchDate,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.post('/karigar/receive', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      receiveKarigar(prisma, {
        scope: scopeOf(req),
        karigarAc: b.karigarAc,
        karigarName: b.karigarName,
        vchDate: b.vchDate,
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
        labourAmt: b.labourAmt != null ? Number(b.labourAmt) : undefined,
        labourGstPct: b.labourGstPct != null ? Number(b.labourGstPct) : undefined,
        gstAc: b.gstAc,
        interState: !!b.interState,
        labourAc: b.labourAc,
        tagPrefix: b.tagPrefix,
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

  // Desktop jobwork issue (TR_JDT_REC). Routes are declared explicitly: the RBAC route
  // inventory and apps/api/test/routePolicy.test.ts are static analyses of these literals.
  app.post('/mfg/jobwork-issue', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      issueMfg(prisma, {
        ...b,
        scope: scopeOf(req),
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/mfg/jobwork-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getMfg(prisma, readScope(req), (req.params as any).vchNo));
  });
  app.put('/mfg/jobwork-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editMfg(prisma, {
        ...b,
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        mode: 'issue',
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/mfg/jobwork-issue/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteMfg(prisma, {
        scope: scopeOf(req),
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
    return run(reply, 201, () =>
      receiveMfg(prisma, {
        ...b,
        scope: scopeOf(req),
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.get('/mfg/jobwork-receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getMfg(prisma, readScope(req), (req.params as any).vchNo));
  });
  app.put('/mfg/jobwork-receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      editMfg(prisma, {
        ...b,
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        mode: 'receive',
        mainUser: sess(req).sub,
        lines: b.lines ?? [],
      }),
    );
  });
  app.delete('/mfg/jobwork-receive/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteMfg(prisma, {
        scope: scopeOf(req),
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

  const REPORT_BUILDERS: Record<string, ReportBuilder> = {
    // Registered so the slug is recognised rather than 404. Their real filters cannot be expressed in the
    // shared builder signature, so the export route below reads them from the query and calls the SAME
    // builder with them — otherwise a lot-zoom export would always be empty, which looks like "no data"
    // instead of "no lot given".
    'tag-estimate': (prisma: any, scope: any) => tagEstimate(prisma, scope, { direction: 'In' }),
    'order-lot-zoom': (prisma: any, scope: any) => orderLotZoom(prisma, scope, ''),
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
  };
  /**
   * Resolve a report to its rows and totals.
   *
   * Shared by the XLSX and CSV exports so the two cannot disagree about what a report contains. Keeping the
   * resolution in one place also means the filter handling below — which the shared builder signature cannot
   * express — is applied identically to both formats.
   */
  const resolveReport = async (
    slug: string,
    req: FastifyRequest,
  ): Promise<{ rows: Record<string, unknown>[]; totals?: Record<string, unknown> }> => {
    const build = REPORT_BUILDERS[slug]!;
    const scope = readScope(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const result: any =
      slug === 'order-lot-zoom'
        ? await orderLotZoom(prisma, scope, q.lotNo ?? '')
        : slug === 'tag-estimate'
          ? await tagEstimate(prisma, scope, {
              ...readFilters(q),
              tagNo: q.tagNo || undefined,
              direction: q.direction === 'Out' ? 'Out' : 'In',
            })
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
    return { rows, totals };
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
    if (!REPORT_BUILDERS[slug]) {
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
    const build = REPORT_BUILDERS[slug];
    if (!build) return reply.code(404).send({ error: 'unknown-report', report: slug });
    const scope = readScope(req);
    // The range is always supplied: a builder that does not accept one ignores it, whereas guessing which
    // reports are date-filtered would silently export an unfiltered report.
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    // These two carry filters the shared builder signature cannot express, so the export reproduces exactly
    // what the screen requested instead of exporting a default view.
    const result: any =
      slug === 'order-lot-zoom'
        ? await orderLotZoom(prisma, scope, q.lotNo ?? '')
        : slug === 'tag-estimate'
          ? await tagEstimate(prisma, scope, {
              prCode: q.prCode || undefined,
              grCode: q.grCode || undefined,
              itType: q.itType ? q.itType.slice(0, 1) : undefined,
              tagNo: q.tagNo || undefined,
              direction: q.direction === 'Out' ? 'Out' : 'In',
            })
          : await build(prisma, scope, range(req));
    // Report builders return either a bare array or { rows, totals }.
    const rows: Record<string, unknown>[] = Array.isArray(result)
      ? result
      : Array.isArray(result?.rows)
        ? result.rows
        : [result];
    const totals =
      !Array.isArray(result) && result?.totals && typeof result.totals === 'object'
        ? (result.totals as Record<string, unknown>)
        : undefined;
    const out = await renderXlsx([inferSheet(slug, rows, totals)], slug);
    return reply
      .header('content-type', out.contentType)
      .header('content-disposition', `attachment; filename="${out.fileName}"`)
      .send(out.buffer);
  });
  // ---- Tag images (desktop BtnImgS / BtnImgC / BtnImgD, 24 forms) ----
  // One shared surface keyed on the tag instance, so every form that shows a tag can attach, replace,
  // enlarge and delete its photograph without repeating the plumbing.
  app.get('/stock/tag-image', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const s = sess(req);
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
    const s = sess(req);
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
  app.post('/stock/tag-image', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = sess(req);
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
        { data: b.data, mimeType: b.mimeType, user: s.sub },
      ),
    );
  });
  app.delete('/stock/tag-image', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const s = sess(req);
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    return run(reply, 200, () =>
      deleteEntityImage(prisma, {
        tenantId: s.tenantId,
        coCode: s.coCode,
        lcCode: s.lcCode,
        entityType: q.entityType ?? 'TAG',
        entityKey: String(q.entityKey ?? q.tagNo ?? ''),
        instance: Number(q.instance ?? q.vchSrno ?? 0),
        imageType: q.imageType,
      }),
    );
  });

  // ---- Data repair console (desktop MS_UPDATE) ----
  // Every operation is preview-then-apply. Listing is view-gated; preview and apply are admin-gated
  // because they rewrite historical financial and stock data.
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
    if (!guard(req, reply, 'delete')) return; // admin-gate
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
    if (!guard(req, reply, 'delete')) return; // admin-gate
    const s = sess(req);
    const b = body(req);
    return run(reply, 200, () =>
      applyRepair(
        prisma,
        String((req.params as any).id),
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear },
        {
          previewHash: String(b.previewHash ?? ''),
          confirmation: b.confirmation ? String(b.confirmation) : undefined,
          operator: s.sub ?? 'unknown',
          reason: b.reason ? String(b.reason) : undefined,
        },
      ),
    );
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
    const b = body(req);
    return run(reply, 200, () =>
      restoreCompany(prisma, sess(req).tenantId, b.doc ?? b, { clear: b.clear !== false }),
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
  app.post('/stock/tag-transfer', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      tagTransfer(prisma, { scope: scopeOf(req), vchDate: b.vchDate, lines: b.lines ?? [] }),
    );
  });
  app.delete('/stock/tag-transfer/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTagTransfer(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
      }),
    );
  });
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
  app.post('/stock/tag-cancel', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      tagCancel(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        book: b.book,
        lines: b.lines ?? [],
      }),
    );
  });
  app.post('/stock/tag-weight-diff', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
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
  app.delete('/stock/tag-cancel/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTagCancel(prisma, scopeOf(req) as any, (req.params as any).vchNo, body(req).book),
    );
  });
  app.delete('/stock/tag-weight-diff/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
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
  app.get('/masters/design-book', auth, async (req) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return listDesignBook(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
      String(qy.bookName ?? ''),
      String(qy.prCode ?? ''),
    );
  });
  app.post('/masters/design-book', auth, async (req) => {
    const s = scopeOf(req);
    const body = (req.body as any) || {};
    const written = await saveDesignBook(prisma, {
      scope: { tenantId: s.tenantId, coCode: s.coCode },
      bookName: String(body.bookName ?? ''),
      prCode: String(body.prCode ?? ''),
      vchDate: body.vchDate,
      mainUser: sess(req).sub,
      lines: Array.isArray(body.lines) ? body.lines : [],
    });
    return { written };
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
    const staged = await withTenant(prisma, s.tenantId, (tx: any) =>
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
    const behavior = await withTenant(prisma, scope.tenantId, (tx: any) =>
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
    const behavior = await withTenant(prisma, scope.tenantId, (tx: any) =>
      resolveSettingsBehaviorTx(tx, scope),
    );
    const companyMail = await withTenant(prisma, scope.tenantId, async (tx: any) => {
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
    const behavior = await withTenant(prisma, scope.tenantId, (tx: any) =>
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
    const behavior = await withTenant(prisma, scope.tenantId, (tx: any) =>
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
    const { sender, mode } = senderFromEnv();
    // MS_OPNCOMP.cs:687,694-695,714-715: flags and gateway are loaded, never body-supplied.
    const r = await notifyWithAttemptLog(
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
    const behavior = await withTenant(prisma, scope.tenantId, (tx: any) =>
      resolveSettingsBehaviorTx(tx, scope),
    );
    return {
      liveRates: { provider: 'gold-api.com + frankfurter.app', status: 'live (no key required)' },
      messaging: {
        provider: senderFromEnv().mode,
        status:
          senderFromEnv().mode === 'fake'
            ? 'wired — set WA_PHONE_ID/WA_TOKEN or SMS_URL_TEMPLATE/SMS_KEY to go live'
            : 'live',
      },
      einvoice: {
        provider: 'Chartered Info GSP (charteredinfo.com)',
        status:
          irnTransportFromEnv().mode === 'fake'
            ? 'wired (Fake) — set GSP_ASPID/GSP_PASSWORD/GSP_GSTIN/GSP_USER/GSP_EINV_PWD to go live'
            : `live (${irnTransportFromEnv().mode})`,
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

  // Server-side PDF (Crystal Reports replacement) — renders posted HTML to a real PDF via Chromium.
  app.post('/render/pdf', auth, async (req, reply) => {
    const b = body(req);
    const html = String(b.html ?? '<p>(empty)</p>');
    let pdf: Buffer;
    try {
      pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
    } catch {
      return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
    }
    const fn = String(b.filename ?? 'document').replace(/[^\w.-]/g, '') || 'document';
    return reply
      .header('content-type', 'application/pdf')
      .header('content-disposition', `inline; filename="${fn}.pdf"`)
      .send(pdf);
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
  app.get('/reports/trial-balance', auth, async (req) => trialBalance(prisma, readScope(req)));
  app.get('/reports/account-ledger/:acCode', auth, async (req) =>
    accountLedger(prisma, readScope(req), (req.params as any).acCode, range(req)),
  );
  app.get('/reports/dhrn-outstanding', auth, async (req) =>
    dhrnOutstandingList(prisma, readScope(req)),
  );
  app.get('/vouchers/recent', auth, async (req) => {
    const s = scopeOf(req);
    const qy = (req.query as any) || {};
    return recentVouchers(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode },
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
        },
      ),
    );
  });
  app.post('/years/:coYear/close', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    return run(reply, 200, () =>
      closeYear(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String((req.params as any).coYear),
        body(req).clDate,
      ),
    );
  });
  app.post('/years/:coYear/reopen', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const s = readScope(req);
    return run(reply, 200, () =>
      reopenYear(
        prisma,
        { tenantId: s.tenantId, coCode: s.coCode },
        String((req.params as any).coYear),
      ),
    );
  });
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
  app.get('/reports/balance-sheet', auth, async (req) => {
    // Desktop RP_BALANCE passes an operator-entered closing date and gold/silver rates into
    // Ac_Final.Trading_Stock; without a rate the metal pass cannot value stock at all.
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const n = (v: string | undefined): number | undefined =>
      v == null || v === '' ? undefined : Number(v);
    return balanceSheet(prisma, readScope(req), {
      closingDate: q.closingDate || undefined,
      goldRate: n(q.goldRate),
      silverRate: n(q.silverRate),
      ledgerFineGold: n(q.ledgerFineGold),
      ledgerFineSilver: n(q.ledgerFineSilver),
    });
  });
  app.get('/reports/outstanding', auth, async (req) => outstandingReport(prisma, readScope(req)));
  app.get('/reports/bill-outstanding', auth, async (req) =>
    billOutstanding(prisma, readScope(req)),
  );
  app.get('/reports/cash-book', auth, async (req) => cashBook(prisma, readScope(req)));
  app.get('/reports/scheme-adjustments', auth, async (req) =>
    schemeAdjustments(prisma, readScope(req)),
  );
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
    const bound = await bindReport(prisma, spec, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      coBook: String(s.coBook ?? 'SAL'),
      vchNo: String(q.vchNo ?? ''),
    });
    if (!bound) return reply.code(404).send({ error: 'voucher-not-found' });
    const html = renderReportLayout(spec, {
      header: bound.header,
      detailRows: bound.detailRows,
      company: bound.company,
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
    return reply.type('text/html').send(renderKarigarLedgerHtml(ac, rep));
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
    return run(reply, 201, () =>
      postRateCut(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        acCode: b.acCode,
        acName: b.acName,
        itType: b.itType,
        lines: b.lines ?? [],
        pay: b.pay,
        accounts: b.accounts,
      }),
    );
  });
  app.delete('/rate-cut/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteRateCut(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
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
  app.post('/stock/tag-split', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () =>
      splitTag(prisma, {
        scope: scopeOf(req),
        vchDate: b.vchDate,
        parent: b.parent,
        children: b.children ?? [],
      }),
    );
  });
  app.delete('/stock/tag-split/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTagSplit(prisma, scopeOf(req) as any, (req.params as any).vchNo, body(req).book),
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
    gstr1(prisma, readScope(req), { threshold: Number((req.query as any).threshold) || undefined }),
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
