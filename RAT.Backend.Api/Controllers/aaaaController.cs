using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace RAT.Backend.Api.Controllers
{
    public class aaaaController : Controller
    {
        private SqlDbContext db = new SqlDbContext();

        // GET: /aaaa/
        public ActionResult Index()
        {
            return View(db.DM_Categories.ToList());
        }

        // GET: /aaaa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_Categories dm_categories = db.DM_Categories.Find(id);
            if (dm_categories == null)
            {
                return HttpNotFound();
            }
            return View(dm_categories);
        }

        // GET: /aaaa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /aaaa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Note")] DM_Categories dm_categories)
        {
            if (ModelState.IsValid)
            {
                db.DM_Categories.Add(dm_categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dm_categories);
        }

        // GET: /aaaa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_Categories dm_categories = db.DM_Categories.Find(id);
            if (dm_categories == null)
            {
                return HttpNotFound();
            }
            return View(dm_categories);
        }

        // POST: /aaaa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Note")] DM_Categories dm_categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dm_categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dm_categories);
        }

        // GET: /aaaa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_Categories dm_categories = db.DM_Categories.Find(id);
            if (dm_categories == null)
            {
                return HttpNotFound();
            }
            return View(dm_categories);
        }

        // POST: /aaaa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DM_Categories dm_categories = db.DM_Categories.Find(id);
            db.DM_Categories.Remove(dm_categories);
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
