using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string numstr;
            Console.Write("Please enter the number of your datas: ");
            numstr = Console.ReadLine();
            int num = Int32.Parse(numstr);
            int[] arr = new int[num];

            Console.WriteLine("Please enter your data: ");
            for(int i = 0; i < num; i++)
            {
                string enterNum = Console.ReadLine();

                int a = Int32.Parse(enterNum);
                arr[i] = a;

            }

            //此时arr数组包含了用户输入的数据
            //接下来处理数据
            int j;
            for(int i = 0; i < num; i++)
            {
                //遍历数组
                for(j = 2; j < arr[i]; j++)
                {
                    //判断arr[i]是不是素数
                    if (arr[i] % j == 0)
                    {
                        Console.WriteLine(arr[i] + "不是素数");
                        break;
                    }
                    
                }
                if (j == arr[i])
                {
                    Console.WriteLine(arr[i] + "是素数");
                }
            }

            //for(int i = 0; i < num; i++)
            //{
            //    Console.Write(arr[i]+" ");
            //}
        }
    }
}
