# 🎓 Escola API

API REST desenvolvida em **.NET (ASP.NET Core)** para gerenciamento de uma escola, permitindo controle de usuários, cursos, turmas, matrículas e notas.

Projeto construído com foco em **boas práticas de arquitetura**, segurança e organização de código.

---

## 🚀 Tecnologias utilizadas

- .NET (ASP.NET Core)
- C#
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token)
- Clean Architecture

---

## 📂 Arquitetura do projeto

O projeto segue o padrão **Clean Architecture**, separando responsabilidades em camadas:

- **Escola.API** → camada de entrada (Controllers, Middleware)
- **Escola.Application** → regras de negócio (Services, DTOs)
- **Escola.Domain** → entidades e interfaces
- **Escola.Infra.Data** → acesso ao banco (EF Core, Repositories)
- **Escola.Infra.Ioc** → injeção de dependência

---

## 🔐 Autenticação

A API utiliza autenticação baseada em **JWT (JSON Web Token)**.

### 🔄 Fluxo de autenticação

1. Usuário realiza login  
2. API valida email e senha  
3. Um token JWT é gerado  
4. O cliente utiliza esse token nas requisições protegidas  

---

## 📌 Funcionalidades

- 👤 Cadastro e login de usuários  
- 📚 Gerenciamento de cursos  
- 🏫 Gerenciamento de turmas  
- 📝 Matrícula de alunos  
- 📊 Controle de notas  
- 🔐 Controle de acesso por perfil (Aluno / Administrador)  

---

## 🧠 Conceitos aplicados

- Separação de responsabilidades  
- Injeção de dependência  
- Padrão Repository  
- Uso de DTOs para segurança  
- Autenticação com JWT  
- Boas práticas de API REST  

---

## ⚙️ Como rodar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/SEU-USUARIO/escola-api.git
```

---

### 2. Configurar o banco de dados

No arquivo `appsettings.json`, configure sua string de conexão:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SUA_STRING_AQUI"
  }
}
```

---

### 3. Rodar as migrations

```bash
dotnet ef database update
```

---

### 4. Executar o projeto

```bash
dotnet run
```

---

## 📬 Endpoints principais

### 👤 Usuário

- POST `/api/usuario` → criar usuário  
- POST `/api/usuario/login` → autenticar usuário  

---


## 📈 Melhorias futuras

- Implementar testes automatizados  
- Adicionar paginação nas consultas  
- Melhorar tratamento de erros  
- Documentação com Swagger mais detalhada  

---

## 👨‍💻 Autor

**Matheus Maximiano**

📍 Araraquara - SP  
📧 mthsmaximiano@gmail.com  
🔗 https://www.linkedin.com/in/matheusmaximiano/

---

## ⭐ Considerações

Este projeto foi desenvolvido com foco em aprendizado e aplicação de boas práticas de desenvolvimento backend, servindo como base para evolução contínua em APIs com .NET.