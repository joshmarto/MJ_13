﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class Predicadores
    {
        public int ID { set; get; }
        public int Nombre { set; get; }
        public int Telefono { set; get; }
        public int Email { set; get; }
        public int Tipo { set; get; }

        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}