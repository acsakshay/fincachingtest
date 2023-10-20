using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinbourneCachingTest
{
    using System;
    using System.Collections.Generic;

    public class Caching
    {
        public static void Main()
        {
            var cache = new LRUCache<string, string>(3);
            cache.Add("1", "one");
            cache.Add("2", "two");
            cache.Add("3", "three");
            Console.WriteLine(cache.Get("1")); // Outputs: one
            Console.WriteLine(cache.Get("2")); // Outputs: two
            cache.Add("4", "four"); // This will evict key "3"
            Console.WriteLine(cache.Get("3")); // Outputs: (null)
            Console.WriteLine(cache.Get("4")); // Outputs: four
        }
    }

    public class LRUCache<TKey, TValue>
    {
        private readonly int capacity;
        private readonly Dictionary<TKey, LinkedListNode<CacheItem>> cache;
        private readonly LinkedList<CacheItem> lruLList = new LinkedList<CacheItem>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.cache = new Dictionary<TKey, LinkedListNode<CacheItem>>(capacity);
        }

        public TValue Get(TKey key)
        {
            if (cache.TryGetValue(key, out var node))
            {
                var value = node.Value.Value;
                lruLList.Remove(node);
                lruLList.AddLast(node);
                return value;
            }
            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            if (cache.Count >= capacity)
            {
                var lastNode = lruLList.First;
                cache.Remove(lastNode.Value.Key);
                lruLList.RemoveFirst();
            }

            var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
            lruLList.AddLast(newNode);
            cache.Add(key, newNode);
        }

        private class CacheItem
        {
            public CacheItem(TKey k, TValue v)
            {
                Key = k;
                Value = v;
            }

            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }
    }
}
