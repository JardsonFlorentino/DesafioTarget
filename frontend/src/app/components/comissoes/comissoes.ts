import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core'; 
import { FormsModule } from '@angular/forms';
import { ComissaoResultado, Venda } from '../../models/venda.model';
import { VendaService } from '../../services/venda.service';

@Component({
  selector: 'app-comissoes',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './comissoes.html',
  styleUrl: './comissoes.css'
})
export class ComissoesComponent implements OnInit {

  comissoes: ComissaoResultado[] = [];
  todasVendas: Venda[] = [];

  modalNovaVendaAberto = false;
  vendaAtual: Venda = { vendedor: '', valor: 0 };

  editandoVendaId: string | null = null;
  valorEdicao: number = 0;
  constructor(private vendaService: VendaService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    console.log("1. Angular Iniciou! Pedindo dados ao C#...");
    this.carregarDados();
  }

  carregarDados() {
    this.vendaService.getComissoes().subscribe(dados => {
      console.log("2. Comissões recebidas com sucesso:", dados);
      this.comissoes = dados;
      this.cdr.detectChanges(); // CHOQUE! Força a tela a pintar os dados na hora!
    }, erro => console.error("ERRO ao buscar comissões:", erro));

    this.vendaService.getVendas().subscribe(dados => {
      console.log("3. Vendas recebidas com sucesso:", dados);
      this.todasVendas = dados.reverse();
      this.cdr.detectChanges(); // CHOQUE! Força a tela a pintar os dados na hora!
    }, erro => console.error("ERRO ao buscar vendas:", erro));
  }

  abrirModalNovaVenda() {
    this.vendaAtual = { vendedor: '', valor: 0 };
    this.modalNovaVendaAberto = true;
  }

  fecharModalNovaVenda() { this.modalNovaVendaAberto = false; }

  salvarNovaVenda() {
    this.vendaService.adicionarVenda(this.vendaAtual).subscribe(() => {
      this.carregarDados();
      this.fecharModalNovaVenda();
    });
  }

  iniciarEdicao(venda: Venda) {
    this.editandoVendaId = venda.id || null;
    this.valorEdicao = venda.valor;
  }

  salvarEdicao(venda: Venda) {
    if (venda.id) {
      venda.valor = this.valorEdicao;
      this.vendaService.editarVenda(venda.id, venda).subscribe(() => {
        this.editandoVendaId = null;
        this.carregarDados();
      });
    }
  }

  excluirVenda(id?: string) {
    if (id && confirm("Deseja excluir esta nota fiscal?")) {
      this.vendaService.excluirVenda(id).subscribe(() => this.carregarDados());
    }
  }

  formatarMoeda(valor: number): string {
    return valor.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
  }
}
