using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class Clasificaciones
    {
        public int ID { set; get; }
        public string Clasificacion { set; get; }

        public virtual ICollection<Predicadores> Predicadores { get; set; }
    }
}