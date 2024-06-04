namespace Assignment4_CS_GUI
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            btnLoadFile = new Button();
            label1 = new Label();
            label2 = new Label();
            txtFind = new TextBox();
            txtReplace = new TextBox();
            rtxtSource = new RichTextBox();
            rtxtDest = new RichTextBox();
            lblSource = new Label();
            lstStatus = new ListBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            openFileDialog1 = new OpenFileDialog();
            btnOk = new Button();
            toolTip1 = new ToolTip(components);
            saveFileDialog1 = new SaveFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(24, 11);
            btnLoadFile.Margin = new Padding(3, 2, 3, 2);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(124, 49);
            btnLoadFile.TabIndex = 0;
            btnLoadFile.Text = "Load File";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(177, 13);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Find";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(159, 37);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 2;
            label2.Text = "Replace";
            // 
            // txtFind
            // 
            txtFind.Location = new Point(230, 10);
            txtFind.Margin = new Padding(3, 2, 3, 2);
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(452, 23);
            txtFind.TabIndex = 3;
            txtFind.TextChanged += txtFind_TextChanged_1;
            // 
            // txtReplace
            // 
            txtReplace.Location = new Point(228, 37);
            txtReplace.Margin = new Padding(3, 2, 3, 2);
            txtReplace.Name = "txtReplace";
            txtReplace.Size = new Size(454, 23);
            txtReplace.TabIndex = 4;
            txtReplace.TextChanged += txtReplace_TextChanged;
            // 
            // rtxtSource
            // 
            rtxtSource.Location = new Point(9, 20);
            rtxtSource.Margin = new Padding(3, 2, 3, 2);
            rtxtSource.Name = "rtxtSource";
            rtxtSource.Size = new Size(374, 203);
            rtxtSource.TabIndex = 5;
            rtxtSource.Text = "";
            rtxtSource.TextChanged += rtxtSource_TextChanged;
            // 
            // rtxtDest
            // 
            rtxtDest.Location = new Point(389, 20);
            rtxtDest.Margin = new Padding(3, 2, 3, 2);
            rtxtDest.Name = "rtxtDest";
            rtxtDest.Size = new Size(374, 203);
            rtxtDest.TabIndex = 5;
            rtxtDest.Text = "";
            rtxtDest.TextChanged += rtxtDest_TextChanged;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(24, 71);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(49, 15);
            lblSource.TabIndex = 6;
            lblSource.Text = "Source: ";
            // 
            // lstStatus
            // 
            lstStatus.FormattingEnabled = true;
            lstStatus.ItemHeight = 15;
            lstStatus.Location = new Point(14, 29);
            lstStatus.Margin = new Padding(3, 2, 3, 2);
            lstStatus.Name = "lstStatus";
            lstStatus.Size = new Size(769, 214);
            lstStatus.TabIndex = 8;
            lstStatus.SelectedIndexChanged += lstStatus_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rtxtDest);
            groupBox1.Controls.Add(rtxtSource);
            groupBox1.Location = new Point(12, 98);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(787, 237);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "  Editor  ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstStatus);
            groupBox2.Location = new Point(4, 350);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(798, 192);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Logbook";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOk
            // 
            btnOk.CausesValidation = false;
            btnOk.Location = new Point(688, 13);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(119, 47);
            btnOk.TabIndex = 11;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 530);
            Controls.Add(lblSource);
            Controls.Add(btnOk);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtReplace);
            Controls.Add(txtFind);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLoadFile);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadFile;
        private Label label1;
        private Label label2;
        private TextBox txtFind;
        private TextBox txtReplace;
        private RichTextBox rtxtSource;
        private RichTextBox rtxtDest;
        private Label lblSource;
        private ListBox lstStatus;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private OpenFileDialog openFileDialog1;
        private Button btnOk;
        private ToolTip toolTip1;
        private SaveFileDialog saveFileDialog1;
    }
}