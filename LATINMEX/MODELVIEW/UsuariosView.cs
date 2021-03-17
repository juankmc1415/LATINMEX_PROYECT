using System;

namespace LATINMEX.MODELVIEW
{
    public class UsuariosView
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public bool ForzarContraseña { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public byte[] Foto { get; set; }
        public string Roles { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraActualizacion { get; set; }

        public string Estado => ((ESTADOS_USUARIO)IdEstado).ToString();

        //Cargo la image a base 64 para mostrarla
       public string FotoBase64 => Foto!=null && Foto.Length>0?
                                       "data:image;base64," + Convert.ToBase64String(Foto): "../Files/perfilusuarios.png";

    }
}