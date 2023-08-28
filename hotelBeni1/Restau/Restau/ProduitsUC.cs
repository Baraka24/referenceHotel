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
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=";
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
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from chambre";
            }
            else
            {
                cmd.CommandText = "SELECT *FROM chambre WHERE nom LIKE @nom";
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
        double prix; int num;
        private bool ChampOk()
        {
        
        if (double.TryParse(txtPu.Text, out prix) &&int.TryParse( txtNUm.Text, out num) && txtNom.Text != ""&&cbxCodeCat.SelectedIndex!=-1)
        {
            return true;
        }
        return false;
        }

        private void NotifierErreur()
        {
            if (txtPu.Text != double.TryParse(txtPu.Text, out prix).ToString())
            {
                errorProvider1.SetError(txtPu, "Montant invalide!");
            }
            else
            {
                errorProvider1.SetError(txtPu, "");
            }
            if (txtNUm.Text != int.TryParse(txtNUm.Text, out num).ToString())
            {
                errorProvider1.SetError(txtNUm, "Numero invalide!");
            }
            else
            {
                errorProvider1.SetError(txtNUm, "");
            }
            if (cbxCodeCat.SelectedIndex != -1)
            {
                errorProvider1.SetError(cbxCodeCat, "");
            }
            else
            {
                errorProvider1.SetError(cbxCodeCat, "Veillez selecetionner le code!");
            }
            if (txtNom.Text == "")
            {
                errorProvider1.SetError(txtNom, "Ce champ est obligatoire!");
            }
            else
            {
                errorProvider1.SetError(txtNom, "");
            }
        }

        bool modifier=false;
        private void btnEnrigistrer_Click(object sender, EventArgs e)
        {
            if (!ChampOk())
            {
                NotifierErreur();
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (modifier == false)
            {
                cmd.CommandText = "INSERT INTO `chambre`(`numero`, `nom`, `prix`, `codecat`) VALUES (@numero,@nom,@prix,@codecat)";
            }
            else
            {
                cmd.CommandText = "UPDATE `chambre` SET `nom`=@nom,`prix`=@prix,`codecat`=@codecat WHERE `numero`=@numero";
            }
            cmd.Parameters.Add("nom", MySqlDbType.VarChar).Value = txtNom.Text;
            cmd.Parameters.Add("numero", MySqlDbType.Int16).Value = txtNUm.Text;
            cmd.Parameters.Add("prix", MySqlDbType.Double).Value = txtPu.Text;
            cmd.Parameters.Add("codecat", MySqlDbType.VarChar).Value = cbxCodeCat.Text;
            
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
            
            txtNom.Text = dataGridView1.CurrentRow.Cells["nom"].Value.ToString();
            txtPu.Text = dataGridView1.CurrentRow.Cells["prix"].Value.ToString();
            txtNUm.Text = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();
            cbxCodeCat.Text = dataGridView1.CurrentRow.Cells["codecat"].Value.ToString();
        }
        private void Vider()
        {
            
            txtNom.Text = "";
            txtPu.Text = "";
            
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
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from chambre where numero=@numero";
            cmd.Parameters.Add("numero", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();
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

        private void txtNUm_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNUm, "");
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNom, "");
        }

        private void txtPu_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPu, "");
        }

        private void cbxCodeCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbxCodeCat, "");
        }

    }
}
