using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : IInventory
{
    private IList<IInventoryItem> _items = new List<IInventoryItem>();

    public IEnumerable<IInventoryItem> Items { get { return _items; } }

    public void Add(IInventoryItem item)
    {
        _items.Add(item);
    }

    public void Remove(IInventoryItem item)
    {
        _items.Remove(item);
    }

    public IInventoryItem DropLastItem()
    {
        IInventoryItem item = null;

        if(_items.Count > 0)
        {
            item = _items[_items.Count - 1];

            _items.RemoveAt(_items.Count - 1);
        }

        return item;
    }

    internal IEnumerable<T> Enumerate<T>() where T : IInventoryItem
    {
        return _items.Where(o => o.GetType() == typeof(T)).Cast<T>();
    }
}
