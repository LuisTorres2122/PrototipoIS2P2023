using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;

using Modelo;

namespace Controlador
{
    
    public class csControlador
    {
        sentencias sn = new sentencias();

        public void llenargrid(string tabla, DataGridView grid)
        {
            try
            {
                OdbcDataAdapter dt = sn.llenartabla(tabla);
                DataTable table = new DataTable();
                dt.Fill(table);
                grid.DataSource = table;
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        DataTable llenardatatable(string tabla)
        {
            DataTable table = null;
            try
            {
                OdbcDataAdapter dt = sn.llenartabla(tabla);
                table = new DataTable();
                dt.Fill(table);
               
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
        }

        public void insertar(string tabla, string tipo, string dato)
        {
            try
            {
                sn.insertar(tabla, tipo, dato);
                string mensaje = "Dato insertado correctamente ";
                MessageBox.Show(mensaje, "Inserción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                string mensaje = "No se pudo ingresar lo datos, Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        string evaluartextboxvacios(TextBox[] textbox)
        {
            string autorizacion = " ";
            try
            {
                for (int x = 0; x < textbox.Length; x++)
                {
                    if (textbox[x].Text.Length == 0)
                    {
                        string mensaje = "Porfavor llenar todos los campos";
                        MessageBox.Show(mensaje, "Error Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        autorizacion = "no";
                        break;

                    }
                    else if (textbox[x].Text.Length != 0)
                    {
                        autorizacion = "si";
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return autorizacion;
        }


        public void limpiartextbox(TextBox[] text)
        {
            for(int x = 0; x < text.Length; x++)
            {
                text[x].Clear();
            }

        }

        public int comprobacionvacio(string tabla)
        {
            int resultado = 0;
            try
            {
                resultado = sn.estadotabla(tabla);
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            return resultado;
        }

        public void crearid(TextBox textbox, string tabla,  string campo)
        {

            try
            {
                int incremento = 0;

                int permiso = comprobacionvacio(tabla);
                if (permiso != 0)
                {
                    string resultado = sn.buscarid(tabla, campo);
                    incremento = Convert.ToInt32(resultado) + 1;
                    textbox.Text = incremento.ToString();
                }
                else
                {
                    incremento = 1;
                    textbox.Text = incremento.ToString();
                }



            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ingresardatagrid()
        {


        }

        void bloqueargroup(GroupBox group)
        {


            foreach (Control c in group.Controls)
            {
                if (c is TextBox)
                {
                    c.Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    c.Enabled = false;
                }

                //agregar dependiendo las herramientas a bloquear

            }
        }
        void desbloqueargroup(GroupBox group)
        {


            foreach (Control c in group.Controls)
            {
                if (c is TextBox)
                {
                    c.Enabled = true;
                }
                if (c is DateTimePicker)
                {
                    c.Enabled = true;
                }
                //agregar dependiendo las herramientas a desbloquear

            }
        }

        public void eliminar(string tabla, string campo, string dato)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea eliminar el registro", "Eliminar Registro", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    sn.eliminar(tabla, campo, dato);
                    string mensaje = "Dato eliminado ";
                    MessageBox.Show(mensaje, "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
              
            }
            catch (Exception e)
            {
                string mensaje = "Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void actulizar(string tabla, string dato, string condicion)
        {
            try
            {
                sn.actualizar(tabla, dato, condicion);
                string mensaje = "Dato actualizado correctamente ";
                MessageBox.Show(mensaje, "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                string mensaje = "No se pudo ingresar lo datos, Error: " + e;
                MessageBox.Show(mensaje, "Error controlador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }







    }
}
