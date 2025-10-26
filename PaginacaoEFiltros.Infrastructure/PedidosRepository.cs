using PaginacaoEFiltros.Application.Entities;
using PaginacaoEFiltros.Application.DTOs;
using PaginacaoEFiltros.Application.Interfaces;

namespace PaginacaoEFiltros.Infrastructure
{
    /// <summary>
    /// Repositório para Pedidos com dados simulados
    /// </summary>
    public class PedidosRepository : IPedidoRepository
    {
        private readonly List<Pedido> _entities = new();

        public PedidosRepository()
        {
            InitializeSampleData();
        }


        /// <summary>
        /// Pesquisa pedidos com filtros e paginação simplificada
        /// </summary>
        public async Task<(IEnumerable<Pedido> Items, int TotalCount)> SearchAsync(PedidoSearchRequest request)
        {
            var query = _entities.AsQueryable();

            // Aplica filtros específicos
            if (!string.IsNullOrWhiteSpace(request.NumeroPedido))
            {
                query = query.Where(p => p.Numero.Contains(request.NumeroPedido, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(request.NomeCliente))
            {
                query = query.Where(p => p.ClienteNome.Contains(request.NomeCliente, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(request.UF))
            {
                query = query.Where(p => p.UF != null && p.UF.Equals(request.UF, StringComparison.OrdinalIgnoreCase));
            }

            // Conta total de itens
            var totalCount = query.Count();

            // Aplica ordenação padrão
            query = query.OrderByDescending(p => p.DataCriacao);

            // Aplica paginação
            var skip = (request.PaginaInicial - 1) * request.TotalItensPagina;
            var items = query.Skip(skip).Take(request.TotalItensPagina).ToList();

            return await Task.FromResult((items, totalCount));
        }

        /// <summary>
        /// Inicializa dados de exemplo mais robustos
        /// </summary>
        private void InitializeSampleData()
        {
            var pedidos = new List<Pedido>
            {
                new Pedido
                {
                    Id = 1,
                    Numero = "PED-001",
                    DataCriacao = DateTime.Now.AddDays(-10),
                    Status = "Pendente",
                    ClienteNome = "João Silva",
                    ClienteEmail = "joao.silva@email.com",
                    UF = "SP",
                    ValorTotal = 150.00m,
                    Observacoes = "Pedido urgente",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 1,
                            PedidoId = 1,
                            ProdutoNome = "Produto A",
                            ProdutoCodigo = "PROD-A",
                            Quantidade = 2,
                            ValorUnitario = 75.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 2,
                    Numero = "PED-002",
                    DataCriacao = DateTime.Now.AddDays(-8),
                    Status = "Processando",
                    ClienteNome = "Maria Santos",
                    ClienteEmail = "maria.santos@email.com",
                    UF = "RJ",
                    ValorTotal = 300.00m,
                    Observacoes = "Entrega rápida",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 2,
                            PedidoId = 2,
                            ProdutoNome = "Produto B",
                            ProdutoCodigo = "PROD-B",
                            Quantidade = 1,
                            ValorUnitario = 300.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 3,
                    Numero = "PED-003",
                    DataCriacao = DateTime.Now.AddDays(-5),
                    Status = "Enviado",
                    ClienteNome = "Pedro Oliveira",
                    ClienteEmail = "pedro.oliveira@email.com",
                    UF = "MG",
                    ValorTotal = 450.00m,
                    Observacoes = null,
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 3,
                            PedidoId = 3,
                            ProdutoNome = "Produto C",
                            ProdutoCodigo = "PROD-C",
                            Quantidade = 3,
                            ValorUnitario = 150.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 4,
                    Numero = "PED-004",
                    DataCriacao = DateTime.Now.AddDays(-3),
                    Status = "Entregue",
                    ClienteNome = "Ana Costa",
                    ClienteEmail = "ana.costa@email.com",
                    UF = "SP",
                    ValorTotal = 200.00m,
                    Observacoes = "Cliente satisfeito",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 4,
                            PedidoId = 4,
                            ProdutoNome = "Produto D",
                            ProdutoCodigo = "PROD-D",
                            Quantidade = 1,
                            ValorUnitario = 200.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 5,
                    Numero = "PED-005",
                    DataCriacao = DateTime.Now.AddDays(-1),
                    Status = "Cancelado",
                    ClienteNome = "Carlos Ferreira",
                    ClienteEmail = "carlos.ferreira@email.com",
                    UF = "RS",
                    ValorTotal = 100.00m,
                    Observacoes = "Cancelado pelo cliente",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 5,
                            PedidoId = 5,
                            ProdutoNome = "Produto E",
                            ProdutoCodigo = "PROD-E",
                            Quantidade = 2,
                            ValorUnitario = 50.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 6,
                    Numero = "PED-006",
                    DataCriacao = DateTime.Now.AddDays(-15),
                    Status = "Entregue",
                    ClienteNome = "Fernanda Lima",
                    ClienteEmail = "fernanda.lima@email.com",
                    UF = "SP",
                    ValorTotal = 750.00m,
                    Observacoes = "Cliente VIP",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 6,
                            PedidoId = 6,
                            ProdutoNome = "Produto F",
                            ProdutoCodigo = "PROD-F",
                            Quantidade = 5,
                            ValorUnitario = 150.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 7,
                    Numero = "PED-007",
                    DataCriacao = DateTime.Now.AddDays(-12),
                    Status = "Processando",
                    ClienteNome = "Roberto Alves",
                    ClienteEmail = "roberto.alves@email.com",
                    UF = "RJ",
                    ValorTotal = 320.00m,
                    Observacoes = "Entrega expressa",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 7,
                            PedidoId = 7,
                            ProdutoNome = "Produto G",
                            ProdutoCodigo = "PROD-G",
                            Quantidade = 2,
                            ValorUnitario = 160.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 8,
                    Numero = "PED-008",
                    DataCriacao = DateTime.Now.AddDays(-7),
                    Status = "Enviado",
                    ClienteNome = "Lucia Mendes",
                    ClienteEmail = "lucia.mendes@email.com",
                    UF = "MG",
                    ValorTotal = 180.00m,
                    Observacoes = null,
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 8,
                            PedidoId = 8,
                            ProdutoNome = "Produto H",
                            ProdutoCodigo = "PROD-H",
                            Quantidade = 3,
                            ValorUnitario = 60.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 9,
                    Numero = "PED-009",
                    DataCriacao = DateTime.Now.AddDays(-4),
                    Status = "Pendente",
                    ClienteNome = "Marcos Pereira",
                    ClienteEmail = "marcos.pereira@email.com",
                    UF = "RS",
                    ValorTotal = 420.00m,
                    Observacoes = "Aguardando confirmação",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 9,
                            PedidoId = 9,
                            ProdutoNome = "Produto I",
                            ProdutoCodigo = "PROD-I",
                            Quantidade = 4,
                            ValorUnitario = 105.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 10,
                    Numero = "PED-010",
                    DataCriacao = DateTime.Now.AddDays(-2),
                    Status = "Entregue",
                    ClienteNome = "Patricia Souza",
                    ClienteEmail = "patricia.souza@email.com",
                    UF = "SP",
                    ValorTotal = 250.00m,
                    Observacoes = "Entrega realizada com sucesso",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 10,
                            PedidoId = 10,
                            ProdutoNome = "Produto J",
                            ProdutoCodigo = "PROD-J",
                            Quantidade = 1,
                            ValorUnitario = 250.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 11,
                    Numero = "PED-011",
                    DataCriacao = DateTime.Now.AddDays(-6),
                    Status = "Cancelado",
                    ClienteNome = "Ricardo Costa",
                    ClienteEmail = "ricardo.costa@email.com",
                    UF = "RJ",
                    ValorTotal = 90.00m,
                    Observacoes = "Produto indisponível",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 11,
                            PedidoId = 11,
                            ProdutoNome = "Produto K",
                            ProdutoCodigo = "PROD-K",
                            Quantidade = 1,
                            ValorUnitario = 90.00m
                        }
                    }
                },
                new Pedido
                {
                    Id = 12,
                    Numero = "PED-012",
                    DataCriacao = DateTime.Now.AddDays(-9),
                    Status = "Enviado",
                    ClienteNome = "Sandra Oliveira",
                    ClienteEmail = "sandra.oliveira@email.com",
                    UF = "MG",
                    ValorTotal = 380.00m,
                    Observacoes = "Rastreamento enviado",
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 12,
                            PedidoId = 12,
                            ProdutoNome = "Produto L",
                            ProdutoCodigo = "PROD-L",
                            Quantidade = 2,
                            ValorUnitario = 190.00m
                        }
                    }
                }
            };

            _entities.AddRange(pedidos);
        }
    }
}
