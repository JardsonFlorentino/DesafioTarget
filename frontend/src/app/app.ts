import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ComissoesComponent } from './components/comissoes/comissoes'; // Caminho correto!

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ComissoesComponent], // Registrado corretamente!
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  title = 'frontend';
}
