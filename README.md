# 🎯 Target Sistemas - Desafio Técnico

> 🌐 **Live Demo (Produção):** [Acesse o Sistema Aqui](http://target.jardsonflorentino.com.br)
>
> *(Deploy CI/CD hospedado em Servidor Linux VPS próprio, utilizando Proxy Reverso Nginx e Systemd)*

Este repositório contém a solução completa para o desafio técnico da Target Sistemas, desenvolvido com uma arquitetura moderna (SPA) focada em **Performance, Regras de Negócio e UX/UI Premium**.

## 🏗️ Arquitetura do Projeto
- **Back-end:** .NET 8 (C#) com arquitetura em Services e persistência baseada em arquivos JSON.
- **Front-end:** Angular 17+ (Standalone Components) com tipagem rigorosa no TypeScript.
- **UI/UX:** Design System próprio (Glassmorphism, Dark Mode, CSS Grid/Flexbox) e micro-interações sem uso de bibliotecas de terceiros.

## 🚀 Módulos e Status

### ✅ Desafio 01: Gestão de Vendas (Concluído)
- Lançamento, Edição e Exclusão de vendas diárias.
- Painel de fechamento automático de comissões baseado em regras de negócio (% por meta alcançada).

### ✅ Desafio 02: Controle de Estoque (Concluído)
- Registro rigoroso de movimentações logísticas (Entrada / Saída).
- **Regra de Ouro:** O back-end bloqueia severamente qualquer saída que resulte em estoque negativo.
- Timeline de histórico em tempo real e catálogo de saldos atualizado dinamicamente.
- Proteção UX no front-end contra "duplo clique" acidental (Loaders de segurança).

### ✅ Desafio 03: Cálculo de Juros e Multa (Concluído)
- Calculadora financeira que calcula dias de atraso a partir de uma data de vencimento.
- Aplica dinamicamente a taxa de 2,5% de juros/multa ao dia sobre o valor base.
- Demonstrativo visual gerado em tempo real, informando o valor total corrigido.

## ⚙️ Como Executar
Consulte os arquivos [README do Back-end](./backend/README.md) e [README do Front-end](./frontend/README.md) para instruções específicas de como rodar as APIs e o servidor de interface.

