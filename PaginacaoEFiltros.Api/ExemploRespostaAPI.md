# Exemplo de Resposta da API de Pedidos

## Endpoint
`GET /api/pedidos`

## Parâmetros de Query
- `numeroPedido` (opcional): Número do pedido para filtrar
- `nomeCliente` (opcional): Nome do cliente para filtrar
- `uf` (opcional): UF do cliente para filtrar
- `paginaInicial` (obrigatório): Página inicial (padrão: 1)
- `totalItensPagina` (obrigatório): Total de itens por página (padrão: 10)

## Exemplo de Requisição
```
GET /api/pedidos?paginaInicial=1&totalItensPagina=10&nomeCliente=João&uf=SP
```

## Exemplo de Resposta
```json
{
  "pagina": 1,
  "total": 12,
  "links": [
    {
      "rel": "next",
      "href": "/api/pedidos?paginaInicial=2&totalItensPagina=5",
      "method": "GET"
    },
    {
      "rel": "last",
      "href": "/api/pedidos?paginaInicial=3&totalItensPagina=5",
      "method": "GET"
    },
    {
      "rel": "self",
      "href": "/api/pedidos?paginaInicial=1&totalItensPagina=5",
      "method": "GET"
    }
  ],
  "pedidos": [
    {
      "pedidoId": 5,
      "cliente": "Carlos Ferreira",
      "uf": "RS",
      "valor": 100.00
    },
    {
      "pedidoId": 10,
      "cliente": "Patricia Souza",
      "uf": "SP",
      "valor": 250.00
    },
    {
      "pedidoId": 4,
      "cliente": "Ana Costa",
      "uf": "SP",
      "valor": 200.00
    },
    {
      "pedidoId": 9,
      "cliente": "Marcos Pereira",
      "uf": "RS",
      "valor": 420.00
    },
    {
      "pedidoId": 3,
      "cliente": "Pedro Oliveira",
      "uf": "MG",
      "valor": 450.00
    }
  ]
}
```

## Exemplo com Filtros
### Requisição com filtro por UF
```
GET /api/pedidos?paginaInicial=1&totalItensPagina=3&uf=SP
```

### Resposta com filtro por UF
```json
{
  "pagina": 1,
  "total": 4,
  "links": [
    {
      "rel": "next",
      "href": "/api/pedidos?paginaInicial=2&totalItensPagina=3&uf=SP",
      "method": "GET"
    },
    {
      "rel": "last",
      "href": "/api/pedidos?paginaInicial=2&totalItensPagina=3&uf=SP",
      "method": "GET"
    },
    {
      "rel": "self",
      "href": "/api/pedidos?paginaInicial=1&totalItensPagina=3&uf=SP",
      "method": "GET"
    }
  ],
  "pedidos": [
    {
      "pedidoId": 10,
      "cliente": "Patricia Souza",
      "uf": "SP",
      "valor": 250.00
    },
    {
      "pedidoId": 4,
      "cliente": "Ana Costa",
      "uf": "SP",
      "valor": 200.00
    },
    {
      "pedidoId": 1,
      "cliente": "João Silva",
      "uf": "SP",
      "valor": 150.00
    }
  ]
}
```

## Estrutura da Resposta

### Campos Principais
- **pagina**: Número da página atual
- **total**: Total de registros encontrados
- **links**: Array de links HATEOAS para navegação
- **pedidos**: Array com os pedidos encontrados

### Links HATEOAS
Os links incluem:
- `first`: Primeira página
- `prev`: Página anterior
- `next`: Próxima página
- `last`: Última página

### Estrutura do Pedido
- **pedidoId**: ID único do pedido
- **cliente**: Nome do cliente
- **uf**: UF do cliente
- **valor**: Valor total do pedido
