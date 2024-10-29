namespace JeffersonEncryptionDecryption
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InputText = new RichTextBox();
            label1 = new Label();
            ResultText = new RichTextBox();
            label2 = new Label();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            SuspendLayout();
            // 
            // InputText
            // 
            InputText.Location = new Point(12, 72);
            InputText.Name = "InputText";
            InputText.Size = new Size(776, 120);
            InputText.TabIndex = 0;
            InputText.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 1;
            label1.Text = "Sheno tekstin:";
            // 
            // ResultText
            // 
            ResultText.Location = new Point(12, 302);
            ResultText.Name = "ResultText";
            ResultText.Size = new Size(776, 120);
            ResultText.TabIndex = 2;
            ResultText.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 279);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Rezultati:";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(12, 198);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(164, 45);
            btnEncrypt.TabIndex = 4;
            btnEncrypt.Text = "Enkripto";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(182, 198);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(164, 45);
            btnDecrypt.TabIndex = 5;
            btnDecrypt.Text = "Dekripto";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(label2);
            Controls.Add(ResultText);
            Controls.Add(label1);
            Controls.Add(InputText);
            Name = "Form1";
            Text = "Jefferson Encryption and Decryption";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox InputText;
        private Label label1;
        private RichTextBox ResultText;
        private Label label2;
        private Button btnEncrypt;
        private Button btnDecrypt;
    }
}
