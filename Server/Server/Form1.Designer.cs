namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.myConsole = new System.Windows.Forms.TextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myConsole
            // 
            this.myConsole.Location = new System.Drawing.Point(12, 12);
            this.myConsole.Multiline = true;
            this.myConsole.Name = "myConsole";
            this.myConsole.Size = new System.Drawing.Size(634, 380);
            this.myConsole.TabIndex = 0;
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(348, 398);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(298, 32);
            this.listenButton.TabIndex = 1;
            this.listenButton.Text = "Clear Console";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 461);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.myConsole);
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox myConsole;
        private System.Windows.Forms.Button listenButton;
    }
}

