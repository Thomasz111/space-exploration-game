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
            double distance = CellCoordUtils.Distance(playerPosition, lodObjectPosition);
            if (distance > prefabDistance.GetMinDistance() && distance < prefabDistance.GetMaxDistance())
            {
                if(distance < prevMinDistance || distance > prevMaxDistance)
                {
                    prevMinDistance = prefabDistance.GetMinDistance();
                    prevMaxDistance = prefabDistance.GetMaxDistance();

                    GameObject.Destroy(currentObject);
                    currentObject = GameObject.Instantiate(prefabDistance.prefab);
                    currentObject.transform.parent = gameObject.transform;
                    currentObject.transform.position = gameObject.transform.position;
                }
            }
        }
	}
}
