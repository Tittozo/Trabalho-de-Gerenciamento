using Microsoft.EntityFrameworkCore;
using Trabalho_de_Gerenciamento.Data;
using Trabalho_de_Gerenciamento.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para utilizar MVC no projeto
builder.Services.AddControllersWithViews();

// Configura o Entity Framework Core para utilizar o PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        // Obtém a string de conexão definida no appsettings.json
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Registra o serviço responsável pelas operações dos pacientes
builder.Services.AddScoped<PacienteService>();

var app = builder.Build();

// Configura o tratamento de erros durante a execução da aplicação
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // Define o tempo de validade do HSTS para 30 dias
    app.UseHsts();
}

// Redireciona automaticamente conexões HTTP para HTTPS
app.UseHttpsRedirection();

// Permite que a aplicação encontre arquivos estáticos, como CSS e JavaScript
app.UseStaticFiles();

app.UseRouting();

// Configura o acesso aos Controllers e às Views
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();