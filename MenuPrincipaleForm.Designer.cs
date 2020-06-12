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
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MenuPrincipaleForm";
            this.IniziaPartitaBtn = new System.Windows.Forms.Button();
            this.Controls.Add(IniziaPartitaBtn);
            this.EsciDalGiocoBtn = new System.Windows.Forms.Button();
            this.Controls.Add(EsciDalGiocoBtn);

            //
            // Bottone Inizia Partita
            //            
            this.IniziaPartitaBtn.Text = "INIZIA PARTITA";
            // Imposto un font che utilizza il grassetto Grassetto
            this.IniziaPartitaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                                 System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniziaPartitaBtn.Location = new System.Drawing.Point(321, 287);
            this.IniziaPartitaBtn.Size = new System.Drawing.Size(98, 47);
            this.IniziaPartitaBtn.Name = "IniziaPartitaBtn";
            this.IniziaPartitaBtn.Visible = true;

            //
            // Bottone Esci dal Gioco
            //
            this.EsciDalGiocoBtn.Text = "ESCI DAL GIOCO";
            this.EsciDalGiocoBtn.Location = new Point(321, 366);
            this.EsciDalGiocoBtn.Size = new System.Drawing.Size(98, 47);
            this.EsciDalGiocoBtn.Name = "EsciBtn";
            this.EsciDalGiocoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                                 System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte)(0)));


        }
        


        #endregion
    }
}