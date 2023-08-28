using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comptable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            UCEntrees uc = new UCEntrees();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            CUAccueil uc = new CUAccueil();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            UCSorties uc = new UCSorties();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            UCSources uc = new UCSources();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void pnlShow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CUAccueil uc = new CUAccueil();
            pnlShow.Controls.Add(uc);
        }
    }
}
