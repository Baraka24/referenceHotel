using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            AccueilUC uc = new AccueilUC();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoriesUC uc = new CategoriesUC();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AccueilUC uc = new AccueilUC();
            
            pnlShow.Controls.Add(uc);
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            ProduitsUC uc = new ProduitsUC();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            VenteUC uc = new VenteUC();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(uc);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
