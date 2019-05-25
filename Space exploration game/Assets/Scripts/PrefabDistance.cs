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

    private double minDistance;
    private double maxDistance;

    public void CalculateMinDistance(long CellSize)
    {
        minDistance = (GlobalDistanceFrom * CellSize) + LocalDistanceFrom;
    }

    public double GetMinDistance()
    {
        return minDistance;
    }

    public void CalculateMaxDistance(long CellSize)
    {
        maxDistance = (GlobalDistanceTo * CellSize) + LocalDistanceTo;
    }

    public double GetMaxDistance()
    {
        return maxDistance;
    }
}
