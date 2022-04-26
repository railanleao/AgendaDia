using AgendaDia.Areas.Contatos.Models;
using AgendaDia.Areas.Repository;
using AgendaDia.Areas.Services;
using AgendaDia.Shared.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Configuração de banco de dados
builder.Services.AddControllers();
builder.Services.AddDbContextPool<DbContext, AgendaDbContext>(opt => opt.UseNpgsql
(builder.Configuration.GetConnectionString("AgendaDb")));
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IGenericRepository<Contato>, ContatoRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//usando api
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//usando api
app.MapControllers();

app.MapRazorPages();

app.Run();
