namespace BattagliaNavale
{
    partial class PartitaForm
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
            this.panelCampoGiocatore_1 = new System.Windows.Forms.Panel();
            this.panelCampoGiocatore_2 = new System.Windows.Forms.Panel();
            this.naviPosizionateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelCampoGiocatore_1
            // 
            this.panelCampoGiocatore_1.Location = new System.Drawing.Point(12, 95);
            this.panelCampoGiocatore_1.Name = "panelCampoGiocatore_1";
            this.panelCampoGiocatore_1.Size = new System.Drawing.Size(500, 500);
            this.panelCampoGiocatore_1.TabIndex = 0;
            // 
            // panelCampoGiocatore_2
            // 
            this.panelCampoGiocatore_2.Location = new System.Drawing.Point(739, 95);
            this.panelCampoGiocatore_2.Name = "panelCampoGiocatore_2";
            this.panelCampoGiocatore_2.Size = new System.Drawing.Size(500, 500);
            this.panelCampoGiocatore_2.TabIndex = 1;
            // 
            // naviPosizionateBtn
            // 
            this.naviPosizionateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naviPosizionateBtn.Location = new System.Drawing.Point(518, 276);
            this.naviPosizionateBtn.Name = "naviPosizionateBtn";
            this.naviPosizionateBtn.Size = new System.Drawing.Size(215, 64);
            this.naviPosizionateBtn.TabIndex = 2;
            this.naviPosizionateBtn.Text = "INIZIAMO!";
            this.naviPosizionateBtn.UseVisualStyleBackColor = true;
            this.naviPosizionateBtn.Visible = false;
            // 
            // PartitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 613);
            this.Controls.Add(this.naviPosizionateBtn);
            this.Controls.Add(this.panelCampoGiocatore_2);
            this.Controls.Add(this.panelCampoGiocatore_1);
            this.MaximizeBox = false;
            this.Name = "PartitaForm";
            this.Text = "PartitaForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCampoGiocatore_1;
        private System.Windows.Forms.Panel panelCampoGiocatore_2;
        private System.Windows.Forms.Button naviPosizionateBtn;
    }
}