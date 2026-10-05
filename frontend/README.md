# 💻 Target ERP - Front-end (Angular)

Interface de Alta Fidelidade (High-Fidelity UI) desenvolvida em **Angular 17 (Standalone)**. O foco deste projeto foi construir uma experiência corporativa fluida, rápida e sem necessidade de bibliotecas externas poluentes (como Bootstrap ou Tailwind).

## 🎨 Design System e UX
- **Abordagem Glassmorphism:** Elementos translúcidos e fundo em gradiente noturno (Dark Mode) para evitar fadiga visual em rotinas intensas de Back-Office.
- **Layouts Resilientes:** Uso intensivo de CSS Grid e Flexbox garantindo que tabelas e históricos tenham rolagens independentes sem quebrar a tela inteira.
- **Micro-interações:** Feedback imediato ao usuário (fade-ins sintonizados, hover effects em tabelas e glow nos botões).
- **Proteção de UX (Debounce/Locks):** Botões críticos (como "Confirmar Lançamento") são bloqueados e alteram seu estado visual durante a transação de rede, prevenindo registros fantasmas por "clique duplo".

## 🧩 Estrutura (Single Page Application)
O aplicativo funciona como um SPA unificado através de abas de navegação (\pp.ts\), transitando de forma instantânea entre os Desafios sem recarregar o navegador.

### Módulos Ativos
1. **[ 💼 Gestão de Vendas ]:** Dashboard financeiro com edição e deleção inline de vendas.
2. **[ 📦 Controle de Estoque ]:** Painel logístico dividido entre Ações de Movimentação (Esquerda) e Catálogo de Saldos (Direita).
