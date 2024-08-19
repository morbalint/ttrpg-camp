using Microsoft.EntityFrameworkCore;
using ClientImports = TtrpgCamp.App.Client._Imports;
using TtrpgCamp.App.Components;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureRequestPipeline(app);

app.Run();

return;

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddHealthChecks();
    services.AddHttpContextAccessor();
    services.AddLogging();
    services.AddHttpLogging(_ => {});
    
    services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    var connectionString = configuration.GetConnectionString("main");
    services.AddDbContext<TtrpgCampDbContext>(dbBuilder => dbBuilder.UseNpgsql(connectionString));

    services.AddDefaultIdentity<TtrpgCampUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<TtrpgCampDbContext>();

    services.AddParticipantServices();
}

void ConfigureRequestPipeline(WebApplication webApp)
{
    if (webApp.Environment.IsDevelopment())
    {
        webApp.UseWebAssemblyDebugging();
        webApp.UseDeveloperExceptionPage();
        using var scope = webApp.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<TtrpgCampDbContext>().Database.Migrate();
    }
    else
    {
        webApp.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        webApp.UseHsts();
    }

    webApp.UseHttpsRedirection();

    webApp.UseStaticFiles();
    webApp.UseAntiforgery();

    webApp.MapHealthChecks("/healthz");

    webApp.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(ClientImports).Assembly);

    webApp.MapRazorPages();
}