using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    //Publisher class
    //声明一个委托类型
    public delegate void ClockEventsHandler(object sender,ClockEventsArgs args);

    public class ClockEventsArgs
    {
        public int X { get; set; }//小时
        public int Y { get; set; }//分钟
        public int Z { get; set; }//秒
    }
    //定义闹钟类
    public class Clock
    {
        //事件
        //走时事件
        public event ClockEventsHandler Tick;
        //响铃事件
        public event ClockEventsHandler Alarm;

        //用户设定闹钟时间方法
        public void SetTime()
        {
            //提示用户输入时间
            Console.WriteLine("Please set time:");
            //输入小时
            Console.Write("hour:");
            string s_hour = Console.ReadLine();
            int hour = Int32.Parse(s_hour);
            //输入分钟
            Console.Write("minute:");
            string s_minute = Console.ReadLine();
            int minute = Int32.Parse(s_minute);
            //输入秒
            Console.Write("second:");
            string s_second = Console.ReadLine();
            int second = Int32.Parse(s_second);

            //传入事件参数
            ClockEventsArgs args = new ClockEventsArgs()
            {
                X = hour,
                Y = minute,
                Z = second
            };

            //创建计时器对象
            int now_hour = hour;//现在小时
            int now_minute = minute;//现在分钟
            int now_second = second;//现在分钟
            

            //触发事件
            do
            {
                if(now_hour == 0 && now_minute == 0 && now_second == 0)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000); //休眠1000毫秒
                now_second--;
               
                if (now_second < 0)
                {
                    now_minute--;
                    now_second = 59;
                }
                if (now_minute < 0)
                {
                    now_hour--;
                    now_minute = 59;
                }
                //更新参数
                args.X = now_hour;
                args.Y = now_minute;
                args.Z = now_second;
                //Tick一次
                Tick(this, args);
                
            }
            while
             (now_hour >= 0 && now_minute>=0 && now_second>=0);//每隔一秒触发一次Tick事件

            Alarm(this, args);//时间到，响铃

        }
    }

    //Subscriber
    public class Form
    {
        public Clock myclock = new Clock();

        public Form()
        {
            //添加处理方法
            //添加Tick处理方法
            myclock.Alarm += new ClockEventsHandler(Btn_Alarm);

            //添加Alarm处理方法
            myclock.Tick += new ClockEventsHandler(Btn_Tick);
        }

        //Tick处理方法
        void Btn_Tick(object sender,ClockEventsArgs args)
        {
            Console.WriteLine($"{args.X}:{args.Y}:{args.Z}");
        }

        //Alarm处理方法
        void Btn_Alarm(object sender,ClockEventsArgs args)
        {
            Console.WriteLine("Ring!Ring!Ring!Time is over!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Form myform = new Form();
            myform.myclock.SetTime();
        }
    }
}
