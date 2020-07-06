using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class TipoP
    {
        public int ID { set; get; }
        public string Tipo { set; get; }

        public virtual ICollection<Predicadores> Predeicadores { get; set; }
    }
}