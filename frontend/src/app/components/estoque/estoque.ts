import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Movimentacao, Produto } from '../../models/estoque.model';
import { EstoqueService } from '../../services/estoque.service';

@Component({
  selector: 'app-estoque',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './estoque.html',
  styleUrl: './estoque.css'
})
export class Estoque implements OnInit {
  produtos: Produto[] = [];
  movimentacoes: Movimentacao[] = [];

  novaMovimentacao: Movimentacao = {
    codigoProduto: 101,
    tipoMovimentacao: 'ENTRADA',
    quantidade: 1,
    descricao: ''
  };

  erroMensagem: string = '';
  sucessoMensagem: string = '';

  carregando: boolean = false;

  constructor(
    private estoqueService: EstoqueService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.carregarDados();
  }

  carregarDados() {
    this.estoqueService.getEstoque().subscribe(res => {
      this.produtos = res;
      this.cdr.detectChanges();
    });

    this.estoqueService.getMovimentacoes().subscribe(res => {
      this.movimentacoes = res.reverse();
      this.cdr.detectChanges();
    });
  }

  registrar() {
    if (this.carregando) return;

    this.erroMensagem = '';
    this.sucessoMensagem = '';

    if (this.novaMovimentacao.quantidade <= 0) {
      this.erroMensagem = 'A quantidade deve ser maior que zero.';
      return;
    }

    this.carregando = true;

    this.estoqueService.registrarMovimentacao(this.novaMovimentacao).subscribe({
      next: (res) => {
        this.carregando = false;

        this.sucessoMensagem = `Sucesso! O novo saldo é: ${res.estoqueFinal}`;
        this.novaMovimentacao.descricao = '';
        this.novaMovimentacao.quantidade = 1;
        this.carregarDados();

        setTimeout(() => this.sucessoMensagem = '', 4000);
      },
      error: (err) => {
        this.carregando = false;

        this.erroMensagem = err.error?.erro || 'Erro ao registrar movimentação.';
      }
    });
  }
}
