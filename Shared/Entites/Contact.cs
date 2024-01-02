using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprojet.Shared.Entites
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name ="Nom")]
        public string Nom { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name ="Prenom")]
        public string Prenom { get; set; }
        [Required]
        [Display(Name ="Telephone")]
        public string Telephone { get; set; }
        [Required]
        [Display(Name ="Email")]
        public string? Email { get; set; }

        public Clients? Client { get; set; }
    }
}
