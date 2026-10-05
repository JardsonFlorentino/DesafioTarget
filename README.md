# Desafio Técnico Target

Este repositório contém a resolução dos testes práticos propostos no processo seletivo da Target.

Com o objetivo de demonstrar conhecimentos práticos em desenvolvimento web de ponta a ponta, as respostas aos algoritmos foram integradas em uma única aplicação Full-Stack. Isso permite validar as regras de negócio exigidas através de uma interface visual e próxima de um cenário real de trabalho.

## 🛠️ Tecnologias Utilizadas

- **[Back-end](./backend/README.md):** C# com ASP.NET Core (.NET 8) - Responsável pela validação, cálculos matemáticos das regras de negócio e persistência de dados em arquivos JSON.
- **[Front-end](./frontend/README.md):** Angular 17+ - Interface gráfica reativa construída para consumir a API e apresentar os dados de forma organizada.

---

## 📋 Status dos Desafios

Os três desafios lógicos propostos foram mapeados e organizados como módulos interativos dentro da aplicação:

### [ X ] Desafio 1: Cálculo de Comissões (Módulo Comercial)

> **Enunciado:** "Considerando que o json tem registros de vendas de um time comercial... faça um programa que leia os dados e calcule a comissão... abaixo de 100 (0%), abaixo de 500 (1%), a partir de 500 (5%)."

- **A Solução:** Foi implementado um módulo completo ("Dashboard Comercial") que não apenas resolve o cálculo fixo, mas permite cadastrar, editar e excluir (CRUD) novas vendas na base de dados. A API em C# intercepta os lançamentos, aplica as regras matemáticas exigidas por faixa de valor, e devolve a somatória das comissões consolidadas por colaborador para a tela em tempo real.

### [ ] Desafio 2: Movimentações de Estoque (Módulo de Almoxarifado)

> **Enunciado:** "Faça um programa onde eu possa lançar movimentações de estoque (entrada/saída) dos produtos... cada movimentação deve ter um número identificador único e uma descrição. Ao final, retorne a qtde final do estoque."

- **O Planejamento:** (Próxima etapa). Será criado um painel logístico onde o usuário poderá registrar Entradas e Saídas de produtos. A API irá gerar automaticamente um UUID (Identificador Único), registrar o histórico e o motivo da movimentação, validando para que não haja saída maior que o estoque, e retornando matematicamente o saldo final atualizado do produto.

### [ ] Desafio 3: Cálculo de Juros (Módulo Financeiro)

> **Enunciado:** "Faça um programa que a partir de um valor e de uma data de vencimento, calcule o valor dos juros na data de hoje considerando que a multa seja de 2,5% ao dia."

- **O Planejamento:** (Em breve). Será desenvolvida uma calculadora financeira conectada ao relógio do sistema. O Back-end em C# fará o cruzamento da data de vencimento informada com a data atual (`DateTime.Now`), calculará a diferença de dias de atraso e aplicará a taxa dinâmica de 2,5% ao dia, devolvendo o valor corrigido para a tela.

---

## 🚀 Como Executar e Testar o Projeto

Para manter a documentação limpa, as instruções técnicas detalhadas de instalação e execução foram separadas em suas respectivas pastas.

Para testar a aplicação na sua máquina local, siga os dois manuais abaixo:

- ⚙️ **[Clique aqui para acessar o Manual de Inicialização do Back-end (C#)](./backend/README.md)**
- 🎨 **[Clique aqui para acessar o Manual de Inicialização do Front-end (Angular)](./frontend/README.md)**
