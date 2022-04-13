using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class CAT_TARIFAController : Controller
    {
        //
        // GET: /CAT_TARIFA/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CAT_TARIFA/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CAT_TARIFA/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CAT_TARIFA/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CAT_TARIFA/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CAT_TARIFA/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CAT_TARIFA/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CAT_TARIFA/Delete/5
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

        DXWebApplication1.Models.EMBARQUESRHEEMEntities db = new DXWebApplication1.Models.EMBARQUESRHEEMEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.CAT_TARIFA;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(DXWebApplication1.Models.CAT_TARIFA item)
        {
            var model = db.CAT_TARIFA;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(DXWebApplication1.Models.CAT_TARIFA item)
        {
            var model = db.CAT_TARIFA;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.PK_TARIFA == item.PK_TARIFA);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 PK_TARIFA)
        {
            var model = db.CAT_TARIFA;
            if (PK_TARIFA >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.PK_TARIFA == PK_TARIFA);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
    }
}
