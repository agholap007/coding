using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucutre
{
    public class PriorityQueue<k, v> where k : IComparable 
                                     where v : IComparable
    {
        private SortedSet<Node<k, v>> set;
        private readonly int amount;

        public PriorityQueue(int amount)
        {
            set = new SortedSet<Node<k, v>>(new PriorityComparer<k, v>());
            this.amount = amount;
        }

        public void Add(Node<k, v> value)
        {
            if (amount > set.Count)
                set.Add(value);
            else
            {
                if (set.Max.Val.CompareTo(value.Val) == 1)
                {
                    set.Remove(set.Max);
                    set.Add(value);
                }
            }
        }

        public Node<k, v> ExtractMax()
        {
            var max = set.Max;
            set.Remove(max);

            return max;
        }

        public Node<k, v> ExtractMin()
        {
            var min = set.Min;
            set.Remove(min);

            return min;
        }

        public bool IsEmpty => set.Count == 0;
    }

    public class Node<k, v> where k : IComparable 
                             where v : IComparable
    {
        public k Key;
        public v Val;

        public Node(k key, v val)
        {
            Val = val;
            Key = key;
        }
    }

    public class PriorityComparer<k, v> : IComparer<Node<k, v>> where k : IComparable where v : IComparable
    {
        public int Compare(Node<k, v> x, Node<k, v> y)
        {
            var compareresult = x.Val.CompareTo(y.Val);

            if (compareresult == 0)
                return x.Key.CompareTo(y.Key);

            return compareresult;
        }
    }

    public class PQ
    {
        SortedSet<(int total, int maths, string name, int index)> set = null;
        int index = 0;
        public PQ()
        {
            set = new SortedSet<(int, int, string, int)>(new PQComparer());
        }

        public void AddToQueue((int total, int maths, string name) value)
        {
            var res = set.Add((value.total, value.maths, value.name, index++));
        }

        public (int total, int maths, string name) ExtractMax()
        {
            var max = set.Max;
            set.Remove(max);
            return (max.total, max.maths, max.name);
        }

        public bool IsEmpty => set.Count == 0;
    }

    public class PQComparer : IComparer<(int total, int maths, string name, int index)>
    {
        public int Compare((int total, int maths, string name, int index) x, (int total, int maths, string name, int index) y)
        {
            int res = x.total.CompareTo(y.total);
            
            if (res == 0)
            {
                res = x.maths.CompareTo(y.maths);
                if(res == 0)
                {
                    return x.index.CompareTo(y.index);
                }
            }

            return res;
        }
    }

    public class PriorityQueue1
    {
        SortedDictionary<int, Queue<(int, int)>> map = null;

        public PriorityQueue1()
        {
            map = new SortedDictionary<int, Queue<(int, int)>>();
        }

        public (int, int) PopMin()
        {
            int minKey = map.First().Key;
            var server = map[minKey].Dequeue();

            if (map[minKey].Count == 0)
                map.Remove(minKey);

            return server;
        }

        public bool IsEmpty()
        {
            return map.Count == 0;
        }

        public void AddToQueue(int rank, (int weight, int time) server)
        {
            if (!map.ContainsKey(rank))
            {
                map.Add(rank, new Queue<(int, int)>());
            }

            map[rank].Enqueue(server);
        }
    }
}
