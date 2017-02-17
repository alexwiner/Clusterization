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
        List<Patient> data;
        public Main_Form()
        {
            InitializeComponent();
        }
        public void ReadFile()
        {
            openFileDialog1.ShowDialog();
            StreamReader reader = new StreamReader(openFileDialog1.FileName);
            string[] element;
            int i = 0;   
            while (!reader.EndOfStream)
            {
                List<double> parametr_parient = new List<double>();
                element = reader.ReadLine().Split('\t');
                for (int j = 0; j < element.Length; j++)
                    parametr_parient.Add(Convert.ToDouble(element[j]));
                Patient obj = new Patient(i, parametr_parient, i);
                i++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
        }
        double Euclid(List<double> first_params,List<double> second_params)
        {
            double distans=0;
            int i = 0;
            while (i < first_params.Count())
            {
                distans += Math.Pow((first_params[i] - second_params[i]),2.0);
                i++;
            }
            return Math.Sqrt(distans);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
