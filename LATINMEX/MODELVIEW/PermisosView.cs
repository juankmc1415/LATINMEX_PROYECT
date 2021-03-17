using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LATINMEX.MODELVIEW
{
    public class PermisosView
    {
        public int? IdPermiso { get; set; }
        public string Permiso { get; set; }
        public int? Orden { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int? IdRol { get; set; }

    }
}