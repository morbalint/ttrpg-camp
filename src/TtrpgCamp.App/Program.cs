using Microsoft.EntityFrameworkCore;
using ClientImports = TtrpgCamp.App.Client._Imports;
using TtrpgCamp.App.Components;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var connectionString = builder.Configuration.GetConnectionString("main");
builder.Services.AddDbContext<TtrpgCampDbContext>(dbBuilder => dbBuilder.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<TtrpgCampUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TtrpgCampDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseDeveloperExceptionPage();
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetRequiredService<TtrpgCampDbContext>().Database.Migrate();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ClientImports).Assembly);

app.Run();