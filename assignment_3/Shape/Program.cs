using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    //形状抽象类
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract bool IsLeagal();  
    }
    //矩形类
    public class Rectangle:Shape
    {
        private double length = 0;
        private double width = 0;

        public Rectangle(double length,double width)
        {
            this.length = length;
            this.width = width;
        }

        public override double GetArea()
        {
            return length * width;
            throw new NotImplementedException();
        }
        public override bool IsLeagal()
        {
            if (length > 0 && width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
    //正方形类
    public class Square:Shape
    {
        private double width = 0;
        public Square(double width)
        {
            this.width = width;
        }
        public override double GetArea()
        {
            return width * width;
            throw new NotImplementedException();
        }
        public override bool IsLeagal()
        {
            if (width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
    //三角形类
    public class Triangle:Shape
    {
        private double length1 = 0;
        private double length2 = 0;
        private double length3 = 0;
        public Triangle(double length1,double length2,double length3)
        {
            this.length1 = length1;
            this.length2 = length2;
            this.length3 = length3;
        }
        public override double GetArea()
        {
            double p = (length1 + length2 + length3) / 2;
            double powRes = p * (p - length1) * (p - length2) * (p - length3);
            return Math.Sqrt(powRes);
            throw new NotImplementedException();
        }
        public override bool IsLeagal()
        {
            if (length1 > 0 && length2 > 0 && length3 > 0 &&
                length1 + length2 > length3 && length2 + length3 > length1 
                && length1 + length3 > length2)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //随机生成10个类对象，计算其面积之和
            //引入随机数
            Random random = new Random();

            //计算面积总和变量
            double addArea = 0;

            //测试
            //for(int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(seed);
            //    seed = random.Next(1, 4);
            //}

            //随机生成10个对象
            for(int i = 0; i < 10; i++)
            {
                //生成1~3的随机数种子
                int seed = random.Next(1, 4);
                if (seed == 1)
                {
                    //1.生成矩形类
                    //生成随机长宽，范围为0~100
                    double length = random.Next(0, 101);
                    double width = random.Next(0, 101);
                    Rectangle r = new Rectangle(length,width);
                    Console.WriteLine("生成一个长为" + length + "，宽为" + width + "的矩形对象");
                    double rArea = r.GetArea();
                    Console.WriteLine("计算其面积为：" + rArea);
                    addArea += rArea;
                }
                else if (seed == 2)
                {
                    //2.生成正方形类
                    //生成随机边长，范围为0~100                  
                    double width = random.Next(0, 101);
                    Square s = new Square(width);
                    Console.WriteLine("生成一个边长为"+ width + "的正方形对象");
                    double sArea = s.GetArea();
                    Console.WriteLine("计算其面积为：" + sArea);
                    addArea += sArea;
                }
                else
                {
                    while (true)
                    {
                        //seed=3,生成三角形类
                        //生成随机三边，范围为0~100
                        double length1 = random.Next(0, 101);
                        double length2 = random.Next(0, 101);
                        double length3 = random.Next(0, 101);

                        Triangle t = new Triangle(length1, length2, length3);
                        //判断是否合法
                        if (t.IsLeagal())
                        {   //随机生成的三边长合法，生成成功
                            Console.WriteLine("生成一个三边长分别为" + length1 + "," +
                                length2 + "," + length3 + "的三角形对象");
                            double tArea = t.GetArea();
                            Console.WriteLine("计算其面积为：" + tArea);
                            addArea += tArea;
                            break;
                        }
                       
                    }
                    

                    
                }

                
            }
            //输出最终结果
            Console.WriteLine("计算10个随机对象面积总和为：" + addArea);

        }
    }
}
