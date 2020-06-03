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
    public class AvisController : Controller
    {
        private AvisFormationsEntities db = new AvisFormationsEntities();

        // GET: Avis
        public ActionResult Index()
        {
            var avis = db.Avis.Include(a => a.Formation);
            return View(avis.ToList());
        }

        // GET: Avis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avis avis = db.Avis.Find(id);
            if (avis == null)
            {
                return HttpNotFound();
            }
            return View(avis);
        }

        // GET: Avis/Create
        public ActionResult Create()
        {
            ViewBag.IdFormation = new SelectList(db.Formation, "Id", "Nom");
            return View();
        }

        // POST: Avis/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Description,Note,IdFormation,DateAvis,UserId")] Avis avis)
        {
            if (ModelState.IsValid)
            {
                db.Avis.Add(avis);
                db.SaveChanges();
                return RedirectToAction("details", "formation", new { id = avis.IdFormation });
            }

            ViewBag.IdFormation = new SelectList(db.Formation, "Id", "Nom", avis.IdFormation);
            return View(avis);
        }

        // GET: Avis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avis avis = db.Avis.Find(id);
            if (avis == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFormation = new SelectList(db.Formation, "Id", "Nom", avis.IdFormation);
            return View(avis);
        }

        // POST: Avis/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Description,Note,IdFormation,DateAvis,UserId")] Avis avis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFormation = new SelectList(db.Formation, "Id", "Nom", avis.IdFormation);
            return View(avis);
        }

        // GET: Avis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avis avis = db.Avis.Find(id);
            if (avis == null)
            {
                return HttpNotFound();
            }
            return View(avis);
        }

        // POST: Avis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avis avis = db.Avis.Find(id);
            db.Avis.Remove(avis);
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
