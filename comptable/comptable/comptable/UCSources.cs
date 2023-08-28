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

namespace comptable
{
    public partial class UCSources : UserControl
    {
        public UCSources()
        {
            InitializeComponent();
        }

        private void UCSources_Load(object sender, EventArgs e)
        {
            AfficherCategories(true);
        }
        private void AfficherCategories(bool search)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from sources";
            }
            else
            {
                cmd.CommandText = "SELECT *FROM sources WHERE nom LIKE @nom";
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
        private bool ChampsOk()
        {
            if (txtCodeSource.Text != "" && txtNom.Text != "")
            {
                return true;
            }
            return false;
        }
        private void NotifierErreur()
        {
            if (txtNom.Text == "")
            {
                errorProvider1.SetError(txtNom, "Entrer le nom de la ressource!");
            }
            else
            {
                errorProvider1.SetError(txtNom, "");
            }
            if (txtCodeSource.Text == "")
            {
                errorProvider1.SetError(txtCodeSource, "Entrer le code de la ressource!");
            }
            else
            {
                errorProvider1.SetError(txtCodeSource, "");
            }
        }




        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ChampsOk())
            {
                NotifierErreur();
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (modifier == false)
            {
            cmd.CommandText = "INSERT INTO `sources`(`codeSource`,`nom`) VALUES (@codeSource,@nom)";
            }
            else
            {
                cmd.CommandText = " UPDATE `sources` SET `nom`=@nom WHERE `codeSource`=@codeSource";
          }
            cmd.Parameters.Add("codeSource", MySqlDbType.VarChar).Value = txtCodeSource.Text;
            cmd.Parameters.Add("nom", MySqlDbType.VarChar).Value = txtNom.Text;
            conn.Open();
            if (cmd.ExecuteNonQuery() ==1)
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
         private void Vider()
        {
            txtNom.Text = "";
            txtCodeSource.Text = "";
            txtSearch.Text = "";
        }
         bool modifier = false;
        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier = true;
            txtCodeSource.Text = dataGridView1.CurrentRow.Cells["codeSource"].Value.ToString();
            txtNom.Text = dataGridView1.CurrentRow.Cells["nom"].Value.ToString();
       
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer?", "Question", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (reponse == DialogResult.No)
            {
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from sources where codeSource=@codeSource";
            cmd.Parameters.Add("codeSource", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["codeSource"].Value.ToString();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suppression effectuée avec succès!", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AfficherCategories(true);
        }

        private void txtCodeSource_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodeSource, "");
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNom, "");
        }
    }
}
