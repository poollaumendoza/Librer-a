using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class Venta
    {
        Entidades.Venta eVenta = new Entidades.Venta();

        public bool AgregarVenta(Entidades.Venta eVenta)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into Venta(IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, IdCorrelativo, Correlativo, FechaVenta, FechaRegistro, SubTotal, Impuesto, Total, " +
                    "IdEstado) values(@IdEmpresa, @IdEntidad, @IdTipoDocumento, @IdUsuario, @IdCorrelativo, @Correlativo, @FechaVenta, @FechaRegistro, @SubTotal, @Impuesto, @Total, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eVenta.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdEntidad", eVenta.IdCliente);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eVenta.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdUsuario", eVenta.IdUsuario);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", eVenta.IdCorrelativo);
                Cmd.Parameters.AddWithValue("@Correlativo", eVenta.Correlativo);
                Cmd.Parameters.AddWithValue("@FechaVenta", eVenta.FechaVenta);
                Cmd.Parameters.AddWithValue("@FechaRegistro", eVenta.FechaRegistro);
                Cmd.Parameters.AddWithValue("@SubTotal", eVenta.SubTotal);
                Cmd.Parameters.AddWithValue("@Impuesto", eVenta.Impuesto);
                Cmd.Parameters.AddWithValue("@Total", eVenta.Total);
                Cmd.Parameters.AddWithValue("@IdEstado", eVenta.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.Venta> ListaVenta()
        {
            List<Entidades.Venta> oLista = new List<Entidades.Venta>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdVenta, IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, IdSerie, Correlativo, FechaVenta, FechaRegistro, SubTotal, Impuesto, Total, " +
                    "IdEstado from Venta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Venta()
                        {
                            IdVenta = int.Parse(Dr["IdVenta"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            IdCliente = Dr["IdEntidad"].ToString(),
                            IdTipoDocumento = Dr["IdTipoDocumento"].ToString(),
                            IdUsuario = Dr["IdUsuario"].ToString(),
                            IdCorrelativo = Convert.ToInt32(Dr["IdSerie"].ToString()),
                            Correlativo = Dr["Correlativo"].ToString(),
                            FechaVenta = Dr["FechaVenta"].ToString(),
                            FechaRegistro = Dr["FechaRegistro"].ToString(),
                            SubTotal = decimal.Parse(Dr["SubTotal"].ToString()),
                            Impuesto = decimal.Parse(Dr["Impuesto"].ToString()),
                            Total = decimal.Parse(Dr["Total"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.Venta> ListaVenta(int IdVenta)
        {
            List<Entidades.Venta> oLista = new List<Entidades.Venta>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdVenta, IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, IdSerie, Correlativo, FechaVenta, FechaRegistro, SubTotal, Impuesto, Total, " +
                    "IdEstado from Venta where IdVenta = @IdVenta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Venta()
                        {
                            IdVenta = int.Parse(Dr["IdVenta"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            IdCliente = Dr["IdEntidad"].ToString(),
                            IdTipoDocumento = Dr["IdTipoDocumento"].ToString(),
                            IdUsuario = Dr["IdUsuario"].ToString(),
                            IdCorrelativo = Convert.ToInt32(Dr["IdSerie"].ToString()),
                            Correlativo = Dr["Correlativo"].ToString(),
                            FechaVenta = Dr["FechaVenta"].ToString(),
                            FechaRegistro = Dr["FechaRegistro"].ToString(),
                            SubTotal = decimal.Parse(Dr["SubTotal"].ToString()),
                            Impuesto = decimal.Parse(Dr["Impuesto"].ToString()),
                            Total = decimal.Parse(Dr["Total"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarVenta(Entidades.Venta eVenta)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update Venta set IdVenta = @IdVenta, IdEmpresa = @IdEmpresa, IdEntidad = @IdEntidad, IdTipoDocumento = @IdTipoDocumento, IdUsuario = " +
                    "@IdUsuario, IdCorrelativo = @IdCorrelativo, Correlativo = @Correlativo, FechaVenta = @FechaVenta, FechaRegistro = @FechaRegistro, SubTotal = @SubTotal, " +
                    "Impuesto = @Impuesto, Total = @Total, IdEstado = @IdEstado where IdVenta = @IdVenta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVenta", eVenta.IdVenta);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eVenta.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdEntidad", eVenta.IdCliente);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eVenta.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdUsuario", eVenta.IdUsuario);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", eVenta.IdCorrelativo);
                Cmd.Parameters.AddWithValue("@Correlativo", eVenta.Correlativo);
                Cmd.Parameters.AddWithValue("@FechaVenta", eVenta.FechaVenta);
                Cmd.Parameters.AddWithValue("@FechaRegistro", eVenta.FechaRegistro);
                Cmd.Parameters.AddWithValue("@SubTotal", eVenta.SubTotal);
                Cmd.Parameters.AddWithValue("@Impuesto", eVenta.Impuesto);
                Cmd.Parameters.AddWithValue("@Total", eVenta.Total);
                Cmd.Parameters.AddWithValue("@IdEstado", eVenta.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarVenta(Entidades.Venta eVenta)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from Venta where IdVenta = @IdVenta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVenta", eVenta.IdVenta);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}