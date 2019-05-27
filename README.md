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

    ```
   {
      "ConnectionStrings":{
        "DefaultConnection": "Server=WILLIAME;Database=DbAgenda;Trusted_Connection=True;ConnectRetryCount=0"
      }
   }
    ```
    
3. crie as talebas no banco de dados, executando o comando ``dotnet ef database update`` 
4. Rode a aplicação com o comando `dotnet run`

### Instruções para realizar a integração

#### URL de acesso 
``https://localhost:<port>/api/estacao``

#### Requisições HTTP

Seguimos a estrutura padrão do estilo RESTful

- GET: lista ou consulta dados
- POST: criação de dados
- PUT: atualização de dados
- DELETE: remoção de dados

Exemplo: ``https://localhost:<port>/api/estacao/3`` consulta Apenas a estação por id que virá na listagem.

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

### Testar a Api com o Postman

- Instale o Postman
- Inicie o aplicativo Web.
- Inicie o Postman.

#### Testar o método Create
- Compile o projeto.
- No Postman, defina o método HTTP como POST.
- Selecione a guia Body.
- Selecione o botão de opção raw.
- Defina o tipo como JSON (aplicativo/json).
- No corpo da solicitação, insira JSON para um item pendente:

    ```
    {
    "tipo": "1",
    "nome": "EPC",
    "operadores": [
        {
            "nome": "Manoel",
            "telefones": [
                {
                    "tipo": 2,
                    "fone": "xxxxxxxxx"
                }
            ]
        }
    ],
    "supervisor": {
        "area": "Vertente",
        "nome": "Abraão",
        "telefones": [
            {
                "tipo": 1,
                "fone": "xxxxxxxxx"
            }
        ]
    },
    "dadosEnel": {
        "nome_cliente": "Cagece",
        "endereco": "Av. Presidente Castelo Branco nº 1200",
        "classe": "nao sei",
        "uc": 2
    }
}
    ```
    
- Selecione Enviar.

![Post](https://user-images.githubusercontent.com/42654850/58427619-8822f780-8076-11e9-96df-ae5c4a2f2230.PNG)

#### Testar o método ListaEstacoes
- Crie uma solicitação.
    - Defina o método HTTP como GET.
    - Defina a URL de solicitação como ``https://localhost:<port>/api/estacao`` Por exemplo, ``https://localhost:5001/api/estacao``.
- Defina Exibição de dois painéis no Postman.
- Selecione Enviar.
    
    ![Get](https://user-images.githubusercontent.com/42654850/58427987-9a516580-8077-11e9-9c05-562dc59f5743.PNG)
