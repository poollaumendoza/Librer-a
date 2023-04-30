using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class __Estado
    {
        Entidades.__Estado eEstado = new Entidades.__Estado();

        public bool AgregarEstado(Entidades.__Estado eEstado)
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

        public List<Entidades.__Estado> ListaEstado()
        {
            List<Entidades.__Estado> oLista = new List<Entidades.__Estado>();

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
                        oLista.Add(new Entidades.__Estado()
                        {
                            IdEstado = int.Parse(Dr["IdEstado"].ToString()),
                            NombreEstado = Dr["NombreEstado"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__Estado> ListaEstado(int IdEstado)
        {
            List<Entidades.__Estado> oLista = new List<Entidades.__Estado>();

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
                        oLista.Add(new Entidades.__Estado()
                        {
                            IdEstado = int.Parse(Dr["IdEstado"].ToString()),
                            NombreEstado = Dr["NombreEstado"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarEstado(Entidades.__Estado eEstado)
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

        public bool EliminarEstado(Entidades.__Estado eEstado)
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
