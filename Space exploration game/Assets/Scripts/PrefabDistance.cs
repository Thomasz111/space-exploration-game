using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrefabDistance {

    public GameObject prefab;

    public long GlobalDistanceFrom;
    public float LocalDistanceFrom;

    public long GlobalDistanceTo;
    public float LocalDistanceTo;

    public double GetMinDistance(long CellSize)
    {
        return (GlobalDistanceFrom * CellSize) + LocalDistanceFrom;
    }

    public double GetMaxDistance(long CellSize)
    {
        return (GlobalDistanceTo* CellSize) + LocalDistanceTo;
    }
}
