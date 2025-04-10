# Ambev Developer Evaluation

Este projeto foi desenvolvido como parte de uma avaliação técnica para desenvolvedores. Ele simula um sistema de vendas com regras de negócio aplicadas ao domínio, utilizando os princípios de DDD (Domain-Driven Design), validações com FluentValidation, testes com xUnit e FluentAssertions, além de integração com Docker.

## 🔧 Requisitos

Antes de rodar o projeto, certifique-se de ter os seguintes pré-requisitos instalados em sua máquina:

- ✅ [.NET 8.0 SDK ou superior](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ✅ [Visual Studio 2022 (última versão recomendada)](https://visualstudio.microsoft.com/pt-br/)
  - Workload necessário: **ASP.NET e desenvolvimento web**
- ✅ [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## ▶️ Como rodar o projeto

1. **Clone este repositório:**

   ```bash
   git clone https://github.com/seu-usuario/ambev-developer-evaluation.git
   cd ambev-developer-evaluation

2. **Abra o seguinte com o Visual Studio**
    ```bash
    Ambev.DeveloperEvaluation.sln

3. **Dentre as opções possíveis de execução, selecione a opção Docker Compose**
  - ![image](https://github.com/user-attachments/assets/e1c4b3cd-6d62-4c71-b4e6-a51664bb5a84)

5. **Execute a aplicação**   
  - ![image](https://github.com/user-attachments/assets/a658d92c-a43d-4340-88e5-1b4541f505be)

6. **Por fim a aplicação estará em execução**   
  - ![image](https://github.com/user-attachments/assets/892f0db0-5aaa-47b4-8836-ab5deef86737)

## ▶️ Como rodar os testes unitários

1. **Use o comando:**

   ```bash
   cd ambev-developer-evaluation
   dotnet test

2. **Ou use o gerenciador de testes do Visual Studio**
  - ![image](https://github.com/user-attachments/assets/519dd720-f86b-430d-a7d4-ccd5af489d29)
