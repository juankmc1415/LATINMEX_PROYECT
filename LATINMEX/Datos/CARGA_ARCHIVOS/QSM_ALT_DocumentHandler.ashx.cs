using LATINMEX.Datos.PRODUCTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMesOS3.HANDLERS
{
    /// <summary>
    /// Summary description for QSM_ALT_DocumentHandler
    /// </summary>
    public class QSM_ALT_DocumentHandler : IHttpHandler
    {

        private Dictionary<string, string> _MIMETypes = new Dictionary<string, string>() {

            { ".mp4" , "video/mp4" },
            { ".pdf" , "application/pdf" },
            { ".docx" , "application/docx" },
            { ".xlsx" , "application/xlxs" },
            { ".xlsm" , "application/xlxm" }
        };

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.Clear();
                context.Response.ContentType = "application/pdf";


                System.Data.DataSet dsFile = null;
                CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();

                dsFile = cls_Cli.SP_32_GET_ARCHIVO(Convert.ToInt32(context.Request.QueryString["documentID"].ToString()));
                if (dsFile != null && dsFile.Tables.Count > 0 && dsFile.Tables[0].Rows.Count > 0)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])dsFile.Tables[0].Rows[0]["DATA_ARCHIVO"]);
                    string documentName = (dsFile.Tables[0].Rows[0]["NOMBRE_ARCHIVO"]).ToString();
                    //context.Response.ContentType = _MIMETypes[".pdf"];
                    //context.Response.ContentType = _MIMETypes[(dsFile.Tables[0].Rows[0]["TIPO_ARVIVO"]).ToString()];
                    string documentType = (dsFile.Tables[0].Rows[0]["TIPO_ARVIVO"]).ToString();
                    context.Response.ContentType = (dsFile.Tables[0].Rows[0]["TIPO_ARVIVO"]).ToString();
                    Byte[] documentoBlob = ms.ToArray();
                    string nombreCompleto = documentName;
                    if (context.Request.QueryString["form"].ToString() == "View")
                    {
                        if (documentType.ToString().ToUpper() != ".PDF")
                        {
                            context.Response.AddHeader("content-disposition", "inline; filename=" + nombreCompleto + documentType+ "");
                        }
                        else
                        {
                            context.Response.AddHeader("content-disposition", "inline; filename=" + nombreCompleto + "");
                        }
                        context.Response.BinaryWrite(documentoBlob);
                        context.Response.Flush();
                    }
                    else
                    {
                        if (documentType.ToString().ToUpper() != ".PDF")
                        {
                            context.Response.AddHeader("content-disposition", "attachment; filename=" + nombreCompleto + documentType+ "");
                        }
                        else
                        {
                            context.Response.AddHeader("content-disposition", "attachment; filename=" + nombreCompleto + "");
                        }
                        
                        context.Response.BinaryWrite(documentoBlob);
                        context.Response.Flush();
                    }


                }

                //}

                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Write("ERROR: " + ex.Message);
                context.Response.Write("\n");
                context.Response.Write(ex.StackTrace);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}