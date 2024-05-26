using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem : IItem
{
    IInventory Inventory { get; set; }

    GameObject GameObject { get; }

    void Destroy();
}
