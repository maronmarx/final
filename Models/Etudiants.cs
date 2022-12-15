using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Etudiants", Schema = "HR")]
    public class Etudiants 
    {
        [Key]
        [Display(Name = "ID etud")]
        public int? etudiantId { get; set; }     
        [Required]
        [Display(Name = "niveau")]
        [Column(TypeName = "varchar(200)")]
        public string niveau { get; set; } = String.Empty;

        public int? id_filier { get; set; }
        [ForeignKey("id_filier")]
        public Filiere? filiere { get; set; }
        public int? id_ville { get; set; }
        [ForeignKey("id_ville")]
        public Ville? ville { get; set; }

    }
}
