# Employee Registration System

Este é um sistema de registro de funcionários desenvolvido em ASP.NET Core com Entity Framework Core e SQLite. O projeto inclui uma API para gerenciar funcionários e seus logs de ações.

## Estrutura do Projeto

- **EmployeeRegistrationSystem.API**: Contém a API principal.
- **Migrations**: Contém as migrações do Entity Framework Core.

## Tecnologias Utilizadas

- ASP.NET Core 8.0
- Entity Framework Core 8.0.8
- SQLite
- Swashbuckle (Swagger) 6.7.3

## Configuração do Projeto

### Pré-requisitos

- .NET SDK 8.0 ou superior
- Visual Studio ou outro IDE compatível

### Passos para Configuração

1. **Clone o repositório**:
git clone https://github.com/seu-usuario/EmployeeRegistrationSystem.git
cd EmployeeRegistrationSystem

2. **Restaure os pacotes NuGet**:

3. **Atualize o banco de dados**:

4. **Execute o projeto**:

dotnet ef database update --project EmployeeRegistrationSystem/EmployeeRegistrationSystem.API

dotnet run --project EmployeeRegistrationSystem/EmployeeRegistrationSystem.API


## Endpoints da API

A API possui os seguintes endpoints:

- `GET /api/employees`: Retorna a lista de funcionários.
- `POST /api/employees`: Adiciona um novo funcionário.
- `PUT /api/employees/{id}`: Atualiza um funcionário existente.
- `DELETE /api/employees/{id}`: Remove um funcionário.

## Documentação da API

A documentação da API pode ser acessada via Swagger em `http://localhost:5000/swagger`.

## Estrutura do Banco de Dados

### Tabela Employees

| Coluna            | Tipo         | Descrição                |
|-------------------|--------------|--------------------------|
| Id                | Guid         | Identificador único      |
| Name              | string       | Nome do funcionário      |
| Address           | string       | Endereço do funcionário  |
| ProfessionalEmail | string       | Email profissional       |
| Salary            | decimal      | Salário                  |
| AdmissionDate     | DateTime     | Data de admissão         |

### Tabela EmployeeLogs

| Coluna        | Tipo            | Descrição                        |
|---------------|-----------------|----------------------------------|
| Id            | Guid            | Identificador único              |
| ActionType    | int             | Tipo de ação                     |
| JSON          | string          | Dados da ação em formato JSON    |
| PartitionKey  | string          | Chave de partição                |
| RowKey        | string          | Chave de linha                   |
| Timestamp     | DateTimeOffset  | Data e hora da ação              |
| EmployeeId    | Guid            | Identificador do funcionário     |

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).