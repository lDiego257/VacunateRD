using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunateRD__BD1_Final_.Data
{
    public class Vacunacion
    {
        public int idPersona { get; set; }
        public int idLote { get; set; }
        public int idMesaVacunacion { get; set; }
        public int Dosis { get; set; }
        public int idVacuandor { get; set; }
    }
}
