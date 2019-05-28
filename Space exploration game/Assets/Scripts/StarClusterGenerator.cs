using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClusterGenerator : MonoBehaviour {

    public GameObject SolarSystem;
    public int NumOfSolarSystems;
    public long SizeOfStarCluster;

    private Universe universe;
    private CellCoordPosition clusterCenter;

    void Start () {
        universe = (Universe)GameObject.Find("GameManager").GetComponent(typeof(Universe));
        clusterCenter = gameObject.GetComponent<CellCoordPosition>();
        InstantiateStarCluster();
    }

    private void InstantiateStarCluster()
    {
        for(int StarSystemNumber = 0; StarSystemNumber < NumOfSolarSystems; StarSystemNumber++)
        {
            PrefabCoord StarSystemCoords = new PrefabCoord();
            StarSystemCoords.prefab = SolarSystem;

            StarSystemCoords.GlobalX = (long)Random.Range(-SizeOfStarCluster, SizeOfStarCluster) + (long)clusterCenter.GetGlobalPos().x;
            StarSystemCoords.GlobalY = (long)Random.Range(-SizeOfStarCluster, SizeOfStarCluster) + (long)clusterCenter.GetGlobalPos().y;
            StarSystemCoords.GlobalZ = (long)Random.Range(-SizeOfStarCluster, SizeOfStarCluster) + (long)clusterCenter.GetGlobalPos().z;
            StarSystemCoords.LocalX = Random.Range(-universe.GetCellSize(), universe.GetCellSize()) + clusterCenter.GetLocalPos().x;
            StarSystemCoords.LocalY = Random.Range(-universe.GetCellSize(), universe.GetCellSize()) + clusterCenter.GetLocalPos().y;
            StarSystemCoords.LocalZ = Random.Range(-universe.GetCellSize(), universe.GetCellSize()) + clusterCenter.GetLocalPos().z;

            universe.InstatntiateUniverseObject(StarSystemCoords);
        }
    }

}
