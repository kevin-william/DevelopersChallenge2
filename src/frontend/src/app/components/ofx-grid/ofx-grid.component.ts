import { Component, OnInit } from '@angular/core';
import { OFXTransaction } from 'src/app/models/ofx-transaction.model';
import { OFXGridService } from './ofx-grid.service';
import { OFXTransactionTypeEnum } from 'src/app/models/ofx-transaction-type.enum';
import { OFXTransactionCurrencyEnum } from 'src/app/models/ofx-transaction-currency.enum';
import { OFXEntity } from 'src/app/models/ofx-entity.model';


@Component({
  selector: 'ofx-grid',
  templateUrl: './ofx-grid.component.html',
  styleUrls: ['./ofx-grid.component.scss']
})
export class OfxGridComponent implements OnInit {


  ofxEntity: OFXEntity;  
  get isListEmpty(): boolean{
    return (!this.ofxEntity ||
      !this.ofxEntity.ofxTransactions ||
      this.ofxEntity.ofxTransactions.length == 0);
  }

  constructor(private ofxGridService: OFXGridService) { }

  ngOnInit() {
    this.getAllTransactions();
  }

  getAllTransactions(){
    this.ofxGridService.getAllTransactions()
      .subscribe(response => {
        this.ofxEntity = response;
      });
  }

  getTransactionType(ofxTransactionTypeEnum: OFXTransactionTypeEnum): string{

    switch (ofxTransactionTypeEnum) {
        case OFXTransactionTypeEnum.CREDIT:
            return "Credit";
        case OFXTransactionTypeEnum.UNDEFINED:
            return "Undefined";
        case OFXTransactionTypeEnum.DEBIT:
            return "Debit";                 
        default:
            return "Undefined"
    }        
}

getCurrencyType(ofxTransactionCurrencyEnum: OFXTransactionCurrencyEnum){

    switch (ofxTransactionCurrencyEnum) {
        case OFXTransactionCurrencyEnum.UNDEFINED:
            return "";
        case OFXTransactionCurrencyEnum.BRL:
            return " BRL";
        case OFXTransactionCurrencyEnum.EUR:
            return " EUR";
        case OFXTransactionCurrencyEnum.USD:
            return " USD";
        case OFXTransactionCurrencyEnum.CAD:
            return " CAD";
        case OFXTransactionCurrencyEnum.CNY:
            return " CNY";
        case OFXTransactionCurrencyEnum.ARS:
            return " ARS";
        case OFXTransactionCurrencyEnum.RUB:
            return " RUB";
        case OFXTransactionCurrencyEnum.GBP:
            return " GBP";                       
        default:
            return "";
    }

}
}
