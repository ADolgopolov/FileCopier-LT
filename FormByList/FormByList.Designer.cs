namespace FileCopier.FormByList
{
    partial class FormByList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormByList));
            textBoxForList = new TextBox();
            numericShiftAround = new NumericUpDown();
            label_AroundPhotoNumber = new Label();
            button_SwapFiles = new Button();
            label_Help = new Label();
            ((System.ComponentModel.ISupportInitialize)numericShiftAround).BeginInit();
            SuspendLayout();
            // 
            // textBoxForList
            // 
            textBoxForList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxForList.Location = new Point(12, 45);
            textBoxForList.Multiline = true;
            textBoxForList.Name = "textBoxForList";
            textBoxForList.ScrollBars = ScrollBars.Vertical;
            textBoxForList.Size = new Size(429, 477);
            textBoxForList.TabIndex = 1;
            // 
            // numericShiftAround
            // 
            numericShiftAround.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numericShiftAround.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericShiftAround.Location = new Point(12, 535);
            numericShiftAround.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericShiftAround.Name = "numericShiftAround";
            numericShiftAround.Size = new Size(57, 29);
            numericShiftAround.TabIndex = 2;
            numericShiftAround.TextAlign = HorizontalAlignment.Center;
            numericShiftAround.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label_AroundPhotoNumber
            // 
            label_AroundPhotoNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_AroundPhotoNumber.AutoSize = true;
            label_AroundPhotoNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_AroundPhotoNumber.Location = new Point(84, 537);
            label_AroundPhotoNumber.Name = "label_AroundPhotoNumber";
            label_AroundPhotoNumber.Size = new Size(192, 21);
            label_AroundPhotoNumber.TabIndex = 3;
            label_AroundPhotoNumber.Text = "Around the photo number";
            // 
            // button_SwapFiles
            // 
            button_SwapFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_SwapFiles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button_SwapFiles.Location = new Point(325, 528);
            button_SwapFiles.Name = "button_SwapFiles";
            button_SwapFiles.Size = new Size(116, 38);
            button_SwapFiles.TabIndex = 4;
            button_SwapFiles.Text = "Get Numbers";
            button_SwapFiles.UseVisualStyleBackColor = true;
            button_SwapFiles.Click += button_SwapFiles_Click;
            // 
            // label_Help
            // 
            label_Help.AutoSize = true;
            label_Help.Location = new Point(12, 9);
            label_Help.Name = "label_Help";
            label_Help.Size = new Size(339, 15);
            label_Help.TabIndex = 5;
            label_Help.Text = "Можна вставити з колонки \"New link Photo\" або \"Photo NO\"";
            // 
            // FormByList
            // 
            AcceptButton = button_SwapFiles;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 578);
            Controls.Add(label_Help);
            Controls.Add(button_SwapFiles);
            Controls.Add(label_AroundPhotoNumber);
            Controls.Add(numericShiftAround);
            Controls.Add(textBoxForList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 400);
            Name = "FormByList";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter List from tracking";
            Load += FormByList_Load;
            ((System.ComponentModel.ISupportInitialize)numericShiftAround).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxForList;
        private NumericUpDown numericShiftAround;
        private Label label_AroundPhotoNumber;
        private Button button_SwapFiles;
        private Label label_Help;
    }
}