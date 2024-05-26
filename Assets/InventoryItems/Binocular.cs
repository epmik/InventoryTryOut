using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Binocular : AbstractInventoryItem
{
    static string PrefabName = "BinocularPrefab";

    static Binocular()
    {
        LoadStaticPrefab(PrefabName);
    }

    public Binocular()
    {
        GameObject = UnityEngine.Object.Instantiate(GameObjectPrefabDictionary[PrefabName]);
    }
}
