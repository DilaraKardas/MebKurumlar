using HtmlAgilityPack;
using MebOkullar.Data;
using MebOkullar.DtoModel;
using MebOkullar.Models;
using MebOkullar.Scrapper;
using System.Net.Http;
namespace MebOkullar.Service
{
    public class OzelOkulService
    {
        private readonly GenericScaper _scraper;
        private readonly MebDbContext _dbContext;
        private readonly string BaseUrl = "https://ookgm.meb.gov.tr/kurumlar.php?tur={0}&tur2=0&il=";

        public OzelOkulService(GenericScaper scraper, MebDbContext dbContext)
        {
            _scraper = scraper;
            _dbContext = dbContext;
        }
        public async Task<int> ScrapeAsync()
        {   
            string[] kurumTurleri = {"okul", "kurs", "sosyaletkinlik", "mtsk", "rehabilitasyon", "ozelogretim", "sosyaletkinlikgelisim", "ogrencietkinlik", "yurt" };

            string[] iller = {
                "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AMASYA", "ANKARA", "ANTALYA", "ARTVİN",
                "AYDIN", "BALIKESİR", "BİLECİK", "BİNGÖL", "BİTLİS", "BOLU", "BURDUR", "BURSA", "ÇANAKKALE",
                "ÇANKIRI", "ÇORUM", "DENİZLİ", "DİYARBAKIR", "EDİRNE", "ELAZIĞ", "ERZİNCAN", "ERZURUM",
                "ESKİŞEHİR", "GAZİANTEP", "GİRESUN", "GÜMÜŞHANE", "HAKKARİ", "HATAY", "ISPARTA", "MERSİN",
                "İSTANBUL", "İZMİR", "KARS", "KASTAMONU", "KAYSERİ", "KIRKLARELİ", "KIRŞEHİR", "KOCAELİ",
                "KONYA", "KÜTAHYA", "MALATYA", "MANİSA", "KAHRAMANMARAŞ", "MARDİN", "MUĞLA", "MUŞ",
                "NEVŞEHİR", "NİĞDE", "ORDU", "RİZE", "SAKARYA", "SAMSUN", "SİİRT", "SİNOP", "SİVAS",
                "TEKİRDAĞ", "TOKAT", "TRABZON", "TUNCELİ", "ŞANLIURFA", "UŞAK", "VAN", "YOZGAT", "ZONGULDAK",
                "AKSARAY", "BAYBURT", "KARAMAN", "KIRIKKALE", "BATMAN", "ŞIRNAK", "BARTIN", "ARDAHAN",
                "IĞDIR", "YALOVA", "KARABÜK", "KİLİS", "OSMANİYE", "DÜZCE"
            };
            int totalCount = 0;
            foreach(var kurumTuru in kurumTurleri)
            {
                foreach (var il in iller)
                {
                    var url = string.Format(BaseUrl, kurumTuru) + il;

                    if(kurumTuru == "okul")
                    {
                        var okulDtoList = await _scraper.ScrapeOkulAsync(url, il);
                        var entities = okulDtoList.Select(ozelOkul => new OzelOkul
                        {
                            Il = il,
                            Ilce = ozelOkul.Ilce,
                            KurumAdi = ozelOkul.KurumAdi,
                            KurumTuru = ozelOkul.KurumTuru,
                            Adres = ozelOkul.Adres,
                            Telefon = ozelOkul.Telefon,
                        }).ToList();
                        _dbContext.OzelOkullar.AddRange(entities);
                        totalCount += entities.Count();
                        await Task.Delay(500);
                    }

                    else if (kurumTuru == "mtsk")
                    {
                        var mtskDtoList = await _scraper.ScrapeOkulAsync(url, il);
                        var entities = mtskDtoList.Select(ozelOkul => new SurucuKurslari
                        {
                            Il = il,
                            Ilce = ozelOkul.Ilce,
                            KurumAdi = ozelOkul.KurumAdi,
                            KurumTuru = ozelOkul.KurumTuru,
                            Adres = ozelOkul.Adres,
                            Telefon = ozelOkul.Telefon,
                        }).ToList();
                        _dbContext.SurucuKurslari.AddRange(entities);
                        totalCount += entities.Count();
                        await Task.Delay(500);
                    }
                    else if (kurumTuru == "ozelogretim")
                    {
                        var ozelOgretimDtoList = await _scraper.ScrapeOkulAsync(url, il);
                        var entities = ozelOgretimDtoList.Select(ozelOkul => new OzelOgretimKurslari
                        {
                            Il = il,
                            Ilce = ozelOkul.Ilce,
                            KurumAdi = ozelOkul.KurumAdi,
                            KurumTuru = ozelOkul.KurumTuru,
                            Adres = ozelOkul.Adres,
                            Telefon = ozelOkul.Telefon,
                        }).ToList();
                        _dbContext.OzelOgretimKurslari.AddRange(entities);
                        totalCount += entities.Count();
                        await Task.Delay(500);
                    }
                    else if (kurumTuru == "ogrencietkinlik")
                    {
                        var ogrenciEtkinlikDtoList = await _scraper.ScrapeOkulAsync(url, il);
                        var entities = ogrenciEtkinlikDtoList.Select(ozelOkul => new OgrenciEtkinlikMerkezleri
                        {
                            Il = il,
                            Ilce = ozelOkul.Ilce,
                            KurumAdi = ozelOkul.KurumAdi,
                            KurumTuru = ozelOkul.KurumTuru,
                            Adres = ozelOkul.Adres,
                            Telefon = ozelOkul.Telefon,
                        }).ToList();
                        _dbContext.OgrenciEtkinlikMerkezleri.AddRange(entities);
                        totalCount += entities.Count();
                        await Task.Delay(500);
                    }
                    else if (kurumTuru == "yurt")
                    {
                        var yurtDtoList = await _scraper.ScrapeOkulAsync(url, il);
                        var entities = yurtDtoList.Select(ozelOkul => new OzelYurtlar
                        {
                            Il = il,
                            Ilce = ozelOkul.Ilce,
                            KurumAdi = ozelOkul.KurumAdi,
                            KurumTuru = ozelOkul.KurumTuru,
                            Adres = ozelOkul.Adres,
                            Telefon = ozelOkul.Telefon,
                        }).ToList();
                        _dbContext.OzelYurtlar.AddRange(entities);
                        totalCount += entities.Count();
                        await Task.Delay(500);
                    }
                    else if (kurumTuru == "kurs" )
                    {
                        var kursDtoList = await _scraper.ScrapeKursAsync(url, il);
                        var entities = kursDtoList.Select(kurs => new Kurs
                        {
                            Il = il,
                            Ilce = kurs.Ilce,
                            KurumAdi = kurs.KurumAdi,
                            KurumTuru = kurs.KurumTuru,
                            Adres = kurs.Adres,
                            Telefon = kurs.Telefon,
                            EgitimProgramları = kurs.EgitimProgramları
                        }).ToList();
                        _dbContext.Kurslar.AddRange(entities);
                        totalCount += entities.Count;
                        await Task.Delay(500);
                    }
                    else if (kurumTuru == "sosyaletkinlik")
                    {
                        var sosyalEtkinlikDtoList = await _scraper.ScrapeKursAsync(url, il);
                        var entities = sosyalEtkinlikDtoList.Select(kurs => new SosyalEtkinlikMerkezleri
                        {
                            Il = il,
                            Ilce = kurs.Ilce,
                            KurumAdi = kurs.KurumAdi,
                            KurumTuru = kurs.KurumTuru,
                            Adres = kurs.Adres,
                            Telefon = kurs.Telefon,
                            EgitimProgramları = kurs.EgitimProgramları
                        }).ToList();
                        _dbContext.SosyalEtkinlikMerkezleri.AddRange(entities);
                        totalCount += entities.Count;
                        await Task.Delay(500);
                    }
                    else if (kurumTuru == "rehabilitasyon")
                    {
                        var rehabDtoList = await _scraper.ScrapeKursAsync(url, il);
                        var entities = rehabDtoList.Select(kurs => new RehabilitasyonMerkezleri
                        {
                            Il = il,
                            Ilce = kurs.Ilce,
                            KurumAdi = kurs.KurumAdi,
                            KurumTuru = kurs.KurumTuru,
                            Adres = kurs.Adres,
                            Telefon = kurs.Telefon,
                            EgitimProgramları = kurs.EgitimProgramları
                        }).ToList();
                        _dbContext.RehabilitasyonMerkezleri.AddRange(entities);
                        totalCount += entities.Count;
                        await Task.Delay(500);
                    }
                    else if (kurumTuru == "sosyaletkinlikgelisim")
                    {
                        var sosyalEtkDtoList = await _scraper.ScrapeKursAsync(url, il);
                        var entities = sosyalEtkDtoList.Select(kurs => new SosyalEtkinlikGelisimMerkezleri
                        {
                            Il = il,
                            Ilce = kurs.Ilce,
                            KurumAdi = kurs.KurumAdi,
                            KurumTuru = kurs.KurumTuru,
                            Adres = kurs.Adres,
                            Telefon = kurs.Telefon,
                            EgitimProgramları = kurs.EgitimProgramları
                        }).ToList();
                        _dbContext.SosyalEtkinlikGelisimMerkezleri.AddRange(entities);
                        totalCount += entities.Count;
                        await Task.Delay(500);
                    }
                }
            }

            await _dbContext.SaveChangesAsync();
            return totalCount;


        }
    }
}