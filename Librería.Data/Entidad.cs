using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Librería.Entidades;
using Librería.Data.Properties;

namespace Librería.Data
{
	public class Entidad
	{
		Entidades.Entidad eEntidad = new Entidades.Entidad();
		EntidadCollection listaEntidad = new EntidadCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarEntidad(Entidades.Entidad eEntidad)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Entidad_AgregarEntidad", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
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
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarEntidad(Entidades.Entidad eEntidad)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Entidad_EliminarEntidad", Cnx);
			Cmd.Parameters.AddWithValue("@IdEntidad", eEntidad.IdEntidad);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarEntidad(Entidades.Entidad eEntidad)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Entidad_ActualizarEntidad", Cnx);
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
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Entidad> ListaEntidad()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaEntidad.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Entidad_ObtenerEntidad", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaEntidad.Add(new Entidades.Entidad()
				{
					IdEntidad = Convert.ToInt32(item[0].ToString()),
					IdEmpresa = Convert.ToInt32(item[1].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[2].ToString()),
					NroDocumento = item[3].ToString(),
					RazonSocial = item[4].ToString(),
					Direccion = item[5].ToString(),
					Telefono = item[6].ToString(),
					Email = item[7].ToString(),
					EsCliente = Convert.ToBoolean(item[8]),
					EsProveedor = Convert.ToBoolean(item[9]),
					IdEstado = Convert.ToInt32(item[10].ToString())
				});
			}
			return listaEntidad;
		}
		public ObservableCollection<Entidades.Entidad> ListaEntidad(Entidades.Entidad eEntidad)
		{
			listaEntidad.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Entidad_ObtenerPorIdEntidad", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaEntidad.Add(new Entidades.Entidad()
				{
					IdEntidad = Convert.ToInt32(item[0].ToString()),
					IdEmpresa = Convert.ToInt32(item[1].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[2].ToString()),
					NroDocumento = item[3].ToString(),
					RazonSocial = item[4].ToString(),
					Direccion = item[5].ToString(),
					Telefono = item[6].ToString(),
					Email = item[7].ToString(),
					EsCliente = Convert.ToBoolean(item[8]),
					EsProveedor = Convert.ToBoolean(item[9]),
					IdEstado = Convert.ToInt32(item[10].ToString())
				});
			}
			return listaEntidad;
		}
	}
}

