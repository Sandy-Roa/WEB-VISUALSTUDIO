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
    
    public partial class CAT_TIPO_DEVOLUCION
    {
        public CAT_TIPO_DEVOLUCION()
        {
            this.SIS_HT_DETALLE = new HashSet<SIS_HT_DETALLE>();
        }
    
        public int PK_TIPO_DEVOLUCION { get; set; }
        public string NOMBRE { get; set; }
        public string CODIGO { get; set; }
    
        public virtual ICollection<SIS_HT_DETALLE> SIS_HT_DETALLE { get; set; }
    }
}
