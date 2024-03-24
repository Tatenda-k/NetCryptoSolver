namespace Net6CryptoSolver
{
    partial class UserInterface
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
            uxMessage = new TextBox();
            uxEncrypt = new Button();
            uxDecrypt = new Button();
            uxResult = new TextBox();
            uxMessageLabel = new Label();
            SuspendLayout();
            // 
            // uxMessage
            // 
            uxMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uxMessage.Location = new Point(42, 71);
            uxMessage.Margin = new Padding(3, 4, 3, 4);
            uxMessage.Multiline = true;
            uxMessage.Name = "uxMessage";
            uxMessage.ScrollBars = ScrollBars.Vertical;
            uxMessage.Size = new Size(751, 244);
            uxMessage.TabIndex = 0;
            // 
            // uxEncrypt
            // 
            uxEncrypt.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            uxEncrypt.Location = new Point(125, 344);
            uxEncrypt.Margin = new Padding(3, 4, 3, 4);
            uxEncrypt.Name = "uxEncrypt";
            uxEncrypt.Size = new Size(151, 77);
            uxEncrypt.TabIndex = 1;
            uxEncrypt.Text = "Encrypt";
            uxEncrypt.UseVisualStyleBackColor = true;
            uxEncrypt.Click += UxEncrypt_Click;
            // 
            // uxDecrypt
            // 
            uxDecrypt.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            uxDecrypt.Location = new Point(525, 344);
            uxDecrypt.Margin = new Padding(3, 4, 3, 4);
            uxDecrypt.Name = "uxDecrypt";
            uxDecrypt.Size = new Size(151, 77);
            uxDecrypt.TabIndex = 2;
            uxDecrypt.Text = "Decrypt";
            uxDecrypt.UseVisualStyleBackColor = true;
            uxDecrypt.Click += UxDecrypt_Click;
            // 
            // uxResult
            // 
            uxResult.BackColor = SystemColors.ButtonFace;
            uxResult.Location = new Point(42, 455);
            uxResult.Margin = new Padding(3, 4, 3, 4);
            uxResult.Multiline = true;
            uxResult.Name = "uxResult";
            uxResult.ReadOnly = true;
            uxResult.ScrollBars = ScrollBars.Vertical;
            uxResult.Size = new Size(751, 235);
            uxResult.TabIndex = 3;
            // 
            // uxMessageLabel
            // 
            uxMessageLabel.AutoSize = true;
            uxMessageLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            uxMessageLabel.Location = new Point(26, 36);
            uxMessageLabel.Name = "uxMessageLabel";
            uxMessageLabel.Size = new Size(113, 32);
            uxMessageLabel.TabIndex = 4;
            uxMessageLabel.Text = "Message";
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 707);
            Controls.Add(uxMessageLabel);
            Controls.Add(uxResult);
            Controls.Add(uxDecrypt);
            Controls.Add(uxEncrypt);
            Controls.Add(uxMessage);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "UserInterface";
            Text = "Crypto Solver";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox uxMessage;
        private Button uxEncrypt;
        private Button uxDecrypt;
        private TextBox uxResult;
        private Label uxMessageLabel;
    }
}