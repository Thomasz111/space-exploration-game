using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour {

    public double cellSize = 500.0;
    public List<PrefabCoord> prefabCoords = new List<PrefabCoord>();

    void Start () {
        InstatntiateUniverseObjects();
	}
	
    public void InstatntiateUniverseObjects()
    {
        foreach(PrefabCoord prefabCoord in prefabCoords)
        {
            prefabCoord.prefab.AddComponent(typeof(CellCoordPosition));
            CellCoordPosition cellCoordPosition = (CellCoordPosition) prefabCoord.prefab.GetComponent(typeof(CellCoordPosition));
            cellCoordPosition.SetLocalPosition(prefabCoord.LocalX, prefabCoord.LocalY, prefabCoord.LocalZ);
            cellCoordPosition.SetGlobalPosition(prefabCoord.GlobalX, prefabCoord.GlobalY, prefabCoord.GlobalZ);
            prefabCoord.prefab.transform.position = cellCoordPosition.GetRealPosition();

            GameObject.Instantiate(prefabCoord.prefab);
        }
    }

    void Update () {
		
	}
}
