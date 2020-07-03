using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class Lideres
    {
        public int ID { set; get; }
        public string Nombre { set; get; }
        public string Telefono { set; get; }
        public string Email { set; get; }

        public virtual ICollection<Actividades> Actividades { get; set; }
        public virtual ICollection<Tareas> Tareas { get; set; }
        public virtual ICollection<Programas> Programas { get; set; }
    }
}