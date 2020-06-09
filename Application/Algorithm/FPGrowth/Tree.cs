using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Algorithm.FPGrowth
{
    public class Tree
    {
        public Dictionary<int, Node> TreeNode { get; set; }

        public Dictionary<int, int> Histogram { get; set; }

        public Dictionary<int,List<CP>> FP_Condition { get; set; }

        private Node IsExists;

        private List<CP> nn;

        public Tree(Dictionary<int, int> histogram)
        {
            TreeNode = new Dictionary<int, Node>();
            IsExists = new Node();
            Histogram = new Dictionary<int, int>(histogram);
            FP_Condition = new Dictionary<int, List<CP>>();
            nn = new List<CP>();

            foreach (var i in histogram)
            {
                FP_Condition.Add(i.Key, new List<CP>());
            }
        }

        public void AddNode(List<int> ds)
        {
            if (TreeNode.TryGetValue(ds[0], out IsExists) == false)
            {
                var node = new Node
                {
                    Value = 1
                };
                TreeNode.Add(ds[0], node);
                AddSubNode(ds, node, 1);
            }
            else
            {
                IsExists.Value += 1;
                AddSubNode(ds, IsExists, 1);
            }
        }

        public void AddSubNode(List<int> ds, Node node, int current)
        {
            var newNode = new Node();
            if (current == ds.Count)
                return;
            if (node.SubNode.TryGetValue(ds[current], out newNode))
            {
                newNode.Value++;
                AddSubNode(ds, newNode, current + 1);
            }
            else
            {
                newNode = new Node();
                newNode.Value = 1;
                node.SubNode.Add(ds[current], newNode);
                AddSubNode(ds, newNode, current + 1);
            }
        }

        public void CreateCondition(Node node,List<int> initialValue,int key)
        {

            if (node.SubNode.Count > 0)
            {
                initialValue.Add(key);
                foreach (var n in node.SubNode)
                {
                    CreateCondition(n.Value, initialValue, n.Key);
                }
                initialValue.Remove(key);
                if(initialValue.Count >0)
                FP_Condition[key].Add(new CP
                {
                    Value = node.Value,
                    ListCP = new List<int>(initialValue)
                });
            }
            else
            {
                if (initialValue.Count > 0)
                    FP_Condition[key].Add(new CP
                {
                    Value = node.Value,
                    ListCP = new List<int>(initialValue)
                });
            }
        }

        public void Create_FP_Condition(int MinCount)
        {
            var ds = new Dictionary<int, List<CP>>(FP_Condition);

            foreach(var i in ds)
            {
                var ListCount = new Dictionary<int, int>();
                var ListCP = new List<CP>();
                int count = 0;
                foreach(var j in i.Value)
                {
                    foreach(var z in j.ListCP)
                    {
                        if (ListCount.TryGetValue(z, out count))
                        {
                            ListCount[z] += j.Value;
                        }
                        else
                        {
                            ListCount.Add(z, j.Value);
                        }
                    }
                }
                foreach(var t in ListCount)
                {
                    if (t.Value >= MinCount)
                    {
                        var cp = new CP
                        {
                            ListCP = new List<int>(),
                            Value = t.Value
                        };
                        cp.ListCP.Add(t.Key);
                        ListCP.Add(cp);
                    }
                }
                FP_Condition[i.Key] = new List<CP>(ListCP);
            }

            
        }
    
        public void Gennerate_Frequent()
        {
            var ds = new Dictionary<int, List<CP>>(FP_Condition);
            var ListDCP = new List<DependencyCP>();
            var dcp = new DependencyCP();
            foreach (var i in ds)
            {
                ListDCP = new List<DependencyCP>();
                foreach (var j in i.Value)
                {
                    dcp = new DependencyCP()
                    {
                        Name = j.ListCP[0],
                        Value = j.Value
                    };
                    ListDCP.Add(dcp);
                }
                dcp = new DependencyCP()
                {
                    Name = i.Key,
                    Value = Histogram[i.Key]
                };
                ListDCP.Add(dcp);
                var result = GetCombination(ListDCP);
                FP_Condition[i.Key] = result;
            }
        }


        public List<CP> GetCombination(List<DependencyCP> list)
        {
            var ds = new List<CP>();
            var cp = new CP();
            int s = 0;
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                var lengthStr = str.Length;
                if (lengthStr < list.Count)
                    continue;
                if (str.Where(x =>x == '1').ToList().Count == 1)
                    continue;
                if (str[lengthStr - 1] != '1')
                    continue;
                s = 0;
                cp = new CP();
                cp.ListCP = new List<int>();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        cp.ListCP.Add(list[j].Name);
                        if (s == 0)
                        {
                            cp.Value = list[j].Value;
                            ++s;
                        }
                        else
                        {
                            if (cp.Value > list[j].Value)
                            {
                                cp.Value = list[j].Value;
                            }
                        }
                    }
                };

                ds.Add(cp);
            }
            return ds;
        }
    }
}
