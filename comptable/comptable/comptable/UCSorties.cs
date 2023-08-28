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
    public partial class UCSorties : UserControl
    {
        public UCSorties()
        {
            InitializeComponent();
        }
        private void Vider()
    {
        txtMontant.Clear();
        txtLibelle.Clear();
        txtCodeSorties.Clear();
        txtBeneficiaire.Clear();

    }
        private void Affichersorties(bool search)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=comptable;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from sortie";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM sortie WHERE libelle LIKE @libelle";
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
            if (double.TryParse(txtMontant.Text, out mt) && txtBeneficiaire.Text == "" && txtLibelle.Text != "" && txtCodeSorties.Text != "")
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
            if (txtCodeSorties.Text == "")
            {
                errorProvider1.SetError(txtCodeSorties, "Insérer le code svp!");
            }
            else
            {
                errorProvider1.SetError(txtCodeSorties, "");
            }
            if (txtBeneficiaire.Text == "")
            {
                errorProvider1.SetError(txtBeneficiaire, "Selectionner le code source!");
            }
            else
            {
                errorProvider1.SetError(txtBeneficiaire, "");
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
            cmd.CommandText = "INSERT INTO sortie(codeSortie, dateSortie, libelle,beneficiaire,montant) VALUES (@codeSortie, @dateSortie,@libelle, @beneficiaire,@montant)";
           }
             else
             {
                 cmd.CommandText = "UPDATE sortie SET dateSortie=@dateSortie,libelle=@libelle, beneficiaire=@beneficiaire,montant=@montant WHERE codeSortie=@codeSortie";
             }
            cmd.Parameters.Add("codeSortie", MySqlDbType.VarChar).Value = txtCodeSorties.Text;
            cmd.Parameters.Add("dateSortie", MySqlDbType.Date).Value = bunifuDatepicker1.Value;
            cmd.Parameters.Add("libelle", MySqlDbType.VarChar).Value = txtLibelle.Text;
            cmd.Parameters.Add("beneficiaire", MySqlDbType.VarChar).Value = txtBeneficiaire.Text;
            cmd.Parameters.Add("montant", MySqlDbType.Double).Value = txtMontant.Text;
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Enregistré avec succès!", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Affichersorties(false);

               Vider();
            }
            else
            {
                MessageBox.Show("Erreur", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCSorties_Load(object sender, EventArgs e)
        {
            Affichersorties(true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Affichersorties(true);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier = true;
            txtCodeSorties.Text= dataGridView1.CurrentRow.Cells["codeSortie"].Value.ToString();
            bunifuDatepicker1.Text = dataGridView1.CurrentRow.Cells["dateSortie"].Value.ToString();
            txtLibelle.Text = dataGridView1.CurrentRow.Cells["libelle"].Value.ToString();
            txtBeneficiaire.Text = dataGridView1.CurrentRow.Cells["beneficiaire"].Value.ToString();
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
            cmd.CommandText = "delete from sortie where codeSortie=@codeSortie";
            cmd.Parameters.Add("codeSortie", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["codeSortie"].Value.ToString();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suppression effectuée avec succès!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Affichersorties(false);
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

        private void txtCodeSorties_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodeSorties, "");
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtLibelle, "");
        }

        private void txtBeneficiaire_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtBeneficiaire, "");
        }

        private void txtMontant_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMontant, "");
        }
    }
}
