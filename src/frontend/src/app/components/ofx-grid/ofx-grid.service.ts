import { Injectable } from '@angular/core';
import { HTTPBaseService } from 'src/core/services/http-base.service';
import { OFXTransaction } from 'src/app/models/ofx-transaction.model';
import { Observable } from 'rxjs';
import { OFXTransactionTypeEnum } from 'src/app/models/ofx-transaction-type.enum';
import { OFXTransactionCurrencyEnum } from 'src/app/models/ofx-transaction-currency.enum';
import { OFXEntity } from 'src/app/models/ofx-entity.model';

@Injectable({providedIn:'root'})
export class OFXGridService{    

    private readonly GET_URL = "/OFXFile/";
    
    constructor(private httpBaseService: HTTPBaseService) { }

    getAllTransactions(): Observable<OFXEntity>{
        return this.httpBaseService.get(this.GET_URL)
    }        
}