using System.Drawing;

namespace BattagliaNavale
{
    partial class MenuPrincipaleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iniziaBtn = new System.Windows.Forms.Button();
            this.esciBtn = new System.Windows.Forms.Button();
            this.sfondoMenuPic = new System.Windows.Forms.PictureBox();
            this.titoloLabel = new System.Windows.Forms.Label();
            this.autore1 = new System.Windows.Forms.Label();
            this.autore2 = new System.Windows.Forms.Label();
            this.docente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sfondoMenuPic)).BeginInit();
            this.SuspendLayout();
            // 
            // iniziaBtn
            // 
            this.iniziaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniziaBtn.Location = new System.Drawing.Point(318, 262);
            this.iniziaBtn.Name = "iniziaBtn";
            this.iniziaBtn.Size = new System.Drawing.Size(141, 63);
            this.iniziaBtn.TabIndex = 0;
            this.iniziaBtn.Text = "INIZIA PARTITA";
            this.iniziaBtn.UseVisualStyleBackColor = true;
            // 
            // esciBtn
            // 
            this.esciBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esciBtn.Location = new System.Drawing.Point(318, 355);
            this.esciBtn.Name = "esciBtn";
            this.esciBtn.Size = new System.Drawing.Size(141, 63);
            this.esciBtn.TabIndex = 1;
            this.esciBtn.Text = "ESCI";
            this.esciBtn.UseVisualStyleBackColor = true;
            // 
            // sfondoMenuPic
            // 
            this.sfondoMenuPic.Location = new System.Drawing.Point(-1, 0);
            this.sfondoMenuPic.Name = "sfondoMenuPic";
            this.sfondoMenuPic.Size = new System.Drawing.Size(738, 430);
            this.sfondoMenuPic.TabIndex = 2;
            this.sfondoMenuPic.TabStop = false;
            // 
            // titoloLabel
            // 
            this.titoloLabel.AutoSize = true;
            this.titoloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titoloLabel.Location = new System.Drawing.Point(128, 9);
            this.titoloLabel.Name = "titoloLabel";
            this.titoloLabel.Size = new System.Drawing.Size(146, 55);
            this.titoloLabel.TabIndex = 3;
            this.titoloLabel.Text = "Titolo";
            // 
            // autore1
            // 
            this.autore1.AutoSize = true;
            this.autore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autore1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.autore1.Location = new System.Drawing.Point(135, 64);
            this.autore1.Name = "autore1";
            this.autore1.Size = new System.Drawing.Size(119, 20);
            this.autore1.TabIndex = 4;
            this.autore1.Text = "NomeAutore1";
            // 
            // autore2
            // 
            this.autore2.AutoSize = true;
            this.autore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autore2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.autore2.Location = new System.Drawing.Point(402, 64);
            this.autore2.Name = "autore2";
            this.autore2.Size = new System.Drawing.Size(119, 20);
            this.autore2.TabIndex = 5;
            this.autore2.Text = "NomeAutore2";
            // 
            // docente
            // 
            this.docente.AutoSize = true;
            this.docente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.docente.Location = new System.Drawing.Point(288, 95);
            this.docente.Name = "docente";
            this.docente.Size = new System.Drawing.Size(77, 20);
            this.docente.TabIndex = 6;
            this.docente.Text = "Docente";
            // 
            // MenuPrincipaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 430);
            this.Controls.Add(this.docente);
            this.Controls.Add(this.autore2);
            this.Controls.Add(this.autore1);
            this.Controls.Add(this.titoloLabel);
            this.Controls.Add(this.esciBtn);
            this.Controls.Add(this.iniziaBtn);
            this.Controls.Add(this.sfondoMenuPic);
            this.MaximizeBox = false;
            this.Name = "MenuPrincipaleForm";
            this.Text = "MenuPrincipaleForm";
            ((System.ComponentModel.ISupportInitialize)(this.sfondoMenuPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button iniziaBtn;
        private System.Windows.Forms.Button esciBtn;
        private System.Windows.Forms.PictureBox sfondoMenuPic;
        private System.Windows.Forms.Label titoloLabel;
        private System.Windows.Forms.Label autore1;
        private System.Windows.Forms.Label autore2;
        private System.Windows.Forms.Label docente;
    }
}