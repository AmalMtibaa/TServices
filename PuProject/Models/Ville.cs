using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PuProject.Models
{
    public class Ville
    {
        public int ID { get; set; }
        public String Nom { get; set; }
        public int Id_Gouvernat { get; set; }
        
    }

   
}