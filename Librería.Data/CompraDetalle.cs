using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Librería.Data
{
    public class CompraDetalle
    {
        Entidades.CompraDetalle eCompraDetalle = new Entidades.CompraDetalle();
        string query = string.Empty;
        SQLiteCommand Cmd;

        public bool AgregarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                query = "insert into CompraDetalle(IdCompra, Cantidad, Descripcion, Precio, Importe, IdEstado) values(@IdCompra, @Cantidad, @Descripcion, @Precio, @Importe, @IdEstado)";
                Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCompra", eCompraDetalle.IdCompra);
                Cmd.Parameters.AddWithValue("@Cantidad", eCompraDetalle.Cantidad);
                Cmd.Parameters.AddWithValue("@Descripcion", eCompraDetalle.Descripcion);
                Cmd.Parameters.AddWithValue("@Precio", eCompraDetalle.Precio);
                Cmd.Parameters.AddWithValue("@Importe", eCompraDetalle.Importe);
                Cmd.Parameters.AddWithValue("@IdEstado", eCompraDetalle.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.CompraDetalle> ListaCompraDetalle()
        {
            List<Entidades.CompraDetalle> oLista = new List<Entidades.CompraDetalle>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                query = "Select IdCompraDetalle, IdCompra, Cantidad, Descripcion, Precio, Importe, IdEstado from CompraDetalle";
                Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.CompraDetalle()
                        {
                            IdCompraDetalle = int.Parse(Dr["IdCompraDetalle"].ToString()),
                            IdCompra = int.Parse(Dr["IdEmpresa"].ToString()),
                            Cantidad = int.Parse(Dr["IdTipoDocumento"].ToString()),
                            Descripcion = Dr["IdUsuario"].ToString(),
                            Precio = decimal.Parse(Dr["NroDocumento"].ToString()),
                            Importe = decimal.Parse(Dr["FechaCompraDetalle"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.CompraDetalle> ListaCompraDetalle(string nombreObjeto, string valor)
        {
            List<Entidades.CompraDetalle> oLista = new List<Entidades.CompraDetalle>();

            switch (nombreObjeto)
            {
                case "IdCompraDetalle":
                    using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
                    {
                        Cnx.Open();
                        query = "Select IdCompraDetalle, IdCompra, Cantidad, Descripcion, Precio, Importe, IdEstado from CompraDetalle where IdCompraDetalle = '@IdCompraDetalle'";
                        Cmd = new SQLiteCommand(query, Cnx);
                        Cmd.CommandType = System.Data.CommandType.Text;
                         
                        using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                            {
                                oLista.Add(new Entidades.CompraDetalle()
                                {
                                    IdCompraDetalle = int.Parse(Dr["IdCompraDetalle"].ToString()),
                                    IdCompra = int.Parse(Dr["IdCompra"].ToString()),
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
                case "IdCompra":
                    using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
                    {
                        Cnx.Open();
                        query = "Select IdCompraDetalle, IdCompra, Cantidad, Descripcion, Precio, Importe, IdEstado from CompraDetalle where IdCompra = @IdCompra";
                        SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                        Cmd.Parameters.AddWithValue("@IdCompra", valor);
                        Cmd.CommandType = CommandType.Text;
                        using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                            {
                                oLista.Add(new Entidades.CompraDetalle()
                                {
                                    IdCompraDetalle = int.Parse(Dr["IdCompraDetalle"].ToString()),
                                    IdCompra = int.Parse(Dr["IdCompra"].ToString()),
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

        public List<Entidades.CompraDetalle> ListaCompraDetalle(int IdCompraDetalle)
        {
            List<Entidades.CompraDetalle> oLista = new List<Entidades.CompraDetalle>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdCompraDetalle, IdCompra, Cantidad, Descripcion, Precio, Importe, IdEstado from CompraDetalle where IdCompraDetalle = @IdCompraDetalle";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCompraDetalle", IdCompraDetalle);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.CompraDetalle()
                        {
                            IdCompraDetalle = int.Parse(Dr["IdCompraDetalle"].ToString()),
                            IdCompra = int.Parse(Dr["IdEmpresa"].ToString()),
                            Cantidad = int.Parse(Dr["IdTipoDocumento"].ToString()),
                            Descripcion = Dr["IdUsuario"].ToString(),
                            Precio = decimal.Parse(Dr["NroDocumento"].ToString()),
                            Importe = decimal.Parse(Dr["FechaCompraDetalle"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update CompraDetalle set IdCompra = @IdCompra, Cantidad = @Cantidad, Descripcion = @Descripcion, " +
                    "Precio = @Precio, Importe = @Importe, IdEstado = @IdEstado where IdCompraDetalle = @IdCompraDetalle";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCompraDetalle", eCompraDetalle.IdCompraDetalle);
                Cmd.Parameters.AddWithValue("@IdCompra", eCompraDetalle.IdCompra);
                Cmd.Parameters.AddWithValue("@Cantidad", eCompraDetalle.Cantidad);
                Cmd.Parameters.AddWithValue("@Descripcion", eCompraDetalle.Descripcion);
                Cmd.Parameters.AddWithValue("@Precio", eCompraDetalle.Precio);
                Cmd.Parameters.AddWithValue("@Importe", eCompraDetalle.Importe);
                Cmd.Parameters.AddWithValue("@IdEstado", eCompraDetalle.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from CompraDetalle where IdCompraDetalle = @IdCompraDetalle";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCompraDetalle", eCompraDetalle.IdCompraDetalle);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}