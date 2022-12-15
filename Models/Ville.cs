using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Ville", Schema = "HR")]
    public class Ville
    {
        
        [Key]
        [Display(Name = "id ville")]
        public int id_ville { get; set; }
        [Display(Name = "nom")]
        [Column(TypeName = "varchar(200)")]
        public string? nom_ville { get; set; } = String.Empty;
    }
}
