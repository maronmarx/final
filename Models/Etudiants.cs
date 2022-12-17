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
        public int? etudiantId { get; set; }     
        [Required]
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string niveau { get; set; } = String.Empty;
        public string? Filier { get; set; }
       
        public int? id_ville { get; set; }
        [ForeignKey("id_ville")]
        public Ville? Ville { get; set; }

    }
}
