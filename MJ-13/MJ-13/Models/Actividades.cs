using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJ_13.Models
{
    public class Actividades
    {
        public int ID { set; get; }
        public int Numero { set; get; }
        public string Fecha { set; get; }
        public string Medio { set; get; }
        public string Actividad { set; get; }
        public int LiderID { set; get; }
        public string ActividadL { set; get; }
        public int LeaderID { set; get; }
        public int PredicadorID { set; get; }
        public string PredicadorTipo { set; get; }
        public string Tema { set; get; }
        public string CitaBase { set; get; }
        public int NoParticipantes { set; get; }
        public int ProgramaID { set; get; }
        public bool Realizada { set; get; }
        public string Observaciones { set; get; }

        public virtual Miembros Lider { get; set; }
        public virtual Miembros Leader { get; set; }
        public virtual Programas Programa { get; set; }
        public virtual Predicadores Predicador { get; set; }
    }
}