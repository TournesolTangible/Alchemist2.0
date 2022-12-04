using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointTimer : MonoBehaviour
{
    public Text enemyCountdown;
    public int counter = 5;
    private int baseCounter = 5;
    public GameObject checkpointCanvas;

    void Start() {

        counter = 5;
        enemyCountdown.text = "Defeat " + counter.ToString() + " enemies!";
    }
    
    public void ReduceCountdown() {

        counter -= 1;
        enemyCountdown.text = "Defeat " + counter.ToString() + " enemies!";
        if (counter == 0) {
            checkpointCanvas.GetComponent<CheckpointShop>().OpenCheckpointShop();
        }
    }

    public void IncreaseCountdown() {

        baseCounter += 1;
    }

    public void ResetCountdown() {

        baseCounter += 2;
        counter = baseCounter;
        enemyCountdown.text = "Defeat " + counter.ToString() + " enemies!";

    }
}
