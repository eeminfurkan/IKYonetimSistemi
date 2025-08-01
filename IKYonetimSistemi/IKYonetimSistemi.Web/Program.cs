using IKYonetimSistemi.Shared.Services;
using IKYonetimSistemi.Web.Components;
using IKYonetimSistemi.Web.Services;
using IKYonetimSistemi.Shared;
using IKYonetimSistemi.Shared.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the IKYonetimSistemi.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
// ...
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// --- YEN� VER�TABANI VE SERV�S KAYITLARI ---
// Web projesi i�in veritaban� dosyas�n� do�rudan proje klas�r�nde olu�turuyoruz.
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlite("Data Source=ik_yonetim_web.db")
);

// PersonelServisi'ni buraya da ayn� �ekilde kaydediyoruz.
builder.Services.AddTransient<PersonelServisi>();
// --- YEN� KAYITLARIN SONU ---

var app = builder.Build();
// ...

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    .AddAdditionalAssemblies(typeof(IKYonetimSistemi.Shared._Imports).Assembly);

app.Run();
