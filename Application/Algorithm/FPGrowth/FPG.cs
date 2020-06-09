using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Algorithm.FPGrowth
{
    public class FPG
    {
        public Tree TreeTraining { get; set; }

        public List<Data> Transactions { get; set; }

        public List<string> ListWords { get; set; }
        public Dictionary<int,DataTraining> FinalData { get; set; }

        public Dictionary<int, int> Histogram { get; set; }

        public int MinCount;

        public FPG(List<Data> transaction,double minsup)
        {
            Transactions = new List<Data>(transaction);

            FinalData = new Dictionary<int, DataTraining>();

            Histogram = new Dictionary<int, int>();

            ListWords = new List<string>();

            MinCount = Convert.ToInt32(Math.Round(minsup*(double)transaction.Count/100.0,MidpointRounding.AwayFromZero));
        }

        public void GroupData()
        {
            DataTraining dt = new DataTraining();
            int count = 0;
            var normalHis = new Dictionary<int, int>();
            var ds = new List<int>();
            foreach (var i in Transactions)
            {
                if (FinalData.TryGetValue(i.Id, out dt) == true)
                {
                    FinalData[i.Id].ListProduct.Add(i.IdProduct);
                }
                else
                {
                    ds = new List<int>
                        {
                            i.IdProduct
                        };
                    dt = new DataTraining
                    {
                        Id = i.Id,
                        ListProduct = ds
                    };
                    FinalData.Add(i.Id, dt);
                }

                if(normalHis.TryGetValue(i.IdProduct,out count)==true)
                {
                    
                    normalHis[i.IdProduct] = count + 1;

                    if (count+1 >= MinCount)
                        Histogram[i.IdProduct] = count + 1;
                }
                else
                {
                    normalHis.Add(i.IdProduct, 1);
                }
                
            }

            Histogram= Histogram.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);

            ds = new List<int>();

            foreach(var data in FinalData)
            {

                ds = new List<int>();
                foreach (var masp in data.Value.ListProduct)
                {
                    if(Histogram.TryGetValue(masp,out count) == true)
                    {
                        ds.Add(masp);
                    }
                }
                if(ds.Count == 0)
                {
                    FinalData.Remove(data.Key);
                }
                else
                {
                    ds = ds.OrderByDescending(o => Histogram[o]).ToList();

                    FinalData[data.Key].ListProduct = ds;   
                }
            }
        }

        public void DrawTree()
        {
            TreeTraining = new Tree(Histogram);

            foreach(var row in FinalData)
            {
                TreeTraining.AddNode(row.Value.ListProduct);
            }

            foreach(var node in TreeTraining.TreeNode)
            {
                TreeTraining.CreateCondition(node.Value,new List<int>(),node.Key);
            }

            TreeTraining.Create_FP_Condition(MinCount);

            TreeTraining.Gennerate_Frequent();
        }

        public async Task Run()
        {
            await Task.Run(() =>
            {
                GroupData();
                DrawTree();
            });

        }

    }
}
