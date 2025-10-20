using HtmlAgilityPack;
using MebOkullar.DtoModel;


namespace MebOkullar.Scrapper
{
    public class GenericScaper
    {
        private readonly HttpClient _http;
        public GenericScaper(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<OzelOkulDto>> ScrapeOkulAsync(string url, string il)
        {
            var html = await _http.GetAsync(url);
            var doc = new HtmlDocument();
            var content = await html.Content.ReadAsStringAsync();


            doc.LoadHtml(content);

            var okulListesi = new List<OzelOkulDto>();
            var table = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'table-striped')]");
            var headerCells = table.SelectNodes(".//thead/tr/th");

            if (table == null) return okulListesi;
            var columnIndexes = headerCells
                .Select((h, i) => new {
                    Name = h.InnerText.Trim().Split(new string[] { "Tüm türler" }, StringSplitOptions.None)[0],
                    Index = i})
                .Where(x => !string.IsNullOrWhiteSpace(x.Name))
                .ToDictionary(x => x.Name, x => x.Index, StringComparer.OrdinalIgnoreCase);

            var rows = table.SelectNodes("tbody/tr");

            if (rows == null) return okulListesi;

            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");
                if (cells == null) continue; 

                string ilce = cells[columnIndexes["İlçe"]].InnerText.Trim();
                string kurumAdi = cells[columnIndexes["Kurum Adı"]].InnerText.Trim();
                string kurumTuru = columnIndexes.ContainsKey("Kurum Türü")? cells[columnIndexes["Kurum Türü"]].InnerText.Trim() : string.Empty;
                string? adres = cells[columnIndexes["Adres"]]
                    .SelectSingleNode(".//p[@class='adr']")?
                    .InnerText?.Trim();
                string? telefon = cells[columnIndexes["Telefon"]]
                    .SelectSingleNode(".//a[@class='tlf']")?
                    .InnerText?.Trim();

                okulListesi.Add(new OzelOkulDto
                {
                    Il = il,
                    Ilce = ilce,
                    KurumAdi = kurumAdi,
                    KurumTuru = kurumTuru,
                    Adres = adres,
                    Telefon = telefon
                });
            }
            return okulListesi;
        }
        public async Task<List<KursDto>> ScrapeKursAsync(string url, string il)
        {

            var html = await _http.GetAsync(url);
            var doc = new HtmlDocument();
            var content = await html.Content.ReadAsStringAsync();
            doc.LoadHtml(content);

            var kursListesi = new List<KursDto>();
            var table = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'table-striped')]");
            var headerCells = table.SelectNodes(".//thead/tr/th");

            if (table == null) return kursListesi;

            var columnIndexes = headerCells
                .Select((h, i) => new {
                    Name = h.InnerText.Trim().Split(new string[] { "Tüm türler" }, StringSplitOptions.None)[0],
                    Index = i
                })
                .Where(x => !string.IsNullOrWhiteSpace(x.Name))
                .ToDictionary(x => x.Name, x => x.Index, StringComparer.OrdinalIgnoreCase);

            var rows = table.SelectNodes("tbody/tr");
            if (rows == null) return kursListesi;
            
            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");
                if (cells == null)  continue;

                string ilce = cells[columnIndexes["İlçe"]].InnerText.Trim();
                string kurumAdi = cells[columnIndexes["Kurum Adı"]].InnerText.Trim();
                string kurumTuru = columnIndexes.ContainsKey("Kurum Türü") ? cells[columnIndexes["Kurum Türü"]].InnerText.Trim() : string.Empty;
                string? adres = cells[columnIndexes["Adres"]]
                    .SelectSingleNode(".//p[@class='adr']")?
                    .InnerText?.Trim();
                string? telefon = cells[columnIndexes["Telefon"]]
                    .SelectSingleNode(".//a[@class='tlf']")?
                    .InnerText?.Trim();
                string? egitimProgramları = cells[columnIndexes["Eğitim Programları"]]
                    .SelectSingleNode(".//p[@class='prg bi bi-three-dots']")?
                    .InnerText?.Trim();

                kursListesi.Add(new KursDto
                {
                    Il = il,
                    Ilce = ilce,
                    KurumAdi = kurumAdi,
                    KurumTuru = kurumTuru,
                    Adres = adres,
                    Telefon = telefon,
                    EgitimProgramları = egitimProgramları
                });
            }
            return kursListesi;
        }
    }
}
