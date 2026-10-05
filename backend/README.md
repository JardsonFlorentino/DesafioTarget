# ⚙️ Target API - Servidor (Back-end)

Este é o projeto Back-end do **Desafio Target**, construído utilizando **C# e ASP.NET Core (.NET 8)**.

A responsabilidade desta API é processar as regras de negócio complexas do sistema (como o cálculo progressivo de comissões e gestão de dados), servindo as informações para a interface gráfica de forma rápida e segura.

## 🚀 Como Executar a API

### Pré-requisitos

- [SDK do .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) instalado na sua máquina.

### Executando o Servidor

Abra o seu terminal nesta pasta (`/backend`) e execute o comando:

```bash
dotnet run
```

A API será iniciada na sua máquina (fique atento ao console para ver a porta gerada, geralmente `http://localhost:5000` ou similar).

---

## 🏛️ Arquitetura e Padrões Utilizados

Este projeto não mistura responsabilidades. Ele foi desenhado utilizando padrões corporativos sólidos (**Service Pattern / MVC**):

- **`Controllers/`**: A camada de apresentação (porta de entrada) da API. Recebe as chamadas HTTP (`GET`, `POST`, `PUT`, `DELETE`) e as encaminha para a camada de serviços sem poluir a rota com lógicas matemáticas.
- **`Services/`**: O "cérebro" da aplicação. Onde residem as regras de cálculo (ex: validar quando uma comissão é 0%, 1% ou 5%).
- **`Models/`**: Classes limpas (Entidades) que ditam a estrutura exata e os tipos dos dados trafegados.
- **`Data/`**: Pasta responsável pela persistência temporária de dados (através de arquivos `.json`). Isso foi arquitetado para simular o comportamento de um Banco de Dados leve, garantindo que o histórico de vendas não seja perdido ao reiniciar a API.

## 🛡️ Segurança e Configurações

- **CORS Habilitado**: A API está devidamente configurada (`Program.cs`) para aceitar requisições de outras origens de forma segura, permitindo que a aplicação Angular (Front-end) consuma seus endpoints locais sem bloqueios do navegador.
