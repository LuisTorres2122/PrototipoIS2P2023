using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
namespace Vista
{
    public partial class usuario : Form
    {
        csControlador cn = new csControlador();
        public usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] datos = cn.datos(textBox1.Text, textBox2.Text);
            if(textBox1.Text.Equals(datos[0]) && textBox2.Text.Equals(datos[1]))
            {
                MDICorporacionEducativa m = new MDICorporacionEducativa();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario Invalido");
            }
        }
    }
}
