using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OperasWebSite.Models;

namespace OperasWebSite.Controllers
{
    public class OperaController : Controller
    {
        private OperasDB _contextDb = new OperasDB();

        // GET: Opera
        public ActionResult Index()
        {
            return View("Index", _contextDb.Operas.ToList());
        }

        public ActionResult Details(int id)
        {
            Opera opera = _contextDb.Operas.Find(id);
            /*
            Opera opera = (from p in _contextDb.Operas
                           where p.OperaID == id
                           select p).FirstOrDefault();
                           */

            if( opera != null )
            {
                return View("Details", opera);
            }

            return HttpNotFound();
        }

        public ActionResult Create()
        {
            Opera newOpera = new Opera();

            return View("Create", newOpera);
        }

        [HttpPost]
        public ActionResult Create(Opera newOpera)
        {
            if(ModelState.IsValid)
            {
                _contextDb.Operas.Add(newOpera);
                _contextDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", newOpera);


        }
    }
}