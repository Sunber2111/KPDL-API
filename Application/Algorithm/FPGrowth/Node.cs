using System.Collections.Generic;

namespace Application.Algorithm.FPGrowth
{
    public class Node
    {
        public int Value { get; set; }

        public Dictionary<int,Node> SubNode { get; set; }

        public Node()
        {
            SubNode = new Dictionary<int, Node>();
            Value = 0;
        }

    }
}
