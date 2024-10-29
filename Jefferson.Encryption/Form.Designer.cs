namespace Jefferson.Encryption
{
    partial class Form
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
            this.buttonDekripto = new System.Windows.Forms.Button();
            this.buttonEnkripto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOutputi = new System.Windows.Forms.TextBox();
            this.labelTeksti = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDekripto
            // 
            this.buttonDekripto.Location = new System.Drawing.Point(354, 229);
            this.buttonDekripto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDekripto.Name = "buttonDekripto";
            this.buttonDekripto.Size = new System.Drawing.Size(168, 35);
            this.buttonDekripto.TabIndex = 41;
            this.buttonDekripto.Text = "&Dekripto";
            this.buttonDekripto.UseVisualStyleBackColor = true;
            this.buttonDekripto.Click += new System.EventHandler(this.buttonDekripto_Click);
            // 
            // buttonEnkripto
            // 
            this.buttonEnkripto.Location = new System.Drawing.Point(549, 231);
            this.buttonEnkripto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEnkripto.Name = "buttonEnkripto";
            this.buttonEnkripto.Size = new System.Drawing.Size(168, 35);
            this.buttonEnkripto.TabIndex = 40;
            this.buttonEnkripto.Text = "&Enkripto";
            this.buttonEnkripto.UseVisualStyleBackColor = true;
            this.buttonEnkripto.Click += new System.EventHandler(this.buttonEnkripto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "Rezultati";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxOutputi
            // 
            this.textBoxOutputi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutputi.Location = new System.Drawing.Point(28, 274);
            this.textBoxOutputi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxOutputi.Multiline = true;
            this.textBoxOutputi.Name = "textBoxOutputi";
            this.textBoxOutputi.Size = new System.Drawing.Size(686, 102);
            this.textBoxOutputi.TabIndex = 38;
            this.textBoxOutputi.TextChanged += new System.EventHandler(this.textBoxOutputi_TextChanged);
            // 
            // labelTeksti
            // 
            this.labelTeksti.AutoSize = true;
            this.labelTeksti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeksti.Location = new System.Drawing.Point(24, 86);
            this.labelTeksti.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTeksti.Name = "labelTeksti";
            this.labelTeksti.Size = new System.Drawing.Size(376, 25);
            this.labelTeksti.TabIndex = 37;
            this.labelTeksti.Text = "Shënoni tekstin e pastër ose të enkriptuar:";
            this.labelTeksti.Click += new System.EventHandler(this.labelTeksti_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(28, 117);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(686, 102);
            this.textBoxInput.TabIndex = 36;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 36);
            this.label1.TabIndex = 35;
            this.label1.Text = "Enkriptimi dhe dekriptimi i të dhënave";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 535);
            this.Controls.Add(this.buttonDekripto);
            this.Controls.Add(this.buttonEnkripto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOutputi);
            this.Controls.Add(this.labelTeksti);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDekripto;
        private System.Windows.Forms.Button buttonEnkripto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOutputi;
        private System.Windows.Forms.Label labelTeksti;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label label1;
    }
}

