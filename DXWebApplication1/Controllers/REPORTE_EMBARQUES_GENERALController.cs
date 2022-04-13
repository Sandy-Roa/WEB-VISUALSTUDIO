using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class REPORTE_EMBARQUES_GENERALController : Controller
    {
        //
        // GET: /REPORTE_EMBARQUES_GENERAL/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /REPORTE_EMBARQUES_GENERAL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /REPORTE_EMBARQUES_GENERAL/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /REPORTE_EMBARQUES_GENERAL/Create
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
        // GET: /REPORTE_EMBARQUES_GENERAL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /REPORTE_EMBARQUES_GENERAL/Edit/5
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
        // GET: /REPORTE_EMBARQUES_GENERAL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /REPORTE_EMBARQUES_GENERAL/Delete/5
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

        DXWebApplication1.Reports.REPORTE_EMBARQUES_GENERAL report = new DXWebApplication1.Reports.REPORTE_EMBARQUES_GENERAL();

        public ActionResult ReportPartial()
        {
            return PartialView("_ReportPartial", report);
        }

        public ActionResult ReportPartialExport()
        {
            return DocumentViewerExtension.ExportTo(report, Request);
        }
    }
}
