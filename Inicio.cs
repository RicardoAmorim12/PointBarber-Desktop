using PointBarber;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointBarber
{
    public partial class AreaDeTrabalho : Form
    {
        public AreaDeTrabalho()
        {
            InitializeComponent();
        }

        private void BarbeariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastro telaCadastro = new TelaCadastro();
            telaCadastro.MdiParent = this;
            telaCadastro.Show();
        }

       

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
