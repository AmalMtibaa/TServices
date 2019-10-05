using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TServices.Models;

namespace PuProject.Models
{
    public class Commentaire
    {
        public int ID { get; set; }
        public virtual  Fournisseur Fournisseur  { get; set; }
        public virtual PublicationClient PublicationClient { get; set; }
        public string contenu { get; set; }
    }
}