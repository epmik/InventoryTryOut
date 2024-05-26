using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    IEnumerable<IInventoryItem> Items { get; }

    void Add(IInventoryItem item);

    void Remove(IInventoryItem item);
}
