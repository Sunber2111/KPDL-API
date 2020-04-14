using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Algorithm.KMean
{
    public class TrainingData
    {
        public double Cluster { get; set; }

        public List<Data> Data {get; set;}

        public TrainingData()
        {
            Data = new List<Data>();
        }
    }
}
