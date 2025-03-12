using Microsoft.EntityFrameworkCore;
using WebAPI_RevendaBebidas.Data;
using WebAPI_RevendaBebidas.Services.Pedido;
using WebAPI_RevendaBebidas.Services.Produto;
using WebAPI_RevendaBebidas.Services.Revenda;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPedidoInterface, PedidoService>();
builder.Services.AddScoped<IRevendaInterface, RevendaService>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
