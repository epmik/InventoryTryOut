using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : AbstractInventoryItem
{
    static string PrefabName = "FlashlightPrefab";

    static Flashlight()
    {
        LoadStaticPrefab(PrefabName);
    }

    public Flashlight()
    {
        GameObject = UnityEngine.Object.Instantiate(GameObjectPrefabDictionary[PrefabName]);
    }
}
