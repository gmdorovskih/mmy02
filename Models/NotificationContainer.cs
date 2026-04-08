using System;
using System.Collections.Generic;

namespace UniversityApp.Models
{
    public class NotificationContainer<T> where T : Notification
    {
        protected readonly List<T> _items = new();

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _items.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void Sort()
        {
            _items.Sort();
        }

        public int Count => _items.Count;
    }
}