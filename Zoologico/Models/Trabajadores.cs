//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoologico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trabajadores
    {
        public int id_Trabajador { get; set; }
        public string Cedula_Trabajador { get; set; }
        public string Nombre_Trabajador { get; set; }
        public string Apellido_Trabajador { get; set; }
        public string Telefono_Trabajador { get; set; }
        public string Direccion_Trabajador { get; set; }
        public string Id_Zona { get; set; }
        public Nullable<int> idRol_Trabajador { get; set; }
        public string password_Trabajador { get; set; }
        public string Correo_Trabajador { get; set; }
        public Nullable<int> Edad_Trabajador { get; set; }
    
        public virtual Rol Rol { get; set; }
        public virtual Zonas Zonas { get; set; }
    }
}