using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft = 30.0f;
    public Text timeText;

    public bool TimeLeft()
    {
        return !(timeLeft > 0);
    }

    void Update () {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = "Time left: " + timeLeft.ToString();
        }
        else
        {
            timeText.text = "Time left: 0";
        }
    }
}
