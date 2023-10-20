
# LRU Cache Implementation in C#

This project is a simple yet powerful implementation of a Least Recently Used (LRU) cache in C#. The cache is designed to be generic, meaning it can store any type of objects, and uses a unique key to add and retrieve items. 

## Key Features

- **Generic Implementation**: The cache is implemented as a generic class `LRUCache<TKey, TValue>`, which means it can handle any type of key-value pairs. This makes the cache highly versatile and reusable across different types of applications.

- **Configurable Capacity**: The maximum number of items the cache can hold is set at the time of creation. This allows for flexibility in managing memory usage based on the specific needs of your application.

- **Least Recently Used (LRU) Eviction Policy**: When the cache is full, the least recently used item is evicted to make room for new items. This policy ensures that the most relevant data (i.e., the most recently used items) remains in the cache.

- **Efficient Operations**: The cache uses a combination of a Dictionary and a LinkedList to ensure that all operations (add, retrieve, and remove) are performed in O(1) time complexity.

## Usage



    csharp
    var cache = new LRUCache<string, string>(3);
    cache.Add("1", "one");
    cache.Add("2", "two");
    cache.Add("3", "three");
    Console.WriteLine(cache.Get("1")); // Outputs: one
    Console.WriteLine(cache.Get("2")); // Outputs: two
    cache.Add("4", "four"); // This will remove "1" from the cache because it's the least recently used item
    Console.WriteLine(cache.Get("1")); // Outputs: null
    Console.WriteLine(cache.Get("3")); // Outputs: three
    Console.WriteLine(cache.Get("4")); // Outputs: four




## Features

- Generic: Can store any type of objects.
- Configurable capacity: The maximum number of items the cache can hold can be set at the time of creation.
- Least Recently Used (LRU) eviction: When the cache is full, the least recently used item is evicted to make room for new items.

## Limitations

- This implementation is not thread-safe. If you need to use it in a multi-threaded environment, you will need to add synchronization.
- There is no mechanism for notifying when items are evicted from the cache. This could be added as an event in the `LRUCache` class that is triggered when an item is removed.

## Running the Project

You can run this application from the command line by navigating to the directory containing the project file and using the `dotnet run` command.
