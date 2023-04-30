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
	public class Persona
	{
		Entidades.Persona ePersona = new Entidades.Persona();
		PersonaCollection listaPersona = new PersonaCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarPersona(Entidades.Persona ePersona)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Persona_AgregarPersona", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", ePersona.IdTipoDocumento);
			Cmd.Parameters.AddWithValue("@NroDocumento", ePersona.NroDocumento);
			Cmd.Parameters.AddWithValue("@ApellidoPaterno", ePersona.ApellidoPaterno);
			Cmd.Parameters.AddWithValue("@ApellidoMaterno", ePersona.ApellidoMaterno);
			Cmd.Parameters.AddWithValue("@PrimerNombre", ePersona.PrimerNombre);
			Cmd.Parameters.AddWithValue("@SegundoNombre", ePersona.SegundoNombre);
			Cmd.Parameters.AddWithValue("@Direccion", ePersona.Direccion);
			Cmd.Parameters.AddWithValue("@Telefono", ePersona.Telefono);
			Cmd.Parameters.AddWithValue("@Email", ePersona.Email);
			Cmd.Parameters.AddWithValue("@IdEstado", ePersona.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarPersona(Entidades.Persona ePersona)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Persona_EliminarPersona", Cnx);
			Cmd.Parameters.AddWithValue("@IdPersona", ePersona.IdPersona);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarPersona(Entidades.Persona ePersona)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Persona_ActualizarPersona", Cnx);
			Cmd.Parameters.AddWithValue("@IdPersona", ePersona.IdPersona);
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", ePersona.IdTipoDocumento);
			Cmd.Parameters.AddWithValue("@NroDocumento", ePersona.NroDocumento);
			Cmd.Parameters.AddWithValue("@ApellidoPaterno", ePersona.ApellidoPaterno);
			Cmd.Parameters.AddWithValue("@ApellidoMaterno", ePersona.ApellidoMaterno);
			Cmd.Parameters.AddWithValue("@PrimerNombre", ePersona.PrimerNombre);
			Cmd.Parameters.AddWithValue("@SegundoNombre", ePersona.SegundoNombre);
			Cmd.Parameters.AddWithValue("@Direccion", ePersona.Direccion);
			Cmd.Parameters.AddWithValue("@Telefono", ePersona.Telefono);
			Cmd.Parameters.AddWithValue("@Email", ePersona.Email);
			Cmd.Parameters.AddWithValue("@IdEstado", ePersona.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Persona> ListaPersona()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaPersona.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Persona_ObtenerPersona", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaPersona.Add(new Entidades.Persona()
				{
					IdPersona = Convert.ToInt32(item[0].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[1].ToString()),
					NroDocumento = item[2].ToString(),
					ApellidoPaterno = item[3].ToString(),
					ApellidoMaterno = item[4].ToString(),
					PrimerNombre = item[5].ToString(),
					SegundoNombre = item[6].ToString(),
					Direccion = item[7].ToString(),
					Telefono = item[8].ToString(),
					Email = item[9].ToString(),
					IdEstado = Convert.ToInt32(item[10].ToString())
				});
			}
			return listaPersona;
		}
		public ObservableCollection<Entidades.Persona> ListaPersona(Entidades.Persona ePersona)
		{
			listaPersona.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Persona_ObtenerPorIdPersona", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaPersona.Add(new Entidades.Persona()
				{
					IdPersona = Convert.ToInt32(item[0].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[1].ToString()),
					NroDocumento = item[2].ToString(),
					ApellidoPaterno = item[3].ToString(),
					ApellidoMaterno = item[4].ToString(),
					PrimerNombre = item[5].ToString(),
					SegundoNombre = item[6].ToString(),
					Direccion = item[7].ToString(),
					Telefono = item[8].ToString(),
					Email = item[9].ToString(),
					IdEstado = Convert.ToInt32(item[10].ToString())
				});
			}
			return listaPersona;
		}
	}
}

