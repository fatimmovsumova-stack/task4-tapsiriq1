using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace task4_tapsiriq1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
     
            InitializeComponent();
            listBox1.SelectedIndexChanged +=
    listBox1_SelectedIndexChanged;
            comboBox1.Items.Add("C#");
            comboBox1.Items.Add("Java");
            comboBox1.Items.Add("Python");
            comboBox1.Items.Add("Linux");

            numericUpDown1.Minimum = 16;
            numericUpDown1.Maximum = 60;
            numericUpDown1.Value = 18;

            labelMelumat.Text = "Telebe secilmeyib.";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                labelMelumat.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show(
                    "Tələbənin adını daxil edin!",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Zəhmət olmasa, kurs seçin!",
                    "Xəbərdarlıq",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show(
                    "Cinsi seçin!",
                    "Xəbərdarlıq",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }
            int yas = (int)numericUpDown1.Value;
            string kurs = comboBox1.SelectedItem.ToString();

            string cins;

            if (radioButton2.Checked)
            {
                cins = "Kişi";
            }
            else
            {
                cins = "Qadın";
            }

            string telebe = "Ad: " + ad
                + " | Yaş: " + yas
                + " | Kurs: " + kurs
                + " | Cins: " + cins;

            listBox1.Items.Add(telebe);

            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            radioButton2.Checked = false;
            radioButton1.Checked = false;
            numericUpDown1.Value = 18;

            MessageBox.Show("Telebe elave edildi!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Evvelce telebe secin!");
                return;
            }

            DialogResult cavab = MessageBox.Show(
                "Secilmis telebeni silmek isteyirsiniz?",
                "Tesdiq",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cavab == DialogResult.Yes)
            {
                listBox1.Items.RemoveAt(
                    listBox1.SelectedIndex
                );

                labelMelumat.Text = "Telebe secilmeyib.";
            }
        }
    }
}
