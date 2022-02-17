using System;
using System.Collections.Generic;

public interface ILRUCache
{
    int Get(int key);

    void Put(int key, int val);
}

public class LRUCache : ILRUCache
{
    private int Capacity = 10;
    DbLinkedList linkedList = null;
    Dictionary<int, DbLinkedListNode> map = null;
    public LRUCache(int capacity)
    {
        this.Capacity = capacity;
        map = new Dictionary<int, DbLinkedListNode>();
        linkedList = new DbLinkedList();
    }

    public int Get(int key)
    {
        if (!map.ContainsKey(key))
        {
            throw new KeyNotFoundException("Key doesn't exist!!");
        }
        DbLinkedListNode node = map[key];
        ReOrder(node);
        return node.Val.Value;
    }

    private void ReOrder(DbLinkedListNode node)
    {
        linkedList.Remove(node);
        linkedList.AddFirst(node);
    }

    public void Put(int key, int val)
    {
        DbLinkedListNode node = new DbLinkedListNode(new KeyValuePair<int,int>(key, val)); ;
        if (map.Count == Capacity)
        {
            var tail = linkedList.tail;
            map.Remove(tail.Val.Key);
            linkedList.Remove(tail);
        }
        linkedList.AddFirst(node);
        map.Add(key, node);
    }
}

public class DbLinkedList
{
    public DbLinkedListNode head { get; set; }

    public DbLinkedListNode tail { get; set; }

    public void AddFirst(DbLinkedListNode first)
    {
        if (head == null)
        {
            head = first;
            tail = first;
        }
        else
        {
            var temp = head;
            head = first;
            head.Next = temp;
            temp.Prev = head;
        }
    }

    public void Remove(DbLinkedListNode remove)
    {
        if (remove.Next == null && remove.Prev == null)
        { // not next & prev
            head = null;
            tail = null;
        }
        else if (remove.Next == null)
        {// last node
            tail = remove.Prev;
            remove.Prev.Next = null;
        }
        else
        {
            remove.Prev.Next = remove.Next;
            remove.Next.Prev = remove.Prev;
        }
    }
}
public class DbLinkedListNode
{
    public KeyValuePair<int,int> Val { get; set; }
    public DbLinkedListNode(DbLinkedListNode prev, DbLinkedListNode next, KeyValuePair<int, int> val)
    {
        this.Prev = prev;
        this.Next = next;
        this.Val = val;
    }

    public DbLinkedListNode(KeyValuePair<int, int> val)
    {
        this.Val = val;
    }
    public DbLinkedListNode Prev { get; set; }

    public DbLinkedListNode Next { get; set; }

}

public static class LRUTestClass
{
    public static void Test()
    {
        LRUCache cache = new LRUCache(3);
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(3, 3);
        Console.WriteLine($"3-->2-->1");
        Console.WriteLine($"result 1 - 1 { Get(cache, 1)}");
        Console.WriteLine($"1-->3-->2");
        Console.WriteLine($"result 2 - 2 { Get(cache, 2)}");
        Console.WriteLine($"2-->1-->3");
        cache.Put(4, 4);
        Console.WriteLine($"4-->2-->1");
        cache.Put(5, 5);
        Console.WriteLine($"5-->4-->2");
        Console.WriteLine($"result 3(Exp) - 1 { Get(cache, 1)}");
        Console.WriteLine($"result 4 - 4 { Get(cache, 4)}");
        Console.WriteLine($"4-->5-->2");
        Console.WriteLine($"result 5 - 2 { Get(cache, 2)}");
        Console.WriteLine($"2-->4-->5");
        cache.Put(6, 6);
        Console.WriteLine($"6-->2-->4");
        Console.WriteLine($"result(exp) 6  - 5 { Get(cache, 5)}");
        Console.Read();
    }

    public static int Get(LRUCache cache, int key)
    {
        try
        {
            return cache.Get(key);
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"this is expected exception");
            return -1;
        }
    }
}