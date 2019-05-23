using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodObject : MonoBehaviour {

    public List<PrefabDistance> prefabDistances = new List<PrefabDistance>();

    private CellCoordPosition playerPosition;
    private CellCoordPosition lodObjectPosition;
    private GameObject currentObject = null;
    private double prevMaxDistance = 0;
    private double prevMinDistance = 0;

    void Start () {
        playerPosition = (CellCoordPosition)GameObject.Find("Player").GetComponent(typeof(CellCoordPosition));
        lodObjectPosition = (CellCoordPosition)gameObject.GetComponent(typeof(CellCoordPosition));
    }
	
	void Update () {
        
        foreach(PrefabDistance prefabDistance in prefabDistances)
        {
            double distance = CellCoordUtils.Distance(playerPosition, lodObjectPosition, lodObjectPosition.GetCellSize());
            if (distance > prefabDistance.GetMinDistance(lodObjectPosition.GetCellSize()) && distance < prefabDistance.GetMaxDistance(lodObjectPosition.GetCellSize()))
            {
                if(distance < prevMinDistance || distance > prevMaxDistance)
                {
                    prevMinDistance = prefabDistance.GetMinDistance(lodObjectPosition.GetCellSize());
                    prevMaxDistance = prefabDistance.GetMaxDistance(lodObjectPosition.GetCellSize());

                    GameObject.Destroy(currentObject);
                    currentObject = GameObject.Instantiate(prefabDistance.prefab);
                    currentObject.transform.parent = gameObject.transform;
                    currentObject.transform.position = gameObject.transform.position;
                }
            }
        }
	}
}
