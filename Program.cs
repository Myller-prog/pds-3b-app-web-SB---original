using AppWeb.Components;
using AppWeb.Configs;
using AppWeb.Models; // não pode esquecer desses dois

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Conexão com as outras tabelas
builder.Services.AddSingleton<Conexao>();
builder.Services.AddSingleton<ProdutoDAO>();
builder.Services.AddSingleton<FuncionarioDAO>();
builder.Services.AddSingleton<PedidoDAO>();
builder.Services.AddSingleton<AlimentoDAO>();
builder.Services.AddSingleton<RecebimentoDAO>();
builder.Services.AddSingleton<ClienteDAO>();
builder.Services.AddSingleton<IngredientesDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
