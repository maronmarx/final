using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Formation", Schema = "HR")]
    public class Formation
    {

        [Key]
        [Display(Name = "formation ID")]
        public int id_formation { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? nom_FormationId { get; set; }
        [Display(Name = "description_formation")]
        public string desc_frmt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date_debut { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date_fin { get; set; } 
        
    }
}
