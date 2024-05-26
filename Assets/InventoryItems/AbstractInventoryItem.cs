using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class AbstractInventoryItem : IInventoryItem
{
    protected static Dictionary<string, GameObject> GameObjectPrefabDictionary { get; set; } = new Dictionary<string, GameObject>();

    public IInventory Inventory { get; set; }

    public GameObject GameObject { get; protected set; }

    public string Name { get; set; }

    protected static void LoadStaticPrefab(string name)
    {
        if (!GameObjectPrefabDictionary.ContainsKey(name))
        {
            GameObjectPrefabDictionary.Add(name, Resources.Load<GameObject>(name));
        }
    }

    public virtual void Update()
    {

    }

    public virtual void Destroy()
    {
        UnityEngine.Object.Destroy(GameObject);
    }
}
