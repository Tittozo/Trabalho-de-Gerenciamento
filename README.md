# Trabalho de Gerenciamento

Sistema web desenvolvido para fins acadêmicos durante o curso de **Análise e Desenvolvimento de Sistemas (ADS)**.

O projeto tem como objetivo aplicar na prática conceitos de **C#, ASP.NET Core MVC, Entity Framework Core, PostgreSQL, CRUD, validação de dados, migrations e Git/GitHub**.

---

##  Sobre o Projeto

O sistema foi desenvolvido para realizar o **gerenciamento de pacientes**, permitindo cadastrar, consultar, editar e excluir informações.

A aplicação utiliza o padrão **MVC (Model-View-Controller)**, mantendo uma separação simples entre:

* **Model** → representa os dados do sistema.
* **View** → responsável pela interface apresentada ao usuário.
* **Controller** → recebe as requisições e executa as operações.
* **Data** → responsável pelo acesso ao banco de dados.

O projeto foi desenvolvido de maneira incremental, registrando as principais etapas através do Git.

---

##  Objetivos

O desenvolvimento do projeto busca colocar em prática:

* Programação em C#
* Orientação a Objetos
* ASP.NET Core MVC
* Entity Framework Core
* PostgreSQL
* Data Annotations
* Validação de dados
* Operações CRUD
* Migrations
* Seed de dados
* Razor Views
* Bootstrap
* Git e GitHub

---

#  Tecnologias Utilizadas

| Tecnologia                | Utilização                           |
| ------------------------- | ------------------------------------ |
| **C#**                    | Linguagem principal                  |
| **ASP.NET Core MVC**      | Desenvolvimento da aplicação web     |
| **Entity Framework Core** | Comunicação com o banco de dados     |
| **PostgreSQL**            | Banco de dados                       |
| **Npgsql**                | Integração do EF Core com PostgreSQL |
| **Razor**                 | Desenvolvimento das Views            |
| **Bootstrap**             | Interface visual                     |
| **Git**                   | Controle de versão                   |
| **GitHub**                | Hospedagem do repositório            |

### Pacotes principais

```text
Npgsql.EntityFrameworkCore.PostgreSQL
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
```

---

#  Estrutura do Projeto

A aplicação utiliza uma estrutura baseada no padrão MVC:

```text
Trabalho-de-Gerenciamento/
│
├── Controllers/
│   ├── HomeController.cs
│   └── PacientesController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│   └── Arquivos das migrations
│
├── Models/
│   ├── ErrorViewModel.cs
│   └── Pacientes.cs
│
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   │
│   ├── Pacientes/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   │
│   └── Shared/
│
├── appsettings.json
├── Program.cs
└── Trabalho-de-Gerenciamento.csproj
```

---

#  Model — Pacientes

A classe `Pacientes` representa os pacientes cadastrados no sistema.

Atualmente possui os seguintes campos:

| Campo            | Tipo       | Descrição           |
| ---------------- | ---------- | ------------------- |
| `Id`             | `int`      | Identificador único |
| `Nome`           | `string`   | Nome do paciente    |
| `CPF`            | `string`   | CPF do paciente     |
| `Telefone`       | `string`   | Telefone            |
| `Endereco`       | `string`   | Endereço            |
| `DataNascimento` | `DateTime` | Data de nascimento  |

O `Id` é utilizado como chave primária através da convenção do Entity Framework Core.

---

#  Validação dos Dados

Foram utilizadas **Data Annotations** para realizar validações básicas diretamente no Model.

Exemplo:

```csharp
[Required]
[StringLength(100)]
public string Nome { get; set; }
```

### `[Required]`

Indica que o campo é obrigatório.

### `[StringLength]`

Define a quantidade máxima de caracteres permitida.

As validações foram aplicadas aos campos:

* Nome
* CPF
* Telefone
* Endereço
* Data de nascimento

---

#  Banco de Dados

O sistema utiliza o **PostgreSQL** para armazenar os pacientes.

Durante o desenvolvimento local foi utilizado:

```text
Host: localhost
Porta: 5432
Banco: Gerenciamento
Usuário: postgres
```

A tabela principal do sistema é:

```text
Pacientes
```

---

# 🔌 Entity Framework Core

O acesso ao banco de dados é realizado através do **Entity Framework Core**.

