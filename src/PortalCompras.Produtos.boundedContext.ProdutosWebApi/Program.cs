using Microsoft.AspNetCore.Rewrite;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PortalCompras.Produtos.boundedContext.Application.Validators;
using PortalCompras.Produtos.boundedContext.DependencyInjection;
using PortalCompras.Produtos.boundedContext.Infrastructure.Configurations;
using System.Data.SQLite;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {

        Title = "Microserviço WebApi RestFul",
        Version = "v1",
        Description = "Microserviços desenvolvido pra gerenciamento de Produtos.",
        Contact = new OpenApiContact()
        {
            Name = "Edson Rodrigo",
            Url = new Uri("https://microservicoprodutos.com.br/"),
            Email = "edson@edson.com",
        }
    });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));


});


var conection = builder.Configuration.GetConnectionString("mysqlConnectionString");
builder.Services.AddDbContext<ProdutosMysqlDbContext>(options =>
    options.UseMySql(conection, new MySqlServerVersion(new Version(8, 0, 21)))
);

var conectionSqlLite = builder.Configuration.GetConnectionString("sqlliteConnectionString");
var conn = new SQLiteConnection(conectionSqlLite);
builder.Services.AddDbContext<ProdutosSqlLiteDbContext>(options =>
    options.UseSqlite(conectionSqlLite)
);


builder.Services.AddFluentValidation(typeof(ProdutoValidator));
builder.Services.ResolveDependencies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}
   // var options = new RewriteOptions();
   // options.AddRedirect("^$", "swagger");

   // app.UseRewriter(options);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
