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
    public partial class ProduitsUC : UserControl
    {
        public ProduitsUC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProduitsUC_Load(object sender, EventArgs e)
        {
            FillcbxCodeCat();
            AfficherProduits(false);
        }
        private void FillcbxCodeCat()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=restau;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select codecat from categorie";
            conn.Open();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adaptor.SelectCommand = cmd;
            adaptor.Fill(table);
            foreach (DataRow element in table.Rows)
            {
                cbxCodeCat.Items.Add(element[0]);
            }
            conn.Close();
        }
        private void AfficherProduits(bool search)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=restau;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from produits";
            }
            else
            {
                cmd.CommandText = "SELECT *FROM produits WHERE nom LIKE @nom";
                cmd.Parameters.Add("nom", MySqlDbType.VarChar).Value = txtSearch.Text + "%";
            }

            cmd.Connection = conn;
            conn.Open();
            MySqlDataAdapter tuyau = new MySqlDataAdapter();
            DataTable table = new DataTable();
            tuyau.SelectCommand = cmd;
            tuyau.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AfficherProduits(true);
        }
        double prix, qte;
        private bool ChampsOk()
        {
            if (double.TryParse(txtPu.Text, out prix) && double.TryParse(txtQte.Text, out qte) && txtNom.Text != "" && txtCodePro.Text != "")
            {
                return true;
            }
            return false;
        }

        private void notifierErreur()
        {
            if (txtPu.Text != double.TryParse(txtPu.Text, out prix).ToString())
            {
                errorProvider1.SetError(txtPu, "Prix invalide!");
            }
            else
            {
                errorProvider1.SetError(txtPu, "");
            }
            if (txtQte.Text != double.TryParse(txtQte.Text, out prix).ToString())
            {
                errorProvider1.SetError(txtQte, "Quantité invalide!");
            }
            else 
            {
                errorProvider1.SetError(txtQte, "");
            }
            if (txtCodePro.Text == "")
            {
                errorProvider1.SetError(txtCodePro, "Entrez un code svp!");
            }
            else
            {
                errorProvider1.SetError(txtCodePro, "");
            }
            if (cbxCodeCat.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbxCodeCat, "Selectionner le code Svp!");
            }
            else
            {
                errorProvider1.SetError(cbxCodeCat, "");
            }
            if (txtNom.Text == "")
            {
                errorProvider1.SetError(txtNom, "Insérer le nom svp!");
            }
            else
            {
                errorProvider1.SetError(txtNom, "");
            }
            if (txtCodePro.Text == "")
            {
                errorProvider1.SetError(txtCodePro, "Insérer le code svp!");
            }
            else
            {
                errorProvider1.SetError(txtCodePro, "");
            }
        }

        bool modifier=false;
        private void btnEnrigistrer_Click(object sender, EventArgs e)
        {
            if (!ChampsOk())
            {
                notifierErreur();
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=restau;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (modifier == false)
            {
                cmd.CommandText = "INSERT INTO `produits`(`codeproduit`, `nom`, `quantite`, `prixunitaire`, `codecat`) VALUES (@codeproduit,@nom,@quantite,prixunitaire,@codecat)";
            }
            else
            {
                cmd.CommandText = "UPDATE `produits` SET `nom`=@nom,`quantite`=@quantite,`prixunitaire`=@prixunitaire,`codecat`=@codecat WHERE `codeproduit`=@codeproduit";
            }
            cmd.Parameters.Add("codecat", MySqlDbType.VarChar).Value = cbxCodeCat.Text;
            cmd.Parameters.Add("nom", MySqlDbType.VarChar).Value = txtNom.Text;
            cmd.Parameters.Add("quantite", MySqlDbType.Double).Value =txtQte.Text;
            cmd.Parameters.Add("prixunitaire", MySqlDbType.Double).Value = txtPu.Text;
            cmd.Parameters.Add("codeproduit", MySqlDbType.VarChar).Value = txtCodePro.Text;
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Enregistré avec succès!", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AfficherProduits(false);
                
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
            txtCodePro.Text = dataGridView1.CurrentRow.Cells["codeproduit"].Value.ToString();
            txtNom.Text = dataGridView1.CurrentRow.Cells["nom"].Value.ToString();
            txtPu.Text = dataGridView1.CurrentRow.Cells["prixunitaire"].Value.ToString();
            txtQte.Text = dataGridView1.CurrentRow.Cells["quantite"].Value.ToString();
            cbxCodeCat.Text = dataGridView1.CurrentRow.Cells["codecat"].Value.ToString();
        }
        private void Vider()
        {
            txtCodePro.Text = "";
            txtNom.Text = "";
            txtPu.Text = "";
            txtQte.Text = "";
            cbxCodeCat.SelectedIndex = -1;
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
            cmd.CommandText = "delete from produits where codeproduit=@codeproduit";
            cmd.Parameters.Add("codeproduit", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["codeproduit"].Value.ToString();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suppression effectuée avec succès!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AfficherProduits(false);
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

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNom, "");
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtQte, "");
        }

        private void txtPu_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPu, "");
        }

        private void cbxCodeCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbxCodeCat, "");
        }

        private void txtCodePro_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodePro, "");
        }

    }
}
