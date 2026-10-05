import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CalculoJurosRequest, CalculoJurosResponse, FinanceiroService } from '../../services/financeiro.service';

@Component({
  selector: 'app-financeiro',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './financeiro.html',
  styleUrl: './financeiro.css'
})
export class Financeiro {
  request: any = {
    valorOriginal: '',
    dataVencimento: ''
  };

  resultado: CalculoJurosResponse | null = null;
  carregando: boolean = false;
  erroMensagem: string = '';

  constructor(
    private financeiroService: FinanceiroService,
    private cdr: ChangeDetectorRef
  ) {}

  calcular() {
    if (this.carregando) return;

    this.erroMensagem = '';
    this.resultado = null;

    const valor = parseFloat(this.request.valorOriginal);
    if (isNaN(valor) || valor <= 0) {
      this.erroMensagem = 'O valor original deve ser maior que zero.';
      this.cdr.detectChanges();
      return;
    }
    if (!this.request.dataVencimento) {
      this.erroMensagem = 'Informe a data de vencimento.';
      this.cdr.detectChanges();
      return;
    }

    this.carregando = true;
    this.cdr.detectChanges();
    
    const reqEnvio = { valorOriginal: valor, dataVencimento: this.request.dataVencimento };

    this.financeiroService.calcularJuros(reqEnvio).subscribe({
      next: (res) => {
        this.carregando = false;
        this.resultado = res;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.carregando = false;
        this.erroMensagem = err.error?.erro || 'Erro ao processar cálculo.';
        this.cdr.detectChanges();
      }
    });
  }
}


