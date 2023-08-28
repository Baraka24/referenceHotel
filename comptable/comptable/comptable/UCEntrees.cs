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
    public partial class UCEntrees : UserControl
    {
        public UCEntrees()
        {
            InitializeComponent();
        }

        private void UCEntrees_Load(object sender, EventArgs e)
        {
            FillcbxCodeSource();
            AfficherEntrees(true);
        }
        private void FillcbxCodeSource()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select codeSource from sources";
            conn.Open();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adaptor.SelectCommand = cmd;
            adaptor.Fill(table);
            foreach (DataRow element in table.Rows)
            {
                cbxSource.Items.Add(element[0]);
            }
            conn.Close();
        }
        private void AfficherEntrees(bool search)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from entree";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM entree WHERE libelle LIKE @libelle";
                cmd.Parameters.Add("libelle", MySqlDbType.VarChar).Value = txtSearch.Text + "%";
            }

            cmd.Connection = conn;
            conn.Open();
            MySqlDataAdapter tuyau = new MySqlDataAdapter();
            DataTable table = new DataTable();
            tuyau.SelectCommand = cmd;
            tuyau.Fill(table);
            dataGridView1.DataSource = table;
        }
        double mt;
        private bool ChampsOk()
        { 
            if(double.TryParse(txtMontant.Text,out mt)&&cbxSource.SelectedIndex!=-1&& txtLibelle.Text!=""&& txtCodeEntrees.Text!="")
            {
                return true;
            }
            return false;
        }
        private void NotifierErreur()
        {
            if (txtMontant.Text != double.TryParse(txtMontant.Text, out mt).ToString())
            {
                errorProvider1.SetError(txtMontant, "Entrer un montant correct!");
            }
            else
            {
                errorProvider1.SetError(txtMontant, "");
            }
            if (txtLibelle.Text == "")
            {
                errorProvider1.SetError(txtLibelle, "Insérer le libellé svp!");
            }
            else
            {
                errorProvider1.SetError(txtLibelle, "");
            }
            if (txtCodeEntrees.Text == "")
            {
                errorProvider1.SetError(txtCodeEntrees, "Insérer le code svp!");
            }
            else
            {
                errorProvider1.SetError(txtCodeEntrees, "");
            }
            if (cbxSource.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbxSource, "Selectionner le code source!");
            }
            else
            {
                errorProvider1.SetError(cbxSource, "");
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
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=; Convert Zero DateTime=true";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (modifier == false)
            {
                cmd.CommandText = "INSERT INTO entree(codeEntree, dateEntree, libelle,codeSource,montant) VALUES (@codeEntree,@dateEntree,@libelle,@codeSource,@montant)";
            }
            else
            {
                cmd.CommandText = "UPDATE entree SET dateEntree=@dateEntree,libelle=@libelle, codeSource=@codeSource,montant=@montant WHERE codeEntree=@codeEntree";
            }
            cmd.Parameters.Add("codeEntree", MySqlDbType.VarChar).Value = txtCodeEntrees.Text;
            cmd.Parameters.Add("dateEntree", MySqlDbType.Date).Value = bunifuDatepicker1.Value;
            cmd.Parameters.Add("libelle", MySqlDbType.VarChar).Value = txtLibelle.Text;
            cmd.Parameters.Add("codeSource", MySqlDbType.VarChar).Value = cbxSource.Text;
            cmd.Parameters.Add("montant", MySqlDbType.Double).Value = txtMontant.Text;
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Enregistré avec succès!", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AfficherEntrees(false);

                Vider();
            }
            else
            {
                MessageBox.Show("Erreur", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Vider()
        {
            txtCodeEntrees.Clear();
            txtLibelle.Clear();
            txtMontant.Clear();
            cbxSource.SelectedIndex = -1;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AfficherEntrees(true);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier = true;
            txtCodeEntrees.Text = dataGridView1.CurrentRow.Cells["codeEntree"].Value.ToString();
            bunifuDatepicker1.Text = dataGridView1.CurrentRow.Cells["dateEntree"].Value.ToString();
            txtLibelle.Text = dataGridView1.CurrentRow.Cells["libelle"].Value.ToString();
            cbxSource.Text = dataGridView1.CurrentRow.Cells["codeSource"].Value.ToString();
            txtMontant.Text = dataGridView1.CurrentRow.Cells["montant"].Value.ToString();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse == DialogResult.No)
            {
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from entree where codeEntree=@codeEntree";
            cmd.Parameters.Add("codeEntree", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["codeEntree"].Value.ToString();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suppression effectuée avec succès!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfficherEntrees(false);
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

        private void txtCodeEntrees_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodeEntrees, "");
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtLibelle, "");
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbxSource, "");
        }

        private void txtMontant_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMontant, "");
        }
    }
}
