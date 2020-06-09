using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithm.KMean
{
    public class KMean
    {
        private List<double> Clusters ;

        private List<double> PreClusters ;

        public List<TrainingData> TrainingDatas;

        private List<Data> Datas;

        private int MaxTrainingTimes;

        private int SumOfClusters;

        private BeLongTo BeLong;

        private double Distance;

        public int TrainTimes;

        public KMean(List<Data> datas,int sumCluster,int maxTraining = 1200)
        {
            Clusters = new List<double>();
            Datas = new List<Data>(datas);
            PreClusters = new List<double>();
            TrainingDatas = new List<TrainingData>();
            BeLong = new BeLongTo();
            SumOfClusters = sumCluster;
            MaxTrainingTimes = maxTraining;
        }

        private double NewClus(List<Data> list)
        {
            double sum = 0;
            foreach(var item in list)
            {
                sum += item.Value;
            }
            return Math.Round(sum / list.Count,2,MidpointRounding.AwayFromZero);;
        }

        public void UpdateCluster()
        {

            PreClusters = new List<double>(Clusters);
            Clusters = new List<double>();
            double newclus = 0;
            var newDataTraining = new List<TrainingData>();
            foreach (var data in TrainingDatas)
            {
                newclus = NewClus(data.Data);
                Clusters.Add(newclus);
                newDataTraining.Add(
                    new TrainingData
                    {
                        Cluster = newclus
                    });
            };
            TrainingDatas = new List<TrainingData>(newDataTraining);
        }

        public bool Update()
        {

            if (PreClusters.Count <= 0)
                return true;
            int index = 0;
            foreach (var i in PreClusters)
            {
                if (i != Clusters.ElementAt(index))
                    return true;
                index++;
            }
            return false;
        }

        public void Training()
        {
            foreach(var data in Datas)
            {
                Distance = Math.Abs(data.Value - Clusters.ElementAt(0));

                BeLong = new BeLongTo()
                {
                    Cluster = 0,
                    Distance = Distance
                };

                for(var index = 0; index < Clusters.Count;index++)
                {
                    Distance = Math.Abs(data.Value - Clusters[index]);
                    if (Distance <= BeLong.Distance)
                    {
                        BeLong.Cluster = index;
                        BeLong.Distance = Distance;
                    }
                }

                TrainingDatas[BeLong.Cluster].Data.Add(data);
            }
        }

        public void Run()
        {
            for(var i =0; i< SumOfClusters;i++)
            {
                Clusters.Add(Datas.ElementAt(i).Value);
                TrainingDatas.Add(new TrainingData()
                {
                    Cluster = Datas.ElementAt(i).Value
                });
            }

            int count = 0;
            while(count< MaxTrainingTimes)
            {
                Training();
                if (Update())
                    UpdateCluster();
                else
                    break;
                count++;
            }
            TrainTimes = count;
        }
    }
}
