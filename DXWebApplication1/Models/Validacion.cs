using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace DXWebApplication1.Models
{
     [MetadataType(typeof(UE_EMBARQUEHT))]
    public class Validacion
    {
       public class UE_EMBARQUEHT
       {
           [Required(ErrorMessage = "EL CAMPO CEDIS ES OBLIGATORIO")]
           public int PK_EMBARQUE_HT { get; set; }
           
       }
        
    }
}

