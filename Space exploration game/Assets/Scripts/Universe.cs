using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour {

    public long CellSize = 100;
    public List<PrefabCoord> prefabCoords = new List<PrefabCoord>();
    public CellCoordCameraMovement player;

    private List<GameObject> universeObjects = new List<GameObject>();

    void Start () {
        InstantiatePlayer();
        InstatntiateUniverseObjects();
	}
	
    public void InstantiatePlayer()
    {
        player.SetCellSize(CellSize);
    }

    public void AddUniverseObject(GameObject universeObject)
    {
        universeObjects.Add(universeObject);
    }

    public List<GameObject> GetUniverseObjects()
    {
        return universeObjects;
    }

    public long GetCellSize()
    {
        return CellSize;
    }

    public void InstatntiateUniverseObjects()
    {
        foreach(PrefabCoord prefabCoord in prefabCoords)
        {
            InstatntiateUniverseObject(prefabCoord);
        }
    }

    public GameObject InstatntiateUniverseObject(PrefabCoord prefabCoord)
    {
        GameObject universeObject = GameObject.Instantiate(prefabCoord.prefab);

        CellCoordPosition cellCoordPosition = (CellCoordPosition)universeObject.AddComponent(typeof(CellCoordPosition));
        cellCoordPosition.SetCellSize(CellSize);
        cellCoordPosition.SetLocalPosition(prefabCoord.LocalX, prefabCoord.LocalY, prefabCoord.LocalZ);
        cellCoordPosition.SetGlobalPosition(prefabCoord.GlobalX, prefabCoord.GlobalY, prefabCoord.GlobalZ);
        universeObject.transform.position = cellCoordPosition.GetRealPosition();

        universeObjects.Add(universeObject);
        return universeObject;
    }

    public void SnapUniverse(Vector3 playerGlobalPos)
    {
        foreach(GameObject universeObject in universeObjects)
        {
            if(universeObject != null)
                TranslateObject(universeObject, playerGlobalPos);
        }
    }

    public void TranslateObject(GameObject universeObject, Vector3 playerGlobalPos)
    {
        CellCoordPosition cellCoordPosition = (CellCoordPosition)universeObject.GetComponent(typeof(CellCoordPosition));
        Vector3 globalPosDif = cellCoordPosition.GetGlobalPos() - playerGlobalPos;

        Transform transform = (Transform)(universeObject.GetComponent(typeof(Transform)));
        transform.position = (globalPosDif * CellSize) + cellCoordPosition.GetLocalPos();
    }

    void Update () {
        if (player.OutOfBounds())
        {
            player.SnapCamera();
            SnapUniverse(player.GetGlobalPos());
        }
	}
}
