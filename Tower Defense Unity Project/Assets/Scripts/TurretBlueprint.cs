using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint {

    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

    public int GetSellUpgrade()
    {
        return (cost + upgradeCost) / 2;
    }
}
