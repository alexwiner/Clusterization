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
            List<List<int>> m = Clusterisation_func();
            for (int i = 0; i < m.Count(); i++)
            {
                string s="";
                for (int j = 0; j < data.Count; j++)
                {
                    s += m[i][j] + "\t";
                }
                listBox1.Items.Add(s);
            }
        }
        List<List<int>> Clusterisation_func()
        {
            double [,] matrix = Distance_matrix();
            double minimum = 10000;
            int x = 0, y = 0;
            List<List<int>> cluster_matrix = new List<List<int>>();
            List<int> cl = new List<int>();
            for (int i = 0; i < data.Count(); i++)  
                cl.Add(data[i].Cluster);
            cluster_matrix.Add(new List<int>(cl));

            ///start
            while (true)
            {
                minimum = 10000;
                int k = 0;
                for (int i = 0; i < data.Count(); i++)
                    for (int j = 0; j < data.Count(); j++)
                    {
                        if ((matrix[i, j] < minimum) && (matrix[i, j] > 0))
                        {
                            minimum = matrix[i, j];
                            x = i;
                            y = j;
                            k++;
                        }
                    }

                if (k == 0)
                    return cluster_matrix;

                List<int> clust = new List<int>();
                for (int i = 0; i < data.Count(); i++)
                {
                    if (data[i].Cluster == data[y].Cluster)
                        data[i].Cluster = data[x].Cluster;
                    clust.Add(data[i].Cluster);
                }
                cluster_matrix.Add(new List<int>(clust));

                for (int i = 0; i < data.Count(); i++)
                    for (int j = 0; j < data.Count(); j++)
                        if (data[i].Cluster == data[j].Cluster)
                            matrix[i, j] = 0;
                for (int i = 0; i < data.Count(); i++)
                    for (int j = 0; j < data.Count(); j++)
                        if (matrix[i, j] == 0)
                            data[i].Cluster = data[j].Cluster;
                       
            }
        }
        double [,] Distance_matrix()
        { 
            double [,] matrix = new double[data.Count(), data.Count()];
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
