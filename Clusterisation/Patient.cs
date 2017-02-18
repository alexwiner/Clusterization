using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterisation
{
    class Patient
    {
        public int Id;
        public List<double> Parameters;
        public int Cluster;
        public Patient(int id,List<double>parameters,int cluster)
        {
            Id = id;
            Parameters = parameters;
            Cluster = cluster;
        }
    }
    
}
