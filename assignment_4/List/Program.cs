﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    //链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        //遍历的方法
        public void ForEach(Action<T> action)
        {
            Node<T> temp = head;
            while (temp.Next != null)
            {
                action(temp.Data);
                temp = temp.Next;
            }
            action(temp.Data);
        }
    }

        class Program
        {
            static void Main(string[] args)
            {
                // 整型List
                GenericList<int> li = new GenericList<int>();
                for (int x = 0; x < 10; x++)
                {
                    li.Add(x);
                }
                //实现遍历输出
                li.ForEach(m => Console.WriteLine(m));

                //输出最大值
                int max = 0;
                li.ForEach(i => { if (max < i) max = i; });
                Console.WriteLine($"最大值为：{max}");

                //输出最小值
                int min = 0;
                li.ForEach(i => { if (min > i) min = i; });
                Console.WriteLine($"最小值为：{min}");
            }
        }
 }

