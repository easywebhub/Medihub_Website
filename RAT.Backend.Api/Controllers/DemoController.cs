using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using RAT.Backend.Api.DAL;
using RAT.Backend.Api.Service;

namespace RAT.Backend.Api.Controllers
{
    public class DemoController : Controller
    {
        
        private readonly ICategoryService _categoryService;
         public DemoController()
        {
            var context = new SqlDbContext();
            _categoryService = new CategoryService(new UnitOfWorkMssql(context));
        }
        //
        // GET: /Demo/
        public ActionResult Index()
        {
            var rs = _categoryService.GetCategorieses();
            return View(rs);
        }

        //
        // GET: /Demo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Demo/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Demo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Note")] DM_Categories dm_categories)
        {
            if (ModelState.IsValid)
            {

                _categoryService.UpdateDmCategory(dm_categories);
              
                return RedirectToAction("Index");
            }

            return View(dm_categories);
        }

        //
        // GET: /Demo/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_Categories dm_categories = _categoryService.GetCategorybyId(id);
            if (dm_categories == null)
            {
                return HttpNotFound();
            }
            return View(dm_categories);
        }

        //
        // POST: /Demo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Note")] DM_Categories dm_categories)
        {
            if (ModelState.IsValid)
            {
                NLog.LogManager.GetCurrentClassLogger().Debug("test:",dm_categories.Name); // cach ghi Nlog
                _categoryService.UpdateDmCategory(dm_categories);
                return RedirectToAction("Index");
            }
            return View(dm_categories);
        }


        //
        // GET: /Demo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Demo/Delete/5
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
