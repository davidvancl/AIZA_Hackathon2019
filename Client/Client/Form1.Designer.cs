namespace Client
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
            this.inputData = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.myConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputData
            // 
            this.inputData.Location = new System.Drawing.Point(12, 12);
            this.inputData.Multiline = true;
            this.inputData.Name = "inputData";
            this.inputData.Size = new System.Drawing.Size(776, 100);
            this.inputData.TabIndex = 0;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(615, 118);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(173, 40);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "SendData";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // myConsole
            // 
            this.myConsole.Location = new System.Drawing.Point(12, 280);
            this.myConsole.Multiline = true;
            this.myConsole.Name = "myConsole";
            this.myConsole.Size = new System.Drawing.Size(776, 148);
            this.myConsole.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myConsole);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.inputData);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputData;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox myConsole;
    }
}

