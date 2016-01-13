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
    public class AfericoesGlicemiaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AfericoesGlicemia
        public ActionResult Index()
        {
            var afericoesGlicemia = db.AfericoesGlicemia.Include(a => a.Cliente);
            return View(afericoesGlicemia.ToList());
        }

        // GET: AfericoesGlicemia/ByCliente/5
        public ActionResult ByCliente(int id)
        {
            ViewBag.Cliente = id;
            var afericaoGlicemia = db.AfericoesGlicemia.Where(g => g.ClienteId == id);
            return View(afericaoGlicemia);
        }

        // GET: AfericoesGlicemia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfericaoGlicemia afericaoGlicemia = db.AfericoesGlicemia.Find(id);
            if (afericaoGlicemia == null)
            {
                return HttpNotFound();
            }
            return View(afericaoGlicemia);
        }

        // GET: AfericoesGlicemia/Create
        public ActionResult Create(int id)
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome",id);
            return View();
        }

        // POST: AfericoesGlicemia/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataHoraAfericao,Valor,Jejum,ClienteId")] AfericaoGlicemia afericaoGlicemia)
        {
            if (ModelState.IsValid)
            {
                db.AfericoesGlicemia.Add(afericaoGlicemia);
                db.SaveChanges();
                return RedirectToAction("ByCliente", new { id = afericaoGlicemia.ClienteId });
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", afericaoGlicemia.ClienteId);
            return View(afericaoGlicemia);
        }

        // GET: AfericoesGlicemia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfericaoGlicemia afericaoGlicemia = db.AfericoesGlicemia.Find(id);
            if (afericaoGlicemia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", afericaoGlicemia.ClienteId);
            return View(afericaoGlicemia);
        }

        // POST: AfericoesGlicemia/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataHoraAfericao,Valor,Jejum,ClienteId")] AfericaoGlicemia afericaoGlicemia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afericaoGlicemia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ByCliente", new { id = afericaoGlicemia.ClienteId });
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", afericaoGlicemia.ClienteId);
            return View(afericaoGlicemia);
        }

        // GET: AfericoesGlicemia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfericaoGlicemia afericaoGlicemia = db.AfericoesGlicemia.Find(id);
            if (afericaoGlicemia == null)
            {
                return HttpNotFound();
            }
            return View(afericaoGlicemia);
        }

        // POST: AfericoesGlicemia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AfericaoGlicemia afericaoGlicemia = db.AfericoesGlicemia.Find(id);
            db.AfericoesGlicemia.Remove(afericaoGlicemia);
            db.SaveChanges();
            return RedirectToAction("ByCliente", new { id = afericaoGlicemia.ClienteId });
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
