using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class Tareas
    {
        public int ID { set; get; }
        public string Tarea { set; get; }
        public int LiderID { set; get; }
        public string FechaInicio { set; get; }
        public string FechaFinal { set; get; }

        public virtual Lideres Lider { set; get; }
    }
}