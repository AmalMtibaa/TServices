using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TServices.Models;

namespace PuProject.Models
{
    public class CatFour4
    {
        public IEnumerable<Categorie> cat2 { get; set; }
        public int ID { get; set; }
        public string Gouvernorat { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
        public string Description { get; set; }
        public string Id_Categorie { get; set; }
    }
}