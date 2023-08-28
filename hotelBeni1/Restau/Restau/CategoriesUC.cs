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
    public partial class CategoriesUC : UserControl
    {
        public CategoriesUC()
        {
            InitializeComponent();
        }

        private void CategoriesUC_Load(object sender, EventArgs e)
        {
            AfficherCategories(false);
        }
        private void AfficherCategories(bool search)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from categorie";
            }
            else
            {
                cmd.CommandText = "SELECT *FROM categorie WHERE nom LIKE @nom";
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
            AfficherCategories(true);
        }
        private bool ChampOk()
        {

            if (txtCodeCat.Text!=""&&txtNom.Text!="")
            {
                return true;
            }
            return false;
        }
        private void NotifierErreur()
        {
            if (txtNom.Text == "")
            {
                errorProvider1.SetError(txtNom, "Veillez insérer le nom!");
            }
            else
            {
                errorProvider1.SetError(txtNom, "");
            }
            if (txtCodeCat.Text == "")
            {
                errorProvider1.SetError(txtCodeCat, "Veillez insérer le code!");
            }
            else
            {
                errorProvider1.SetError(txtCodeCat, "");
            }
        }

        bool modifier=false;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(!ChampOk())
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
                cmd.CommandText = "INSERT INTO `categorie`(`codecat`, `nom`) VALUES (@codecat,@nom)";
            }
            else
            {
                cmd.CommandText = " UPDATE `categorie` SET `nom`=@nom WHERE `codecat`=@codecat";
            }
            cmd.Parameters.Add("codecat", MySqlDbType.VarChar).Value = txtCodeCat.Text;
            cmd.Parameters.Add("nom", MySqlDbType.VarChar).Value = txtNom.Text;
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Enregistré avec succès!", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AfficherCategories(false);
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
            txtCodeCat.Text = dataGridView1.CurrentRow.Cells["codecat"].Value.ToString();
        }
        private void Vider()
        {
            txtNom.Text = "";
            txtCodeCat.Text = "";
            txtSearch.Text = "";
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
            cmd.CommandText = "delete from categorie where codecat=@codecat";
            cmd.Parameters.Add("codecat", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["codecat"].Value.ToString();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suppression effectuée avec succès!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AfficherCategories(false);
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

        private void txtCodeCat_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodeCat, "");
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNom, "");
        }
    }
}
