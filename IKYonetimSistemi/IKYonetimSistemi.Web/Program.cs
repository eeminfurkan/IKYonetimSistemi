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

// --- YENÝ VERÝTABANI VE SERVÝS KAYITLARI ---
// Web projesi için veritabaný dosyasýný doðrudan proje klasöründe oluþturuyoruz.
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlite("Data Source=ik_yonetim_web.db")
);

// PersonelServisi'ni buraya da ayný þekilde kaydediyoruz.
builder.Services.AddTransient<PersonelServisi>();
// --- YENÝ KAYITLARIN SONU ---

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
