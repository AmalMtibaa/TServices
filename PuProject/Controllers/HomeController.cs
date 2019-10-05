using PuProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TServices.Models;

namespace TServices.Controllers
{
    public class HomeController : Controller
    {
        private TServicesContext db = new TServicesContext();
        public ActionResult Index()
        {
            var categories = from m in db.Categories
                             select m;

            return View(categories);
        }


        public ActionResult Recherche(String Categorie, String Gouvernorat, String Ville)
        {
            
            var categories = from m in db.Categories
                             select m;
            var result=new List<Fournisseur>();
            if (!String.IsNullOrEmpty(Categorie) && !String.IsNullOrEmpty(Ville) && !String.IsNullOrEmpty(Gouvernorat) )
            {
                categories = db.Categories.Where(s => s.Nom.Contains(Categorie));
                foreach ( var item in db.Fournisseurs)
                {
                    foreach (var item2 in categories)
                    {
                        if (item2.Nom.ToString().Equals(item.Id_Categorie) && item.Ville.Equals(Ville) && item.Gouvernorat.Equals(Gouvernorat))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            var model = new CatFour2();
            model.cat = categories;
            model.four = result;
            model.cat2 = db.Categories;
            model.four2 = db.Fournisseurs;
            model.Gouvernerat = db.Gouvernorats;
            model.Ville = db.Villes;
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Fournisseur = db.Fournisseurs.Find(id);
            if (Fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(Fournisseur);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FiltrerParCategorie(string C)
        {
           
            var fournisseurs = from m in db.Fournisseurs
                               where m.Id_Categorie.Equals(C) 
                               select m;
            return View(fournisseurs.OrderByDescending(x => x.Rate).ToList());
        }

        public ActionResult Accueil()
        {
            return View();
        }
    }
}