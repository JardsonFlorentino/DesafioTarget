# 🎨 Target API - Interface Gráfica (Front-end)

Este é o projeto Front-end do **Desafio Target**, construído com o Framework **Angular**.

O foco principal desta aplicação é fornecer uma experiência de usuário (UX) de alto nível. A interface foi construída do zero para simular um sistema "Desktop" moderno dentro do navegador, utilizando conceitos de Dark Mode, Glassmorphism (painéis translúcidos) e travamento de viewport.

## 🚀 Como Executar o Projeto

### Pré-requisitos

Certifique-se de ter o [Node.js](https://nodejs.org/) instalado na sua máquina (recomendado versão 18 ou superior).

### Instalando as Dependências

Abra o seu terminal exatamente nesta pasta (`/frontend`) e rode o comando abaixo para baixar as dependências do projeto:

```bash
npm install
```

### Iniciando o Servidor de Desenvolvimento

Para rodar a aplicação localmente na sua máquina, execute:

```bash
npm start
```

Após terminar a compilação, abra o seu navegador e acesse `http://localhost:4200/`. A aplicação possui "Live Reload", então ela atualizará sozinha caso você altere algum código no futuro.

---

## 🛠️ Tecnologias e Arquitetura Utilizadas

- **Angular 17+ (Standalone Components)**: O projeto foi desenvolvido com a arquitetura moderna do Angular, sem a necessidade pesada de módulos globais, tornando-o extremamente rápido e limpo.
- **Integração HTTP**: Consumo dinâmico da API REST do C# via `HttpClient`.
- **Design e CSS3 Avançado**:
  - Layout construído com `CSS Grid` e `Flexbox`.
  - Efeitos modernos como `backdrop-filter: blur`.
  - Controle estrito de altura (`100vh`) e barras de rolagem nativas injetadas diretamente nos painéis (UX Premium).
- **Reatividade**: Uso estratégico do `ChangeDetectorRef` para garantir atualizações instantâneas e sem "piscar" na tela após ações de CRUD (Inserção e Edição).

---

## 📁 Estrutura do Projeto (Destaques)

- `src/app/components/`: Onde residem as telas principais do sistema (ex: Módulo de Comissões).
- `src/app/services/`: Camada que isola toda a comunicação (HTTP) com o servidor Back-end.
- `src/app/models/`: Interfaces do TypeScript que espelham exatamente os Models criados no C#, garantindo segurança e tipagem forte em todo o fluxo de dados.
