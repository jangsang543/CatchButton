namespace CatchButton
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
            myButton = new Button();
            SuspendLayout();
            // 
            // myButton
            // 
            myButton.BackColor = Color.FromArgb(255, 255, 128);
            myButton.Font = new Font("휴먼둥근헤드라인", 36F, FontStyle.Bold, GraphicsUnit.Point, 129);
            myButton.ForeColor = Color.Fuchsia;
            myButton.Location = new Point(347, 282);
            myButton.Name = "myButton";
            myButton.Size = new Size(493, 156);
            myButton.TabIndex = 0;
            myButton.Text = "나를 잡아봐";
            myButton.UseVisualStyleBackColor = false;
            myButton.Click += myButton_Click;
            myButton.MouseEnter += myButton_MouseEnter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 790);
            Controls.Add(myButton);
            Name = "Form1";
            Text = "버튼 잡기 게임";
            ResumeLayout(false);
        }

        #endregion

        private Button myButton;
    }
}
