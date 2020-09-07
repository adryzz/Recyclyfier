using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Recyclifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
            {
                var d = new DirectoryInfo(textBox1.Text);
                string ini = "[.ShellClassInfo]\nCLSID={645FF040-5081-101B-9F08-00AA002F954E}\nLocalizedResourceName=@%SystemRoot%\\system32\\shell32.dll, -8964";
                File.WriteAllText(Path.Combine(textBox1.Text, "desktop.ini"), ini);
                d.Attributes = d.Attributes | FileAttributes.Hidden | FileAttributes.System;
                MessageBox.Show("Done. you may need to restart Explorer", "Recyclyfier", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The specified folder doesn't exist", "Recyclyfier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
