using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TServices.Models;

namespace PuProject.Models
{
    public class CatFour3
    {
        public IEnumerable<Categorie> cat2 { get; set; }
        public IEnumerable<Gouvernorat> Gouvernerat { get; set; }
        public IEnumerable<Ville> Ville { get; set; }

        public string Description { get; set; }
        public int DebutBudget { get; set; }
        public int FinDebut { get; set; }

    }
}