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
    
    public partial class SIS_HT_DETALLE
    {
        public SIS_HT_DETALLE()
        {
            this.HT_SUBDESTINOS = new HashSet<HT_SUBDESTINOS>();
        }
    
        public int PK_DETALLE { get; set; }
        public string FOLIO_EMBARQUE { get; set; }
        public string CLAVE_DOCUMENTO { get; set; }
        public string DIRECCION_ENTREGA { get; set; }
        public string CLAVE_COTIZACION { get; set; }
        public string CLAVE_PEDIDO { get; set; }
        public string CLAVE_FACTURA { get; set; }
        public string CLAVE_ORDEN_COMPRA { get; set; }
        public string CLAVE_CLIENTE { get; set; }
        public string CLAVE_ARTICULO { get; set; }
        public Nullable<double> CANTIDAD_ORIGINAL { get; set; }
        public Nullable<double> CANTIDAD_EMBARCADA { get; set; }
        public Nullable<double> CANTIDAD_DEVUELTA { get; set; }
        public Nullable<int> FK_TIPO_DEVOLUCION { get; set; }
        public string DESCRIPCION_DEVOLUCIÓN { get; set; }
        public string CLAVE_NOTA_CREDITO { get; set; }
        public Nullable<int> FK_EMBARQUE_HT { get; set; }
        public string OBSERVACIONES { get; set; }
    
        public virtual CAT_TIPO_DEVOLUCION CAT_TIPO_DEVOLUCION { get; set; }
        public virtual UE_EMBARQUEHT UE_EMBARQUEHT { get; set; }
        public virtual ICollection<HT_SUBDESTINOS> HT_SUBDESTINOS { get; set; }
    }
}
