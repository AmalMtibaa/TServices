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
    public class GouvernoratsController : Controller
    {
        private TServicesContext db = new TServicesContext();

        // GET: Gouvernerats
        public ActionResult Index()
        {
            return View(db.Gouvernorats.ToList());
        }

        // GET: Gouvernerats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gouvernorat gouvernerat = db.Gouvernorats.Find(id);
            if (gouvernerat == null)
            {
                return HttpNotFound();
            }
            return View(gouvernerat);
        }

        // GET: Gouvernerats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gouvernerats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom")] Gouvernorat gouvernerat)
        {
            if (ModelState.IsValid)
            {
                db.Gouvernorats.Add(gouvernerat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gouvernerat);
        }

        // GET: Gouvernerats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gouvernorat gouvernerat = db.Gouvernorats.Find(id);
            if (gouvernerat == null)
            {
                return HttpNotFound();
            }
            return View(gouvernerat);
        }

        // POST: Gouvernerats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom")] Gouvernorat gouvernerat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gouvernerat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gouvernerat);
        }

        // GET: Gouvernerats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gouvernorat gouvernerat = db.Gouvernorats.Find(id);
            if (gouvernerat == null)
            {
                return HttpNotFound();
            }
            return View(gouvernerat);
        }

        // POST: Gouvernerats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gouvernorat gouvernerat = db.Gouvernorats.Find(id);
            db.Gouvernorats.Remove(gouvernerat);
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
    }
}
