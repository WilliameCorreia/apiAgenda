# ApiAgenda
Repositório para fornecer dados referente as estação elevatórias da cagece

### Pré-Requisitos

- Visual Studio Code
- Sdk 2.2 ou posterior
- C# para Visual Studio Code (versão mais recente)
- Banco de dados SqlSever.

### Instalação

1. Faça o clone deste projeto com `git clone https://github.com/WilliameCorreia/apiAgenda.git`
2. atualize ``appsettings.json`` o ``ConnectionStrings`` altere ``DefaultConnection`` para o seu banco de dados, exemplo:
    ``
   {
    "ConnectionStrings":{
     "DefaultConnection": "Server=WILLIAME;Database=DbAgenda;Trusted_Connection=True;ConnectRetryCount=0"
    }
   }
    ``
3. crie as talebas no banco de dados, executando o comando ``dotnet ef database update`` 
4. Rode a aplicação com o comando `dotnet run`

### Instruções para realizar a integração

#### URL de acesso 
https://localhost:5001/api/estacao

#### Requisições HTTP

Seguimos a estrutura padrão do estilo RESTful

- GET: lista ou consulta dados
- POST: criação de dados
- PUT: atualização de dados
- DELETE: remoção de dados

Exemplo: https://localhost:5001/api/estacao/3 consulta Apenas a estação por id que virá na listagem.

#### Retorno

- Response (application/json)

```
{
    "estacaoId": 3,
    "tipo": "1",
    "nome": "EPC",
    "operadores": [
        {
            "operadorId": 11,
            "nome": "Manoel",
            "telefones": [
                {
                    "telefoneId": 21,
                    "tipo": 2,
                    "fone": "xxxxxxxxx"
                }
            ]
        }
    ],
    "supervisor": {
        "supervisorId": 11,
        "area": "Vertente",
        "nome": "Abraão",
        "telefones": [
            {
                "telefoneId": 22,
                "tipo": 1,
                "fone": "xxxxxxxxx"
            }
        ],
        "estacaoId": 3
    },
    "dadosEnel": {
        "dadosEnelId": 11,
        "nome_cliente": "Cagece",
        "endereco": "Av. Presidente Castelo Branco nº 1200",
        "classe": "nao sei",
        "uc": 2,
        "estacaoId": 3
    }
}
```

#### Endpoints Disponíveis

```
Listagem: GET api/estacao/
Inserção: POST api/estacao/
Visualização: GET api/estacao/{id}
Atualização: PUT api/estacao/{id}
Exclusão: DELETE api/estacao/{id}
```
