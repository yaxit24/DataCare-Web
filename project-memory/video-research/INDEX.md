# DataCare Softech India — Video Research Index
_Source: https://www.youtube.com/@DataCareSoftechIndia/playlists — official DataCareNext desktop tutorials (Hindi). ~33 videos / ~2.2h. Pipeline: yt-dlp subtitles + low-res → ffmpeg scene keyframes → per-video artifact → delete video (23GB disk budget)._

## Playlists
| key | videos | module focus |
|---|---|---|
| transaction | 12 | Sales/Purchase/Receipts/Returns/Contra/Approval/Labour/Other-exp/Bill-wise → `/txn/*` (HIGH) |
| master | 6 | Company + User + Account + Item + Barcoding + Backup → setup + `/masters/*` (HIGH) |
| karigar | 2 | Karigar metal issue/receive → `/txn/karigar-*` (mfg) |
| other | 10 | Rate/TagCancel/StockAdjust/PhysicalStock/OrderCancel/TagTransfer/TagWtChange/LabourUpd/BankRecon/Reminder |
| android | 1 | mobile catalog app (promo — low priority) |
| plus | 2 | DataCare Plus reporting + Next overview (low priority) |

## Video → web module/page map
### transaction (PLBQOU1UUe1lxDNWZxKzKHbQC-yBrQ0XtZ)
| # | id | dur | title | → web |
|---|---|---|---|---|
| 1 | DF_P2GD9AuU | 8:14 | Sales Invoice Create | `/txn/sales` |
| 2 | tpKMyaRMlFM | 3:40 | Cash Received & Payment | `/txn/receipt` + `/txn/payment` |
| 3 | dVfvnhzWQKI | 3:49 | Sales Return Credit Note | `/txn/sale-return` |
| 4 | AdgxtGwjrfc | 8:10 | Bank Received & Payment | `/txn/receipt`+`/txn/payment` (bank) |
| 5 | Sq-Xo4E5GTE | 7:00 | Sales Order Create | `/txn/sales-order` |
| 6 | lqJjexUe4MA | 4:57 | Purchase Voucher Create | `/txn/purchase` |
| 7 | wuIFZsCf4Mw | 2:33 | Purchase Return Debit Note | `/txn/purchase-return` |
| 8 | tSRFXH2BoZ0 | 2:58 | Contra Entry | `/txn/contra` |
| 9 | DpdQpC7Od2M | 5:42 | Approval Issue Received | `/txn/tour` (approval) |
| 10 | tLThVxaKF5o | 5:25 | Labour Invoice Create | `/txn/labour-sale` |
| 11 | f2mXV47LSXk | 3:32 | Other Expenses Create | `/txn/other-purchase` (TR_OTH_PURC) |
| 12 | sE2H-ztIINE | 3:42 | Bill Wise Amount Received | `/txn/bill-to-bill` |

### master (PLBQOU1UUe1lw7QMxIc58pz17XMLASOehL)
| 1 | VnXnYL5F6VE | 2:15 | Company Create | company setup |
| 2 | X-ba6-Q_L1g | 4:10 | User Create | `/admin/users` (+ form-rights) |
| 3 | NyEAB-xn7Hw | 2:25 | Account Create | `/masters/accounts` |
| 4 | WmJ9la4_FP4 | 5:01 | Item Create | `/masters/items` |
| 5 | 3eHsCZC1gu4 | 8:02 | Barcoding Stock Create | `/txn/tag-opening` / tagging |
| 6 | vLIK-w9pFlY | 1:27 | Data Backup | `/backup` |

### karigar (PLBQOU1UUe1lxZj3zJ2yRdI6L_JBPvhH-j)
| 1 | Gd0TSp2OoXA | 3:18 | Karigar Metal Issue | `/txn/karigar-issue` |
| 2 | CO9Ro-ZeeE8 | 3:21 | Karigar Ornament Received | `/txn/karigar-receive` |

### other (PLBQOU1UUe1lzQPSo8Hrwh9KdcD7Nzbb2K)
| 1 | 5mIg4yRl0aE | 3:59 | Daily Rate Master | `/masters/rates` |
| 2 | VzkTOy9vGL0 | 3:21 | Tag Cancel and Print | `/txn/tag-cancel` |
| 3 | yP6XAirZ36I | 2:17 | Stock Adjust Entry | `/txn/physical-stock` / stock adjust |
| 4 | QEPhVyaV_xU | 2:31 | Physical Stock Verification | `/txn/physical-stock` |
| 5 | 0BXTuAzGk-c | 3:11 | Order Cancel | sales-order cancel |
| 6 | 1EziXFnnH7I | 2:23 | Tag Transfer in Item Stock | `/txn/item-lot` / tag transfer |
| 7 | LiUHTEUPzEw | 4:37 | Tag Weight Change | `/txn/tag-weight-diff` |
| 8 | 1DggmBgcA9I | 2:54 | Labour Update | labour master |
| 9 | 2244Ll1nFxI | 3:15 | Bank Reconciliation | (recon — verify built) |
| 10 | AN2AiLXuP28 | 5:02 | Reminder Entry | `/utilities/reminders` |
