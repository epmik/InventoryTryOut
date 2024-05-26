using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Magazine : AbstractInventoryItem
{
    public int BulletCount { get; private set; }

    private const int DefaultBulletCount = 50;

    static string PrefabName = "MagazinePrefab";

    static Magazine()
    {
        LoadStaticPrefab(PrefabName);
    }

    public Magazine() 
        : this(DefaultBulletCount)
    {
    }

    public Magazine(int bulletCount)
    {
        BulletCount = bulletCount;
        GameObject = UnityEngine.Object.Instantiate(GameObjectPrefabDictionary[PrefabName]);
    }

    public void Fire()
    {
        BulletCount--;
    }

    public override void Update()
    {
        //if (Input.GetMouseButtonDown(1) && _lastBulletFiredTime + _bulletRateTimeout >= Time.time)
        //{
        //    BulletCount--;

        //    if(BulletCount == 0)
        //    {
        //        Inventory.Remove(this);

        //        GameObject.Destroy(GameObject);
        //    }

        //    _lastBulletFiredTime = Time.time;
        //}
    }
}