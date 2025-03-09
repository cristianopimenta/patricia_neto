using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Globalization;
using web;

using web.Components;
using web.Auth;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using web.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using web.Controller.Interface;
using web.Controller.Services;
using web.Controller.Services.Autenticacao;
using web.Controller.Services.Financeiro;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Falha de conexão com  'DefaultConnection' não existe.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
    mySqlOptions => mySqlOptions.EnableRetryOnFailure()));


// Configuração do MySQL
builder.Services.AddTransient<DatabaseService>(_ => new DatabaseService(connectionString));

// Registra o serviço de agendamento de backup
builder.Services.AddHostedService<DatabaseBackupScheduler>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

//atenticação jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddScoped(sp =>
{
    var apiUrl = builder.Configuration["ApiSettings:BaseUrl"];
    return new HttpClient
    {
        BaseAddress = new Uri(apiUrl)
    };
    
});


//logs detalhados
builder.Logging.AddConsole();

// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddControllers();


//Autentica��o
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<TokenAuthenticationProvider>();

builder.Services.AddScoped<IAuthorizeService, TokenAuthenticationProvider>(
    provider => provider.GetRequiredService<TokenAuthenticationProvider>());


builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationProvider>(
    provider => provider.GetRequiredService<TokenAuthenticationProvider>());

builder.Services.AddScoped<AuthenticationStateProvider, Autentica>();
builder.Services.AddAuthenticationCore();


// Adicione o serviço LocalStorage

builder.Services.AddScoped<IPlanoConta, PlanoContaService>();
builder.Services.AddScoped<IPet, PetService>();

builder.Services.AddScoped<IEmpresa, EmpresaService>();
builder.Services.AddScoped<IImoveis, ImovelService>();
builder.Services.AddScoped<ILocalidade, LocalidadeService>();
builder.Services.AddScoped<IOcorrenciaInterna, OcorrenciaInternaService>();
builder.Services.AddScoped<IPessoaVeiculo, PessoaVeiculoService>();
builder.Services.AddScoped<IPessoaDocumento, PessoaDocumentoService>();
builder.Services.AddScoped<ICondominio, CondominioService>();
builder.Services.AddScoped<IPessoa, PessoaService>();
builder.Services.AddScoped<IPessoaPermanente, PessoaPermanenteService>();
builder.Services.AddScoped<IPessoaContato, PessoaContatoService>();
builder.Services.AddScoped<IPessoaEnderecos, PessoaEnderecoService>();
builder.Services.AddScoped<IPanicoMobile, PanicoMobileService>();

//Financeiro//
builder.Services.AddScoped<IContaPagar, ContaPagarService>();
builder.Services.AddScoped<IContaReceber, ContaReceberService>();
builder.Services.AddScoped<ContaReceberService>();
builder.Services.AddScoped<ContaPagarService>();
builder.Services.AddScoped<DerService>();
builder.Services.AddScoped<RelatorioService>();
builder.Services.AddScoped<FornecedorService>();

builder.Services.AddScoped<IConciliacaoBancaria, ConciliacaoBancariaService>();

builder.Services.AddScoped<HelperConfiguracoes>();
builder.Services.AddHttpClient<BuscarCEPService>();

builder.Services.AddScoped<HelperConfiguracoes>();
builder.Services.AddScoped<IPanicoMobile, PanicoMobileService>();
builder.Services.AddScoped<UsuarioService>();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<BuscarCEPService>(client =>
{
    client.BaseAddress = new Uri("https://viacep.com.br/");
});


/*builder.Services.AddServerSideBlazor()
   .AddHubOptions(options =>
   {
       options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
   });*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});

app.UseWebSockets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
