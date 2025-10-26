using PaginacaoEFiltros.Application.Services;
using PaginacaoEFiltros.Infrastructure;
using PaginacaoEFiltros.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { 
        Title = "PaginacaoEFiltros API", 
        Version = "v1",
        Description = "API para demonstração de paginação, filtros genéricos e HATEOAS"
    });
});

// Configuração da injeção de dependência
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaginacaoEFiltros API v1");
        c.RoutePrefix = "swagger"; // Para acessar o Swagger em /swagger
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/// <summary>
/// Configura os serviços da aplicação
/// </summary>
static void ConfigureServices(IServiceCollection services)
{
    // Repositórios
    services.AddScoped<IPedidoRepository, PedidosRepository>();

    // Serviços
    services.AddScoped<IPedidoService, PedidoService>();
}
