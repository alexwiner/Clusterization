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
namespace Clusterisation
{
    public partial class Main_Form : Form
    {
        List<double>[] data;
        double list_length;
        public Main_Form()
        {
            InitializeComponent();
        }
        public void ReadFile()
        {
            List<double>[] datastring = new List<double>[90];
            openFileDialog1.ShowDialog();
            StreamReader reader = new StreamReader(openFileDialog1.FileName);
            int i = 0;
            string[] element;
            while (!reader.EndOfStream)
            {
                element = reader.ReadLine().Split('\t');
                datastring[i] = new List<double>();
                for (int j = 0; j < element.Length; j++)
                    datastring[i].Add(Convert.ToDouble(element[j]));
                i++;
                list_length = element.Length;
            }
            data = datastring;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
            Output_data();
        }
        void Output_data()
        {
            for (int i = 0; i < 90; i++)
            {
                chart1.Series.Add("s"+i);
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                for (int j = 0; j < list_length; j++)
                {
                    chart1.Series[i].Points.AddXY(j, data[i][j]);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
