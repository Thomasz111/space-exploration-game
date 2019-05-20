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
            GameObject universeObject = GameObject.Instantiate(prefabCoord.prefab);

            universeObject.AddComponent(typeof(CellCoordPosition));
            CellCoordPosition cellCoordPosition = (CellCoordPosition) universeObject.GetComponent(typeof(CellCoordPosition));
            cellCoordPosition.SetLocalPosition(prefabCoord.LocalX, prefabCoord.LocalY, prefabCoord.LocalZ);
            cellCoordPosition.SetGlobalPosition(prefabCoord.GlobalX, prefabCoord.GlobalY, prefabCoord.GlobalZ);
            universeObject.transform.position = cellCoordPosition.GetRealPosition();

            universeObjects.Add(universeObject);
        }
    }

    public void SnapUniverse(Vector3 snapVector)
    {
        foreach(GameObject universeObject in universeObjects)
        {
            Transform transform = (Transform)(universeObject.GetComponent(typeof(Transform)));
            transform.Translate(-snapVector);
        }
    }

    void Update () {
		
	}
}
