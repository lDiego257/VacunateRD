using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacunateRD__BD1_Final_.Data.Data_models.VacunadosPorArea;
using VacunateRD__BD1_Final_.Data.Data_models.VacunasDisponibles;

namespace VacunateRD__BD1_Final_.Data
{
    public class DatosEstadisticos
    {
        public List<VacunadosPorRegion> VacunadosPorRegion { get; set; }
        public List<VacunadosPorProvincia> VacunadosPorProvincia { get; set; }
        public List<VacunadosPorMunicipio> VacunadosPorMunicipio { get; set; }
        public List<VacunasDisponiblesPorRegion> VacunasDisponiblesPorRegion { get; set; }
        public int VacunasDisponiblesCentral { get; set; }

        public DatosEstadisticos(
            List<VacunadosPorRegion> porRegion,
            List<VacunadosPorProvincia> porProvincia,
            List<VacunadosPorMunicipio> porMunicipio,
            List<VacunasDisponiblesPorRegion> vacunasDisponiblesPorRegion,
            int vacunasDisponiblesEnCentral)
        {
            this.VacunadosPorRegion = porRegion;
            this.VacunadosPorProvincia = porProvincia;
            this.VacunadosPorMunicipio = porMunicipio;
            this.VacunasDisponiblesPorRegion = vacunasDisponiblesPorRegion;
            this.VacunasDisponiblesCentral = vacunasDisponiblesEnCentral;
        }

    }
}
