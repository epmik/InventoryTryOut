using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Potion : AbstractInventoryItem
{
    static string PrefabName = "PotionPrefab";

    static Potion()
    {
        LoadStaticPrefab(PrefabName);
    }

    public Potion()
    {
        GameObject = UnityEngine.Object.Instantiate(GameObjectPrefabDictionary[PrefabName]);
    }
}
