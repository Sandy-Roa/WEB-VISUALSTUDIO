using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class REPORTE_HT_SUBDESTINOSController : Controller
    {
        //
        // GET: /REPORTE_HT_SUBDESTINOS/
        public ActionResult Index()
        {
            return View();
        }

        

        DXWebApplication1.Reports.REPORTE_HT_SUBDESTINOS report = new DXWebApplication1.Reports.REPORTE_HT_SUBDESTINOS();

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
