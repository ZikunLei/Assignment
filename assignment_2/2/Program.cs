using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
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
            for (int i = 0; i < num; i++)
            {
                string enterNum = Console.ReadLine();

                int a = Int32.Parse(enterNum);
                arr[i] = a;

            }

            //此时arr数组包含了用户输入的数据
            //接下来求最大值、最小值、平均值和所有元素之和
            int max=arr[0];//最大值
            int min=arr[0];//最小值
            double ava;//平均值
            int addRes=0;//元素之和

            //求最大值和最小值
            for(int i = 1; i < num; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }

            }

            //求和
            
            for(int j = 0; j < num; j++)
            {
                addRes += arr[j];
            }

            //求平均
            ava = addRes / num;

            //输出结果
            Console.WriteLine("最大值为" + max);
            Console.WriteLine("最小值为" + min);
            Console.WriteLine("平均值为" + ava);
            Console.WriteLine("元素之和为" + addRes);
        }
    }
}
