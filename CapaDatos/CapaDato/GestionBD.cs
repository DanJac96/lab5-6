using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 
using System.Configuration;
using System.Data;
using CapaDato.Entidades;

namespace CapaDatos
{
    public class GestionBD
    {
        SqlConnection conexion;
        SqlCommand comando;
        string cadenaConexion = "Server=DESKTOP-AGCSGKE;Database=Lab5_6;User Id=sa;Password=root;";



        public int actualizarCarro(Carro objCarro)
        {
            int cantidadRegistros = -1;
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Carro " +
                                  "set idCarro = @idCarro, " +
                                  "    Marca = @Marca, " +
                                  "    Modelo = @Modelo, " +
                                  "    Pais = @Pais, " +
                                  "    Costo = @Costo " +
                                  "Where IdCarro = @IdCarro ";
                cmd.Parameters.Add(new SqlParameter("@idCarro", objCarro.idCarro));
                cmd.Parameters.Add(new SqlParameter("@Marca", objCarro.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarro.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarro.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarro.Costo));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int eliminarCarro(Carro objCarro)
        {
            int cantidadRegistros = -1;
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Carro Where idCarro = @idCarro";
                cmd.Parameters.Add(new SqlParameter("@idCarro", objCarro.idCarro));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int registrarCarro(Carro objCarro)
        {
            int cantidadRegistros = -1;
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Carro (idCarro,Marca,Modelo,Pais,Costo) Values (@idCarro,@Marca,@Modelo,@Pais,@Costo)";
                cmd.Parameters.Add(new SqlParameter("@idCarro", objCarro.idCarro));
                cmd.Parameters.Add(new SqlParameter("@Marca", objCarro.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarro.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarro.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarro.Costo));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;




        }

        public DataTable cargaCarro()
        {
            DataTable objTabla = new DataTable();
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Carro";
            comando.Connection = conexion;
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
            sqlAdaptador.Fill(objTabla);
            return objTabla;
        }

    }
}
