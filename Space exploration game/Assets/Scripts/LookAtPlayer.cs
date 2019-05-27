using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    private Transform playerPosition;

    void Start () {
        playerPosition = (Transform)GameObject.Find("Player").GetComponent(typeof(Transform));
    }
	
	void Update () {
        transform.LookAt(playerPosition);
    }
}
