export class PurchaseValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'PurchaseValidationError';
  }
}
