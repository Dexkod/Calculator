namespace Calculator
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
            CalculateTextBox = new TextBox();
            CalculateBtn = new Button();
            DerTextBox = new TextBox();
            Label1 = new Label();
            SuspendLayout();
            // 
            // CalculateTextBox
            // 
            CalculateTextBox.Location = new Point(189, 174);
            CalculateTextBox.Name = "CalculateTextBox";
            CalculateTextBox.Size = new Size(300, 27);
            CalculateTextBox.TabIndex = 0;
            // 
            // CalculateBtn
            // 
            CalculateBtn.Location = new Point(495, 172);
            CalculateBtn.Name = "CalculateBtn";
            CalculateBtn.Size = new Size(94, 29);
            CalculateBtn.TabIndex = 1;
            CalculateBtn.Text = "Вычислить";
            CalculateBtn.UseVisualStyleBackColor = true;
            CalculateBtn.Click += CalculateBtn_Click;
            // 
            // DerTextBox
            // 
            DerTextBox.Location = new Point(231, 59);
            DerTextBox.Name = "DerTextBox";
            DerTextBox.Size = new Size(125, 27);
            DerTextBox.TabIndex = 2;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(362, 62);
            Label1.Name = "Label1";
            Label1.Size = new Size(104, 20);
            Label1.TabIndex = 3;
            Label1.Text = "Производная";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Label1);
            Controls.Add(DerTextBox);
            Controls.Add(CalculateBtn);
            Controls.Add(CalculateTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CalculateTextBox;
        private Button CalculateBtn;
        private TextBox DerTextBox;
        private Label Label1;
    }
}
