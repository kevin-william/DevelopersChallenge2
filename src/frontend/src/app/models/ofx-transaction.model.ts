import { OFXTransactionTypeEnum } from './ofx-transaction-type.enum';
import { OFXTransactionCurrencyEnum } from './ofx-transaction-currency.enum';

export class OFXTransaction{

    type: OFXTransactionTypeEnum;
    value: number;
    dateTime: Date;
    description: string;    

}