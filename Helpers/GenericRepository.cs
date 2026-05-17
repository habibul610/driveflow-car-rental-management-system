using System;
using System.Collections.Generic;
using System.Linq;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers
{
    // Demonstrating Generics (Generic class)
    public class GenericRepository<T> where T : class
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            if (item != null)
                _items.Add(item);
        }

        public void Remove(T item)
        {
            if (item != null)
                _items.Remove(item);
        }

        public List<T> GetAll()
        {
            return _items;
        }

        // Demonstrating Indexers
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _items.Count)
                    return _items[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < _items.Count)
                    _items[index] = value;
            }
        }
    }
}
