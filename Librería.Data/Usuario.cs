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
	public class Usuario
	{
		Entidades.Usuario eUsuario = new Entidades.Usuario();
		UsuarioCollection listaUsuario = new UsuarioCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarUsuario(Entidades.Usuario eUsuario)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Usuario_AgregarUsuario", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@IdUsuario", eUsuario.IdUsuario);
			Cmd.Parameters.AddWithValue("@IdPersona", eUsuario.IdPersona);
			Cmd.Parameters.AddWithValue("@NombreUsuario", eUsuario.NombreUsuario);
			Cmd.Parameters.AddWithValue("@Contraseña", eUsuario.Contraseña);
			Cmd.Parameters.AddWithValue("@IdEstado", eUsuario.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarUsuario(Entidades.Usuario eUsuario)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Usuario_EliminarUsuario", Cnx);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarUsuario(Entidades.Usuario eUsuario)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Usuario_ActualizarUsuario", Cnx);
			Cmd.Parameters.AddWithValue("@IdUsuario", eUsuario.IdUsuario);
			Cmd.Parameters.AddWithValue("@IdPersona", eUsuario.IdPersona);
			Cmd.Parameters.AddWithValue("@NombreUsuario", eUsuario.NombreUsuario);
			Cmd.Parameters.AddWithValue("@Contraseña", eUsuario.Contraseña);
			Cmd.Parameters.AddWithValue("@IdEstado", eUsuario.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Usuario> ListaUsuario()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaUsuario.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Usuario_ObtenerUsuario", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaUsuario.Add(new Entidades.Usuario()
				{
					IdUsuario = Convert.ToInt32(item[0].ToString()),
					IdPersona = Convert.ToInt32(item[1].ToString()),
					NombreUsuario = item[2].ToString(),
					Contraseña = item[3].ToString(),
					IdEstado = Convert.ToInt32(item[4].ToString())
				});
			}
			return listaUsuario;
		}
		public ObservableCollection<Entidades.Usuario> ListaUsuario(Entidades.Usuario eUsuario)
		{
			listaUsuario.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Usuario_ObtenerPorIdUsuario", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaUsuario.Add(new Entidades.Usuario()
				{
					IdUsuario = Convert.ToInt32(item[0].ToString()),
					IdPersona = Convert.ToInt32(item[1].ToString()),
					NombreUsuario = item[2].ToString(),
					Contraseña = item[3].ToString(),
					IdEstado = Convert.ToInt32(item[4].ToString())
				});
			}
			return listaUsuario;
		}
	}
}

