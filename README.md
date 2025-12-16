# Mirante
POC - Sistema de Controle de Task


# 📝 ToDo Task API

API RESTful para gerenciamento de tarefas (ToDo), desenvolvida em **.NET 8**, utilizando boas práticas de arquitetura, separação de responsabilidades e padrões amplamente adotados no mercado.

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

## 🏗️ Arquitetura do Projeto

O projeto segue princípios da **Clean Architecture / Arquitetura Hexagonal**, garantindo baixo acoplamento, alta coesão e facilidade de manutenção.

### 🔄 Fluxo de Comunicação

Controller → Adapter → Service → Repository → Database

---

## 📁 Estrutura de Camadas

### Controller (API Layer)
Responsável por:
- Receber requisições HTTP
- Fazer o binding de dados
- Retornar status HTTP adequados
- Delegar chamadas ao Adapter

### Adapter (Application Layer)
Responsável por:
- Converter DTOs de entrada e saída usando AutoMapper
- Orquestrar chamadas para o Service

### Service (Domain / Business Layer)
Responsável por:
- Aplicar regras de negócio
- Executar validações com FluentValidation
- Registrar logs via ILogger

### Repository (Infrastructure Layer)
Responsável por:
- Persistência de dados
- CRUD e consultas filtradas
- Comunicação com o banco via EF Core

### Domain
Contém as entidades e enums do domínio.

---

## 🔍 Validações

As regras de validação são implementadas com FluentValidation, garantindo consistência e centralização das regras de negócio.

---

## 🔄 AutoMapper

Utilizado para converter:
- DTO → Entidade
- Entidade → DTO de resposta

---

## 🔌 Injeção de Dependência

Todos os serviços, adapters, repositórios e validações são registrados via Dependency Injection.

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
- Testável e extensível
