using Microsoft.EntityFrameworkCore;
using PedidoFornecedorAPI.Data;
using PedidoFornecedorAPI.Repositories;
using PedidoFornecedorAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();

// Configuração do DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositórios
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();

// Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Se estiver no ambiente de desenvolvimento, habilita a página de exceção
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Exibe os detalhes do erro no navegador
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuração de roteamento
app.UseRouting();

// Configuração do controlador
app.MapControllers();

// Executa a aplicação
app.Run();