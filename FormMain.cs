using FileCopier.FormByList;
using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileCopier
{
    public partial class FormMain : Form
    {
        // Зчитування налаштувань
        UserSettings userSettings = new UserSettings();

        FormByList.FormByList formByList = new FormByList.FormByList();

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(string folder, string startNumber)
        {
            InitializeComponent();

            if (Directory.Exists(folder))
            {
                userSettings.SourceBaseFolder = folder;
                userSettings.SaveSettings();
            }

            if (decimal.TryParse(startNumber, out decimal dd))
            {
                numericUpDownStartIndex.Value = dd;
            }
        }

        private async void Button_StartCopy_Click(object sender, EventArgs e)
        {
            if (checkBox_SwapByList.Checked && formByList.photoListNumbers.Count > 0)
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = formByList.photoListNumbers.Count;
                button_StartCopy.Enabled = false;
                _ = new FileCopier();
                await FileCopier.CopyFilesByListAsync(
                    textBoxSourceDir.Text,
                    formByList.photoListNumbers,
                    progressBar,
                    labelProgress);
                if (userSettings.isAutoCloseProgram)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Google Drive complete to swape files.", "Close this window...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_StartCopy.Enabled = true;
                }
            }
            else
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
                    progressBar.Maximum = (int)numericUpDownEndIndex.Value; 
                }

                if (Math.Abs(numericUpDownEndIndex.Value - numericUpDownStartIndex.Value) < 5000)
                {
                    button_StartCopy.Enabled = false;
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
                        button_StartCopy.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Reduce the photo range. And try again.", "It will take a long time...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

            toolTip.SetToolTip(numericUpDownStartIndex, "Ctrl + V");
            toolTip.SetToolTip(numericUpDownEndIndex, "Ctrl + Shift + V");
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
                        if (e.Shift) numericUpDownEndIndex.Value = dd;
                        else numericUpDownStartIndex.Value = dd;
                    }
                }
                else
                {
                    if (Clipboard.ContainsText())
                    {
                        string input = Clipboard.GetText(); // "SmithsFalls|SmithsFalls-4|Run 25|28";
                        string[] parts = input.Split('|'); // Розділити рядок по символу "|"
                        string lastPart = parts[parts.Length - 1]; // Взяти останній елемент масиву (останнє число)
                        lastPart = Regex.Match(lastPart, @"\d+").Value; // Витягти всі цифри з останнього елементу
                        decimal result;
                        if (decimal.TryParse(lastPart, out result))
                        {
                            // Вдалося перетворити
                            if (e.Shift) numericUpDownEndIndex.Value = result;
                            else numericUpDownStartIndex.Value = result;
                        }
                        else
                        {
                            // Не вдалося перетворити
                            Console.WriteLine("Не вдалося розпізнати останні цифри рядка в число.");
                            MessageBox.Show("Не вдалося розпізнати останні цифри рядка в число: \n\n" + Clipboard.GetText(), "Не відповідність вводу.", MessageBoxButtons.OK);
                        }
                    }
                    else MessageBox.Show("Буфер не місить назву JPG файлу чи \"Photo NO\": \n\n" + Clipboard.GetText(), "Не відповідність вводу.", MessageBoxButtons.OK);
                }
            }
        }

        private void button_ByList_Click(object sender, EventArgs e)
        {
            
            formByList.ShowDialog();
            if (formByList.photoListNumbers.Count > 0)
            {
                checkBox_SwapByList.Checked = true;
                checkBox_SwapByList.Enabled = true;
                numericUpDownStartIndex.Value = formByList.photoListNumbers[0];
                numericUpDownEndIndex.Value = formByList.photoListNumbers[formByList.photoListNumbers.Count - 1];
                label_PhotoAmount.Text = formByList.photoListNumbers.Count.ToString();
            }
            else
            {
                label_PhotoAmount.Text = "000";
                checkBox_SwapByList.Checked = false;
                checkBox_SwapByList.Enabled = false;
            }
        }
    }
}
