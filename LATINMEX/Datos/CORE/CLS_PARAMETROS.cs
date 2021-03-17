using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LATINMEX
{
    public enum TIPOS_MENUS
    { 
     ADMINITRACION =1,
     CLIENTE =2,
     ASESOR = 3
    }
    public enum ESTADOS_USUARIO :int
    {
        Activo = 1,
        Inactivo= 2
    }
    public enum HERENCIA: int
    {
        Padre = 0
    }

    public enum ROLES : int
    {
        Super = 1
    }

    public enum PERMISOS_USUARIOS : int
    {
        CrearUsuario = 8,
        ActualizarUsuario =11,
        EliminarUsuario= 12,
        AsignarRoles = 13
    }

    public enum PERMISOS_ROLES : int
    {
        AsignarMenus= 14,
        AsignarPermisos = 15,
    }


}