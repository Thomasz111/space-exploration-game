using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    public GameObject planet;

    private GameObject instantiatedPlanet;

    void Start () {
        instantiatedPlanet = GameObject.Instantiate(planet);
    }
	
	void Update () {
        instantiatedPlanet.GetComponent<Planet>().SetStarPosition(gameObject.transform.position);
    }
}
