using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SkyboxCamera : MonoBehaviour {

    public Transform player;

	void Start () {
        transform.position = Vector3.zero;

    }
	
	void Update () {
        transform.rotation = player.rotation;
	}
}
