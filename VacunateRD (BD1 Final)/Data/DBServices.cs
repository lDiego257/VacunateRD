using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunateRD__BD1_Final_.Data
{
    public class DBServices
    {
        DBDataAccessLayer dbAccess = new DBDataAccessLayer();
        public string Create(Persona p1)
        {
            //DBDataAccessLayer dbAccess = new DBDataAccessLayer();
            dbAccess.AddPersona(p1);
            return "Exito";
        }
        public List<PersonaVacunacion> GetPersonaDataByIdentificacion(string id)
        {
            //DBDataAccessLayer dbAccess = new DBDataAccessLayer();
            return dbAccess.GetPersonaData(id);
            
        }

        public List<Vacunador> GetVacunadoresById(int id)
        {
            return dbAccess.getVacunadoresByCentro(id);
        }
        public List<Lote> getLotesByCentroId(int id)
        {
            List<Lote> Lotes = new List<Lote>();
            Lotes = dbAccess.getLotesByCentro(id).ToList();
            return Lotes;
        }

        public List<MesaVacunacion> getMesasByCentroId(int id)
        {
            return dbAccess.getMesaVacunacionByCentroID(id);
		}

        public DatosEstadisticos GetDatosEstadisticos()
        {
            return dbAccess.GetStatsData();
        }
        public string addVacunacion(Vacunacion v1)
        {
            //DBDataAccessLayer dbAccess = new DBDataAccessLayer();
            dbAccess.AddVacunacion(v1);
            return "Exito";
        }
        public int getIdPersonaByIdentificacion(string identificacion)
        {
            return dbAccess.getPersonaIdByIdentificacion(identificacion);
        }

        public List<CentroVacunacion> getAllCentros()
        {
            return dbAccess.GetAllCentroVacunacion();
        }
    }
}
