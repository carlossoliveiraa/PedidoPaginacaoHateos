# Exemplo de Resposta da API - Paginação HATEOAS

## Endpoint
```
GET /v1/pedidos?limite=2&pagina=1&nome-cliente=João&uf=SP
```

## Resposta JSON
```json
{
  "links": {
    "pagina_atual": "/v1/pedidos?limite=2&pagina=1&nome-cliente=João&uf=SP",
    "pagina_anterior": null,
    "proxima_pagina": "/v1/pedidos?limite=2&pagina=2&nome-cliente=João&uf=SP",
    "primeira_pagina": "/v1/pedidos?limite=2&pagina=1&nome-cliente=João&uf=SP",
    "ultima_pagina": "/v1/pedidos?limite=2&pagina=12957&nome-cliente=João&uf=SP"
  },
  "paginacao": {
    "pagina": 1,
    "registros_pagina": 2,
    "total_paginas": 12957,
    "total_registros_encontrados": 25914
  },
  "pedidos": [
    {
      "pedidoId": 1,
      "cliente": "João Silva",
      "uf": "SP",
      "valor": 150.50
    },
    {
      "pedidoId": 2,
      "cliente": "João Santos",
      "uf": "SP",
      "valor": 275.75
    }
  ]
}
```

## Estrutura dos Links HATEOAS

### Links Disponíveis
- **pagina_atual**: URL da página atual (sempre presente)
- **pagina_anterior**: URL da página anterior (null se for a primeira página)
- **proxima_pagina**: URL da próxima página (null se for a última página)
- **primeira_pagina**: URL da primeira página (sempre presente)
- **ultima_pagina**: URL da última página (sempre presente)

### Informações de Paginação
- **pagina**: Número da página atual
- **registros_pagina**: Quantidade de registros por página
- **total_paginas**: Total de páginas disponíveis
- **total_registros_encontrados**: Total de registros encontrados

## Parâmetros de Query Suportados

### Paginação
- `limite`: Quantidade de registros por página (padrão: 10, máximo: 150)
- `pagina`: Número da página (começando em 1)

### Filtros
- `numero-pedido`: Filtro por número do pedido
- `nome-cliente`: Filtro por nome do cliente
- `uf`: Filtro por UF do cliente

## Exemplos de Uso

### Primeira página
```
GET /v1/pedidos?limite=10&pagina=1
```

### Página específica com filtros
```
GET /v1/pedidos?limite=5&pagina=3&uf=RJ&nome-cliente=Maria
```

### Última página
```
GET /v1/pedidos?limite=10&pagina=12957&uf=SP
```