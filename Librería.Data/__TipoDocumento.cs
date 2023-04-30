using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class __TipoDocumento
    {
        Entidades.__TipoDocumento eTipoDocumento = new Entidades.__TipoDocumento();

        public bool AgregarTipoDocumento(Entidades.__TipoDocumento eTipoDocumento)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into TipoDocumento(IdClasificacionTipoDocumento, NombreTipoDocumento, IdEstado) " +
                    "values(@IdClasificacionTipoDocumento, @NombreTipoDocumento, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdClasificacionTipoDocumento", eTipoDocumento.IdClasificacionTipoDocumento);
                Cmd.Parameters.AddWithValue("@NombreTipoDocumento", eTipoDocumento.NombreTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdEstado", eTipoDocumento.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.__TipoDocumento> ListaTipoDocumento()
        {
            List<Entidades.__TipoDocumento> oLista = new List<Entidades.__TipoDocumento>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdTipoDocumento, IdClasificacionTipoDocumento, NombreTipoDocumento, IdEstado " +
                    "from TipoDocumento";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__TipoDocumento()
                        {
                            IdTipoDocumento = int.Parse(Dr["IdTipoDocumento"].ToString()),
                            IdClasificacionTipoDocumento = int.Parse(Dr["IdClasificacionTipoDocumento"].ToString()),
                            NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString(),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__TipoDocumento> ListaTipoDocumento(int IdTipoDocumento)
        {
            List<Entidades.__TipoDocumento> oLista = new List<Entidades.__TipoDocumento>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdTipoDocumento, IdClasificacionTipoDocumento, NombreTipoDocumento, IdEstado " +
                    "from TipoDocumento where IdTipoDocumento = @IdTipoDocumento";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", IdTipoDocumento);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__TipoDocumento()
                        {
                            IdTipoDocumento = int.Parse(Dr["IdTipoDocumento"].ToString()),
                            IdClasificacionTipoDocumento = int.Parse(Dr["IdClasificacionTipoDocumento"].ToString()),
                            NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString(),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarTipoDocumento(Entidades.__TipoDocumento eTipoDocumento)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update TipoDocumento set IdClasificacionTipoDocumento = @IdClasificacionTipoDocumento," +
                    "NombreTipoDocumento = @NombreTipoDocumento, IdEstado = @IdEstado where IdTipoDocumento = @IdTipoDocumento";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eTipoDocumento.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdClasificacionTipoDocumento", eTipoDocumento.IdClasificacionTipoDocumento);
                Cmd.Parameters.AddWithValue("@NombreTipoDocumento", eTipoDocumento.NombreTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdEstado", eTipoDocumento.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarTipoDocumento(Entidades.__TipoDocumento eTipoDocumento)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from TipoDocumento where IdTipoDocumento = @IdTipoDocumento";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eTipoDocumento.IdTipoDocumento);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}