# ⚙️ Target ERP - Back-end API

API robusta construída em **.NET 8** responsável por aplicar as regras de negócio vitais do sistema e garantir a integridade dos dados antes da persistência.

## 📂 Persistência de Dados
A API utiliza persistência orientada a documentos (JSON), localizados na pasta \Data/\. Os arquivos (\endas.json\, \estoque.json\, \movimentacoes.json\) são gerados de forma automática na primeira requisição, garantindo resiliência (Lazy Loading estrutural).

## 🛡️ Regras de Negócio Aplicadas
- **Comissões (Vendas):** O servidor jamais confia no valor de comissão enviado pelo Front-end. O cálculo é refeito e validado 100% no lado do servidor para evitar fraudes.
- **Estoque Negativo (Almoxarifado):** Toda movimentação de SAÍDA sofre auditoria matemática em tempo real. Se a quantidade de saída for maior que o saldo atual do produto, a API recusa o registro e devolve HTTP 400.
- **Cálculos Financeiros:** A projeção de juros e multas é feita no servidor para impedir manipulações do lado do cliente.

## 🔗 Endpoints (Rotas)

### Vendas (\/api/vendas\)
- \GET /\ - Retorna histórico
- \GET /resumo\ - Retorna métricas de comissão
- \POST /\ - Lança nova venda
- \PUT /{id}\ - Atualiza uma venda
- \DELETE /{id}\ - Exclui uma venda

### Estoque (\/api/estoque\)
- \GET /\ - Retorna o catálogo de produtos com saldo atual
- \GET /movimentacoes\ - Retorna o histórico de movimentações logísticas
- \POST /movimentar\ - Registra nova Entrada ou Saída e calcula novo saldo

### Financeiro (\/api/financeiro\)
- \POST /calcular\ - Recebe Valor e Vencimento, retorna dias de atraso e projeção final com juros aplicados (2,5% a.d).
