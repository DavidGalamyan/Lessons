using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Add(100);
            tree.Add(130);
            tree.Add(90);
            tree.Add(85);
            tree.Add(88);
            tree.Add(86);
            tree.Add(120);
            tree.Add(125);
            tree.Add(122);
            tree.Add(121);
            tree.Add(84);
            tree.Add(87);


           
            tree.PrintDFS(87);


            
            Console.ReadLine();



        }
    }
}
