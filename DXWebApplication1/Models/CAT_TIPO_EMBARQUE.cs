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
    
    public partial class CAT_TIPO_EMBARQUE
    {
        public CAT_TIPO_EMBARQUE()
        {
            this.UE_EMBARQUEHT = new HashSet<UE_EMBARQUEHT>();
        }
    
        public int PK_TIPO_EMBARQUE { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<UE_EMBARQUEHT> UE_EMBARQUEHT { get; set; }
    }
}
