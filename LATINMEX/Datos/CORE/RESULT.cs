using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos.CORE
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
        public object ResultObjet { get; set; }
    }
}