namespace GPT4allTest
{
    partial class mainform
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
            btnSend = new Button();
            txtSend = new TextBox();
            rtbConver = new RichTextBox();
            rtbLogOutput = new RichTextBox();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(288, 256);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(110, 84);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtSend
            // 
            txtSend.Location = new Point(12, 256);
            txtSend.Multiline = true;
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(253, 84);
            txtSend.TabIndex = 1;
            // 
            // rtbConver
            // 
            rtbConver.Location = new Point(12, 12);
            rtbConver.Name = "rtbConver";
            rtbConver.Size = new Size(789, 238);
            rtbConver.TabIndex = 2;
            rtbConver.Text = "";
            // 
            // rtbLogOutput
            // 
            rtbLogOutput.Location = new Point(12, 399);
            rtbLogOutput.Name = "rtbLogOutput";
            rtbLogOutput.Size = new Size(843, 208);
            rtbLogOutput.TabIndex = 3;
            rtbLogOutput.Text = "";
            // 
            // mainform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 619);
            Controls.Add(rtbLogOutput);
            Controls.Add(rtbConver);
            Controls.Add(txtSend);
            Controls.Add(btnSend);
            Name = "mainform";
            Text = "Form1";
            Load += mainform_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private TextBox txtSend;
        private RichTextBox rtbConver;
        private RichTextBox rtbLogOutput;
    }
}