namespace Restau
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRapports = new System.Windows.Forms.Button();
            this.btnVente = new System.Windows.Forms.Button();
            this.btnProduits = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlShow = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.btnAccueil);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnRapports);
            this.panel1.Controls.Add(this.btnVente);
            this.panel1.Controls.Add(this.btnProduits);
            this.panel1.Controls.Add(this.btnCategories);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 532);
            this.panel1.TabIndex = 0;
            // 
            // btnAccueil
            // 
            this.btnAccueil.FlatAppearance.BorderSize = 0;
            this.btnAccueil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccueil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.ForeColor = System.Drawing.Color.White;
            this.btnAccueil.Image = global::Restau.Properties.Resources.icons8_home_50px_2;
            this.btnAccueil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccueil.Location = new System.Drawing.Point(-1, 127);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Size = new System.Drawing.Size(145, 79);
            this.btnAccueil.TabIndex = 0;
            this.btnAccueil.Text = "Accueil";
            this.btnAccueil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccueil.UseVisualStyleBackColor = true;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Restau.Properties.Resources.Logo_Hotel_la_Reference_Beni;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnRapports
            // 
            this.btnRapports.FlatAppearance.BorderSize = 0;
            this.btnRapports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnRapports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRapports.ForeColor = System.Drawing.Color.White;
            this.btnRapports.Image = global::Restau.Properties.Resources.icons8_report_card_filled_50px_1;
            this.btnRapports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapports.Location = new System.Drawing.Point(-1, 458);
            this.btnRapports.Name = "btnRapports";
            this.btnRapports.Size = new System.Drawing.Size(145, 79);
            this.btnRapports.TabIndex = 0;
            this.btnRapports.Text = "Rapports";
            this.btnRapports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRapports.UseVisualStyleBackColor = true;
            // 
            // btnVente
            // 
            this.btnVente.FlatAppearance.BorderSize = 0;
            this.btnVente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnVente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVente.ForeColor = System.Drawing.Color.White;
            this.btnVente.Image = global::Restau.Properties.Resources.icons8_lift_cart_here_50px;
            this.btnVente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVente.Location = new System.Drawing.Point(-4, 373);
            this.btnVente.Name = "btnVente";
            this.btnVente.Size = new System.Drawing.Size(145, 79);
            this.btnVente.TabIndex = 0;
            this.btnVente.Text = "Vente";
            this.btnVente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVente.UseVisualStyleBackColor = true;
            this.btnVente.Click += new System.EventHandler(this.btnVente_Click);
            // 
            // btnProduits
            // 
            this.btnProduits.FlatAppearance.BorderSize = 0;
            this.btnProduits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnProduits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduits.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduits.ForeColor = System.Drawing.Color.White;
            this.btnProduits.Image = global::Restau.Properties.Resources.icons8_procurement_50px;
            this.btnProduits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduits.Location = new System.Drawing.Point(-4, 288);
            this.btnProduits.Name = "btnProduits";
            this.btnProduits.Size = new System.Drawing.Size(145, 79);
            this.btnProduits.TabIndex = 0;
            this.btnProduits.Text = "Produits";
            this.btnProduits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProduits.UseVisualStyleBackColor = true;
            this.btnProduits.Click += new System.EventHandler(this.btnProduits_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Image = global::Restau.Properties.Resources.icons8_sorting_answers_50px;
            this.btnCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.Location = new System.Drawing.Point(-1, 212);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(145, 79);
            this.btnCategories.TabIndex = 0;
            this.btnCategories.Text = "Catégories";
            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(144, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 130);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(378, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bar";
            // 
            // pnlShow
            // 
            this.pnlShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(98)))), ((int)(((byte)(1)))));
            this.pnlShow.Location = new System.Drawing.Point(144, 130);
            this.pnlShow.Name = "pnlShow";
            this.pnlShow.Size = new System.Drawing.Size(848, 402);
            this.pnlShow.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(241, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "HOTEL LA REFERENCE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(992, 532);
            this.Controls.Add(this.pnlShow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAccueil;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVente;
        private System.Windows.Forms.Button btnProduits;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnRapports;
        private System.Windows.Forms.Panel pnlShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

