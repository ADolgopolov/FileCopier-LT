using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FileCopier
{
    public partial class FormMain : Form
    {
        // Зчитування налаштувань
        UserSettings userSettings = new UserSettings();

        public FormMain()
        {
            InitializeComponent();
        }

        private async void Button_StartCopy_Click(object sender, EventArgs e)
        {
            if (numericUpDownEndIndex.Value < numericUpDownStartIndex.Value)
            {
                // Міняємо значення місцями
                progressBar.Minimum = (int)numericUpDownEndIndex.Value;
                progressBar.Maximum = (int)numericUpDownStartIndex.Value;
            }
            else
            {
                progressBar.Minimum = (int)numericUpDownStartIndex.Value;
                progressBar.Maximum = (int)numericUpDownEndIndex.Value; ;
            }

            if (Math.Abs(numericUpDownEndIndex.Value - numericUpDownStartIndex.Value) < 5000)
            {

                _ = new FileCopier();
                await FileCopier.CopyFilesInRangeAsync(
                    textBoxSourceDir.Text,
                    (int)numericUpDownStartIndex.Value,
                    (int)numericUpDownEndIndex.Value,
                    progressBar,
                    labelProgress);
                if (userSettings.isAutoCloseProgram)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Google Drive complete to swape files.", "Close this window...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Reduce the photo range. And try again.", "It will take a long time...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonOpenSourceDir_Click(object sender, EventArgs e)
        {
            // Відображення діалогового вікна
            DialogResult result = folderBrowserDialogSource.ShowDialog();

            // Обробка результату
            if (result == DialogResult.OK)
            {
                // Отримання обраної папки
                textBoxSourceDir.Text = folderBrowserDialogSource.SelectedPath;
                button_StartCopy.Enabled = true;

                try
                {
                    userSettings.SourceBaseFolder = folderBrowserDialogSource.SelectedPath;
                    userSettings.SaveSettings();
                }
                catch { }
            }
        }

        private void NumericUpDownStartIndex_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_ValueChanged();
        }

        private void numericUpDownEndIndex_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_ValueChanged();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxSourceDir.Text = userSettings.SourceBaseFolder;
            button_StartCopy.Enabled = true;
            checkBox_AutoClose.Checked = userSettings.isAutoCloseProgram;
        }

        private void checkBox_AutoClose_CheckedChanged(object sender, EventArgs e)
        {
            userSettings.isAutoCloseProgram = checkBox_AutoClose.Checked;
            userSettings.SaveSettings();
        }

        private void numericUpDown_ValueChanged()
        {
            decimal amount = Math.Abs(numericUpDownStartIndex.Value - numericUpDownEndIndex.Value);
            label_PhotoAmount.Text = amount.ToString();
            if (amount < 500)
                label_PhotoAmount.ForeColor = Color.Green;
            else
                if (amount < 1000)
                label_PhotoAmount.ForeColor = Color.OrangeRed;
            else label_PhotoAmount.ForeColor = Color.Red;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText() && Clipboard.GetText().Contains(".jpg"))
                {
                    if (decimal.TryParse(Path.GetFileNameWithoutExtension(Clipboard.GetText()), out decimal dd))
                    {
                        if(e.Shift) numericUpDownEndIndex.Value = dd;
                        else numericUpDownStartIndex.Value = dd;
                    }
                }
                else MessageBox.Show("Буфер не місить назву JPG файлу: \n\n" + Clipboard.GetText(), "Не відповідність вводу.", MessageBoxButtons.OK);
            }
        }
    }
}
