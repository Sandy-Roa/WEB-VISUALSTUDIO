using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Data;

namespace DXWebApplication1.Controllers
{
    public class SIS_HT_DETALLEController : Controller
    {
        //
        // GET: /SIS_HT_DETALLE/
        public ActionResult Index()
        {
            return View();
        }

      
        DXWebApplication1.Models.EMBARQUESRHEEMEntities db = new DXWebApplication1.Models.EMBARQUESRHEEMEntities();

        [ValidateInput(false)]
        public ActionResult GridView2Partial()
        {
            var model = db.SIS_HT_DETALLE;
            return PartialView("_GridView2Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView2PartialAddNew(DXWebApplication1.Models.SIS_HT_DETALLE item)
        {
            var model = db.SIS_HT_DETALLE;
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
            return PartialView("_GridView2Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView2PartialUpdate(DXWebApplication1.Models.SIS_HT_DETALLE item)
        {
            
            var model = db.SIS_HT_DETALLE;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.PK_DETALLE == item.PK_DETALLE);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                        
                        
                        ///Manda a Llamar al Stored Procedure
                        string NomStored = "[dbo].[SP_ACT_HT_CANT_EMB]";
                        System.Data.SqlClient.SqlConnection _cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EMBARQUESRHEEMEntitiesFramework"].ConnectionString);
                        System.Data.SqlClient.SqlCommand _parametro = new System.Data.SqlClient.SqlCommand(NomStored, _cnn);
                        _parametro.Parameters.Add("PK_DETALLE", SqlDbType.Int).Value = item.PK_DETALLE;
                        _parametro.CommandType = System.Data.CommandType.StoredProcedure;
                        _cnn.Open();
                        _parametro.ExecuteNonQuery();

                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView2Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView2PartialDelete(System.Int32 PK_DETALLE)
        {
            var model = db.SIS_HT_DETALLE;
            if (PK_DETALLE >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.PK_DETALLE == PK_DETALLE);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView2Partial", model.ToList());
        }
    }
}
