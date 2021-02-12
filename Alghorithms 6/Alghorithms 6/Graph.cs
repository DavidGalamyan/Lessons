using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghorithms_6
{
    public class Node
    {
        public int Value;
        public List<Edges> Edges; //исходящие связи
    }
    public class Edges
    {
        public int Weight; // вес связи/стоимость перехода
        public Node Node; //узел,на который ссылается связь
    }
}
