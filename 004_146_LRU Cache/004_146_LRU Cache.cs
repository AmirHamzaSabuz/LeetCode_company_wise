
using System;
using System.Collections.Generic;

public class LRUCache
{
    private int capacity;
    private Dictionary<int, Node> cache;
    private Node head, tail;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, Node>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;

        Node node = cache[key];
        // Move the accessed node to the head to mark it as most recently used
        RemoveNode(node);
        AddToHead(node);

        return node.value;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            Node node = cache[key];
            node.value = value;
            // Move the updated node to the head
            RemoveNode(node);
            AddToHead(node);
        }
        else
        {
            Node newNode = new Node(key, value);
            AddToHead(newNode);
            cache[key] = newNode;

            if (cache.Count > capacity)
            {
                // Evict the least recently used node (tail)
                Node tail = RemoveTail();
                cache.Remove(tail.key);
            }
        }
    }

    private void AddToHead(Node node)
    {
        node.next = head;
        node.prev = null;
        if (head != null)
            head.prev = node;
        head = node;
        if (tail == null)
            tail = head;
    }

    private void RemoveNode(Node node)
    {
        if (node.prev != null)
            node.prev.next = node.next;
        else
            head = node.next;

        if (node.next != null)
            node.next.prev = node.prev;
        else
            tail = node.prev;
    }

    private Node RemoveTail()
    {
        Node removed = tail;
        tail = tail.prev;
        if (tail != null)
            tail.next = null;
        else
            head = null;
        return removed;
    }

    private class Node
    {
        public int key;
        public int value;
        public Node prev;
        public Node next;

        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
}

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a cache with a capacity of 2
        LRUCache cache = new LRUCache(2);

        // Test the cache operations
        cache.Put(1, 1);
        cache.Put(2, 2);
        Console.WriteLine(cache.Get(1));  // Output: 1
        cache.Put(3, 3);
        Console.WriteLine(cache.Get(2));  // Output: -1 (evicted)
        cache.Put(4, 4);
        Console.WriteLine(cache.Get(1));  // Output: -1 (evicted)
        Console.WriteLine(cache.Get(3));  // Output: 3
        Console.WriteLine(cache.Get(4));  // Output: 4
    }
}
