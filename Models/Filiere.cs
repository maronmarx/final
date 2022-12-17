using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalOr.Models
{
    [Table("Filiere", Schema = "HR")]
    public class Filiere
    {
        [Key]
        public int id { get; set; }
        public string nom_Filier { get; set; }
    }
}
