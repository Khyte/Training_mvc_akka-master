using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingMVC.DATA;

namespace TrainingMVC.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class FormationController : Controller
    {
        private AvisFormationsEntities db = new AvisFormationsEntities();
        // GET: Formation

        public ActionResult Index()
        {
            var formations = db.Formation.ToList();
            ViewBag.formationName = "";
            return View(formations);
        }

        [HttpPost]
        public ActionResult Index(String formationName)
        {
            ViewBag.formationName = formationName;

            var formations = (formationName.Length > 0)
                ? db.Formation.Where(x => x.Nom.ToLower().Contains(formationName.ToLower())).ToList()
                : db.Formation.ToList();
                

            return View(formations);
        }


        // GET: Formation/Details/5
        public ActionResult Details(string nomSeo)
        {
            if (String.IsNullOrWhiteSpace(nomSeo))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);    


            //var selectedFormation = db.Formation.Find(id);
            var selectedFormation = db.Formation.Where(x => x.NomSeo.ToLower().Equals(nomSeo.ToLower())).FirstOrDefault();

            if (selectedFormation == null)
                return HttpNotFound();


            return View(selectedFormation);
        }

        // GET: Formation/Create
        public ActionResult Create()
        {
            var newFormation = new Formation();
            return View(newFormation);
        }

        // POST: Formation/Create
        [HttpPost]
        public ActionResult Create(Formation newFormation)
        {
            try
            {
                if (ModelState.IsValid) { 

                    db.Formation.Add(newFormation);
                    db.SaveChanges();
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                
                }

                return View(newFormation);

            }
            catch
            {
                return View(newFormation);
            }
        }

        // GET: Formation/Edit/5
        public ActionResult Edit(int id)
        {
            if (id.Equals(0))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            //var selectedFormation = db.Formation.Find(id);
            var selectedFormation = db.Formation.Where(x => x.Id == id).FirstOrDefault();

            if (selectedFormation == null)
                return HttpNotFound();


            return View("editformation", selectedFormation);
        }

        // POST: Formation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Formation selectedFormation)
        {
            try
            {
                db.Entry(selectedFormation).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Formation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Formation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
