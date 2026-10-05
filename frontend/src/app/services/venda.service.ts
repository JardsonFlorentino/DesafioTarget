import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ComissaoResultado, Venda } from '../models/venda.model';

@Injectable({
  providedIn: 'root'
})
export class VendaService {
  // O endereÃ§o exato do nosso C#.
  private apiUrl = 'http://localhost:5169/api/vendas';

  constructor(private http: HttpClient) { }

  getVendas(): Observable<Venda[]> {
    return this.http.get<Venda[]>(this.apiUrl);
  }

  getComissoes(): Observable<ComissaoResultado[]> {
    return this.http.get<ComissaoResultado[]>(`${this.apiUrl}/comissoes`);
  }

  adicionarVenda(venda: Venda): Observable<any> {
    return this.http.post(this.apiUrl, venda);
  }

  editarVenda(id: string, venda: Venda): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, venda);
  }

  excluirVenda(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}

