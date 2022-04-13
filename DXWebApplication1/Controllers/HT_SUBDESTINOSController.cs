using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class HT_SUBDESTINOSController : Controller
    {
        //
        // GET: /HT_SUBDESTINOS/
        public ActionResult Index()
        {
            return View();
        }


        DXWebApplication1.Models.EMBARQUESRHEEMEntities db = new DXWebApplication1.Models.EMBARQUESRHEEMEntities();

        [ValidateInput(false)]
        public ActionResult GridView3Partial()
        {
            var model = db.HT_SUBDESTINOS;
            return PartialView("_GridView3Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView3PartialAddNew(DXWebApplication1.Models.HT_SUBDESTINOS item)
        {
            var model = db.HT_SUBDESTINOS;
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
            return PartialView("_GridView3Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView3PartialUpdate(DXWebApplication1.Models.HT_SUBDESTINOS item)
        {
            var model = db.HT_SUBDESTINOS;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.PK_SUBDESTINO == item.PK_SUBDESTINO);
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
            return PartialView("_GridView3Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView3PartialDelete(System.Int32 PK_SUBDESTINO)
        {
            var model = db.HT_SUBDESTINOS;
            if (PK_SUBDESTINO >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.PK_SUBDESTINO == PK_SUBDESTINO);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView3Partial", model.ToList());
        }
    }
}
