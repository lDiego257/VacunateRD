using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunateRD__BD1_Final_.Data.Data_models.VacunadosPorArea
{
    public abstract class VacunadosPorArea
    {
        public string NombreArea { get; set; }
        public int CantidadArea { get; set; }
        public VacunadosPorArea(string nombre, int cantidad)
        {
            this.NombreArea = nombre;
            this.CantidadArea = cantidad;
        }
    }
}
