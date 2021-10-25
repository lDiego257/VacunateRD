using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunateRD__BD1_Final_.Data.Data_models.VacunasDisponibles
{
    public class VacunasDisponiblesPorRegion
    {
        public string Region { get; set; }
        public int Cantidad { get; set; }
        public VacunasDisponiblesPorRegion(string region, int cantidad)
        {
            this.Region = region;
            this.Cantidad = cantidad;
        }
    }
}
