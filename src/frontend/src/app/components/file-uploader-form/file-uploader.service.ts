import { Injectable } from '@angular/core';
import { HTTPBaseService } from 'src/core/services/http-base.service';
import { Observable } from 'rxjs';

@Injectable({providedIn:"root"})
export class FileUploaderService{

    private readonly sendFileURL: string = '/OFXFile/Salvar';    
    
    constructor(private httpBaseService: HTTPBaseService) {                
    }

    sendFile(form: any): Observable<any>{        
        return this.httpBaseService.post(this.sendFileURL, form);
    } 

}