Foi criado o `AppDbContext`:

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pacientes> Pacientes { get; set; }
}
```

O `DbSet<Pacientes>` representa a tabela de pacientes no banco de dados.

---

#  Seed de Dados

Foram adicionados dados iniciais utilizando o recurso `HasData()` do Entity Framework Core.

Atualmente existem três pacientes utilizados como dados iniciais:

* João Silva
* Mateus Sousa
* Maria Oliveira

O Seed facilita os testes e permite que a aplicação tenha registros disponíveis logo após a criação do banco.

---

#  Configuração da Data de Nascimento

Como o projeto utiliza PostgreSQL, a propriedade `DataNascimento` foi configurada para utilizar:

```csharp
.HasColumnType("timestamp without time zone")
```

Essa configuração evita problemas relacionados ao armazenamento da data no PostgreSQL.

---

#  Connection String

A conexão com o banco é configurada através do `appsettings.json`.

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=Gerenciamento;Username=postgres;Password=SUA_SENHA"
  }
}
```

O `Program.cs` utiliza essa configuração para conectar a aplicação ao PostgreSQL.

>  **Importante:** nunca publique uma senha real de banco de dados em um repositório público.

---

#  Program.cs

O `Program.cs` realiza as principais configurações da aplicação.

Entre elas:

* Configuração do MVC
* Configuração do Entity Framework Core
* Conexão com PostgreSQL
* Leitura da Connection String
* Configuração do HTTPS
* Arquivos estáticos
* Roteamento da aplicação
* Tratamento básico de erros

A configuração do banco utiliza:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
```

---

#  CRUD de Pacientes

O sistema possui um CRUD completo.

CRUD significa:

```text
C → Create  → Criar
R → Read    → Ler
U → Update  → Atualizar
D → Delete  → Excluir
```

##  Create

Permite cadastrar um novo paciente.

Fluxo:

```text
Formulário
    ↓
Create POST
    ↓
Validação
    ↓
AppDbContext
    ↓
PostgreSQL
```

---

##  Read

A página `Index` consulta os pacientes cadastrados e apresenta os dados em uma tabela.

São exibidos:

* ID
* Nome
* CPF
* Telefone
* Endereço
* Data de nascimento

---

##  Update

A função `Edit` permite alterar os dados de um paciente existente.

O sistema:

1. Localiza o paciente pelo `Id`.
2. Apresenta os dados no formulário.
3. Recebe as alterações.
4. Valida os dados.
5. Atualiza o registro.
6. Salva as alterações no banco.

---

##  Delete

A exclusão possui uma tela de confirmação.

O sistema:

1. Localiza o paciente pelo `Id`.
2. Apresenta os dados.
3. Solicita confirmação.
4. Remove o registro.
5. Salva a alteração no banco.

---

#  PacientesController

O `PacientesController` concentra as operações relacionadas aos pacientes.

| Método                             | Função              |
| ---------------------------------- | ------------------- |
| `Index()`                          | Lista os pacientes  |
| `Create()`                         | Abre o cadastro     |
| `Create(Pacientes paciente)`       | Salva novo paciente |
| `Edit(int? id)`                    | Abre edição         |
| `Edit(int id, Pacientes paciente)` | Salva alterações    |
| `Delete(int? id)`                  | Abre confirmação    |
| `Delete(int id)`                   | Remove paciente     |

O Controller recebe o `AppDbContext` através de **injeção de dependência**.

---

#  Views

## `Index.cshtml`

Responsável pela listagem dos pacientes.

Possui:

* Tabela de pacientes
* Botão para cadastro
* Link para edição
* Link para exclusão

---

## `Create.cshtml`

Formulário utilizado para cadastrar novos pacientes.

Campos:

```text
Nome
CPF
Telefone
Endereço
Data de nascimento
```

Também utiliza mensagens de validação.

---

## `Edit.cshtml`

Formulário utilizado para editar os dados de um paciente.

O `Id` é mantido através de um campo oculto:

```html
<input type="hidden" asp-for="Id" />
```

---

## `Delete.cshtml`

Página utilizada para confirmar a exclusão de um paciente antes de removê-lo do banco.

---

#  Interface

Além das funcionalidades do sistema, foram realizadas melhorias simples na interface.

A intenção foi deixar o projeto mais organizado visualmente sem adicionar complexidade desnecessária.

##  Home

A página inicial foi personalizada com:

* Título do sistema
* Descrição
* Botão de acesso aos pacientes
* Cards informativos
* Melhor espaçamento
* Botões utilizando Bootstrap
* Layout responsivo

A Home apresenta três áreas principais:

```text
Pacientes
Cadastro
Gerenciamento
```

---

##  Privacy

A página de privacidade também foi personalizada.

Foram adicionados:

* Título
* Descrição
* Card de informações
* Seções de conteúdo
* Alerta informativo
* Espaçamento melhor organizado

A página mantém uma aparência simples e adequada ao projeto acadêmico.

---

#  Bootstrap

O Bootstrap foi utilizado para melhorar a apresentação visual das páginas.

Algumas classes utilizadas incluem:

```text
container
row
col-md-4
card
card-body
btn
btn-primary
btn-outline-primary
shadow-sm
text-center
text-muted
mt-3
mb-3
py-5
```

Não foi adicionada uma estrutura visual complexa. A ideia foi utilizar recursos básicos já disponíveis no projeto.

---

#  Razor Tag Helpers

As Views utilizam recursos do Razor e Tag Helpers do ASP.NET Core.

Exemplo:

```html
<a asp-action="Create">
    Cadastrar novo paciente
