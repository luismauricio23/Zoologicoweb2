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
    
    public partial class Citas
    {
        public string Codigo_Cita { get; set; }
        public Nullable<System.DateTime> Hora_inicio_Cita { get; set; }
        public Nullable<System.DateTime> Hora_fin_Cita { get; set; }
        public string Diagnostico_Cita { get; set; }
        public string Observaciones { get; set; }
        public string Cedula_Veterinario { get; set; }
        public string Id_Animal { get; set; }
    
        public virtual Animales Animales { get; set; }
        public virtual Veterinario Veterinario { get; set; }
    }
}