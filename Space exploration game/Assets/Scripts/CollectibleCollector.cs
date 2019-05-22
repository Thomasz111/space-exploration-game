using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollector : MonoBehaviour {

    public int points = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Collectible")) {
            points++;
            GameObject.Destroy(other.gameObject);
        }
    }
}
