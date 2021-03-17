using LATINMEX.Datos.CORE;
using LATINMEX.MODELVIEW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LATINMEX.MODULOS
{
    public partial class frm_roles : System.Web.UI.Page, ICallbackEventHandler
    {
        CLS_MENUS cls_menu = new CLS_MENUS();
        CLS_PERMISOS cls_permisos = new CLS_PERMISOS();

        string respuesta = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaRoles();
                ListaMenus();
                ConsultarPermisos();
            }

            string cbref = Page.ClientScript.GetCallbackEventReference(this,
                         "arg", "JSCallback", "context");
            // Generate JS method trigger callback 
            string cbScr = string.Format("function UseCallBack(arg," +
                                         " context) {{ {0}; }} ", cbref);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                              "UseCallBack", cbScr, true);
        }

        public void ListaRoles()
        {
            DataTable data = cls_menu.SP_47_LISTA_ROLES();

            if (data != null && data.Rows.Count > 0)
            {
               List<RolesView> lista = data.AsEnumerable().Select(x => new RolesView
                {
                    IdRol = x.Field<int>("ID_ROL"),
                    Rol = x.Field<string>("ROL")

                }).ToList();

                if (!EsRolSuper())// Quito los roles super
                {
                    lista = lista.Where(x => !x.Rol.Contains(ROLES.Super.ToString().ToUpper())).ToList();
                }
                
                lst_roles.DataSource = lista;
                lst_roles.DataBind();
            }
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            bool permiso = eventArgument.Contains("permiso");
            eventArgument = eventArgument.Replace("permiso", "");
            if (!permiso)
            {
                int Tienepermiso = ValidarPermiso(PERMISOS_ROLES.AsignarMenus);
                if (Tienepermiso < 0)
                {
                    respuesta = "Permiso";
                    return;
                }

                if (!string.IsNullOrEmpty(eventArgument))
                {
                    string[] arrayActulizarEIdMenu = eventArgument.Split(',');
                    int idMenu = Convert.ToInt32(arrayActulizarEIdMenu[1]);
                    bool seAsignara = Convert.ToBoolean(arrayActulizarEIdMenu[0]);
                    int idrol = Convert.ToInt32(lst_roles.SelectedValue);
                    int res = -1;
                    if (seAsignara)
                    {
                        res = cls_menu.SP_45_ASIGNACION_ROLES_MENUS(idMenu, idrol);
                        ListaMenus();
                    }
                    else
                    {
                        res = cls_menu.SP_49_DESASIGNAR_ROLES_MENUS(idMenu, idrol);
                    }
                    if (res > 0)
                    {
                        respuesta = "Correcto";
                    }
                    else
                    {
                        respuesta = "Incorrecto";
                    }

                }
            }
            else
            {
                int Tienepermiso = ValidarPermiso(PERMISOS_ROLES.AsignarPermisos);
                if (Tienepermiso < 0)
                {
                    respuesta = "Permiso";
                    return;
                }
                string[] arrayActulizarIdPermiso = eventArgument.Split(',');
                int idPermiso = Convert.ToInt32(arrayActulizarIdPermiso[1]);
                bool seAsignara = Convert.ToBoolean(arrayActulizarIdPermiso[0]);
                int idrol = Convert.ToInt32(lst_roles.SelectedValue);
                int res = -1;
                if (seAsignara)
                {
                    res = cls_permisos.SP_57_ASIGNAR_ROLES_PERMISOS(idPermiso, idrol);
                }
                else
                {
                    res = cls_permisos.SP_59_DESASIGNAR_ROLES_PERMISOS(idPermiso, idrol);
                }

                if (res > 0)
                {
                    respuesta = "Correcto";
                }

            }
        }
        public string GetCallbackResult()
        {
            this.Master.RefrescarListaDeMenu(true);
            return respuesta;
        }
        public void ListaMenus()
        {
            if (!string.IsNullOrEmpty(lst_roles.SelectedValue))
            {
                int idrol = Convert.ToInt32(lst_roles.SelectedValue);
                DataTable dataMenu = cls_menu.SP_48_LISTA_MENU_POR_ROLES(idrol);

                if (dataMenu != null && dataMenu.Rows.Count > 0)
                {
                    var listaMenus = dataMenu.AsEnumerable().Select(x => new MenuView
                    {
                        Texto = x.Field<string>("TEXTO"),
                        IdMenu = x.Field<int>("ID_MENU"),
                        Descripcion = x.Field<string>("DESCRIPCION"),
                        Icono = x.Field<string>("ICONO"),
                        Tipo = x.Field<string>("TIPO"),
                        Url = x.Field<string>("URL"),
                        IdMenuParent = x.Field<int?>("ID_MENU_PARENT"),
                        Orden = x.Field<int>("ORDEN"),
                        IdRol = x.Field<int?>("ID_ROL")
                    }).ToList();

                    //Relaciono las tablas
                    var listaAgrupada = listaMenus.Where(m => m.IdMenuParent == (int)HERENCIA.Padre || !m.IdMenuParent.HasValue).Select(x => new
                    {
                        Text = x.Texto,
                        IdMenu = x.IdMenu,
                        IdRol = x.IdRol,
                        Icono = x.Icono,
                        data = listaMenus.Where(p => p.IdMenuParent.HasValue && p.IdMenuParent == x.IdMenu).ToList(),
                        Count = listaMenus.Where(p => p.IdMenuParent.HasValue && p.IdMenuParent == x.IdMenu).Count()
                    }).ToList();

                    Rp_ColumnaMennu.DataSource = listaAgrupada;
                    Rp_ColumnaMennu.DataBind();

                }
            }

        }

        public void ConsultarPermisos()
        {
            if (!string.IsNullOrEmpty(lst_roles.SelectedValue))
            {

                int idrol = Convert.ToInt32(lst_roles.SelectedValue);
                DataTable dataPermiso = cls_permisos.SP_61_CONSULTAR_PERMISOS(idrol);

                if (dataPermiso != null && dataPermiso.Rows.Count > 0)
                {
                    var listaPermisos = dataPermiso.AsEnumerable().Select(x => new PermisosView
                    {
                        Permiso = x.Field<string>("PERMISO"),
                        Descripcion = x.Field<string>("DESCRIPCION"),
                        IdPermiso = x.Field<int?>("ID_PERMISO"),
                        Orden = x.Field<int?>("ORDEN"),
                        Tipo = x.Field<string>("TIPO"),
                        IdRol = x.Field<int?>("ID_ROL")
                    }).ToList();

                    //Relaciono las tablas
                    var listaAgrupada = listaPermisos.GroupBy(b => b.Tipo).Select(x => new
                    {
                        Tipo = x.Key,
                        data = listaPermisos.Where(p => p.IdPermiso.HasValue && p.Tipo == x.Key).ToList(),
                        Count = listaPermisos.Where(p => p.IdPermiso.HasValue && p.Tipo == x.Key).Count()
                    }).ToList();

                    Rp_ColumnaPermiso.DataSource = listaAgrupada;
                    Rp_ColumnaPermiso.DataBind();
                }

            }
        }

        protected void lst_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaMenus();
        }

        protected void Rp_ColumnaMennu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btn_recargar_Click(object sender, EventArgs e)
        {
            this.Master.RefrescarListaDeMenu(true);
            ListaMenus();
        }

        public int ValidarPermiso(PERMISOS_ROLES permisos)
        {
            int idUsuario = Convert.ToInt32(Session["userID"]);
            //permiso de creacion de usuario
            int permiso = cls_permisos.FS_06_CHECK_PERMISO_USUARIO((int)permisos, idUsuario);
            return permiso;
        }

        public bool EsRolSuper()
        {
            return Session["roles"] == null ? false : Session["roles"].ToString().Contains(ROLES.Super.ToString().ToUpper());
        }


    }
}