using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TServices.Models
{
    public class Fournisseur
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Gouvernorat { get; set; }
        public string Ville { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string Adresse { get; set; }
        public int? Telephone { get; set; }
        public string Description { get; set; }
        public string Id_Categorie { get; set; }
        public string Photo { get; set; }
        public int? Rate { get; set; }
        public Boolean ProposeService { get; set; }
        public String UserName { get; set; }

        [DataType(DataType.Password)]
        public String Password { get; set; }

    }


}