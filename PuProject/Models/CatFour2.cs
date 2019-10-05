using PuProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TServices.Models;

namespace TServices.Models
{
    public class CatFour2
    {
        public IEnumerable<Fournisseur> four { get; set; }
        public IEnumerable<Categorie> cat { get; set; }
        public IEnumerable<Fournisseur> four2 { get; set; }
        public IEnumerable<Categorie> cat2 { get; set; }
        public IEnumerable<Gouvernorat> Gouvernerat { get; set; }
        public IEnumerable<Ville> Ville { get; set; }
    }
}