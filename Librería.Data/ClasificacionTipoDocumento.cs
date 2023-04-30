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
	public class ClasificacionTipoDocumento
	{
		Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento = new Entidades.ClasificacionTipoDocumento();
		ClasificacionTipoDocumentoCollection listaClasificacionTipoDocumento = new ClasificacionTipoDocumentoCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_ClasificacionTipoDocumento_AgregarClasificacionTipoDocumento", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@NombreClasificacionTipoDocumento", eClasificacionTipoDocumento.NombreClasificacionTipoDocumento);
			Cmd.Parameters.AddWithValue("@IdEstado", eClasificacionTipoDocumento.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_ClasificacionTipoDocumento_EliminarClasificacionTipoDocumento", Cnx);
			Cmd.Parameters.AddWithValue("@IdClasificacionTipoDocumento", eClasificacionTipoDocumento.IdClasificacionTipoDocumento);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_ClasificacionTipoDocumento_ActualizarClasificacionTipoDocumento", Cnx);
			Cmd.Parameters.AddWithValue("@IdClasificacionTipoDocumento", eClasificacionTipoDocumento.IdClasificacionTipoDocumento);
			Cmd.Parameters.AddWithValue("@NombreClasificacionTipoDocumento", eClasificacionTipoDocumento.NombreClasificacionTipoDocumento);
			Cmd.Parameters.AddWithValue("@IdEstado", eClasificacionTipoDocumento.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.ClasificacionTipoDocumento> ListaClasificacionTipoDocumento()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaClasificacionTipoDocumento.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_ClasificacionTipoDocumento_ObtenerClasificacionTipoDocumento", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaClasificacionTipoDocumento.Add(new Entidades.ClasificacionTipoDocumento()
				{
					IdClasificacionTipoDocumento = Convert.ToInt32(item[0].ToString()),
					NombreClasificacionTipoDocumento = item[1].ToString(),
					IdEstado = Convert.ToInt32(item[2].ToString())
				});
			}
			return listaClasificacionTipoDocumento;
		}
		public ObservableCollection<Entidades.ClasificacionTipoDocumento> ListaClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaClasificacionTipoDocumento.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_ClasificacionTipoDocumento_ObtenerPorIdClasificacionTipoDocumento", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaClasificacionTipoDocumento.Add(new Entidades.ClasificacionTipoDocumento()
				{
					IdClasificacionTipoDocumento = Convert.ToInt32(item[0].ToString()),
					NombreClasificacionTipoDocumento = item[1].ToString(),
					IdEstado = Convert.ToInt32(item[2].ToString())
				});
			}
			return listaClasificacionTipoDocumento;
		}
	}
}

