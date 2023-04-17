using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class Estado
    {
        Entidades.Estado eEstado = new Entidades.Estado();

        public bool AgregarEstado(Entidades.Estado eEstado)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into Estado(NombreEstado) values(@NombreEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@NombreEstado", eEstado.NombreEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.Estado> ListaEstado()
        {
            List<Entidades.Estado> oLista = new List<Entidades.Estado>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdEstado, NombreEstado from Estado";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Estado()
                        {
                            IdEstado = int.Parse(Dr["IdEstado"].ToString()),
                            NombreEstado = Dr["NombreEstado"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.Estado> ListaEstado(int IdEstado)
        {
            List<Entidades.Estado> oLista = new List<Entidades.Estado>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdEstado, NombreEstado from Estado where IdEstado = @IdEstado";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEstado", IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Estado()
                        {
                            IdEstado = int.Parse(Dr["IdEstado"].ToString()),
                            NombreEstado = Dr["NombreEstado"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarEstado(Entidades.Estado eEstado)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update Estado set NombreEstado = @NombreEstado where IdEstado = @IdEstado";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEstado", eEstado.IdEstado);
                Cmd.Parameters.AddWithValue("@NombreEstado", eEstado.NombreEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarEstado(Entidades.Estado eEstado)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from Estado where IdEstado = @IdEstado";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEstado", eEstado.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}
