using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Data;

namespace DXWebApplication1.Controllers
{
    public class UE_EMBARQUEHTESPECIALController : Controller
    {
        //
        // GET: /UE_EMBARQUEHTESPECIAL/
        public ActionResult Index()
        {
            return View();
        }

        DXWebApplication1.Models.EMBARQUESRHEEMEntities db = new DXWebApplication1.Models.EMBARQUESRHEEMEntities();

        [ValidateInput(false)]
        public ActionResult GridView5Partial()
        {
            var model = db.UE_EMBARQUEHT;
            return PartialView("_GridView5Partial", DXWebApplication1.Models.RHEEMDAL.GetFKTIPOESPECIAL());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView5PartialAddNew(DXWebApplication1.Models.UE_EMBARQUEHT item)
        {
            string NomStored = "[dbo].[SP_ALTA_HT_CAB_ESP]";

            System.Data.SqlClient.SqlConnection _cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EMBARQUESRHEEMEntitiesFramework"].ConnectionString);
            System.Data.SqlClient.SqlCommand _parametro = new System.Data.SqlClient.SqlCommand(NomStored, _cnn);

            _parametro.Parameters.Add("CEDIS", SqlDbType.Int).Value = item.FK_CEDIS;
            _parametro.Parameters.Add("FECHA_ELAB", SqlDbType.Date).Value = item.FECHA_ELABORACION;
            _parametro.Parameters.Add("PROVEEDOR", SqlDbType.Int).Value = item.FK_PROVEEDOR;
            _parametro.Parameters.Add("DESTINO", SqlDbType.Int).Value = item.FK_DESTINO;
            _parametro.Parameters.Add("OPERADOR", SqlDbType.VarChar).Value = item.OPERADOR;
            _parametro.Parameters.Add("PROVIENEDE", SqlDbType.Int).Value = item.FK_PROVIENE_DE;
            _parametro.Parameters.Add("TIPO_ENT", SqlDbType.Int).Value = item.TIPO_ENTREGA;
            _parametro.Parameters.Add("TIPO_EMBARQUE", SqlDbType.Int).Value = item.FK_TIPO_EMBARQUE;
            _parametro.Parameters.Add("TRANSPORTE", SqlDbType.Int).Value = item.FK_TRANSPORTE;
            _parametro.Parameters.Add("RESPONSABLE", SqlDbType.VarChar).Value = item.RESPONSABLE;
            _parametro.CommandType = CommandType.StoredProcedure;
            _cnn.Open();
            _parametro.ExecuteNonQuery();

            //System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(_parametro);
            //DataSet ds = new DataSet();
            //          adapter.Fill(ds);
            var model = db.UE_EMBARQUEHT;
            if (ModelState.IsValid)
            {
                try
                {
                    //model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView5Partial", DXWebApplication1.Models.RHEEMDAL.GetFKTIPOESPECIAL());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView5PartialUpdate(DXWebApplication1.Models.UE_EMBARQUEHT item)
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
                        ///Manda a Llamar al Stored Procedure
                        string NomStored = "[dbo].[SP_ACT_HT_CABECERA]";
                        System.Data.SqlClient.SqlConnection _cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EMBARQUESRHEEMEntitiesFramework"].ConnectionString);
                        System.Data.SqlClient.SqlCommand _parametro = new System.Data.SqlClient.SqlCommand(NomStored, _cnn);
                        _parametro.Parameters.Add("PK_EMBARQUE_HT", SqlDbType.Int).Value = item.PK_EMBARQUE_HT;
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
            return PartialView("_GridView5Partial", DXWebApplication1.Models.RHEEMDAL.GetFKTIPOESPECIAL());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView5PartialDelete(System.Int32 PK_EMBARQUE_HT)
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
            return PartialView("_GridView5Partial", model.ToList());
        }
    }
}
