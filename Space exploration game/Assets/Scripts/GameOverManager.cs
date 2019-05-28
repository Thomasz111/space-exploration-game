using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public Text gameOverText;
    public Text reloadText;

    private Timer timer;
    private CellCoordCameraMovement player;
    private CollectibleCollector collectibleCollector;

    void Start () {
        gameOverText.text = "";
        reloadText.text = "";
        timer = gameObject.GetComponent<Timer>();
        player = GameObject.Find("Player").GetComponent<CellCoordCameraMovement>();
        collectibleCollector = GameObject.Find("Player").GetComponent<CollectibleCollector>();
    }

    void Update()
    {
        if (timer.TimeLeft())
        {
            gameOverText.text = "Game over, points: " + collectibleCollector.points;
            reloadText.text = "Press 'r' to play again";
            player.StopPlayer();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}