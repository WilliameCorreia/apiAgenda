# ApiAgenda
Repositório para fornecer dados referente as estação elevatórias da cagece

### Instalação

1. Faça o clone deste projeto com `git clone https://github.com/WilliameCorreia/apiAgenda.git`
2. Entre na pasta do projeto e instale as dependências com `npm install`
3. Rode a aplicação com `dotnet run`

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
Listagem: GET /estacao/
Inserção: POST /estacao/
Visualização: GET /estacao/{id}
Atualização: PUT /estacao/{id}
Exclusão: DELETE /estacao/{id}
```
