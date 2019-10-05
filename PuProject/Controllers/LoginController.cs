using PuProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TServices.Models;

namespace PuProject.Controllers
{
    public class LoginController : Controller
    {
        TServicesContext db = new TServicesContext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Fournisseur a, string fileTitle)
        {
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                byte[] imageSize = new byte[file.ContentLength];
                file.InputStream.Read(imageSize, 0, (int)file.ContentLength);
              
                a.Photo = file.FileName.Split('\\').Last().Substring(0, file.FileName.Split('\\').Last().Length-4);
                if (ModelState.IsValid)
                {
                    
                        db.Fournisseurs.Add(a);
                        db.SaveChanges();
                    
                    ModelState.Clear();
                    ViewBag.Message = "Registred !";
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("uploadError", e);
            }


            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Fournisseur user)
        {
            
                var usr = db.Fournisseurs.Where(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password)).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserId"] = usr.ID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
               
                    var tmp = Int64.Parse(Session["UserId"].ToString());
                    var usr = db.Fournisseurs.Where(u => u.ID == tmp).FirstOrDefault();
                    return View(usr);
                

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            {
                var usr = db.Fournisseurs.Find(id);
                var c = new CatFour4();
                c.ID = usr.ID;
                c.cat2 = db.Categories;
                if (usr == null)
                {
                    return HttpNotFound();
                }
                return View(c);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Id_Categorie,Adresse,Description,Gouvernorat,Ville")] CatFour4 user)
        {
            if (ModelState.IsValid)
            {
                
                    var n = db.Fournisseurs.Find(user.ID);
                    n.ProposeService = true;
                    n.Id_Categorie = user.Id_Categorie;
                    n.Gouvernorat = user.Gouvernorat;
                    n.Ville = user.Ville;
                    n.Adresse = user.Adresse;
                    string address = user.Adresse;
                    string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));
                    Console.WriteLine(requestUri);
                    WebRequest request = WebRequest.Create(requestUri);
                    WebResponse response = request.GetResponse();
                    XDocument xdoc = XDocument.Load(response.GetResponseStream());

                    XElement res = xdoc.Element("GeocodeResponse").Element("result");
                    XElement locationElement = res.Element("geometry");
                    XElement test = locationElement.Element("location");
                    String lat = test.Element("lat").Value;
                    String lng = test.Element("lng").Value;
                    n.Lat = Double.Parse(lat.Replace('.', ','));
                    n.Lon = Double.Parse(lng.Replace('.', ','));

                    n.Description = user.Description;
                    db.SaveChanges();
            
                return RedirectToAction("LoggedIn");
             }
            return View();

        }

    }
}