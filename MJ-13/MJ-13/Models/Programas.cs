using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class Programas
    {
        public int ID { set; get; }
        public string Programa { set; get; }
        public int LiderID { set; get; }
        public string Descripcion { set; get; }
        public string Observaciones { set; get; }

        public virtual Lideres Lider { get; set; }
        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}