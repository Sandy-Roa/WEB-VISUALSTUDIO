using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Data;

namespace DXWebApplication1.Controllers
{
    public class UE_RETORNOHTController : Controller
    {
        //
        // GET: /UE_RETORNOHT/
        public ActionResult Index()
        {
            return View();
        }

        

        DXWebApplication1.Models.EMBARQUESRHEEMEntities db = new DXWebApplication1.Models.EMBARQUESRHEEMEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {

            var model = db.UE_EMBARQUEHT;//Where(item => item.FK_STATUS_EMBARQUE == 1);

            return PartialView("_GridView1Partial", DXWebApplication1.Models.RHEEMDAL.GetFKSTATUSEMBARQUE());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(DXWebApplication1.Models.UE_EMBARQUEHT item)
        {
            
            var model = db.UE_EMBARQUEHT;
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
            
            
            return PartialView("_GridView1Partial", model.ToList());
            
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(DXWebApplication1.Models.UE_EMBARQUEHT item)
        {
            var model = db.UE_EMBARQUEHT;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.PK_EMBARQUE_HT == item.PK_EMBARQUE_HT);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                        /////Manda a Llamar al Stored Procedure
                        //string NomStored = "[dbo].[SP_RET_HT_CABECERA]";
                        //System.Data.SqlClient.SqlConnection _cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EMBARQUESRHEEMEntitiesFramework"].ConnectionString);
                        //System.Data.SqlClient.SqlCommand _parametro = new System.Data.SqlClient.SqlCommand(NomStored, _cnn);
                        //_parametro.Parameters.Add("PK_EMBARQUE_HT", SqlDbType.Int).Value = item.PK_EMBARQUE_HT;
                        //_parametro.CommandType = System.Data.CommandType.StoredProcedure;
                        //_cnn.Open();
                        //_parametro.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", DXWebApplication1.Models.RHEEMDAL.GetFKSTATUSEMBARQUE());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 PK_EMBARQUE_HT)
        {
            var model = db.UE_EMBARQUEHT;
            if (PK_EMBARQUE_HT >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.PK_EMBARQUE_HT == PK_EMBARQUE_HT);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList());
        }
    }
}
