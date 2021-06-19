using System;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Conexion
    {
        // Variable a nivel de clase
        SqlConnection con;

        public Conexion(String strCadena)
        {
            // Constructor
            con = new SqlConnection(strCadena);
            con.Open();
        }

        public String EliminarDatos(String strTabla, String strCondicion)
        {
            // Elabora el sql
            String sql = "delete from " + strTabla + " where " + strCondicion;

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                return "Datos eliminados exitosamente";
                //con.Close();
            }
            catch (Exception)
            {
                return "Error al momento de eliminar datos";
            }

            // Cierro la conexion
            //con.Close();
        }

        public String InsertarDatos(String strTabla, String strCampos, String strValores)
        {
            // Inserta los datos a la tabla especificada
            String sql = "insert into " + strTabla + " ";
            sql += "(" + strCampos + ") " + "values (" + strValores + ")";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                return "Datos guardados correctamente";
            }
            catch (Exception)
            {
                return "Error al momento de insertar datos";
            }

            // Cierro la conexion
            //con.Close();
         }

        public String ModificarDatos(String strTabla, String strValores, String strCondicion)
        {
            // Elaboro el sql
            String sql = "update " + strTabla + " set " + strValores + " where " + strCondicion;

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                return "Datos modificados exitosamente";
            }
            catch (Exception)
            {
                return "Error al momento de modificar datos";
            }

            // Cierro la conexion
            //con.Close();
        }

        public DataTable LlenarTabla(String strTabla, String strCondicion = "")
        {
            String sql = "";

            //Obtiene el sql
            if (strCondicion == "")
            {
                sql = "select * from " + strTabla;
            }
            else
            {
                sql = "select * from " + strTabla + " where " + strCondicion;
            }

            // Llena la tabla
            SqlDataAdapter adaptador = new SqlDataAdapter(sql, con);

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            
            return tabla;
        }
     }
}