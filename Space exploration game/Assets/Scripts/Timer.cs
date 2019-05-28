using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft = 30.0f;
    public Text timeText;

    void Update () {
        timeLeft -= Time.deltaTime;
        timeText.text = "Time left: " + timeLeft.ToString();
    }
}
