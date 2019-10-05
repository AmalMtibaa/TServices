using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PuProject.Models;
using TServices.Models;

namespace PuProject.Controllers
{
    public class PublicationClientsController : Controller
    {
        private TServicesContext db = new TServicesContext();

        // GET: PublicationClients
        public ActionResult Index()
        {
            var tmp = new CatFour();
            tmp.Commentaires = db.Commentaires;
            tmp.PubicationClients =db.PublicationClients;
            return View(tmp);
        }

        // GET: PublicationClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationClient publicationClient = db.PublicationClients.Find(id);
            if (publicationClient == null)
            {
                return HttpNotFound();
            }
            return View(publicationClient);
        }

        // GET: PublicationClients/Create
        public ActionResult Create()
        {
            var tmp = new CatFour3();
            tmp.Gouvernerat = db.Gouvernorats;
            tmp.Ville = db.Villes;
            tmp.cat2 = db.Categories;
            
            return View(tmp);
        }

        // POST: PublicationClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,DebutBudget,FinDebut")] PublicationClient pub,
            String Categorie, String Gouvernorat, String Ville)
        {
            if (ModelState.IsValid)
            {
                var publicationClient = new PublicationClient();
                publicationClient.Description = pub.Description;
                publicationClient.DebutBudget = pub.DebutBudget;
                publicationClient.FinDebut = pub.FinDebut;
                publicationClient.Categorie = db.Categories.Where(s => s.Nom.Contains(Categorie)).FirstOrDefault();
                publicationClient.Gouvernerat = db.Gouvernorats.Where(s => s.Nom.Contains(Gouvernorat)).FirstOrDefault();
                publicationClient.Ville = db.Villes.Where(s => s.Nom.Contains(Ville)).FirstOrDefault();
                publicationClient.Fournisseur = db.Fournisseurs.Find(Int32.Parse((String)Session["UserId"]));
                db.PublicationClients.Add(publicationClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: PublicationClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationClient publicationClient = db.PublicationClients.Find(id);
            if (publicationClient == null)
            {
                return HttpNotFound();
            }
            return View(publicationClient);
        }

        // POST: PublicationClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,DebutBudget,FinDebut")] PublicationClient publicationClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicationClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicationClient);
        }

        // GET: PublicationClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationClient publicationClient = db.PublicationClients.Find(id);
            if (publicationClient == null)
            {
                return HttpNotFound();
            }
            return View(publicationClient);
        }

        // POST: PublicationClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicationClient publicationClient = db.PublicationClients.Find(id);
            db.PublicationClients.Remove(publicationClient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult MesPublication()
        {
            var model = new CatFour();
            var tmp = Int64.Parse((String)Session["UserId"]);
            model.PubicationClients = db.PublicationClients.Where(u => u.Fournisseur.ID == tmp);
            model.Commentaires = db.Commentaires;
            return View("Index", model);
        }
    }
}
