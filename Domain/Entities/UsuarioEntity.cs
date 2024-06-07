using System;

namespace Domain.Entities
{   
    
    public class UsuarioEntity
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni {  get; set; }
        public string Usuario { get; set;}
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public RolesEntity Rol { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set;}
        public string Telefono { get; set;}
        public DateTime FechaRegistro { get; set; }
    }
}
