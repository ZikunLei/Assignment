using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArrayLoop
{
    public static void Main(string[] args)
    {
        Console.Write("Please input the first num: ");
        string fn = Console.ReadLine();
        int f = Int32.Parse(fn);
        Console.Write("input the operator: ");
        string op = Console.ReadLine();
        Console.Write("Please input the second num: ");
        string sn = Console.ReadLine();
        int s = Int32.Parse(sn);
        int result = 0;

        switch (op)
        {
            case "+":
                result = f + s;
                break;
            case "-":
                result = f - s;
                break;
            case "*":
                result = f * s;
                break;
            case "/":
                result = f / s;
                break;
            default:
                Console.WriteLine("False");
                break;
        }
        Console.WriteLine("The result is " + result);
    }
}
