using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class ReporteEmbarquesHTController : Controller
    {
        //
        // GET: /ReporteEmbarquesHT/
        public ActionResult Index(string PK_EMBARQUE_HT)
        {
            ViewData["PK_EMBARQUE_HT"] = PK_EMBARQUE_HT;
            return View();
        }


        DXWebApplication1.Reports.ReporteEmbarquesHT report = new DXWebApplication1.Reports.ReporteEmbarquesHT();

        public ActionResult ReportPartial(string PK_EMBARQUE_HT)
        {
            ViewData["PK_EMBARQUE_HT"] = PK_EMBARQUE_HT;
            report.Parameters["parameter1"].Value = PK_EMBARQUE_HT;
            report.Parameters["parameter1"].Visible = false;
            return PartialView("_ReportPartial", report);
        }

        public ActionResult ReportPartialExport()
        {
            return DocumentViewerExtension.ExportTo(report, Request);
        }
    }
}
