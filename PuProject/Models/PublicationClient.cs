using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TServices.Models;

namespace PuProject.Models
{
    public class PublicationClient
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int DebutBudget { get; set; }
        public int FinDebut { get; set; }
        public virtual Categorie Categorie { get; set; }
        public virtual Gouvernorat Gouvernerat{ get; set; }
        public virtual Ville Ville { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
    }
}