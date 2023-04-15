using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class CompraDetalle
    {
        Entidades.CompraDetalle eCompraDetalle = new Entidades.CompraDetalle();

        public bool AgregarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into CompraDetalle(IdCompra, Cantidad, Descripcion, Precio, Importe, IdEstado) values(@IdCompra, @Cantidad, @Descripcion, @Precio, @Importe, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
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
                string query = "Select IdCompraDetalle, IdCompra, Cantidad, Descripcion, Precio, Importe, IdEstado from CompraDetalle";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
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
                string query = "Delete CompraDetalle where IdCompraDetalle = @IdCompraDetalle";
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