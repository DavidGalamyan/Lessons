using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghorithms_6
{
    public class WorkOnGraph
    {
        public List<Edges> AddEdges(Node node, Node nodeEnd, int weigth)
        {
            
            
        }
        public Node BFS(Node startNode, Node endNode)
        {
            var queue = new Queue<Node>();
            var node = new Node();
            queue.Enqueue(startNode);
            while (queue.Count != 0)
            {
               node = queue.Dequeue();
                if (node.Edges != null)
                {
                    for (int i = 0; i < node.Edges.Count; i++)
                    {
                        if (node.Edges[i].Node == endNode)
                        {
                            node = node.Edges[i].Node;
                            return node;
                        }
                        queue.Enqueue(node.Edges[i].Node);
                    }
                }
            }
            return node;
        }
        public Node DFS(Node startNode, Node endNode)
        {
            Stack < Node > stack = new Stack<Node>();
            stack.Push(startNode);
            var node = new Node();
            while (stack.Count != 0)
            {
                node = stack.Pop();
                if (node.Edges != null)
                {
                    for (int i = 0; i < node.Edges.Count; i++)
                    {
                        if (node.Edges[i].Node == endNode)
                        {
                            node = node.Edges[i].Node;
                            return node;
                        }
                        stack.Push(node.Edges[i].Node);
                    }
                }
            }
            return node;
        }
    }
}
