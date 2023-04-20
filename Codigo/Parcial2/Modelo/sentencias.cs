using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;

namespace Modelo
{
   
    public class sentencias
    {
        conexion con = new conexion();

        public OdbcDataAdapter llenartabla(string tabla)
        {
            OdbcDataAdapter datatable = null;
            try
            {
                
                string sql = "select * from " + tabla + ";";
                datatable = new OdbcDataAdapter(sql, con.cconexion());
            }
            catch(Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error Sentencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
           
            return datatable;
        }


        public void insertar(string tabla, string tipo, string dato)
        {
            try
            {
                string sql = "insert into " + tabla + "(" + tipo + ") values (" + dato + ")";
                OdbcCommand cmd = new OdbcCommand(sql, con.cconexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error Sentencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminar(string tabla, string campo, string valor)
        {
            try
            {
                string sql = "delete from " + tabla + " where " + campo + "=" + valor + ";";
                OdbcCommand cmd = new OdbcCommand(sql, con.cconexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error Sentencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void actualizar(string tabla, string dato, string condicion)
        {
            try
            {
                string sql = "Update " + tabla + " " + dato + " where " + condicion;
                OdbcCommand cmd = new OdbcCommand(sql, con.cconexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error Sentencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        public string buscarid(string tabla, string tipo)
        {
            string dato = " ";
            try
            {

                string sql = "select " + tipo + " from " + tabla + " Order by " + tipo + " Desc Limit 1";
                OdbcCommand cmd = new OdbcCommand(sql, con.cconexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error Sentencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return dato;
        }

        public int estadotabla(string tabla)
        {
            int dato = 0;

            try
            {
                string sql = "select count(*) as total from " + tabla;
                OdbcCommand cmd = new OdbcCommand(sql, con.cconexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {

                    dato = lr.GetInt32(0);


                }
            }
            catch(Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error Sentencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return dato;
        }

        public OdbcDataAdapter buscardatosespecificos(string tabla, string tipo, string campo, string valor)
        {
            OdbcDataAdapter datatable = null;
            try
            {

                string sql = "select " + tipo + " from " + tabla + " where " + campo + " = '" + valor + "'";
                datatable = new OdbcDataAdapter(sql, con.cconexion());
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error Sentencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return datatable;
        }
    }
}
