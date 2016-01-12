using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiUbs.WebApp.Models;

namespace SiUbs.WebApp.Controllers
{
    [Authorize]
    public class AfericoesPressaoArterialController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AfericoesPressaoArterial
        public ActionResult Index()
        {
            var afericoesPressaoArterial = db.AfericoesPressaoArterial.Include(a => a.Cliente);
            return View(afericoesPressaoArterial.ToList());
        }

        // GET: AfericoesPressaoArterial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfericaoPressaoArterial afericaoPressaoArterial = db.AfericoesPressaoArterial.Find(id);
            if (afericaoPressaoArterial == null)
            {
                return HttpNotFound();
            }
            return View(afericaoPressaoArterial);
        }

        // GET: AfericoesPressaoArterial/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            return View();
        }

        // POST: AfericoesPressaoArterial/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataHoraAfericao,Sistolica,Diastolica,ClienteId")] AfericaoPressaoArterial afericaoPressaoArterial)
        {
            if (ModelState.IsValid)
            {
                db.AfericoesPressaoArterial.Add(afericaoPressaoArterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", afericaoPressaoArterial.ClienteId);
            return View(afericaoPressaoArterial);
        }

        // GET: AfericoesPressaoArterial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfericaoPressaoArterial afericaoPressaoArterial = db.AfericoesPressaoArterial.Find(id);
            if (afericaoPressaoArterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", afericaoPressaoArterial.ClienteId);
            return View(afericaoPressaoArterial);
        }

        // POST: AfericoesPressaoArterial/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataHoraAfericao,Sistolica,Diastolica,ClienteId")] AfericaoPressaoArterial afericaoPressaoArterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afericaoPressaoArterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", afericaoPressaoArterial.ClienteId);
            return View(afericaoPressaoArterial);
        }

        // GET: AfericoesPressaoArterial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfericaoPressaoArterial afericaoPressaoArterial = db.AfericoesPressaoArterial.Find(id);
            if (afericaoPressaoArterial == null)
            {
                return HttpNotFound();
            }
            return View(afericaoPressaoArterial);
        }

        // POST: AfericoesPressaoArterial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AfericaoPressaoArterial afericaoPressaoArterial = db.AfericoesPressaoArterial.Find(id);
            db.AfericoesPressaoArterial.Remove(afericaoPressaoArterial);
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
