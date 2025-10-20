# MEB e Bağlı Kurumlar

Bu proje, Türkiye’de Milli Eğitim Bakanlığı’na bağlı kurumların verilerini sorgulamak için geliştirilmiş bir .NET uygulamasıdır. ASP.NET Core ve Entity Framework Core kullanılarak geliştirilmiştir.

Projede **SoC (Separation of Concerns / Sorumlulukların Ayrılması)** prensibine özel önem verilmiştir. Her bileşen kendi sorumluluğunu taşır: Controller’lar API endpoint’lerini yönetir, Service katmanı iş mantığını uygular, Data katmanı veri erişimini sağlar, ViewModel ve DTO’lar ise veri aktarımı için yapılandırılmıştır. Bu yapı, kodun okunabilirliğini, bakımını ve test edilebilirliğini büyük ölçüde artırır.

## Veri Toplama Yöntemleri

- **Devlet Okulları (Kamu Okulları)**: [MEB Devlet Okulları](https://www.meb.gov.tr/baglantilar/okullar/index.php) sayfasında JSON desteği bulunduğu için API üzerinden veri çekildi. API çağrıları yapılırken gerekli **body** ve **headers** parametreleri taklit edildi. Sayfa tek seferde 25 kayıt gösterdiği için **pagination** uygulanarak tüm veriler alındı.

- **Özel Kurumlar**: [MEB Özel Kurumlar](https://ookgm.meb.gov.tr/kurumlar.php?tur=okul) sayfasında JSON desteği bulunmadığından, **HTML scraping** kullanıldı. Sayfa yapısı analiz edilerek, özel okullar, kurslar, yurtlar ve sosyal etkinlik merkezleri gibi kurumların verileri çekildi. Farlı tablo yapısına sahip sayfalar için tek bir **Generic Class** oluşturulup bu class içinde sayfa yapısına uygun metodlar yazıldı ve veri çekme işlemi standardize edildi.  

Bu yaklaşım, farklı veri kaynaklarının farklı yapılarını yönetirken temiz ve sürdürülebilir bir veri çekme mantığı sağlar.

## Özellikler

- Okullar, özel okullar, kurslar, yurtlar ve sosyal etkinlik merkezleri gibi kurumların kayıtlarını yönetme.
- CRUD (Create, Read, Update, Delete) işlemleri.
- EF Core üzerinden SQLite veritabanı kullanımı.
- REST API desteği ile veri sorgulama ve yönetim.
- Katmanlı mimari ve SoC prensibi ile temiz kod yapısı.

## Teknolojiler

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQLite
- C#

## Kurulum

1. Projeyi klonlayın:
   
   ```bash
   git clone https://github.com/DilaraKardas/MebKurumlar.git

3. Proje dizinine gidin:
    ```bash
    cd MebKurumlar
4. Gerekli paketleri yükleyin:
   ```bash
   dotnet restore
6. Projeyi çalıştırın:
   ```bash
   dotnet run

## Katkıda Bulunma

Projeye katkıda bulunmak isterseniz, fork yapıp pull request gönderebilirsiniz.

