using AvisFormation.DATA;
using AvisFormation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.Controllers
{
    public class HomeController : Controller
    {
        private AvisFormationEntities db = new AvisFormationEntities();
        public ActionResult Index()
        {

            var formationsAvisList = new List<FormationAvisDto>();
            var formations = db.Formation
                                        .OrderBy(_ => Guid.NewGuid())
                                        .Take(4)
                                        .ToList();
            foreach (var item in formations)
            {
                var dto = new FormationAvisDto();
                dto.Formation = item;
                dto.Note = (item.Avis.Count == 0 ) ? 0 : item.Avis.Average(a => a.Note);
				formationsAvisList.Add(dto);
            }

            return View(formationsAvisList);
        }

        public ActionResult Formation()
        {
			var formationsAvisList = new List<FormationAvisDto>();
			var formations = db.Formation.ToList();

			foreach (var item in formations)
			{
				var dto = new FormationAvisDto();
				dto.Formation = item;
				dto.Note = (item.Avis.Count == 0) ? 0 : item.Avis.Average(a => a.Note);
				formationsAvisList.Add(dto);
			}

			return View(formationsAvisList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

		public ActionResult Panier()
		{
			ViewBag.Message = "Your basket is empty!";

			return View();
		}

		public ActionResult Langue()
		{
			ViewBag.Message = "Your language page.";

			return null;
		}
	}
}