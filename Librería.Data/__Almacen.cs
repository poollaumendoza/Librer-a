using Librería.Data.Properties;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Librería.Data
{
    public class __Almacen
    {
        Entidades.__Almacen eAlmacen = new Entidades.__Almacen();

        public bool AgregarAlmacen(Entidades.__Almacen eAlmacen)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into almacen(NombreAlmacen, Direccion, IdEstado) values(@NombreAlmacen, @Direccion, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@NombreAlmacen", eAlmacen.NombreAlmacen);
                Cmd.Parameters.AddWithValue("@Direccion", eAlmacen.Direccion);
                Cmd.Parameters.AddWithValue("@IdEstado", eAlmacen.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.__Almacen> ListaAlmacen()
        {
            List<Entidades.__Almacen> oLista = new List<Entidades.__Almacen>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdAlmacen, NombreAlmacen, Direccion, IdEstado from Almacen";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Almacen()
                        {
                            IdAlmacen = int.Parse(Dr["IdAlmacen"].ToString()),
                            NombreAlmacen = Dr["NombreAlmacen"].ToString(),
                            Direccion = Dr["Direccion"].ToString(),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__Almacen> ListaAlmacen(int IdAlmacen)
        {
            List<Entidades.__Almacen> oLista = new List<Entidades.__Almacen>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdAlmacen, NombreAlmacen, Direccion, IdEstado from Almacen where IdAlmacen = @IdAlmacen";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdAlmacen", IdAlmacen);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Almacen()
                        {
                            IdAlmacen = int.Parse(Dr["IdAlmacen"].ToString()),
                            NombreAlmacen = Dr["NombreAlmacen"].ToString(),
                            Direccion = Dr["Direccion"].ToString(),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarAlmacen(Entidades.__Almacen eAlmacen)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update almacen set NombreAlmacen = @NombreAlmacen, Direccion = @Direccion, IdEstado = @IdEstado where IdAlmacen = @IdAlmacen";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdAlmacen", eAlmacen.IdAlmacen);
                Cmd.Parameters.AddWithValue("@NombreAlmacen", eAlmacen.NombreAlmacen);
                Cmd.Parameters.AddWithValue("@Direccion", eAlmacen.Direccion);
                Cmd.Parameters.AddWithValue("@IdEstado", eAlmacen.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarAlmacen(Entidades.__Almacen eAlmacen)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from Almacen where IdAlmacen = @IdAlmacen";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdAlmacen", eAlmacen.IdAlmacen);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}