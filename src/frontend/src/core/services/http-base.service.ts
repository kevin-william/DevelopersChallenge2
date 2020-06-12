import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const OFX_CONCILIACAO_API = environment.OFX_CONCILIACAO_API;

@Injectable({providedIn: 'root'})
export class HTTPBaseService {    
    
    constructor(private httpClient: HttpClient) { }

    get(url: string, options?: any): Observable<any> {
        return this.httpClient.get(`${OFX_CONCILIACAO_API + url}`, options);
    }
    
    post<T>(url: string, object: T, options?: any) {
        return this.httpClient.post(`${OFX_CONCILIACAO_API + url}`, object, options);
    }

    put<T>(url: string, object: T, options?: any) {
        return this.httpClient.put(`${OFX_CONCILIACAO_API + url}`, object, options);
    }

    delete(url: string, options?: any) {        
        return this.httpClient.delete(`${OFX_CONCILIACAO_API + url}`, options);        
    }

    patch<T>(url: string, object: T, options?: any) {
        return this.httpClient.patch(`${OFX_CONCILIACAO_API + url}`, object, options);
    }
}