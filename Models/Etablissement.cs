using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Etablissement", Schema = "HR")]
    public class Etablissement
    {
        [Key]
        public int etabId { get; set; }
        [Required]
        public string nom { get; set; } = String.Empty;
        public string Description { get; set; }
        public string? Image { get; set; }
       [ForeignKey("id_formation")]
        public int? id_formation { get; set; }
        public Formation? Formation { get; set; }
        public string? nom_Filier { get; set; }
        public string nom_ville { get; set; }
        

    }
}
