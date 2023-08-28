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
            FillcbxNumero();
            AfficherReservations(false);

        }
        private void Vider()
        {
            txtCodeRe.Text = "";
            txtDuree.Text = "";
            cbxNumero.SelectedIndex = -1;
        }
        private void FillcbxNumero()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select numero from chambre";
            conn.Open();
            MySqlDataAdapter adaptor = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adaptor.SelectCommand = cmd;
            adaptor.Fill(table);
            foreach (DataRow element in table.Rows)
            {
                cbxNumero.Items.Add(element[0]);
            }
            conn.Close();
        }
        private void AfficherReservations(bool search)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=;Convert Zero DateTime=true";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            if (search == false)
            {
                cmd.CommandText = "select * from reservation";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM reservation WHERE numero LIKE @numero";
                cmd.Parameters.Add("numero", MySqlDbType.VarChar).Value = txtSearch.Text + "%";
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
        private bool ChampOk()
        {
            if (txtCodeRe.Text != "" && txtDuree.Text != "" && cbxNumero.SelectedIndex != -1)
            {
                return true;
            }
            return false;
        }
        private void IlYaErreur()
        {
            if (txtCodeRe.Text != "")
            {
                errorProvider1.SetError(txtCodeRe, "");
            }
            else
            {
                errorProvider1.SetError(txtCodeRe, "Veillez entrer le code svp!");
            }
            if (txtDuree.Text == "")
            {
                errorProvider1.SetError(txtDuree, "Veillez remplir ce champ");
            }
            else
            {
                errorProvider1.SetError(txtDuree, "");
            }
            if (cbxNumero.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbxNumero, "Veillez selectionner ce numero!");
            }
            else
            {
                errorProvider1.SetError(cbxNumero, "");
            }
        }
        
        bool modifier = false;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ChampOk())
            {
                IlYaErreur();
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=logement;uid=root;pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (modifier == false)
            {
                cmd.CommandText = "INSERT INTO `reservation`(`codeReservation`, `dateReservation`, `numero`, `duree`) VALUES (@codeReservation,@dateReservation,@numero,@duree)";
            }
            else
            {
                cmd.CommandText = "UPDATE `reservation` SET `dateReservation`=@dateReservation,`numero`=@numero,`duree`=@duree WHERE `codeReservation`=@codeReservation";
            }
            cmd.Parameters.Add("numero", MySqlDbType.Int16).Value = cbxNumero.Text;
            cmd.Parameters.Add("codeReservation", MySqlDbType.VarChar).Value = txtCodeRe.Text;
            cmd.Parameters.Add("duree", MySqlDbType.VarChar).Value = txtDuree.Text;
            cmd.Parameters.Add("dateReservation", MySqlDbType.Date).Value = bunifuDatepicker1.Value;
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Enregistré avec succès!", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AfficherReservations(false);

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
            txtCodeRe.Text = dataGridView1.CurrentRow.Cells["codeReservation"].Value.ToString();
            txtDuree.Text = dataGridView1.CurrentRow.Cells["duree"].Value.ToString();
            cbxNumero.Text = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();
            bunifuDatepicker1.Text = dataGridView1.CurrentRow.Cells["dateReservation"].Value.ToString();
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
            cmd.CommandText = "delete from reservation where codeReservation=@codeReservation";
            cmd.Parameters.Add("codeReservation", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells["codeReservation"].Value.ToString();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suppression effectuée avec succès!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AfficherReservations(false);
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
            //AfficherVentes(true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //AfficherVentes(true);
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            AfficherReservations(true);
        }

        private void txtCodeRe_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtCodeRe.Text))
            //{
            //    e.Cancel = true;
            //    txtCodeRe.Focus();
            //    errorProvider1.SetError(txtCodeRe, "Svp entrer le code!");
            //}
            //else
            //{
            //    e.Cancel = true;
            //    //txtCodeRe.Focus();
            //    errorProvider1.SetError(txtCodeRe, null);
            //}
        }

        private void txtCodeRe_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodeRe, "");
        }

        private void txtDuree_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDuree, "");
        }

        private void cbxNumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbxNumero, "");
        }
    }
}
