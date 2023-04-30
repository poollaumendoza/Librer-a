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
	public class Empresa
	{
		Entidades.Empresa eEmpresa = new Entidades.Empresa();
		EmpresaCollection listaEmpresa = new EmpresaCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarEmpresa(Entidades.Empresa eEmpresa)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Empresa_AgregarEmpresa", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", eEmpresa.IdTipoDocumento);
			Cmd.Parameters.AddWithValue("@NroDocumento", eEmpresa.NroDocumento);
			Cmd.Parameters.AddWithValue("@RazonSocial", eEmpresa.RazonSocial);
			Cmd.Parameters.AddWithValue("@Direccion", eEmpresa.Direccion);
			Cmd.Parameters.AddWithValue("@Telefono", eEmpresa.Telefono);
			Cmd.Parameters.AddWithValue("@Email", eEmpresa.Email);
			Cmd.Parameters.AddWithValue("@IdEstado", eEmpresa.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarEmpresa(Entidades.Empresa eEmpresa)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Empresa_EliminarEmpresa", Cnx);
			Cmd.Parameters.AddWithValue("@IdEmpresa", eEmpresa.IdEmpresa);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarEmpresa(Entidades.Empresa eEmpresa)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Empresa_ActualizarEmpresa", Cnx);
			Cmd.Parameters.AddWithValue("@IdEmpresa", eEmpresa.IdEmpresa);
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", eEmpresa.IdTipoDocumento);
			Cmd.Parameters.AddWithValue("@NroDocumento", eEmpresa.NroDocumento);
			Cmd.Parameters.AddWithValue("@RazonSocial", eEmpresa.RazonSocial);
			Cmd.Parameters.AddWithValue("@Direccion", eEmpresa.Direccion);
			Cmd.Parameters.AddWithValue("@Telefono", eEmpresa.Telefono);
			Cmd.Parameters.AddWithValue("@Email", eEmpresa.Email);
			Cmd.Parameters.AddWithValue("@IdEstado", eEmpresa.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Empresa> ListaEmpresa()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaEmpresa.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Empresa_ObtenerEmpresa", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaEmpresa.Add(new Entidades.Empresa()
				{
					IdEmpresa = Convert.ToInt32(item[0].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[1].ToString()),
					NroDocumento = item[2].ToString(),
					RazonSocial = item[3].ToString(),
					Direccion = item[4].ToString(),
					Telefono = item[5].ToString(),
					Email = item[6].ToString(),
					IdEstado = Convert.ToInt32(item[7].ToString())
				});
			}
			return listaEmpresa;
		}
		public ObservableCollection<Entidades.Empresa> ListaEmpresa(Entidades.Empresa eEmpresa)
		{
			listaEmpresa.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Empresa_ObtenerPorIdEmpresa", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaEmpresa.Add(new Entidades.Empresa()
				{
					IdEmpresa = Convert.ToInt32(item[0].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[1].ToString()),
					NroDocumento = item[2].ToString(),
					RazonSocial = item[3].ToString(),
					Direccion = item[4].ToString(),
					Telefono = item[5].ToString(),
					Email = item[6].ToString(),
					IdEstado = Convert.ToInt32(item[7].ToString())
				});
			}
			return listaEmpresa;
		}
	}
}

