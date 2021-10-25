using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VacunateRD__BD1_Final_.Data
{
    public class Persona
    {
        public int idPersona { get; set; }
        public int idTipoIdentificacion { get; set; }
        public int idProfesion { get; set; }
        public int idFase { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            {
                TimeSpan span = DateTime.Now - FechaNacimiento;
                int years = (int)(span.Days / 365.25);
                return years;
            }
        }
    }
}
