using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public Text gameOverText;

    private Timer timer;
    private CellCoordCameraMovement player;
    private CollectibleCollector collectibleCollector;

    void Start () {
        gameOverText.text = "";
        timer = gameObject.GetComponent<Timer>();
        player = GameObject.Find("Player").GetComponent<CellCoordCameraMovement>();
        collectibleCollector = GameObject.Find("Player").GetComponent<CollectibleCollector>();
    }

    void Update()
    {
        if (timer.TimeLeft())
        {
            gameOverText.text = "Game over, points: " + collectibleCollector.points;
            player.StopPlayer();
        }
    }
}
