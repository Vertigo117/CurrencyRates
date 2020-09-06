import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import CurrencyRate from '../app/CurrencyRate';
import { Observable } from 'rxjs';

@Injectable()
export default class Service {
    public API = 'https://localhost:44356//api/CurrencyRates/';

    constructor(private http: HttpClient) {}

    getDates(): Observable<Array<string>> {
        return this.http.get<Array<string>>(this.API + 'GetDates');
    }

    getCurrencies(): Observable<Array<string>> {
        return this.http.get<Array<string>>(this.API + 'GetCurrencies');
    }

    getCurrencyRate(date: string, currencyName: string): Observable<CurrencyRate> {
        const params = new HttpParams()
            .set('date', date)
            .set('currencyName', currencyName);

        return this.http.get<CurrencyRate>(this.API + 'GetCurrencyRate', {params});
    }
}