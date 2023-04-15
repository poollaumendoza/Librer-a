using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class Entidad
    {
        Entidades.Entidad eEntidad = new Entidades.Entidad();

        public bool AgregarEntidad(Entidades.Entidad eEntidad)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into Entidad(IdEmpresa, IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, " +
                    "Email, EsCliente, EsProveedor, IdEstado) values(@IdEmpresa, @IdTipoDocumento, @NroDocumento, @RazonSocial, " +
                    "@Direccion, @Telefono, @Email, @EsCliente, @EsProveedor, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eEntidad.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eEntidad.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@NroDocumento", eEntidad.NroDocumento);
                Cmd.Parameters.AddWithValue("@RazonSocial", eEntidad.RazonSocial);
                Cmd.Parameters.AddWithValue("@Direccion", eEntidad.Direccion);
                Cmd.Parameters.AddWithValue("@Telefono", eEntidad.Telefono);
                Cmd.Parameters.AddWithValue("@Email", eEntidad.Email);
                Cmd.Parameters.AddWithValue("@EsCliente", eEntidad.EsCliente);
                Cmd.Parameters.AddWithValue("@EsProveedor", eEntidad.EsProveedor);
                Cmd.Parameters.AddWithValue("@IdEstado", eEntidad.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.Entidad> ListaEntidad()
        {
            List<Entidades.Entidad> oLista = new List<Entidades.Entidad>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdEntidad, IdEmpresa, IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, " +
                    "Email, EsCliente, EsProveedor, IdEstado from Entidad";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Entidad()
                        {
                            IdEntidad = int.Parse(Dr["IdEntidad"].ToString()),
                            IdEmpresa = int.Parse(Dr["NombreEntidad"].ToString()),
                            IdTipoDocumento = int.Parse(Dr["Direccion"].ToString()),
                            NroDocumento = Dr["Direccion"].ToString(),
                            RazonSocial = Dr["Direccion"].ToString(),
                            Direccion = Dr["Direccion"].ToString(),
                            Telefono = Dr["Direccion"].ToString(),
                            Email = Dr["IdEstado"].ToString(),
                            EsCliente = bool.Parse(Dr["IdEstado"].ToString()),
                            EsProveedor = bool.Parse(Dr["IdEstado"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.Entidad> ListaEntidad(int IdEntidad)
        {
            List<Entidades.Entidad> oLista = new List<Entidades.Entidad>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdEntidad, IdEmpresa, IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, " +
                    "Email, EsCliente, EsProveedor, IdEstado from Entidad where IdEntidad = @IdEntidad";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEntidad", IdEntidad);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Entidad()
                        {
                            IdEntidad = int.Parse(Dr["IdEntidad"].ToString()),
                            IdEmpresa = int.Parse(Dr["NombreEntidad"].ToString()),
                            IdTipoDocumento = int.Parse(Dr["Direccion"].ToString()),
                            NroDocumento = Dr["Direccion"].ToString(),
                            RazonSocial = Dr["Direccion"].ToString(),
                            Direccion = Dr["Direccion"].ToString(),
                            Telefono = Dr["Direccion"].ToString(),
                            Email = Dr["IdEstado"].ToString(),
                            EsCliente = bool.Parse(Dr["IdEstado"].ToString()),
                            EsProveedor = bool.Parse(Dr["IdEstado"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarEntidad(Entidades.Entidad eEntidad)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update Entidad set IdEmpresa = @IdEmpresa, IdTipoDocumento = @IdTipoDocumento, NroDocumento = @NroDocumento, " +
                    "RazonSocial = @RazonSocial, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, EsCliente = @EsCliente, " +
                    "EsProveedor = @EsProveedor, IdEstado = @IdEstado where IdEntidad = @IdEntidad";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEntidad", eEntidad.IdEntidad);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eEntidad.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eEntidad.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@NroDocumento", eEntidad.NroDocumento);
                Cmd.Parameters.AddWithValue("@RazonSocial", eEntidad.RazonSocial);
                Cmd.Parameters.AddWithValue("@Direccion", eEntidad.Direccion);
                Cmd.Parameters.AddWithValue("@Telefono", eEntidad.Telefono);
                Cmd.Parameters.AddWithValue("@Email", eEntidad.Email);
                Cmd.Parameters.AddWithValue("@EsCliente", eEntidad.EsCliente);
                Cmd.Parameters.AddWithValue("@EsProveedor", eEntidad.EsProveedor);
                Cmd.Parameters.AddWithValue("@IdEstado", eEntidad.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarEntidad(Entidades.Entidad eEntidad)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete Entidad where IdEntidad = @IdEntidad";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEntidad", eEntidad.IdEntidad);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}