using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollector : MonoBehaviour {

    public int points = 0;

    void OnTriggerEnter(Collider other)
    {
        points++;
        GameObject.Destroy(other.gameObject);
    }
}
