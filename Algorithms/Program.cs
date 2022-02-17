using DataStrucutre;
using DS.Array;
using DS.Queue;
using DS.Stack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dic = new SortedDictionary<char, int>(new ValueComparer());

            dic.Add('A', 1);
            dic.Add('B', 51);
            dic.Add('C', 11);
            dic.Add('D', 10);
            dic.Add('E', 111);

            Console.WriteLine($"{dic.Max()}");
            Console.ReadLine();

            //array list
            //ArrayList();

            //array stack
            //ArrayStack();

            //array queue
            //ArrayQueue();

            //min heap
            //MinHeap();

            int[] nums = new int[] { 5, 1, 4, 2, 8 };
            //BubbleSort bubbleSort = new BubbleSort();
            //bubbleSort.Sort(nums);
            //InsertionSort insertionSort = new InsertionSort();
            //insertionSort.Sort(nums);

            PQ priorityQueue = new PQ();

            priorityQueue.AddToQueue((99, 49, "Amit"));
            priorityQueue.AddToQueue((99, 50, "Sohail"));
            priorityQueue.AddToQueue((100, 50, "Paresh"));
            priorityQueue.AddToQueue((100, 49, "Pritam"));
            priorityQueue.AddToQueue((100, 48, "Ankit"));
            priorityQueue.AddToQueue((90, 45, "Amol"));
            priorityQueue.AddToQueue((90, 45, "Shweta"));

            while (!priorityQueue.IsEmpty)
            {
                var student = priorityQueue.ExtractMax();
                Console.WriteLine($"{student.name} {student.total} {student.maths}");
            }
            int index = 0;
            Console.WriteLine($"----------------------------------------");
            SortedSet<(int t, int m, string n, int index)> s = new SortedSet<(int, int, string, int)>();
            s.Add((99, 49, "Amit", index++));
            s.Add((99, 50, "Sohail", index++));
            s.Add((100, 50, "Paresh", index++));
            s.Add((100, 49, "Pritam", index++));
            s.Add((100, 48, "Ankit", index++));
            s.Add((90, 45, "Amol", index++));
            s.Add((90, 45, "Shweta", index++));

            while (s.Count > 0)
            {
                var student = s.Max;
                Console.WriteLine($"{student.n} {student.t} {student.m}");
                s.Remove(student);
            }

            Console.ReadLine();




        }

        
        static void MinHeap1()
        {
            var ran = new Random();
            MinHeap1 minHeap = new MinHeap1();
            for(int i = 0; i < 10; i++)
            {
                int num = ran.Next(100);
                minHeap.Insert(num);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(minHeap.RemoveMin());
            }
        }


        static void ArrayStack()
        {
            ArrayStack stack = new ArrayStack();
            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());

            Console.ReadLine();
        }

        static void ArrayQueue()
        {
            ArrayQueue queue = new ArrayQueue();

            queue.Enqueue(1);
            queue.Enqueue(2);

            while(queue.Count() > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.ReadLine();
        }
    }

    public class ValueComparer : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            return x.CompareTo(y);
        }
    }
}

