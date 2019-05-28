using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCollector : MonoBehaviour {

    public int points = 0;
    public Text countText;

    void Start()
    {
        countText.text = "Points: " + points.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Collectible")) {
            points++;
            countText.text = "Points: " + points.ToString();
            GameObject.Destroy(other.gameObject);
        }
    }
}
