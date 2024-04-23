using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileCopier.FormByList
{
    public partial class FormByList : Form
    {
        public List<decimal> photoListNumbers = new List<decimal>();
        public FormByList()
        {
            InitializeComponent();
        }

        private void button_SwapFiles_Click(object sender, EventArgs e)
        {
            // Отримання доступу до масиву рядків
            string[] lines = textBoxForList.Lines;
            decimal number;
            int around = (int)numericShiftAround.Value;
            
            this.photoListNumbers.Clear();

            // Проходження по всіх рядках
            foreach (string line in lines)
            {
                number = PhotoNumberByString.ParseString(line);
                if (number > 0)
                {
                    // Додавання сусідніх чисел
                    for (int i = (int)number - around; i <= number + around; i++)
                    {
                        if (i > 0)
                        {
                            this.photoListNumbers.Add(i);
                        }
                    }
                }
            }
            this.Close();
        }
    }
}
