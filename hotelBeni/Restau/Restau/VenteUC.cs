using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Restau
{
    public partial class VenteUC : UserControl
    {
        public VenteUC()
        {
            InitializeComponent();
        }

        private void VenteUC_Load(object sender, EventArgs e)
        {
            FillcbxCodePro();
            AfficherVentes(false);

        }
        private void Vider()
        {
            txtCodeVente.Text = "";
            txtQte.Text = "";
            cbxCodePro.SelectedIndex = -1;
        }
        private void FillcbxCodePro()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=restau;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select codeproduit from produits";
            conn.Open();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adaptor.SelectCommand = cmd;
            adaptor.Fill(table);
            foreach (DataRow element in table.Rows)
            {
                cbxCodePro.Items.Add(element[0]);
            }
            conn.Close();
        }
        private void AfficherVentes(bool search)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=restau;uid=root;pwd=;Convert Zero DateTime=true";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from vente";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM vente WHERE datevente LIKE @datevente";
                //cmd.Parameters.Add("nom", MySqlDbType.VarChar).Value = txtSearch.Text + "%";
                //cmd.Parameters.Add("datevente", MySqlDbType.Date).Value = txtSearch.Text + "%";
            }

            cmd.Connection = conn;
            conn.Open();
            MySqlDataAdapter tuyau = new MySqlDataAdapter();
            DataTable table = new DataTable();
            tuyau.SelectCommand = cmd;
            tuyau.Fill(table);
            dataGridView1.DataSource = table;
        }
        double qte;
        private bool ChampsOk()
        {
            if ( double.TryParse(txtQte.Text, out qte) && txtCodeVente.Text!=""&& cbxCodePro.SelectedIndex!=-1)
            {
                return true;
            }
            return false;
        }

        private void NotifierErreur()
        {
            if (txtCodeVente.Text == "")
            {
                errorProvider1.SetError(txtCodeVente, "Insérer le code svp!");
            }
            else
            {
                errorProvider1.SetError(txtCodeVente, "");
            }
            if (txtQte.Text == "")
            {
                errorProvider1.SetError(txtQte, "Quantité invalide!");
            }
            else
            {
                errorProvider1.SetError(txtQte,"");
            }
            if (cbxCodePro.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbxCodePro, "Selectioner un code svp!");
            }
            else
            {
                errorProvider1.SetError(cbxCodePro, "");
            }
        }

        bool modifier = false;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ChampsOk())
            {
                NotifierErreur();
                return;
            }

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=restau;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (modifier == false)
            {
                cmd.CommandText = "INSERT INTO `vente`(`codevente`, `datevente`, `quantitevendue`, `codeproduit`) VALUES (@codevente,@datevente,@quantite,@codeproduit)";
            }
            else
            {
                cmd.CommandText = "UPDATE `vente` SET `datevente`=@datevente,`quantitevendue`=@quantite,`codeproduit`=@codeproduit WHERE `codevente`=@codevente";
            }
            cmd.Parameters.Add("codeproduit", MySqlDbType.VarChar).Value = cbxCodePro.Text;
            cmd.Parameters.Add("codevente", MySqlDbType.VarChar).Value = txtCodeVente.Text;
            cmd.Parameters.Add("quantite", MySqlDbType.Double).Value = txtQte.Text;
            cmd.Parameters.Add("datevente", MySqlDbType.Date).Value = bunifuDatepicker1.Value;
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Enregistré avec succès!", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AfficherVentes(false);

                Vider();
            }
            else
            {
                MessageBox.Show("Erreur", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier = true;
            txtCodeVente.Text = dataGridView1.CurrentRow.Cells["codevente"].Value.ToString();
            txtQte.Text = dataGridView1.CurrentRow.Cells["quantitevendue"].Value.ToString();
            cbxCodePro.Text = dataGridView1.CurrentRow.Cells["codeproduit"].Value.ToString();
            bunifuDatepicker1.Text = dataGridView1.CurrentRow.Cells["codeproduit"].Value.ToString();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reponse == DialogResult.No)
            {
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=restau;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from vente where codevente=@codevente";
            cmd.Parameters.Add("codevente", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["codevente"].Value.ToString();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suppression effectuée avec succès!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AfficherVentes(false);
                }
                else
                {
                    MessageBox.Show("Echec de suppression!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void bunifuDatepicker2_onValueChanged(object sender, EventArgs e)
        {
            AfficherVentes(true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AfficherVentes(true);
        }

        private void txtCodeVente_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodeVente, "");
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtQte, "");
        }

        private void cbxCodePro_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbxCodePro, "");
        }
    }
}
