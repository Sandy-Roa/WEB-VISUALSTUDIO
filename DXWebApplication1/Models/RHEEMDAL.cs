using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class RHEEMDAL
    {
        public static IEnumerable GetCEDIS()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from CEDIS in db1.CAT_CEDIS select CEDIS;

            return _m.ToList();
        }
        public static IEnumerable GetTIPOEMBARQUE()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from TIPOEMBARQUE in db1.CAT_TIPO_EMBARQUE select TIPOEMBARQUE;

            return _m.ToList();
        }
        public static IEnumerable GetTIPOENTREGA()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from GetTIPOENTREGA in db1.CAT_TIPO_ENTREGA select GetTIPOENTREGA;

            return _m.ToList();
        }
        public static IEnumerable GetPROVIENEDE()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from PROVIENEDE in db1.CAT_PROVIENE_DE select PROVIENEDE;

            return _m.ToList();
        }
        public static IEnumerable GetPROVEEDOR()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from PROVEEDOR in db1.CAT_PROVEEDOR select PROVEEDOR;

            return _m.ToList();
        }
        public static IEnumerable GetDESTINO()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from DESTINO in db1.CAT_DESTINO select DESTINO;

            return _m.ToList();
        }

        public static IEnumerable GetSTATUSEMBARQUE()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from STATUSEMBARQU in db1.CAT_STATUS_EMBARQUE select STATUSEMBARQU;

            return _m.ToList();
        }
        public static IEnumerable GetTRANSPORTE()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from TRANSPORTE in db1.CAT_TRANSPORTE select TRANSPORTE;

            return _m.ToList();
        }



        /*****************************************HT DOCUMENTOS************************************************/
        public static IEnumerable GetEMBARQUEHT()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from EMBARQUEHT in db1.UE_EMBARQUEHT select EMBARQUEHT;

            return _m.ToList();
        }
        public static IEnumerable GetREMISIONES()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
       
            var _m = from REMISIONES in db1.AUX_REMISIONES where REMISIONES.DISPONIBLE == "S" 
                     orderby REMISIONES.CLAVE_DOC ascending
                     
            select REMISIONES;
            return _m.ToList();

             
        }

        public static IEnumerable GetEMPRESA()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from EMPRESA in db1.CAT_EMPRESA
                  
                     orderby EMPRESA.NOMBRE ascending

                     select EMPRESA;
            return _m.ToList();


        }
        /**************************/
        public static IEnumerable GetREMISIONES_1()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
       
            var _m = from REMISIONES in db1.AUX_REMISIONES 
                     group REMISIONES by REMISIONES into g
                     where g.Count() < 1

                     select g.Key;
                     
                     
            // select g;
            
            
            
            
            return _m.ToList();

             
        }
        /******************************PARAMETROS DE HT DOCUMENTOS PARA OBTENER EL PK_EMBARQUES***********************************************/
        public static IEnumerable GetHTDOCUMENTOSByEMBARQUESHT(int? PK_EMBARQUE_HT)
        {
            if (PK_EMBARQUE_HT == null) return null;
            else
            {
                EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
                return db1.HT_DOCUMENTOS.Where(item => item.FK_EMBARQUE_HT == PK_EMBARQUE_HT).ToList();

            }
            //return null;
        }
        /******************************PARAMETROS DE HT DETALLEESPECIAL PARA OBTENER EL PK_EMBARQUES***********************************************/
        public static IEnumerable GetHTDETALLEESPECIALByEMBARQUESHT(int? PK_EMBARQUE_HT)
        {
            if (PK_EMBARQUE_HT == null) return null;
            else
            {
                EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
                return db1.SIS_HT_DETALLE.Where(item => item.FK_EMBARQUE_HT == PK_EMBARQUE_HT).ToList();

            }
            //return null;
        }

        /// <summary>
        /// // fk status embarque = 1 cerrado 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable GetFKSTATUSEMBARQUE()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
            return db1.UE_EMBARQUEHT.Where(item => item.FK_STATUS_EMBARQUE == 1).ToList();
        }


        //EMBARQUE NORMAL FK_TIPO_HT = 1
        public static IEnumerable GetFKTIPONORMAL()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
            return db1.UE_EMBARQUEHT.Where(item => item.FK_TIPO_HT == 1).ToList();
        }
        //EMBARQUE ESPECIAL FK_TIPO_HT = 2
        public static IEnumerable GetFKTIPOESPECIAL()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
            return db1.UE_EMBARQUEHT.Where(item => item.FK_TIPO_HT == 2).ToList();
        }

        /// <summary>
        /// // FK_EMBARQUE_HT para el retorno 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable GetFKEMBARQUEHT(int? PK_EMBARQUE_HT)
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();
            
            return db1.SIS_HT_DETALLE.Where(item => item.FK_EMBARQUE_HT == PK_EMBARQUE_HT).ToList();
        }

        /************************************************RETORENO EMBARQUES*************************************************/
        public static IEnumerable GetSTATUSRETORNO()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from STATUSRETORNO in db1.CAT_STATUS_RETORNO select STATUSRETORNO;

                return _m.ToList();
            

        }
        /************************************************RETORENO DETALLES*************************************************/
        public static IEnumerable GetTIPODEVOLUCION()
        {
            EMBARQUESRHEEMEntities db1 = new EMBARQUESRHEEMEntities();

            var _m = from TIPODEVOLUCION in db1.CAT_TIPO_DEVOLUCION select TIPODEVOLUCION;

            return _m.ToList();
        }
        
    }
}