using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::IKYonetimSistemi.Shared.Models;
using IKYonetimSistemi.Shared.Models;

namespace IKYonetimSistemi.Shared.Services
{
     // Personel modelimizi kullanabilmek için ekledik.

    
        public class PersonelServisi
        {
            // Uygulama boyunca verileri bellekte tutacak olan statik liste.
            private static List<Personel> _personelListesi;

            public PersonelServisi()
            {
                // Eğer liste daha önce oluşturulmadıysa, içine birkaç örnek personel ekle.
                if (_personelListesi == null)
                {
                    _personelListesi = new List<Personel>()
                {
                    new Personel()
                    {
                        Id = 1,
                        Ad = "Ahmet",
                        Soyad = "Yılmaz",
                        Departman = "Yazılım Geliştirme",
                        Pozisyon = "Kıdemli Yazılım Uzmanı",
                        Eposta = "ahmet.yilmaz@sirket.com",
                        IseGirisTarihi = new DateTime(2022, 5, 15)
                    },
                    new Personel()
                    {
                        Id = 2,
                        Ad = "Ayşe",
                        Soyad = "Kaya",
                        Departman = "İnsan Kaynakları",
                        Pozisyon = "İK Uzmanı",
                        Eposta = "ayse.kaya@sirket.com",
                        IseGirisTarihi = new DateTime(2023, 1, 10)
                    },
                    new Personel()
                    {
                        Id = 3,
                        Ad = "Mehmet",
                        Soyad = "Demir",
                        Departman = "Yazılım Geliştirme",
                        Pozisyon = "Junior Yazılım Uzmanı",
                        Eposta = "mehmet.demir@sirket.com",
                        IseGirisTarihi = new DateTime(2024, 6, 1)
                    }
                };
                }
            }

            // Dışarıdan personel listesini isteyenlere bu metot cevap verecek.
            public List<Personel> PersonelleriGetir()
            {
                return _personelListesi;
            }

            // Dışarıdan gelen yeni bir personeli listeye ekleyecek metot.
            public void PersonelEkle(Personel yeniPersonel)
            {
                // Gerçek bir veritabanında Id otomatik artar, biz şimdilik manuel olarak en büyük Id'nin bir fazlasını veriyoruz.
                yeniPersonel.Id = _personelListesi.Max(p => p.Id) + 1;
                _personelListesi.Add(yeniPersonel);
            }
        }
    }