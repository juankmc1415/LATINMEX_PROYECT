using LATINMEX.Datos.PRODUCTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMesOS3.HANDLERS
{
    /// <summary>
    /// Summary description for QSM_ALT_ImageHandler
    /// </summary>
    public class QSM_ALT_ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "image/png";

            System.Data.DataSet dsImagen = null;
            Int32 PK_IMG = -1;
            if (Int32.TryParse(context.Request.QueryString["PK"].ToString(), out PK_IMG))
            {
                CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
                dsImagen = cls_Cli.SP_32_GET_ARCHIVO(PK_IMG);
            }
            else
            {
                int imageWidth = 200;
                int imageHeight = 150;

                System.Drawing.Bitmap blankImage = new System.Drawing.Bitmap(imageWidth, imageHeight);
                using (System.Drawing.Graphics blankGraphics = System.Drawing.Graphics.FromImage(blankImage))
                {
                    blankGraphics.FillRectangle(System.Drawing.Brushes.White, 0, 0, blankImage.Width, blankImage.Height);
                    blankGraphics.DrawString("No hay imagen", new System.Drawing.Font("Arial", 16), System.Drawing.Brushes.Black, new System.Drawing.PointF(imageWidth / 2 - 64, imageHeight / 2 - 10));
                }

                blankImage.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                return;
            }


            if (dsImagen != null && dsImagen.Tables.Count > 0 && dsImagen.Tables[0].Rows.Count > 0)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])dsImagen.Tables[0].Rows[0]["DATA_ARCHIVO"]);

                System.Drawing.Image altImage = System.Drawing.Image.FromStream(ms);

                if (altImage != null)
                {
                    ms.WriteTo(context.Response.OutputStream);
                }
                else
                {
                    int imageWidth = 200;
                    int imageHeight = 150;

                    System.Drawing.Bitmap blankImage = new System.Drawing.Bitmap(imageWidth, imageHeight);
                    using (System.Drawing.Graphics blankGraphics = System.Drawing.Graphics.FromImage(blankImage))
                    {
                        blankGraphics.FillRectangle(System.Drawing.Brushes.White, 0, 0, blankImage.Width, blankImage.Height);
                        blankGraphics.DrawString("No hay imagen", new System.Drawing.Font("Arial", 16), System.Drawing.Brushes.Black, new System.Drawing.PointF(imageWidth / 2 - 64, imageHeight / 2 - 10));
                    }

                    blankImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.WriteTo(context.Response.OutputStream);
                }
            }
            else
            {
                int imageWidth = 200;
                int imageHeight = 150;

                System.Drawing.Bitmap blankImage = new System.Drawing.Bitmap(imageWidth, imageHeight);
                using (System.Drawing.Graphics blankGraphics = System.Drawing.Graphics.FromImage(blankImage))
                {
                    blankGraphics.FillRectangle(System.Drawing.Brushes.White, 0, 0, blankImage.Width, blankImage.Height);
                    blankGraphics.DrawString("No hay imagen", new System.Drawing.Font("Arial", 16), System.Drawing.Brushes.Black, new System.Drawing.PointF(imageWidth / 2 - 64, imageHeight / 2 - 10));
                }

                blankImage.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
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