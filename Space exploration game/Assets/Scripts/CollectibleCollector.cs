using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCollector : MonoBehaviour {

    public int points = 0;
    public Text countText;

    private AudioSource audio;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        countText.text = "Points: " + points.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Collectible")) {
            audio.Play();
            points++;
            countText.text = "Points: " + points.ToString();
            GameObject.Destroy(other.gameObject);
        }
    }
}
