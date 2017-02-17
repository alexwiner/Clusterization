using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterisation
{
    class Patient
    {
        int Id;
        List<double> Parameters;
        int Cluster;
        public Patient(int id,List<double>parameters,int cluster)
        {
            Id = id;
            Parameters = parameters;
            Cluster = cluster;
        }
    }
    
}
