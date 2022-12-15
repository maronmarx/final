using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Etablissement", Schema = "HR")]
    public class Etablissement
    {
        [Key]
        [Display(Name = "ID")]
        public int? etabId { get; set; }
        [Required]
        [Display(Name = "nom_etablissement")]
        [Column(TypeName = "varchar(200)")]
        public string nom { get; set; } = String.Empty;
        [Display(Name = "description_etablissement")]
        public string Description { get; set; }
        [Display(Name = "Image_etablissement")]
        public string? Image { get; set; }

        public int? id_formation { get; set; }
        [ForeignKey("id_formation")]
        public Formation? formation { get; set; }

        public int? id_filier { get; set; }
        [ForeignKey("id filier")]
        public Filiere? filiere { get; set; }
        [Display(Name = "niveau")]
        public string niveau  { get; set; }

        public int? id_ville { get; set; }
        [ForeignKey("id_ville")]
        public Ville? ville { get; set; }

    }
}
