import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movimentacao, Produto } from '../models/estoque.model';

@Injectable({
  providedIn: 'root'
})
export class EstoqueService {
  private apiUrl = 'http://localhost:5169/api/estoque';

  constructor(private http: HttpClient) { }
  getEstoque(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.apiUrl);
  }

  getMovimentacoes(): Observable<Movimentacao[]> {
    return this.http.get<Movimentacao[]>(`${this.apiUrl}/movimentacoes`);
  }

  // 2. Aciona o Cérebro [HttpPost("movimentar")]
  registrarMovimentacao(mov: Movimentacao): Observable<any> {
    return this.http.post(`${this.apiUrl}/movimentar`, mov);
  }

  // 3. Os métodos do CRUD do Catálogo de Produtos que fizemos por capricho!
  adicionarProduto(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(`${this.apiUrl}/produto`, produto);
  }

  atualizarProduto(codigo: number, produto: Produto): Observable<Produto> {
    return this.http.put<Produto>(`${this.apiUrl}/produto/${codigo}`, produto);
  }

  deletarProduto(codigo: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/produto/${codigo}`);
  }
}
