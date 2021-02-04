using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_4
{
    public class Tree
    {
        public static Node Root;
        private int count = 0;
        private int descent = 5;
        private int width = 10;

        public void DelLeaves(int value)
        {
            var delnode = Search(value);
            if (delnode != null)
            {
                if (delnode.Right == null)
                {
                    if (delnode.Left != null)
                    {
                        if (delnode == Root)
                        {
                            Root = delnode.Left;
                            Root.Parent = null;
                        }
                        else
                        {
                            delnode.Left.Parent = delnode.Parent;
                            delnode.Parent.Left = delnode.Left;
                        }
                    }
                    else
                    {
                        if (delnode == Root)
                        {
                            Root = null;
                        }
                    }
                }
                else if (delnode.Right != null && delnode.Right.Left == null)
                {
                    if (delnode == Root)
                    {
                        Root = delnode.Right;
                        Root.Parent = null;
                        Root.Left = delnode.Left;
                        delnode.Left.Parent = Root;
                        
                    }
                    else
                    {
                        var parent = delnode.Parent;
                        if (parent.Left == delnode)
                        {
                            parent.Left = delnode.Right;
                            delnode.Right.Parent = parent;
                            if (delnode.Left != null)
                            {
                                delnode.Right.Left = delnode.Left;
                            }
                        }
                        else if (parent.Right == delnode)
                        {
                            parent.Right = delnode.Right;
                            delnode.Right.Parent = parent;
                            if (delnode.Left != null)
                                delnode.Right.Left = delnode.Left;
                        }
                    }
                }
                else if (delnode.Right.Left != null)
                {
                    var minValue = MinValue(delnode.Right);
                    delnode.Data = minValue.Data;
                    minValue.Parent.Left = null;
                }
            }
            count--;
        }
        // Метод поиска ноды с минимальным значением
        private Node MinValue(Node node) 
        {            
            while (node.Left != null) // выполняем цикл пока, не найдем левую ноду
            {             
                 node = node.Left;                               
            }
            return node;
        }
        public Node Search(int value)
        {
            if (value == Root.Data)
            {
                return Root;
            }
            else
            {
                var searchLeaves = Root;
                if (searchLeaves != null)
                {
                    if (searchLeaves.Data > value && searchLeaves.Left != null)
                    {
                        return Search(searchLeaves.Left, value);
                    }
                    if (searchLeaves.Data < value && searchLeaves.Right != null)
                    {
                        return Search(searchLeaves.Right, value);
                    }
                }
                return null;
            }
        }
        public int GetCount()
        { return count; }
        private Node Search(Node searchLeaves, int value)
        {
            if (searchLeaves != null)
            {
                if (searchLeaves.Data > value)
                {
                    return Search(searchLeaves.Left, value);
                }
                if (searchLeaves.Data < value)
                {
                    return Search(searchLeaves.Right, value);
                }
                else
                {
                    if (searchLeaves.Data == value)
                    {
                        return searchLeaves;
                    }
                    if (searchLeaves.Right == null || searchLeaves.Left == null && searchLeaves.Data != value)
                    { return null; }
                }
            }
            return null;
        }        
        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new Node { Data = value };
            }
            else 
            {
                var node = Root;
                while (true)
                {
                    if (node.Data > value)
                    {                        
                        if (node.Left == null)
                        {
                            var Add = new Node { Data = value, Parent = node };
                            node.Left = Add;
                            break;
                        }
                        node = node.Left;
                    }
                    if (node.Data < value)
                    {
                        if (node.Right == null)
                        {
                            var Add = new Node { Data = value, Parent = node };
                            node.Right = Add;
                            break;
                        }
                        node = node.Right;
                    }
                }
                
            }
            count++;
        }
        public void PrintTree()
        {
            string[,] matrix = new string[descent * 4, width * 4];
            for (int i = 0; i < descent * 4; i++)
            {
                for (int j = 0; j < width * 4; j++)
                {
                    matrix[i, j] = "////";
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            
        }
        public void PrintBFS(int value)
        {
            Queue<Node> queue = new Queue<Node>();            
            var node = Root;
            if (node != null)
            {
                queue.Enqueue(node);
                while (queue.Count != 0)
                {
                    node = queue.Dequeue();
                    Console.WriteLine(node.Data);
                    if (node.Data != value)
                    {
                        if (node.Left != null)
                        {
                            queue.Enqueue(node.Left);
                        }
                        if (node.Right != null)
                        {
                            queue.Enqueue(node.Right);
                        }
                    }
                    else { break; }
                }
                                       
            }
        }
        public void PrintDFS(int value)
        {
            Stack<Node> stack = new Stack<Node>();
            var node = Root;
            if (node != null)
            {
                stack.Push(node);
                while (stack.Count != 0)
                {
                    node = stack.Pop();
                    Console.WriteLine(node.Data);
                    if (node.Data != value)
                    {
                        if (node.Right != null)
                        {
                            stack.Push(node.Right);
                        }
                        if (node.Left != null)
                        {
                            stack.Push(node.Left);
                        }
                        
                    }
                    else { break; }
                }
            }
        }
    }
}

