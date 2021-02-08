using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghorithms_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new WorkOnGraph();
            var nodeEnd = new Node() { Value = 1 };
            var node2 = new Node() { Value = 23,Edges = new List<Edges>() { new Edges { Weight = 1, Node = nodeEnd } } };
            var node3 = new Node() { Value = 2 };
            var node4 = new Node() { Value = 61};
            var node = new Node()
            {
                Value = 27,
                Edges = new List<Edges>() { new Edges() { Weight = 23, Node = node2 },
                { new Edges() { Weight = 41, Node = node3 } },
                { new Edges() { Weight = 11, Node = node4 } } }
            };
            graph.DFS(node, nodeEnd);
        }
    }
}
