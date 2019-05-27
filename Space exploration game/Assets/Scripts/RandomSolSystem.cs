using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSolSystem : MonoBehaviour {

    public List<GameObject> planets = new List<GameObject>();
    public int numOfPlanets;
    public long minGlobalDistance;
    public long maxGlobalDistance;

    private List<GameObject> instantiatedPlanets = new List<GameObject>();
    private Universe universe;
    private CellCoordPosition cellCoordPosition;
    private ShadowManager shadowManager;

    void Start () {
        universe = (Universe)GameObject.Find("GameManager").GetComponent(typeof(Universe));
        cellCoordPosition = gameObject.GetComponent<CellCoordPosition>();
        shadowManager = gameObject.GetComponent<ShadowManager>();
        for(int i = 0; i < numOfPlanets; i++)
        {
            int randomIndex = Random.Range(0, planets.Count);
            GameObject planet = planets[randomIndex];
            PrefabCoord planetCoord = new PrefabCoord();
            planetCoord.prefab = planet;


            planetCoord.GlobalX = (long)Random.Range(-maxGlobalDistance, maxGlobalDistance);
            planetCoord.GlobalY = (long)Random.Range(-maxGlobalDistance, maxGlobalDistance);
            planetCoord.GlobalZ = 0;
            planetCoord.LocalX = Random.Range(-cellCoordPosition.GetCellSize(), cellCoordPosition.GetCellSize());
            planetCoord.LocalY = Random.Range(-cellCoordPosition.GetCellSize(), cellCoordPosition.GetCellSize());
            planetCoord.LocalZ = 0;

            planetCoord.GlobalX += (long)cellCoordPosition.GetGlobalPos().x;
            planetCoord.GlobalY += (long)cellCoordPosition.GetGlobalPos().y;
            planetCoord.GlobalZ += (long)cellCoordPosition.GetGlobalPos().z;
            planetCoord.LocalX += cellCoordPosition.GetLocalPos().x;
            planetCoord.LocalY += cellCoordPosition.GetLocalPos().y;
            planetCoord.LocalZ += cellCoordPosition.GetLocalPos().z;
            GameObject instantiatedPlanet = universe.InstatntiateUniverseObject(planetCoord);
            instantiatedPlanets.Add(instantiatedPlanet);
            shadowManager.planet[i] = instantiatedPlanet;
        }
        shadowManager.Init(numOfPlanets);
    }
	
	void Update () {
        foreach (GameObject instantiatedPlanet in instantiatedPlanets)
            instantiatedPlanet.GetComponent<Planet>().SetStarPosition(gameObject.transform.position);
    }
}
