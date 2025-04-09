using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraficEditor.Forms
{
    public partial class ProgressForm: Form
    {
        public ProgressForm(int maxValue)
        {
            InitializeComponent();

            progressBar1.Maximum = maxValue;
            progressBar1.Value = 0;
            label1.Text = "0,00 %";
        }
        public void UpdateProgressbar(int newValue) {
            if(newValue > progressBar1.Maximum) {
                throw new Exception("Значение прогресса не может быть больше максимального значения");
            }

            progressBar1.Value = newValue;

            label1.Text = Math.Round((double)newValue * 100 / progressBar1.Maximum, 2).ToString() + " %";
        }
    }
}
