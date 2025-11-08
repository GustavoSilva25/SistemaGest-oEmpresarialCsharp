# 🏢 Sistema de Gestão Empresarial

> Projeto desenvolvido como trabalho acadêmico para a disciplina de **Programação em C#**.  
> Aplicação web construída com **ASP.NET Core MVC**, **MySQL** e **Identity** para autenticação

---

## ⚙️ Tecnologias Utilizadas

- **ASP.NET Core MVC** — framework principal da aplicação  
- **Entity Framework Core** — ORM para acesso e manipulação dos dados  
- **MySQL** — banco de dados relacional utilizado  
- **ASP.NET Identity** — autenticação e controle de usuários  
- **Bootstrap** — estilização e design responsivo  
- **C#** — linguagem de programação base  

---

## 📁 Estrutura do Projeto

- /Controllers        → Controladores responsáveis pelas rotas e regras de negócio
- /Models             → Modelos das entidades (Empresa, Endereco e Contato)
- /Views              → Páginas da interface do usuário (MVC Views)
- /Migrations         → Arquivos de migração do Entity Framework
- /wwwroot            → Arquivos estáticos (CSS, JS, imagens)
- appsettings.json    → Configuração do banco de dados e Identity
- Program.cs          → Ponto de entrada da aplicação

---

## 🚀 Funcionalidades

- 🔐 **Login e Registro de Usuários** com ASP.NET Identity  
- 🏬 **CRUD completo de Empresas** (criar, listar, editar e excluir)  
- 🔎 **Busca de Empresas por CNPJ**  
- 💾 **Persistência de dados** no banco MySQL  
---

## 🧩 Como Executar o Projeto

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/GustavoSilva25/SistemaGestaoEmpresarialCsharp.git
2. Acesse a pasta do projeto:
   ```bash
   cd SistemaGestaoEmpresarialCsharp
3. Suba o container do MySQL com Docker Compose:
   > ⚠️ Observação: o projeto utiliza o MySQL em container Docker.
   É necessário fazer o build e iniciar o serviço antes de rodar a aplicação.
   ```bash
    docker-compose up -d
   ```
4. Restaure os pacotes e crie o banco de dados:
   ```bash
   dotnet restore
   dotnet ef database update

5. Execute a aplicação:
   ```bash
   dotnet run
