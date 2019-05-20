using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour {

    public double cellSize = 500.0;
    public List<PrefabCoord> prefabCoords = new List<PrefabCoord>();

    private List<GameObject> universeObjects = new List<GameObject>();

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

            universeObjects.Add(GameObject.Instantiate(prefabCoord.prefab));
        }
    }

    public void SnapUniverse(Vector3 snapVector)
    {
        foreach(GameObject universeObject in universeObjects)
        {
            Debug.Log(snapVector);
            Transform transform = (Transform)(universeObject.GetComponent(typeof(Transform)));
            transform.Translate(-snapVector);
        }
    }

    void Update () {
		
	}
}
