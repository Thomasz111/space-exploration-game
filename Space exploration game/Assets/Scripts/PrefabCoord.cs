using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrefabCoord {
    public GameObject prefab;

    public double LocalX;
    public double LocalY;
    public double LocalZ;

    public long GlobalX;
    public long GlobalY;
    public long GlobalZ;
}
