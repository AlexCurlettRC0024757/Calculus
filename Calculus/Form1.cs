using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class row
        {
            public double time;
            public double voltage;
            public double current;
            public double voltageDerivative;
            public double charge;
        }
        List<row> table = new List<row>();

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV Files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string line = sr.ReadLine().Split(',');
                        while (!sr.EndOfStream)
                        {
                            table.Add(new data());
                            string[] 1 = sr.ReadLine().Split(',');
                            table.Last().voltage = double.Parse(1[0]);
                            table.Last().current = double.Parse(1[1]);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show(OpenFileDialog1.FileName + " failed to open.");
                }
                catch (FormatException)
                {
                    MessageBox.Show(OpenFileDialog1.FileName + " is not in the required format.");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show(OpenFileDialog1.FileName + " is not in the required format.");
                }
            }
        }
    }
}
