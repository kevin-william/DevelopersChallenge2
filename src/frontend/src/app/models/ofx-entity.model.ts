import { OFXTransaction } from './ofx-transaction.model';
import { OFXTransactionCurrencyEnum } from './ofx-transaction-currency.enum';

export class OFXEntity{
    currency: OFXTransactionCurrencyEnum;
    ofxTransactions: Array<OFXTransaction>
}