</a>
```

Outro exemplo:

```html
<input asp-for="Nome" class="form-control" />
```

E para validação:

```html
<span asp-validation-for="Nome"></span>
```

Esses recursos facilitam a ligação entre as Views e os Models.

---

#  Migrations

As migrations foram utilizadas para controlar a estrutura do banco de dados através do Entity Framework Core.

A migration inicial foi criada utilizando:

```powershell
Add-Migration InitialCreate
```

Para aplicar as alterações ao banco:

```powershell
Update-Database
```

Para consultar as migrations:

```powershell
Get-Migration
```

As migrations permitiram criar a tabela `Pacientes` e posteriormente registrar o Seed inicial.

---

#  Fluxo da Aplicação

O funcionamento básico do sistema pode ser representado da seguinte forma:

```text
             USUÁRIO
                │
                ▼
              VIEW
                │
                ▼
           CONTROLLER
                │
                ▼
          APPDBCONTEXT
                │
                ▼
           ENTITY FRAMEWORK
                │
                ▼
           POSTGRESQL
```

### Exemplo: cadastro

```text
Usuário preenche o formulário
            ↓
Create.cshtml
            ↓
PacientesController
            ↓
ModelState.IsValid
            ↓
AppDbContext
            ↓
SaveChanges()
            ↓
PostgreSQL
            ↓
Lista de pacientes
```

---

#  Validação no Controller

Antes de salvar os dados, o Controller verifica:

```csharp
if (ModelState.IsValid)
```

Quando os dados são válidos:

```csharp
_context.Pacientes.Add(paciente);
_context.SaveChanges();
```

Quando existem erros de validação, o usuário retorna ao formulário para corrigir os dados.

---

#  Execução do Projeto

## Pré-requisitos

Para executar o projeto é necessário ter instalado:

* .NET SDK
* PostgreSQL
* Visual Studio ou VS Code
* Git

---

## 1. Clonar o repositório

```bash
git clone https://github.com/Tittozo/Trabalho-de-Gerenciamento.git
```

Depois entre na pasta:

```bash
cd Trabalho-de-Gerenciamento
```

---

## 2. Configurar o banco

Crie um banco PostgreSQL chamado:

```text
Gerenciamento
```

Depois configure a Connection String no `appsettings.json`.

Exemplo:

```json
"DefaultConnection": "Host=localhost;Port=5432;Database=Gerenciamento;Username=postgres;Password=SUA_SENHA"
```

---

## 3. Aplicar as migrations

No Console do Gerenciador de Pacotes do Visual Studio:

```powershell
Update-Database
```

---

## 4. Executar a aplicação

No terminal:

```bash
dotnet run
```

Ou execute diretamente pelo Visual Studio.

---

#  Principais Arquivos

| Arquivo                              | Responsabilidade                  |
| ------------------------------------ | --------------------------------- |
| `Program.cs`                         | Configuração da aplicação         |
| `appsettings.json`                   | Configurações e conexão com banco |
| `Models/Pacientes.cs`                | Modelo de paciente                |
| `Data/AppDbContext.cs`               | Acesso ao banco                   |
| `Controllers/PacientesController.cs` | Operações CRUD                    |
| `Views/Pacientes/Index.cshtml`       | Listagem                          |
| `Views/Pacientes/Create.cshtml`      | Cadastro                          |
| `Views/Pacientes/Edit.cshtml`        | Edição                            |
| `Views/Pacientes/Delete.cshtml`      | Exclusão                          |
| `Views/Home/Index.cshtml`            | Página inicial                    |
| `Views/Home/Privacy.cshtml`          | Página de privacidade             |
| `Migrations/`                        | Histórico da estrutura do banco   |

---

#  Controle de Versão

O projeto foi desenvolvido utilizando Git e GitHub.

As principais etapas foram registradas individualmente através de commits.

## Histórico de desenvolvimento

```text
chore: criar projeto inicial

feat: criar AppDbContext

feat: criar classe Paciente

