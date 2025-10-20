using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MebOkullar.Models
{
    public class Kurs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //primary key
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? KurumAdi { get; set; }
        public string? KurumTuru { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public string? EgitimProgramları { get; set; }
    }
}
