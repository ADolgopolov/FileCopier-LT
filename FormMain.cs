using Microsoft.Win32;
using System.Windows.Forms;

namespace FileCopier
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private async void Button_StartCopy_Click(object sender, EventArgs e)
        {
            progressBar.Minimum = (int)numericUpDownStartIndex.Value;
            progressBar.Maximum = (int)numericUpDownEndIndex.Value;

            if (progressBar.Maximum - progressBar.Minimum < 500)
            {

                _ = new FileCopier();
                await FileCopier.CopyFilesInRangeAsync(
                    textBoxSourceDir.Text,
                    (int)numericUpDownStartIndex.Value,
                    (int)numericUpDownEndIndex.Value,
                    progressBar,
                    labelProgress);
                MessageBox.Show("Google Drive complete to swape files.", "Close this window...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Reduce the photo range. And try again.", "It will take a long time...", MessageBoxButtons.OK, MessageBoxIcon.Information); }
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
                    Properties.Settings.Default.SourceBaseFolder = textBoxSourceDir.Text;
                    Properties.Settings.Default.Save();
                }
                catch { }
            }
        }

        private void NumericUpDownStartIndex_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownEndIndex.Minimum = (int)numericUpDownStartIndex.Value;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxSourceDir.Text = Properties.Settings.Default.SourceBaseFolder;
            button_StartCopy.Enabled = true;
        }
    }
}
