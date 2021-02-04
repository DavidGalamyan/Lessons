using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithms_4_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BenhmarkClass
    {        
        static HashSet<string> Hash = new HashSet<string>();
        static int x = 10000;
        static string[] Array = new string[x];   
        static BenhmarkClass()
        {           
            for (int i = 0; i < x; i++)
            {
                Hash.Add(RandomString());
                Array[i] = RandomString();
            }
        }
    public static string RandomString()
        {
            StringBuilder newString = new StringBuilder();
            string chars = "qwertyuiopasdfghjklzxcvbnm";
            int Max = chars.Length;
            var rnd = new Random();
            for (int i = 0; i < Max; i++)
            {
                newString.Append(chars[rnd.Next(Max)]);
            }
            return newString.ToString();
        }
        [Benchmark]
        public void TestHash()
        {            
            Hash.Contains(RandomString());
        }
        [Benchmark]
        public void TestArray()
        {
            for (int i = 0; i < x; i++)
            {
                if (Array[i] == RandomString())
                { break; }
            }
        }
    }
}
