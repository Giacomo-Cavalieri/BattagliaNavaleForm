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
            // MenuPrincipaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 430);
            this.Controls.Add(this.esciBtn);
            this.Controls.Add(this.iniziaBtn);
            this.Controls.Add(this.sfondoMenuPic);
            this.MaximizeBox = false;
            this.Name = "MenuPrincipaleForm";
            this.Text = "MenuPrincipaleForm";
            ((System.ComponentModel.ISupportInitialize)(this.sfondoMenuPic)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button iniziaBtn;
        private System.Windows.Forms.Button esciBtn;
        private System.Windows.Forms.PictureBox sfondoMenuPic;
    }
}