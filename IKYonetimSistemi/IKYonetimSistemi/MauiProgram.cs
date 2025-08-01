using IKYonetimSistemi.Services;
using IKYonetimSistemi.Shared.Services;
using Microsoft.Extensions.Logging;
using IKYonetimSistemi.Shared; // UygulamaDbContext'i tanımak için
using IKYonetimSistemi.Shared.Services; // PersonelServisi'ni tanımak için
using Microsoft.EntityFrameworkCore; // UseSqlite gibi EF Core metotları için

namespace IKYonetimSistemi
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the IKYonetimSistemi.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

            // --- YENİ VERİTABANI VE SERVİS KAYITLARI ---
            // Veritabanı dosyasının tam yolunu MAUI'nin kendi araçlarıyla belirliyoruz.
            var dbYolu = Path.Combine(FileSystem.AppDataDirectory, "ik_yonetim.db");

            // DbContext'i kaydediyoruz ve ona SQLite kullanacağını ve veritabanı yolunu söylüyoruz.
            builder.Services.AddDbContext<UygulamaDbContext>(options =>
                options.UseSqlite($"Data Source={dbYolu}")
            );

            // PersonelServisi'ni kaydediyoruz. DbContext kullanan servisler için AddTransient daha uygundur.
            builder.Services.AddTransient<PersonelServisi>();
            // --- YENİ KAYITLARIN SONU ---

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
