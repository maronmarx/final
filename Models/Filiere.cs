using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Filiere", Schema = "HR")]
    public class Filiere
    {

        [Key]
        [Display(Name = "id filier")]
        public int id_filier { get; set; }
        [Required]
        [Display(Name = "nom filier")]
        [Column(TypeName = "varchar(200)")]
        public string? nom_Filier { get; set; }
    }
}
