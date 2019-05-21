using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour {

    public readonly double cellSize = 100.0;
    public List<PrefabCoord> prefabCoords = new List<PrefabCoord>();
    public CellCoordCameraMovement player;

    private List<GameObject> universeObjects = new List<GameObject>();

    void Start () {
        InstatntiateUniverseObjects();
	}
	
    public void InstatntiateUniverseObjects()
    {
        foreach(PrefabCoord prefabCoord in prefabCoords)
        {
            GameObject universeObject = GameObject.Instantiate(prefabCoord.prefab);

            CellCoordPosition cellCoordPosition = (CellCoordPosition) universeObject.AddComponent(typeof(CellCoordPosition));
            cellCoordPosition.SetLocalPosition(prefabCoord.LocalX, prefabCoord.LocalY, prefabCoord.LocalZ);
            cellCoordPosition.SetGlobalPosition(prefabCoord.GlobalX, prefabCoord.GlobalY, prefabCoord.GlobalZ);
            universeObject.transform.position = cellCoordPosition.GetRealPosition();

            universeObjects.Add(universeObject);
        }
    }

    public void SnapUniverse(Vector3 playerGlobalPos)
    {
        foreach(GameObject universeObject in universeObjects)
        {
            CellCoordPosition cellCoordPosition = (CellCoordPosition)universeObject.GetComponent(typeof(CellCoordPosition));
            Vector3 globalPosDif = cellCoordPosition.GetGlobalPos() - playerGlobalPos;

            Transform transform = (Transform)(universeObject.GetComponent(typeof(Transform)));
            transform.position = (globalPosDif * (int)cellSize) + cellCoordPosition.GetLocalPos();
        }
    }

    void Update () {
        if (player.OutOfBounds())
        {
            player.SnapCamera();
            SnapUniverse(player.GetGlobalPos());
        }
	}
}
