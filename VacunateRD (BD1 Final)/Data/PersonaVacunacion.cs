using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunateRD__BD1_Final_.Data
{
    public class PersonaVacunacion
    {

        public string Nombres { get; set; }
        public string Apelllidos { get; set; }

        public string Identificacion { get; set; }

        public DateTime Fechanacimiento { get; set; }

        public string Profesion { get; set; }
        public string CodigoFase { get; set; }
        public string NumMesa { get; set; }
        public string Centro { get; set; }
        public DateTime Fechaproporcionada { get; set; }
        public int  IdLote { get; set; }
        public int DosisCorrespondiente { get; set; }
        public string NombreVacuna { get; set; }
        public int Edad
        {
            get
            {
                TimeSpan span = DateTime.Now - Fechanacimiento;
                int years = (int)(span.Days / 365.25);
                return years;
            }
        }

    }
}
