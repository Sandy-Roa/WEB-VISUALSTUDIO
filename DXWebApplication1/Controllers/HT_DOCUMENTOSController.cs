using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Data;

namespace DXWebApplication1.Controllers
{
    public class HT_DOCUMENTOSController : Controller
    {
        //
        // GET: /HT_DOCUMENTOS/
        public ActionResult Index()
        {
            return View();
        }

       

        DXWebApplication1.Models.EMBARQUESRHEEMEntities db = new DXWebApplication1.Models.EMBARQUESRHEEMEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial(int? PK_EMBARQUE_HT)
        {
            ViewData["PK_EMBARQUE_HT"] = PK_EMBARQUE_HT;
            var model = db.HT_DOCUMENTOS;
            return PartialView("_GridView1Partial", DXWebApplication1.Models.RHEEMDAL.GetHTDOCUMENTOSByEMBARQUESHT(PK_EMBARQUE_HT));
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(DXWebApplication1.Models.HT_DOCUMENTOS item, int PK_EMBARQUE_HT)
        {
            ViewData["PK_EMBARQUE_HT"] = PK_EMBARQUE_HT;
            var model = db.HT_DOCUMENTOS;
            var M = "N";
            var T = "T";
            var R = "R";
            
            if (ModelState.IsValid)
            {
                try
                {
                    item.TOTAL_PARCIAL = T;
                    item.TIPO_DOCUMENTO = R;
                    item.PROCESADO = M;
                    item.FK_EMBARQUE_HT = PK_EMBARQUE_HT;
                    model.Add(item);
                    db.SaveChanges();

                    ///Manda a Llamar al Stored Procedure
                    string NomStored = "[dbo].[SP_ALTA_HT_DET]";

            System.Data.SqlClient.SqlConnection _cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EMBARQUESRHEEMEntitiesFramework"].ConnectionString);
            System.Data.SqlClient.SqlCommand _parametro = new System.Data.SqlClient.SqlCommand(NomStored, _cnn);
            _parametro.CommandType = System.Data.CommandType.StoredProcedure;
            _cnn.Open();
            _parametro.ExecuteNonQuery();
                    //Termina llamada al Stored Procedure
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
                // ViewData["dataItem"] = item;
            
            return PartialView("_GridView1Partial", DXWebApplication1.Models.RHEEMDAL.GetHTDOCUMENTOSByEMBARQUESHT(PK_EMBARQUE_HT));

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(DXWebApplication1.Models.HT_DOCUMENTOS item, int PK_EMBARQUE_HT)
        {
            ViewData["PK_EMBARQUE_HT"] = PK_EMBARQUE_HT;
            var model = db.HT_DOCUMENTOS;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.PK_HT_DOCUMENTOS == item.PK_HT_DOCUMENTOS);
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
                //ViewData["dataItem"] = item;
            return PartialView("_GridView1Partial", DXWebApplication1.Models.RHEEMDAL.GetHTDOCUMENTOSByEMBARQUESHT(PK_EMBARQUE_HT));

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 PK_HT_DOCUMENTOS, int PK_EMBARQUE_HT)
        {
            ViewData["PK_EMBARQUE_HT"] = PK_EMBARQUE_HT;
            var model = db.HT_DOCUMENTOS;
            if (PK_HT_DOCUMENTOS >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.PK_HT_DOCUMENTOS == PK_HT_DOCUMENTOS);
                    string NomStored = "[dbo].[SP_BAJA_HT_DET]";

                    System.Data.SqlClient.SqlConnection _cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EMBARQUESRHEEMEntitiesFramework"].ConnectionString);
                    System.Data.SqlClient.SqlCommand _parametro = new System.Data.SqlClient.SqlCommand(NomStored, _cnn);
                    _parametro.Parameters.Add("PK_HT_DOCUMENTOS", SqlDbType.Int).Value = item.PK_HT_DOCUMENTOS;
                    _parametro.CommandType = System.Data.CommandType.StoredProcedure;
                    _cnn.Open();
                    _parametro.ExecuteNonQuery();

                    // if (item != null)
                    //   model.Remove(item);
                    // db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", DXWebApplication1.Models.RHEEMDAL.GetHTDOCUMENTOSByEMBARQUESHT(PK_EMBARQUE_HT));
        }
    }
}
