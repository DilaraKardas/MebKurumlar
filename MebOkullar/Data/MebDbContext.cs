using MebOkullar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
namespace MebOkullar.Data
{
    public class MebDbContext : DbContext
    {
        public MebDbContext(DbContextOptions<MebDbContext> options) : base(options) { }

        public DbSet<Okul> Okullar { get; set; } //devlet okulu
        public DbSet<OzelOkul> OzelOkullar { get; set; } //özel okul tablosu
        public DbSet<SurucuKurslari> SurucuKurslari { get; set; }
        public DbSet<OzelOgretimKurslari> OzelOgretimKurslari { get; set; }
        public DbSet<OgrenciEtkinlikMerkezleri> OgrenciEtkinlikMerkezleri { get; set; }
        public DbSet<OzelYurtlar> OzelYurtlar { get; set; }
        public DbSet<Kurs> Kurslar { get; set; } //kurs tablosu
        public DbSet<SosyalEtkinlikMerkezleri> SosyalEtkinlikMerkezleri { get; set; }
        public DbSet<RehabilitasyonMerkezleri> RehabilitasyonMerkezleri { get; set; }
        public DbSet<SosyalEtkinlikGelisimMerkezleri> SosyalEtkinlikGelisimMerkezleri { get; set; }
    }
}
