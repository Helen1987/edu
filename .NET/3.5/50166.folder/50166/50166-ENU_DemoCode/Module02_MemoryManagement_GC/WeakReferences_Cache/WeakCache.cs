using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakReferences_Cache
{
    /// <summary>
    /// Demonstrates a dictionary-like cache based on strong and weak references.
    /// This class is not thread-safe.
    /// 
    /// The cache is associated with two limits - a limit of how many strong 
    /// references it is willing to store, and a limit of how many weak references
    /// it is willing to store.  If the strong limit is exceeded, items are added
    /// to the weak-references cache.  When retrieving an item from the cache,
    /// the strong cache is queried first.
    /// </summary>
    class WeakCache
    {
        private readonly int _strongLimit;
        private readonly int _weakLimit;

        private Dictionary<string, object> _strongCache = new Dictionary<string, object>();
        private Dictionary<string, WeakReference> _weakCache = new Dictionary<string, WeakReference>();

        public WeakCache(int strongLimit, int weakLimit)
        {
            _strongLimit = strongLimit;
            _weakLimit = weakLimit;
        }

        public void Insert(string key, object value)
        {
            if (_strongCache.Count >= _strongLimit)
            {
                if (_weakCache.Count >= _weakLimit)
                {
                    throw new InvalidOperationException("Cache is full");
                }
                _weakCache.Add(key, new WeakReference(value));
            }
            else
            {
                _strongCache.Add(key, value);
            }
        }

        public object Remove(string key)
        {
            object value;
            if (!_strongCache.TryGetValue(key, out value))
            {
                WeakReference weakRef;
                if (!_weakCache.TryGetValue(key, out weakRef))
                {
                    throw new InvalidOperationException("No such element");
                }
                _weakCache.Remove(key);
                return weakRef.Target;
            }
            else
            {
                _strongCache.Remove(key);
                return value;
            }
        }

        class Box { }

        static void Main(string[] args)
        {
            Box box = new Box();

            WeakCache cache = new WeakCache(2, 2);
            cache.Insert("greeting", "Hello");
            cache.Insert("morning", "Good morning");
            cache.Insert("box", box);   //This will be a weak reference

            //Ensure the box is collected
            box = null;
            GC.Collect();

            //We expect the weak reference's target to be null
            Console.WriteLine(cache.Remove("box") == null);
        }
    }
}
