using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprojet.Shared.Entites
{
    public class Clients
    {
        public int Id { get; set; }
        public string RaisonSociale { get; set; }
        public string Description { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string TelephoneSecreteriat { get; set; }
        public string? ImageUrl { get; set; }

        
        public List<Contact>? Contacts { get; set; }
    }
}
