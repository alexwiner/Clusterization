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
        List<Patient> data = new List<Patient>();
        public Main_Form()
        {
            InitializeComponent();
        }
        public void ReadFile()
        {
            List<Patient> d = new List<Patient>();
            openFileDialog1.ShowDialog();
            StreamReader reader = new StreamReader(openFileDialog1.FileName);
            string[] element;
            int i = 0;   
            while (!reader.EndOfStream)
            {
                List<double> parametr_patient = new List<double>();
                element = reader.ReadLine().Split('\t');
                for (int j = 0; j < element.Length; j++)
                    parametr_patient.Add(Convert.ToDouble(element[j]));
                Patient obj = new Patient(i, parametr_patient, i);
                d.Add(obj);
                i++;
            }
            data = d;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
            double[,] m = Distance_matrix();
            for (int i = 0; i < data.Count(); i++)
                for (int j = 0; j < data.Count(); j++)
                {
                    m[i, j]; 
                }


        }
        double[,] Distance_matrix()
        {
            double[,] matrix = new double[data.Count(), data.Count()];
            for (int i = 0; i < data.Count(); i++)
                for (int j = 0; j < data.Count(); j++)
                {
                    matrix[i, j] = Euclid(data[i].Parameters, data[j].Parameters);
                }
            return matrix;
        }
        double Euclid(List<double> first_params,List<double> second_params)
        {
            double distance=0;
            int i = 0;
            while (i < first_params.Count())
            {
                distance += Math.Pow((first_params[i] - second_params[i]),2.0);
                i++;
            }
            return Math.Sqrt(distance);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
