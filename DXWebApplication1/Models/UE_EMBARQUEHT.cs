//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXWebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UE_EMBARQUEHT
    {
        public UE_EMBARQUEHT()
        {
            this.HT_DOCUMENTOS = new HashSet<HT_DOCUMENTOS>();
            this.SIS_HT_DETALLE = new HashSet<SIS_HT_DETALLE>();
        }
    
        public int PK_EMBARQUE_HT { get; set; }
        public Nullable<int> FK_CEDIS { get; set; }
        public Nullable<System.DateTime> FECHA_ELABORACION { get; set; }
        public Nullable<int> FK_PROVEEDOR { get; set; }
        public string FOLIO_EMBARQUE { get; set; }
        public Nullable<int> FK_DESTINO { get; set; }
        public Nullable<int> TIPO_ENTREGA { get; set; }
        public Nullable<int> TOTAL_FACTURAS { get; set; }
        public Nullable<int> TOTAL_CAJAS_CARGADAS { get; set; }
        public string OPERADOR { get; set; }
        public Nullable<int> FK_PROVIENE_DE { get; set; }
        public Nullable<System.DateTime> FECHA_ENTREGA { get; set; }
        public Nullable<int> FK_STATUS_EMBARQUE { get; set; }
        public Nullable<int> FK_TIPO_EMBARQUE { get; set; }
        public Nullable<int> FK_TIPO_HT { get; set; }
        public Nullable<int> FK_STATUS_RETORNO { get; set; }
        public string PADRE_HIJO { get; set; }
        public string CLAVE_PADRE { get; set; }
        public Nullable<double> TARIFA { get; set; }
        public Nullable<double> IMPORTE_REAL { get; set; }
        public Nullable<System.DateTime> FECHA_ENTREGA_EVIDENCIA { get; set; }
        public string FOLIO_HOJA_DEVOLUCION { get; set; }
        public string DESCRIPCION_RETORNO { get; set; }
        public string RESPONSABLE { get; set; }
        public Nullable<int> FK_TRANSPORTE { get; set; }
    
        public virtual CAT_CEDIS CAT_CEDIS { get; set; }
        public virtual CAT_DESTINO CAT_DESTINO { get; set; }
        public virtual CAT_PROVEEDOR CAT_PROVEEDOR { get; set; }
        public virtual CAT_PROVIENE_DE CAT_PROVIENE_DE { get; set; }
        public virtual CAT_STATUS_EMBARQUE CAT_STATUS_EMBARQUE { get; set; }
        public virtual CAT_STATUS_RETORNO CAT_STATUS_RETORNO { get; set; }
        public virtual CAT_TIPO_EMBARQUE CAT_TIPO_EMBARQUE { get; set; }
        public virtual CAT_TIPO_HT CAT_TIPO_HT { get; set; }
        public virtual CAT_TRANSPORTE CAT_TRANSPORTE { get; set; }
        public virtual ICollection<HT_DOCUMENTOS> HT_DOCUMENTOS { get; set; }
        public virtual ICollection<SIS_HT_DETALLE> SIS_HT_DETALLE { get; set; }
        public virtual CAT_TIPO_ENTREGA CAT_TIPO_ENTREGA { get; set; }
    }
}
