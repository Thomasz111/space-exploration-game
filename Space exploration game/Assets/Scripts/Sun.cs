﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    public List<PrefabCoord> planets = new List<PrefabCoord>();

    private List<GameObject> instantiatedPlanets = new List<GameObject>();
    private Universe universe;
    private CellCoordPosition cellCoordPosition;

    void Start () {
        universe = (Universe)GameObject.Find("GameManager").GetComponent(typeof(Universe));
        cellCoordPosition = gameObject.GetComponent<CellCoordPosition>();
        foreach (PrefabCoord planet in planets)
        {
            planet.GlobalX += (long)cellCoordPosition.GetGlobalPos().x;
            planet.GlobalY += (long)cellCoordPosition.GetGlobalPos().y;
            planet.GlobalZ += (long)cellCoordPosition.GetGlobalPos().z;
            planet.LocalX += cellCoordPosition.GetLocalPos().x;
            planet.LocalY += cellCoordPosition.GetLocalPos().y;
            planet.LocalZ += cellCoordPosition.GetLocalPos().z;
            instantiatedPlanets.Add(universe.InstatntiateUniverseObject(planet));
        }
    }
	
	void Update () {
        foreach(GameObject instantiatedPlanet in instantiatedPlanets)
            instantiatedPlanet.GetComponent<Planet>().SetStarPosition(gameObject.transform.position);
    }
}