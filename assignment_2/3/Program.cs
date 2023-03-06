using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[99];
            //for(int i = 0; i < 99; i++)
            //{
            //    arr[i] = i + 2;
            //}
            //for(int i = 0; i < 99; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            int j;
            for(int i = 2; i < 101; i++)
            {
                for(j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        break;
                    }
                }
                if (i == j)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
