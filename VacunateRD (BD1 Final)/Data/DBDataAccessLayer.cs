using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VacunateRD__BD1_Final_.Data.Data_models.VacunadosPorArea;
using VacunateRD__BD1_Final_.Data.Data_models.VacunasDisponibles;

namespace VacunateRD__BD1_Final_.Data
{
    public class DBDataAccessLayer
    {

        string s = "Server=tcp:vacunacion.database.windows.net,1433;Database=vacunacion_db;User ID=vacunacionadmin@vacunacion.database.windows.net;Password=Porfavor1;Trusted_Connection=False;Encrypt=True;";
        //Nueva Persona
        public void AddPersona(Persona p)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spInsertPersona", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoIdentificacion", p.idTipoIdentificacion);
                cmd.Parameters.AddWithValue("@IdProfesion", p.idProfesion);
                cmd.Parameters.AddWithValue("@Nombres", p.nombres);
                cmd.Parameters.AddWithValue("@Apellidos", p.apellidos);
                cmd.Parameters.AddWithValue("@Identificacion", p.identificacion);
                cmd.Parameters.AddWithValue("@FechaNacimiento", p.FechaNacimiento);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<PersonaVacunacion> GetPersonaData(string id)
        {
            List<PersonaVacunacion> personas = new List<PersonaVacunacion>();
            PersonaVacunacion p1 = new PersonaVacunacion();

            using (SqlConnection con = new SqlConnection(s))
            {

                SqlCommand cmd = new SqlCommand("spSelectVacunacionByIdentificacionPersona", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Identificacion", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    personas.Add(new PersonaVacunacion { 
                    Nombres = rdr["NOMBRES"].ToString(),
                    Apelllidos = rdr["APELLIDOS"].ToString(),
                    Identificacion = rdr["IDENTIFICACION"].ToString(),
                    Fechanacimiento = Convert.ToDateTime(rdr["FECHANACIMIENTO"]),
                    Profesion = rdr["PROFESION"].ToString(),
                    NumMesa  = rdr["NUMMESA"].ToString(),
                    CodigoFase = rdr["CODIGOFASE"].ToString(),
                    Centro = rdr["CENTRO"].ToString(),
                    Fechaproporcionada = Convert.ToDateTime(rdr["FECHAPROPORCIONADA"]),
                    IdLote = Convert.ToInt32(rdr["IDLOTE"]),
                    DosisCorrespondiente = Convert.ToInt32(rdr["DOSISCORRESPONDIENTE"]),
                    NombreVacuna = rdr["NOMBREVACUNA"].ToString(),
                    });     
                }
            }
            return personas;
        }
        private List<VacunadosPorRegion> GetVacunadosPorRegion()
        {
            List<VacunadosPorRegion> porRegion = new List<VacunadosPorRegion>();
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spCantidadVacunacionesPorRegion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["CANTIDADVACUNACIONES"]);
                    Console.WriteLine(rdr["REGION"]);
                    porRegion.Add(new VacunadosPorRegion(
                        rdr["REGION"].ToString(),
                        Convert.ToInt32(rdr["CANTIDADVACUNACIONES"])));
                }
            }
            return porRegion;
        }
        private List<VacunadosPorProvincia> GetVacunadosPorProvincia()
        {
            List<VacunadosPorProvincia> porProvincia = new List<VacunadosPorProvincia>();
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spCantidadVacunacionesPorProvincia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    porProvincia.Add(new VacunadosPorProvincia(
                        rdr["PROVINCIA"].ToString(),
                        Convert.ToInt32(rdr["CANTIDADVACUNACIONES"])));
                }
            }
            return porProvincia;
        }
        private List<VacunadosPorMunicipio> GetVacunadosPorMunicipio()
        {
            List<VacunadosPorMunicipio> porMunicipio = new List<VacunadosPorMunicipio>();
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spCantidadVacunacionesPorMunicipio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    porMunicipio.Add(new VacunadosPorMunicipio(
                        rdr["MUNICIPIO"].ToString(),
                        Convert.ToInt32(rdr["CANTIDADVACUNACIONES"])));
                }
            }
            return porMunicipio;
        }
        private List<VacunasDisponiblesPorRegion> GetVacunasDisponiblesPorRegion()
        {
            List<VacunasDisponiblesPorRegion> vacunasDisponiblesPorRegion = new List<VacunasDisponiblesPorRegion>();
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spVacunasDisponiblesRegion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    vacunasDisponiblesPorRegion.Add(new VacunasDisponiblesPorRegion(
                        rdr["REGION"].ToString(),
                        Convert.ToInt32(rdr["DOSISDISPONIBLES"])));
                }
            }
            return vacunasDisponiblesPorRegion;
        }

        private int GetVacunasDisponiblesCentral()
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spVacunasDisponiblesCentral", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public DatosEstadisticos GetStatsData()
        {
            return new DatosEstadisticos(
                GetVacunadosPorRegion(),
                GetVacunadosPorProvincia(),
                GetVacunadosPorMunicipio(),
                GetVacunasDisponiblesPorRegion(),
                GetVacunasDisponiblesCentral());
        }

        public List<Vacunador> getVacunadoresByCentro(int idCentro)
        {
            List<Vacunador> vacunadores = new List<Vacunador>();
            Vacunador v1 = new Vacunador();

            using (SqlConnection con = new SqlConnection(s))
            {

                SqlCommand cmd = new SqlCommand("spSelectVacunadorByIdCentro", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCentro", idCentro);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                     
                    vacunadores.Add(new Vacunador { Nombres = rdr["NOMBRES"].ToString(),
                        Apellidos = rdr["APELLIDOS"].ToString(),
                        IdVacunador = Convert.ToInt32(rdr["IDVACUNADOR"])
                    });
                }
                con.Close();
            }
            return vacunadores;
        }

        public IEnumerable<Lote> getLotesByCentro(int idCentro)
        {
            List<Lote> lotes = new List<Lote>();
            Lote L1 = new Lote();

            using (SqlConnection con = new SqlConnection(s))
            {

                SqlCommand cmd = new SqlCommand("GetLoteByIdCentro", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCentro", idCentro);
                con.Open();
                Lote L2 = new Lote{ Disponibles = 1, idLote= 1, Nombre = "", };

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lotes.Add(new Lote { Disponibles = Convert.ToInt32(rdr["DISPONIBLES"]), 
                        idLote = Convert.ToInt32(rdr["IDLOTE"]), 
                        Nombre = rdr["NOMBRE"].ToString(), });
                }
                return lotes;
            }
        }

        public List<MesaVacunacion> getMesaVacunacionByCentroID(int idCentro)
        {
            string query = "select IDMESAVACUNACION from TBL_MESAVACUNACION where IDCENTROVACUNACION = @idCentro";
            List<MesaVacunacion> Mesas = new List<MesaVacunacion>();
            MesaVacunacion m1 = new MesaVacunacion();
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand CMD = new SqlCommand(query, con);
                CMD.Parameters.AddWithValue("@idCentro", idCentro);
                con.Open();
                SqlDataReader rdr = CMD.ExecuteReader();
                while (rdr.Read())
                {
              
                    Mesas.Add(new MesaVacunacion { idMesaVacunacion = Convert.ToInt32(rdr["IDMESAVACUNACION"])} );
                }
                con.Close();
            }
            return Mesas;
        }
        public void AddVacunacion(Vacunacion V)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                //@idPersona int, @idLote int, @idMesaVacunacion int, @Dosis tinyint, @idVacunador int
                SqlCommand cmd = new SqlCommand("spInsertVacunacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", V.idPersona);
                cmd.Parameters.AddWithValue("@idLote", V.idLote);
                cmd.Parameters.AddWithValue("@idMesaVacunacion", V.idMesaVacunacion);
                cmd.Parameters.AddWithValue("@Dosis", V.Dosis);
                cmd.Parameters.AddWithValue("@idVacunador", V.idVacuandor);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public int getPersonaIdByIdentificacion(string identificacion)
        {
            string query = "select IDPERSONA FROM TBL_PERSONA WHERE IDENTIFICACION = @IDENTIFICACION";
            int idPersona = 0;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand CMD = new SqlCommand(query, con);
                CMD.Parameters.AddWithValue("@IDENTIFICACION", identificacion);
                con.Open();
                SqlDataReader rdr = CMD.ExecuteReader();
                while (rdr.Read())
                {
                    idPersona = Convert.ToInt32(rdr["IDPERSONA"]);
                    
                }
                con.Close();
            }
            return idPersona;
        }

        public List<CentroVacunacion> GetAllCentroVacunacion()
        {
            List<CentroVacunacion> centrosVacunacion = new List<CentroVacunacion>();
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spSelectAllCentroVacunacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    centrosVacunacion.Add(new CentroVacunacion { 
                        idCentroVacunacion = Convert.ToInt32(rdr["IDCENTROVACUNACION"]), 
                        Nombre= rdr["NOMBRE"].ToString()
                    });
                }
            }
            return centrosVacunacion;
        }
    }
}
