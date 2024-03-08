namespace FileCopier
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            label1 = new Label();
            textBoxSourceDir = new TextBox();
            buttonOpenSourceDir = new Button();
            numericUpDownStartIndex = new NumericUpDown();
            numericUpDownEndIndex = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            button_StartCopy = new Button();
            progressBar = new ProgressBar();
            folderBrowserDialogSource = new FolderBrowserDialog();
            folderBrowserDialogDestanation = new FolderBrowserDialog();
            labelProgress = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStartIndex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEndIndex).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(452, 21);
            label1.TabIndex = 0;
            label1.Text = "Specify the folder and specify the range of photos that you need";
            // 
            // textBoxSourceDir
            // 
            textBoxSourceDir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSourceDir.Location = new Point(12, 33);
            textBoxSourceDir.Name = "textBoxSourceDir";
            textBoxSourceDir.ReadOnly = true;
            textBoxSourceDir.Size = new Size(681, 29);
            textBoxSourceDir.TabIndex = 1;
            textBoxSourceDir.TextAlign = HorizontalAlignment.Right;
            // 
            // buttonOpenSourceDir
            // 
            buttonOpenSourceDir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonOpenSourceDir.Location = new Point(699, 33);
            buttonOpenSourceDir.Name = "buttonOpenSourceDir";
            buttonOpenSourceDir.Size = new Size(158, 32);
            buttonOpenSourceDir.TabIndex = 4;
            buttonOpenSourceDir.Text = "Open Run Folder";
            buttonOpenSourceDir.UseVisualStyleBackColor = true;
            buttonOpenSourceDir.Click += ButtonOpenSourceDir_Click;
            // 
            // numericUpDownStartIndex
            // 
            numericUpDownStartIndex.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownStartIndex.Location = new Point(12, 77);
            numericUpDownStartIndex.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownStartIndex.Name = "numericUpDownStartIndex";
            numericUpDownStartIndex.Size = new Size(80, 29);
            numericUpDownStartIndex.TabIndex = 6;
            numericUpDownStartIndex.ValueChanged += NumericUpDownStartIndex_ValueChanged;
            // 
            // numericUpDownEndIndex
            // 
            numericUpDownEndIndex.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownEndIndex.Location = new Point(302, 77);
            numericUpDownEndIndex.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownEndIndex.Name = "numericUpDownEndIndex";
            numericUpDownEndIndex.Size = new Size(80, 29);
            numericUpDownEndIndex.TabIndex = 7;
            numericUpDownEndIndex.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(98, 79);
            label3.Name = "label3";
            label3.Size = new Size(128, 21);
            label3.TabIndex = 8;
            label3.Text = "Start photo index";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(388, 79);
            label4.Name = "label4";
            label4.Size = new Size(122, 21);
            label4.TabIndex = 9;
            label4.Text = "End photo index";
            // 
            // button_StartCopy
            // 
            button_StartCopy.Enabled = false;
            button_StartCopy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button_StartCopy.Location = new Point(595, 71);
            button_StartCopy.Name = "button_StartCopy";
            button_StartCopy.Size = new Size(262, 36);
            button_StartCopy.TabIndex = 10;
            button_StartCopy.Text = "Swap Files";
            button_StartCopy.UseVisualStyleBackColor = true;
            button_StartCopy.Click += Button_StartCopy_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 128);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(845, 23);
            progressBar.Step = 1;
            progressBar.TabIndex = 11;
            // 
            // folderBrowserDialogSource
            // 
            folderBrowserDialogSource.Description = "Open RUN folder";
            folderBrowserDialogSource.ShowNewFolderButton = false;
            // 
            // folderBrowserDialogDestanation
            // 
            folderBrowserDialogDestanation.Description = "Destanation folder";
            // 
            // labelProgress
            // 
            labelProgress.Location = new Point(12, 110);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(845, 15);
            labelProgress.TabIndex = 12;
            labelProgress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 161);
            Controls.Add(labelProgress);
            Controls.Add(progressBar);
            Controls.Add(button_StartCopy);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDownEndIndex);
            Controls.Add(numericUpDownStartIndex);
            Controls.Add(buttonOpenSourceDir);
            Controls.Add(textBoxSourceDir);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File-Копір";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownStartIndex).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEndIndex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxSourceDir;
        private Button buttonOpenSourceDir;
        private NumericUpDown numericUpDownStartIndex;
        private NumericUpDown numericUpDownEndIndex;
        private Label label3;
        private Label label4;
        private Button button_StartCopy;
        private ProgressBar progressBar;
        private FolderBrowserDialog folderBrowserDialogSource;
        private FolderBrowserDialog folderBrowserDialogDestanation;
        private Label labelProgress;
    }
}
