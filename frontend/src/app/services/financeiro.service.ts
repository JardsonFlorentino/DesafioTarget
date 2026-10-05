import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface CalculoJurosRequest {
  valorOriginal: number;
  dataVencimento: string;
}

export interface CalculoJurosResponse {
  valorOriginal: number;
  dataVencimento: string;
  dataCalculo: string;
  diasAtraso: number;
  valorJuros: number;
  valorTotal: number;
}

@Injectable({
  providedIn: 'root'
})
export class FinanceiroService {
    private get apiUrl(): string {
    const isLocal = window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1';
    return isLocal ? 'http://localhost:5169/api/financeiro' : '/api/financeiro';
  }

  constructor(private http: HttpClient) {}

  calcularJuros(request: CalculoJurosRequest): Observable<CalculoJurosResponse> {
    return this.http.post<CalculoJurosResponse>(this.apiUrl + '/calcular', request);
  }
}



