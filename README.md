# 📝 ToDo Task API

API RESTful para gerenciamento de tarefas (**ToDo**), desenvolvida em **.NET 8**, seguindo boas práticas de arquitetura, separação de responsabilidades e padrões corporativos amplamente adotados no mercado.

---

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- FluentValidation
- AutoMapper
- Docker / Docker Compose
- Injeção de Dependência
- ILogger
- Swagger (OpenAPI)

---

## 🏗 Arquitetura do Projeto

O projeto segue os princípios da **Clean Architecture / Arquitetura Hexagonal**, promovendo **baixo acoplamento**, **alta coesão** e **facilidade de manutenção e evolução**.

### 🔄 Fluxo de Comunicação

Controller → Adapter → Service → Repository → Database

---

## 📁 Estrutura de Camadas

### Controller (API Layer)
Responsável por receber requisições HTTP, realizar o binding de dados, retornar os status HTTP adequados e delegar chamadas para o Adapter.

### Adapter (Application Layer)
Responsável por converter DTOs de entrada e saída utilizando AutoMapper e orquestrar chamadas para a camada Service.

### Service (Domain / Business Layer)
Responsável por aplicar regras de negócio, executar validações com FluentValidation e registrar logs via ILogger.

### Repository (Infrastructure Layer)
Responsável pela persistência de dados, execução de operações CRUD e comunicação com o banco via EF Core.

### Domain
Contém as entidades e enums do domínio.

---

## 🗄 Banco de Dados

A pasta **Mirante.ToDo.DataBase** contém os scripts SQL necessários para criação do banco de dados.

### Scripts disponíveis

- **CREATE_BD.sql**  
  Cria o banco de dados da aplicação.

- **CREATE_TABLE-ToDoTask.sql**  
  Cria a tabela `ToDoTask`, responsável por armazenar as tarefas.

Os scripts devem ser executados via **SQL Server Management Studio (SSMS)**.

---

## 🚀 Como rodar o projeto localmente (sem Docker)

### Pré-requisitos

- .NET SDK 8.0
- SQL Server (LocalDB, Express ou superior)
- Git

### Passos

```bash
git clone https://github.com/VinyRN/Mirante.git
cd Mirante
dotnet restore
dotnet run --project src/Mirante.ToDo.API
```

A API ficará disponível em:

- https://localhost:5001
- http://localhost:5000

Swagger:

- https://localhost:5001/swagger

---

## 📦 Padrão de Resposta da API

```json
{
  "error": false,
  "statusCode": 200,
  "data": {},
  "erros": []
}
```

- **error**: indica se ocorreu erro
- **statusCode**: código HTTP retornado
- **data**: dados da resposta
- **erros**: lista de mensagens de erro

---

## 📌 Endpoints Principais

GET /api/todo-tasks  
GET /api/todo-tasks/{id}  
GET /api/todo-tasks/filtrar  
POST /api/todo-tasks  
PUT /api/todo-tasks/{id}  
DELETE /api/todo-tasks/{id}

---

## 🐳 Executando com Docker

```bash
docker-compose up --build
```

API:
http://localhost:8080

Swagger:
http://localhost:8080/swagger

---

## ✅ Benefícios da Arquitetura

- Separação clara de responsabilidades
- Código limpo e organizado
- Fácil manutenção e escalabilidade
- Estrutura preparada para evolução futura

---

## 👨‍💻 Autor

Vinicius Ribeiro Nunes