feat: adicionar validações em Paciente

feat: configurar banco e migration inicial

feat: adicionar seeding de pacientes

feat: listar pacientes

feat: cadastrar pacientes

feat: editar pacientes

feat: excluir pacientes

feat: melhorar interface das páginas iniciais

docs: adicionar comentários explicativos ao código
```

Essa organização permite acompanhar a evolução do projeto e identificar quando cada funcionalidade foi implementada.

---

#  Comentários no Código

Foram adicionados comentários explicativos aos principais arquivos do projeto.

Entre eles:

* `Pacientes.cs`
* `AppDbContext.cs`
* `Program.cs`
* `PacientesController.cs`
* `Index.cshtml`
* `Create.cshtml`
* `Edit.cshtml`
* `Delete.cshtml`

Os comentários têm como objetivo facilitar a leitura e explicar a função de cada parte do código.

A documentação foi mantida de forma simples para acompanhar o nível do projeto acadêmico.

---

#  Segurança

Alguns cuidados foram considerados durante o desenvolvimento.

### Senha do banco

A senha do PostgreSQL não deve ser disponibilizada publicamente.

A Connection String utilizada no ambiente local deve utilizar a senha correspondente ao banco configurado na máquina.

### HTTPS

O projeto possui configuração para utilização de HTTPS durante a execução da aplicação.

### Dados dos pacientes

Como o sistema trabalha com informações pessoais, uma futura versão de produção deverá possuir controles de acesso e medidas adicionais de segurança.

---

#  Conceitos Aplicados

Durante o desenvolvimento foram trabalhados os seguintes conceitos:

### C#

* Classes
* Propriedades
* Métodos
* Tipos de dados
* Orientação a Objetos

### ASP.NET Core MVC

* Models
* Views
* Controllers
* Actions
* Rotas
* Injeção de dependência

### Entity Framework Core

* `DbContext`
* `DbSet`
* Migrations
* `HasData`
* `SaveChanges`
* Consulta e alteração de registros

### Banco de Dados

* PostgreSQL
* Tabela
* Chave primária
* Campos
* Persistência de dados

### Validação

* `Required`
* `StringLength`
* `ModelState.IsValid`

### Front-end

* Razor
* HTML
* Bootstrap
* Layout responsivo

### Versionamento

* Git
* GitHub
* Commits incrementais
* `git add`
* `git commit`
* `git push`

---

#  Evolução do Projeto

O projeto foi desenvolvido em etapas:

```text
1. Criação do projeto
        ↓
2. Configuração do DbContext
        ↓
3. Criação do Model Pacientes
        ↓
4. Adição das validações
        ↓
5. Configuração do PostgreSQL
        ↓
6. Criação das migrations
        ↓
7. Seed de pacientes
        ↓
8. Listagem
        ↓
9. Cadastro
        ↓
10. Edição
        ↓
11. Exclusão
        ↓
12. Melhoria visual da Home e Privacy
        ↓
13. Organização e comentários do código
```

---

#  Finalidade Acadêmica

O projeto tem finalidade acadêmica e foi desenvolvido para demonstrar a aplicação prática dos conhecimentos estudados durante o curso de **Análise e Desenvolvimento de Sistemas**.

A implementação priorizou uma estrutura simples, funcional e compreensível, permitindo demonstrar a integração entre aplicação web, banco de dados e controle de versão.

---

#  Possíveis Melhorias Futuras

O projeto pode receber novas funcionalidades futuramente, como:

* Autenticação de usuários
* Controle de acesso
* Pesquisa de pacientes
* Paginação
* Máscara para CPF e telefone
* Melhorias adicionais na interface
* Mensagens de confirmação
* Testes automatizados
* Deploy da aplicação
* Configuração de banco para ambiente de produção

Essas funcionalidades não fazem parte da implementação atual e podem ser adicionadas posteriormente conforme a evolução do projeto.

---

#  Autor

**Mateus Antunes**

Projeto desenvolvido para fins acadêmicos no curso de:

**Análise e Desenvolvimento de Sistemas — ADS**

---

##  Status do Projeto

 **Em desenvolvimento**

### Funcionalidades atuais

* [x] Estrutura ASP.NET Core MVC
* [x] Model de pacientes
* [x] Validações
* [x] PostgreSQL
* [x] Entity Framework Core
* [x] Migrations
* [x] Seed de dados
* [x] Listagem
* [x] Cadastro
* [x] Edição
* [x] Exclusão
* [x] Interface inicial personalizada
* [x] Página Privacy personalizada
* [x] Comentários explicativos no código
* [x] Versionamento com Git/GitHub
