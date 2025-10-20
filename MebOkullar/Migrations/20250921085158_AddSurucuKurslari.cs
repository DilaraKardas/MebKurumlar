using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MebOkullar.Migrations
{
    /// <inheritdoc />
    public partial class AddSurucuKurslari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciEtkinlikMerkezleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Il = table.Column<string>(type: "text", nullable: true),
                    Ilce = table.Column<string>(type: "text", nullable: true),
                    KurumAdi = table.Column<string>(type: "text", nullable: true),
                    KurumTuru = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciEtkinlikMerkezleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OzelOgretimKurslari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Il = table.Column<string>(type: "text", nullable: true),
                    Ilce = table.Column<string>(type: "text", nullable: true),
                    KurumAdi = table.Column<string>(type: "text", nullable: true),
                    KurumTuru = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzelOgretimKurslari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OzelYurtlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Il = table.Column<string>(type: "text", nullable: true),
                    Ilce = table.Column<string>(type: "text", nullable: true),
                    KurumAdi = table.Column<string>(type: "text", nullable: true),
                    KurumTuru = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzelYurtlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RehabilitasyonMerkezleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Il = table.Column<string>(type: "text", nullable: true),
                    Ilce = table.Column<string>(type: "text", nullable: true),
                    KurumAdi = table.Column<string>(type: "text", nullable: true),
                    KurumTuru = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    EgitimProgramları = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehabilitasyonMerkezleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SosyalEtkinlikGelisimMerkezleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Il = table.Column<string>(type: "text", nullable: true),
                    Ilce = table.Column<string>(type: "text", nullable: true),
                    KurumAdi = table.Column<string>(type: "text", nullable: true),
                    KurumTuru = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    EgitimProgramları = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalEtkinlikGelisimMerkezleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SosyalEtkinlikMerkezleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Il = table.Column<string>(type: "text", nullable: true),
                    Ilce = table.Column<string>(type: "text", nullable: true),
                    KurumAdi = table.Column<string>(type: "text", nullable: true),
                    KurumTuru = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    EgitimProgramları = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalEtkinlikMerkezleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurucuKurslari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Il = table.Column<string>(type: "text", nullable: true),
                    Ilce = table.Column<string>(type: "text", nullable: true),
                    KurumAdi = table.Column<string>(type: "text", nullable: true),
                    KurumTuru = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurucuKurslari", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciEtkinlikMerkezleri");

            migrationBuilder.DropTable(
                name: "OzelOgretimKurslari");

            migrationBuilder.DropTable(
                name: "OzelYurtlar");

            migrationBuilder.DropTable(
                name: "RehabilitasyonMerkezleri");

            migrationBuilder.DropTable(
                name: "SosyalEtkinlikGelisimMerkezleri");

            migrationBuilder.DropTable(
                name: "SosyalEtkinlikMerkezleri");

            migrationBuilder.DropTable(
                name: "SurucuKurslari");
        }
    }
}
