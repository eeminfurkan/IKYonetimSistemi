using IKYonetimSistemi.Shared.Models;
using Microsoft.EntityFrameworkCore;

// Microsoft.Maui.Storage'a olan bağımlılığı kaldırdık.
// using Microsoft.Maui.Storage; // <-- BU SATIRI SİL VEYA YORUMA AL

namespace IKYonetimSistemi.Shared
{
    public class UygulamaDbContext : DbContext
    {
        // Bu constructor (yapıcı metot), dışarıdan veritabanı ayarlarını almamızı sağlar.
        // Bu sayede bu sınıf, veritabanının nerede veya nasıl olduğundan tamamen habersiz hale gelir.
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {
        }

        public DbSet<Personel> Personeller { get; set; }

        // OnConfiguring metodunu tamamen sildik çünkü veritabanı yolunu artık burada belirlemeyeceğiz.
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // { ... }  // <-- BU METODUN TAMAMINI SİL
    }
}