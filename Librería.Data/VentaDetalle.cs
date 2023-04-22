using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class VentaDetalle
    {
        Entidades.VentaDetalle eVentaDetalle = new Entidades.VentaDetalle();
        string query = string.Empty;
        SQLiteCommand Cmd;

        public bool AgregarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                query = "insert into VentaDetalle(IdVenta, Cantidad, Descripcion, Precio, Importe, IdEstado) values(@IdVenta, @Cantidad, @Descripcion, @Precio, @Importe, @IdEstado)";
                Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVenta", eVentaDetalle.IdVenta);
                Cmd.Parameters.AddWithValue("@Cantidad", eVentaDetalle.Cantidad);
                Cmd.Parameters.AddWithValue("@Descripcion", eVentaDetalle.Descripcion);
                Cmd.Parameters.AddWithValue("@Precio", eVentaDetalle.Precio);
                Cmd.Parameters.AddWithValue("@Importe", eVentaDetalle.Importe);
                Cmd.Parameters.AddWithValue("@IdEstado", eVentaDetalle.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.VentaDetalle> ListaVentaDetalle()
        {
            List<Entidades.VentaDetalle> oLista = new List<Entidades.VentaDetalle>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                query = "Select IdVentaDetalle, IdVenta, Cantidad, Descripcion, Precio, Importe, IdEstado from VentaDetalle";
                Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.VentaDetalle()
                        {
                            IdVentaDetalle = int.Parse(Dr["IdVentaDetalle"].ToString()),
                            IdVenta = int.Parse(Dr["IdEmpresa"].ToString()),
                            Cantidad = int.Parse(Dr["IdTipoDocumento"].ToString()),
                            Descripcion = Dr["IdUsuario"].ToString(),
                            Precio = decimal.Parse(Dr["NroDocumento"].ToString()),
                            Importe = decimal.Parse(Dr["FechaVentaDetalle"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.VentaDetalle> ListaVentaDetalle(string nombreObjeto, string valor)
        {
            List<Entidades.VentaDetalle> oLista = new List<Entidades.VentaDetalle>();

            switch (nombreObjeto)
            {
                case "IdVentaDetalle":
                    using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
                    {
                        Cnx.Open();
                        query = "Select IdVentaDetalle, IdVenta, Cantidad, Descripcion, Precio, Importe, IdEstado from VentaDetalle where IdVentaDetalle = '@IdVentaDetalle'";
                        Cmd = new SQLiteCommand(query, Cnx);
                        Cmd.CommandType = System.Data.CommandType.Text;

                        using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                            {
                                oLista.Add(new Entidades.VentaDetalle()
                                {
                                    IdVentaDetalle = int.Parse(Dr["IdVentaDetalle"].ToString()),
                                    IdVenta = int.Parse(Dr["IdVenta"].ToString()),
                                    Cantidad = int.Parse(Dr["Cantidad"].ToString()),
                                    Descripcion = Dr["Descripcion"].ToString(),
                                    Precio = decimal.Parse(Dr["Precio"].ToString()),
                                    Importe = decimal.Parse(Dr["Importe"].ToString()),
                                    IdEstado = int.Parse(Dr["IdEstado"].ToString())
                                });
                            }
                        }
                    }
                    break;
                case "IdVenta":
                    using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
                    {
                        Cnx.Open();
                        query = "Select IdVentaDetalle, IdVenta, Cantidad, Descripcion, Precio, Importe, IdEstado from VentaDetalle where IdVenta = '" + valor + "'";
                        SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                        Cmd.CommandType = CommandType.Text;
                        using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                            {
                                oLista.Add(new Entidades.VentaDetalle()
                                {
                                    IdVentaDetalle = int.Parse(Dr["IdVentaDetalle"].ToString()),
                                    IdVenta = int.Parse(Dr["IdVenta"].ToString()),
                                    Cantidad = int.Parse(Dr["Cantidad"].ToString()),
                                    Descripcion = Dr["Descripcion"].ToString(),
                                    Precio = decimal.Parse(Dr["Precio"].ToString()),
                                    Importe = decimal.Parse(Dr["Importe"].ToString()),
                                    IdEstado = int.Parse(Dr["IdEstado"].ToString())
                                });
                            }
                        }
                        break;
                    }
            }

            return oLista;
        }

        public List<Entidades.VentaDetalle> ListaVentaDetalle(int IdVentaDetalle)
        {
            List<Entidades.VentaDetalle> oLista = new List<Entidades.VentaDetalle>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdVentaDetalle, IdVenta, Cantidad, Descripcion, Precio, Importe, IdEstado from VentaDetalle where IdVentaDetalle = @IdVentaDetalle";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVentaDetalle", IdVentaDetalle);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.VentaDetalle()
                        {
                            IdVentaDetalle = int.Parse(Dr["IdVentaDetalle"].ToString()),
                            IdVenta = int.Parse(Dr["IdEmpresa"].ToString()),
                            Cantidad = int.Parse(Dr["IdTipoDocumento"].ToString()),
                            Descripcion = Dr["IdUsuario"].ToString(),
                            Precio = decimal.Parse(Dr["NroDocumento"].ToString()),
                            Importe = decimal.Parse(Dr["FechaVentaDetalle"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update VentaDetalle set IdVenta = @IdVenta, Cantidad = @Cantidad, Descripcion = @Descripcion, " +
                    "Precio = @Precio, Importe = @Importe, IdEstado = @IdEstado where IdVentaDetalle = @IdVentaDetalle";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVentaDetalle", eVentaDetalle.IdVentaDetalle);
                Cmd.Parameters.AddWithValue("@IdVenta", eVentaDetalle.IdVenta);
                Cmd.Parameters.AddWithValue("@Cantidad", eVentaDetalle.Cantidad);
                Cmd.Parameters.AddWithValue("@Descripcion", eVentaDetalle.Descripcion);
                Cmd.Parameters.AddWithValue("@Precio", eVentaDetalle.Precio);
                Cmd.Parameters.AddWithValue("@Importe", eVentaDetalle.Importe);
                Cmd.Parameters.AddWithValue("@IdEstado", eVentaDetalle.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from VentaDetalle where IdVentaDetalle = @IdVentaDetalle";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVentaDetalle", eVentaDetalle.IdVentaDetalle);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}
