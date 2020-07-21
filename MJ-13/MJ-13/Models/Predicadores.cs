using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class Predicadores
    {
        public int ID { set; get; }
        public string Nombre { set; get; }
        public string Telefono { set; get; }
        public string Email { set; get; }
        public int TipoID { set; get; }
        public int ClasificacionID { set; get; }
        public string Localidad { set; get; }

        public virtual TipoP Tipo { get; set; }
        public virtual Clasificaciones Clasificacion { get; set; }
        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}