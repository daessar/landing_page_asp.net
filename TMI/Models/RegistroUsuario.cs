using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TMI.Models
{
    public class RegistroUsuario
    {
        private SqlConnection con;

        private void Conectar() //Se crea una función para conectar a la base de bd
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Insertar(Usuario usr) //Se crean los elementos
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO tmi_usuario (usu_nombre,usu_apellido,usu_email,usu_fecharegistro)values(@nombre,@apellido,@email,@fecharegistro)", con);

            //Especifica que tipo de datos es
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.DateTime);

            //Lee y modifica los datos

            comando.Parameters["@nombre"].Value = usr.Nombre;
            comando.Parameters["@apellido"].Value = usr.Apellido;
            comando.Parameters["@email"].Value = usr.Email;
            comando.Parameters["@fecharegistro"].Value = DateTime.Today;

            con.Open(); //Abre la conexion
            int i = comando.ExecuteNonQuery(); //Devuelve el numero de filas afectadas
            con.Close(); //Cierra la conexion
            return i; //Retornas cuantas filas se afectaron
        }
        public List<Usuario> RecupearTodos()
        {
            Conectar();
            List<Usuario> usuario = new List<Usuario>(); //Trae todos los datos que estan en la bd

            SqlCommand com = new SqlCommand("SELECT usu_id,usu_nombre,usu_apellido,usu_email,usu_fecharegistro FROM tmi_usuario ORDER BY usu_nombre ASC", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read()) //Se muestran los campos por filas, uno por uno 
            {
                Usuario usr = new Usuario
                {
                    Id = int.Parse(registros["usu_id"].ToString()),

                    Nombre = registros["usu_nombre"].ToString(),
                    Apellido = registros["usu_apellido"].ToString(),
                    Email = registros["usu_email"].ToString(),
                    FechaRegistro = DateTime.Parse(registros["usu_fechaRegistro"].ToString()),


                };
                usuario.Add(usr);

            }
            con.Close();
            return usuario;
        }
    }
}