using MebOkullar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MebOkullar.Models
{
    public class Okul
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //primary key
        public string? OKUL_ADI {  get; set; }
        public string? HOST {  get; set; }
        public string? YOL { get; set; }
    }
}
