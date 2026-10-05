import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ComissoesComponent } from './components/comissoes/comissoes';
import { Estoque } from './components/estoque/estoque';
import { Financeiro } from './components/financeiro/financeiro';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ComissoesComponent, Estoque, Financeiro],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  abaAtiva: 'vendas' | 'estoque' | 'financeiro' = 'vendas';
}
