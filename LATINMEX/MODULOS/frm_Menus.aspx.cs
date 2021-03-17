using LATINMEX.Datos.CORE;
using LATINMEX.MODELVIEW;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;

using System.Web.UI.WebControls;

namespace LATINMEX.MODULOS
{
    public partial class frm_Menus : System.Web.UI.Page, ICallbackEventHandler
    {
        CLS_MENUS cls_menu = new CLS_MENUS();
        string respuesta = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarRolSuper();

            Message_warning.Visible = false;
            Message_danger.Visible = false;
            Message_info.Visible = false;
            Message_Succes.Visible = false;

            if (!IsPostBack)
            {
                CargarControles();
            }

            // get reference of call back method named JSCallback 
            string cbref = Page.ClientScript.GetCallbackEventReference(this,
                            "arg", "JSCallback", "context");
            // Generate JS method trigger callback 
            string cbScr = string.Format("function UseCallBack(arg," +
                                         " context) {{ {0}; }} ", cbref);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                              "UseCallBack", cbScr, true);

        }
        public void RaiseCallbackEvent(string eventArgument)
        {
            if (!string.IsNullOrEmpty(eventArgument))
            {
                string[] arrayActulizarEIdMenu = eventArgument.Split(',');
                int idMenu = Convert.ToInt32(arrayActulizarEIdMenu[1]);
                bool seAsignara = Convert.ToBoolean(arrayActulizarEIdMenu[0]);
                int idrol = Convert.ToInt32(lst_Roles.SelectedValue);
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
        public string GetCallbackResult()
        {
            this.Master.RefrescarListaDeMenu(true);
            return respuesta;
        }
        public void CargarControles()
        {
            Ordenar();
            ListaHerenciaMenu();
            ListaRoles();
            ListaMenus();
        }
        //Retorna el orden al valor actual
        public void Ordenar()
        {
            int order = cls_menu.FS_02_GET_ORDER_MENU();
            lb_orden.Text = Convert.ToString(order);
        }

        #region Listas

        public void ListaHerenciaMenu()
        {
            DataTable data = cls_menu.SP_39_CONSULTAR_MENUS();
            if (data != null && data.Rows.Count > 0)
            {
                var lista = data.AsEnumerable().Select(x => new MenuView
                {
                    Texto = x.Field<string>("TEXTO"),
                    IdMenu = x.Field<int>("ID_MENU"),
                    IdMenuParent = x.Field<int?>("ID_MENU_PARENT"),
                }).Where(d => d.IdMenuParent == (int)HERENCIA.Padre).ToList();

                lista.Add(new MenuView { IdMenu = 0, Texto = "Seleccione" });
                lista = lista.OrderBy(o => o.IdMenu).ToList();

                lst_menuPadre.DataSource = lista;
                lst_menuPadre.DataBind();

                lsl_MenuPadreModa.DataSource = lista;
                lsl_MenuPadreModa.DataBind();
            }
        }

        public void ListaRoles()
        {
            DataTable data = cls_menu.SP_47_LISTA_ROLES();
            if (data != null && data.Rows.Count > 0)
            {
                lst_Roles.DataSource = data;
                lst_Roles.DataBind();
            }
        }

        public void ListaMenus()
        {
            int idrol = Convert.ToInt32(lst_Roles.SelectedValue);
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

        #endregion
        public void GuardarMenu()
        {
            var result = ValidarCampos();
            if (!result.IsSuccess)
            {
                //Message_warning.Text = result.Message;
                //Message_warning.Visible = true;
                return;
            }

            int? menuPadre = lst_menuPadre.SelectedValue == "0" ? 0 : (int?)Convert.ToInt32(lst_menuPadre.SelectedValue);

            var res = cls_menu.SP_41_INSERTAR_MENUS(txt_nombre.Text, txt_descripcion.Text, txt_icono.Text, txt_url.Text, menuPadre);

            if (res > 0)
            {
                Message_Succes.Visible = true;
                Message_Succes.Text = "El registro del menu fue exitoso";
                LimpiarCampos();
                ListaMenus();
                ListaHerenciaMenu();
            }
            else
            {
                Message_danger.Visible = true;
                Message_danger.Text = "Error al registrar el menu";
            }
        }

        public void ActualizarMenu()
        {
            var result = ValidarCamposModal();
            if (!result.IsSuccess)
            {
                mpe_MenuDMV.Show();
                return;
            }

            int idMenu = Convert.ToInt32(hf_IdmenuDMV.Value);
            int? idParent = lsl_MenuPadreModa.SelectedValue == HERENCIA.Padre.ToString()
                            ? null : (int?)Convert.ToInt32(lsl_MenuPadreModa.SelectedValue);

            var res = cls_menu.SP_42_ACTUALIZAR_MENU(idMenu,
                                                     txt_nombreModa.Text,
                                                     txt_descripcionModa.Text,
                                                     txt_iconoModa.Text,
                                                     txt_urlModa.Text,
                                                     idParent);
            if (res > 0)
            {
                Message_Succes.Text = "Menu actualizado correctamente.";
                Message_Succes.Visible = true;
                ListaMenus();
                if (idParent == (int)HERENCIA.Padre)
                    ListaHerenciaMenu();
            }
            else
            {
                Message_danger.Text = "Se ha presentado un error al actualizar el menu.";
                Message_danger.Visible = true;
            }

        }

        public void EliminarMenu(int idMenu)
        {
            DataTable menu = cls_menu.SP_40_GET_MENU(idMenu);

            int res = cls_menu.SP_43_DELETE_MENU(idMenu);

            if (res > 0)
            {
                Message_Succes.Text = "Menu eliminado correctamente.";
                Message_Succes.Visible = true;
                ListaHerenciaMenu();
                Ordenar();
            }
            else
            {
                Message_danger.Text = "Error al actualizar el menu, puede que este ya se encuentre asignado";
                Message_danger.Visible = true;
            }
        }

        public Result ValidarCampos()
        {
            var res = new Result();
            res.IsSuccess = true;
            if (string.IsNullOrEmpty(txt_nombre.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar el  texto",
                    IsSuccess = false
                };
            }

            if (string.IsNullOrEmpty(txt_descripcion.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar la descripcion",
                    IsSuccess = false
                };
            }

            if (string.IsNullOrEmpty(txt_icono.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar el icono",
                    IsSuccess = false
                };
            }

            if (string.IsNullOrEmpty(txt_url.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar la url",
                    IsSuccess = false
                };
            }

            return res;

        }

        public Result ValidarCamposModal()
        {
            var res = new Result();
            res.IsSuccess = true;
            if (string.IsNullOrEmpty(txt_nombreModa.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar el  texto",
                    IsSuccess = false
                };
            }

            if (string.IsNullOrEmpty(txt_descripcionModa.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar la descripcion",
                    IsSuccess = false
                };
            }

            if (string.IsNullOrEmpty(txt_iconoModa.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar el icono",
                    IsSuccess = false
                };
            }

            if (string.IsNullOrEmpty(txt_urlModa.Text))
            {
                return new Result
                {
                    Message = "Debe diligenciar la url",
                    IsSuccess = false
                };
            }

            return res;

        }

        public void ValidarRolSuper()
        {
            if (Session["roles"] == null ? false : Session["roles"].ToString().Contains(ROLES.Super.ToString().ToUpper()) == false)
            {
                Response.Redirect("Default.aspx");
            }
        }

        public void DetalleMenus(DataTable menu)
        {
            txt_nombreModa.Text = menu.Rows[0]["TEXTO"].ToString();
            lb_ordenModa.Text = menu.Rows[0]["ORDEN"].ToString();
            txt_descripcionModa.Text = menu.Rows[0]["DESCRIPCION"].ToString();
            txt_iconoModa.Text = menu.Rows[0]["ICONO"].ToString();
            txt_urlModa.Text = menu.Rows[0]["URL"].ToString();
            int? idParent = menu.Rows[0].Field<int?>("ID_MENU_PARENT");
            hf_IdmenuDMV.Value = menu.Rows[0]["ID_MENU"].ToString();

            if (idParent.HasValue && idParent != (int)HERENCIA.Padre)
            {
                lsl_MenuPadreModa.SelectedValue = idParent.ToString();
                lsl_MenuPadreModa.Enabled = true;
            }
            else
            {
                lsl_MenuPadreModa.SelectedValue = ((int)HERENCIA.Padre).ToString();
                lsl_MenuPadreModa.Enabled = false;
            }
        }
        public void LimpiarCampos()
        {
            Ordenar();

            txt_nombre.Text = "";
            txt_descripcion.Text = "";
            txt_icono.Text = "";
            txt_url.Text = "";
            lst_menuPadre.SelectedValue = ((int)HERENCIA.Padre).ToString();
        }
        protected void lst_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaMenus();
        }
        protected void btn_registra_Click(object sender, EventArgs e)
        {
            GuardarMenu();

            //this.Master.MyProperty = "Santero";
            //this.Master.RefreshRecentProductsGrid();
        }
        protected void btn_AceptarMenuDMV_Click(object sender, EventArgs e)
        {
            ActualizarMenu();
        }
        protected void gv_Notas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idMenu = Convert.ToInt32(e.CommandArgument);
                EliminarMenu(idMenu);
            }

            if (e.CommandName == "Editar")
            {
                int idMenu = Convert.ToInt32(e.CommandArgument);
                DataTable menu = cls_menu.SP_40_GET_MENU(idMenu);

                if (menu != null)
                {
                    DetalleMenus(menu);
                    mpe_MenuDMV.Show();
                }
            }
        }
        protected void Rp_ColumnaMennu_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {

            }

            if (e.CommandName == "Editar")
            {
                int idMenu = Convert.ToInt32(e.CommandArgument);
                DataTable menu = cls_menu.SP_40_GET_MENU(idMenu);

                if (menu != null)
                {
                    DetalleMenus(menu);
                    mpe_MenuDMV.Show();
                }
            }
        }
        protected void btn_eliminarMenu_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int idMenu = Convert.ToInt32(btn.TabIndex);
            EliminarMenu(idMenu);
            ListaMenus();
        }
        protected void btn_recargar_Click(object sender, EventArgs e)
        {
            this.Master.RefrescarListaDeMenu(true);
            ListaMenus();
        }
    }


}