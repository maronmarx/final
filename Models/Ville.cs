using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Ville", Schema = "HR")]
    public class Ville
    {
        [Key]
        public int id_ville { get; set; }
        public string? nom_ville { get; set; } = String.Empty;
    }
}
