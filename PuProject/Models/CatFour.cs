using PuProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TServices.Models;

namespace TServices.Models
{
    public class CatFour
    {
        public IEnumerable<Fournisseur> four{get; set;}
        public IEnumerable<Categorie> cat { get; set; }
        public IEnumerable<Gouvernorat> Gouvernerat{ get; set; }
        public IEnumerable<Ville> Ville { get; set; }

        public IEnumerable<Commentaire> Commentaires { get; set; }
        public IEnumerable<PublicationClient> PubicationClients { get; set; }

    }
}