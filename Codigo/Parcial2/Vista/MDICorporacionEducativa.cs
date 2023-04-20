using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class MDICorporacionEducativa : Form
    {

        public MDICorporacionEducativa()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void customizeDesing()
        {
            //Metodo para cubrir los paneles
            panelcatalogo.Visible = false;
            panelProcesos.Visible = false;
            panelReportes.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelcatalogo.Visible == true)
                panelcatalogo.Visible = false;
            if (panelProcesos.Visible == true)
                panelProcesos.Visible = false;
            if (panelReportes.Visible == true)
                panelReportes.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = true;
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelcatalogo);
        }

        private void btnProcesos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProcesos);
        }

        private void btnMoviminetos_Click(object sender, EventArgs e)
        {
            //Codigo
           /* Moviminetos_CxP moviminetos = new Moviminetos_CxP();
            moviminetos.MdiParent = this;
            moviminetos.Show();*/

            //Ocultar submenu
            hideSubMenu();
        }

        private void btnreportemovimientos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProveedor_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnConcepto_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReportes);
        }

        private void btnTipoPago_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMoneda_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAntiguedad_Click(object sender, EventArgs e)
        {
            
        }

        private void MDICuentasPorPagar_Load(object sender, EventArgs e)
        {

        }
    }
}
