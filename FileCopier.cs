using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopier
{
    class FileCopier
    {
        public static async Task CopyFilesInRangeAsync(string sourceDir, int startIndex, int endIndex, ProgressBar progressBar, Label progressLabel)
        {
            progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = "Please, wait..."; });

            for (int currentCopedFileIndex = startIndex; currentCopedFileIndex <= endIndex; currentCopedFileIndex++)
            {
                Application.DoEvents(); // Оновлення інтерфейсу
                string sourceFileName = CreateFileName(currentCopedFileIndex);

                foreach (var subDir in new[] { "Forward", "Rear", "Left", "Right" })
                {
                    string filePath = Path.Combine(sourceDir, subDir, sourceFileName);

                    if (File.Exists(filePath))
                    {
                        await ToRead(filePath);

                        progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = Path.Combine(sourceDir, "{DIRECTION}", sourceFileName); });
                        progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = currentCopedFileIndex; });
                    }
                }
            }

            //MessageBox.Show("Google Drive complete to swape files.", "Close this window...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = progressBar.Minimum; });
            progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = String.Empty; });
        }

        private static string CreateFileName(int index) 
        {
            return index.ToString() + ".jpg";
        }

        private static async Task ToRead(string sourceFile)
        {
            using FileStream sourceStream = new(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            await sourceStream.DisposeAsync();
        }
    }

}
