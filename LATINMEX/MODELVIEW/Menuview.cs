namespace LATINMEX.MODELVIEW
{
    public class MenuView
    {
        public int IdMenu { get; set; }
        public string Texto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Icono { get; set; }
        public string Url { get; set; }
        public int? IdMenuParent { get; set; }
        public int Orden { get; set; }
        public int? IdRol { get; set; }
        public int CantidadMenuHijos { get; set; }

    }
}