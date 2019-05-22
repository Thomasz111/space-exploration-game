using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollector : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
}
