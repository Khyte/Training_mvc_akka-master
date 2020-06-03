using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingMVC.DATA;

namespace TrainingMVC.Controllers
{
    public class FormationsController : Controller
    {
        private AvisFormationsEntities db = new AvisFormationsEntities();

        // GET: Formations
        public ActionResult Index()
        {
            return View(db.Formation.ToList());
        }

        // GET: Formations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formation.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // GET: Formations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formations/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Url,Description,NomSeo")] Formation formation)
        {
            if (ModelState.IsValid)
            {
                db.Formation.Add(formation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formation);
        }

        // GET: Formations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formation.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: Formations/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Url,Description,NomSeo")] Formation formation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formation);
        }

        // GET: Formations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formation.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: Formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formation formation = db.Formation.Find(id);
            db.Formation.Remove(formation);
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
