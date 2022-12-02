using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpOnClick : MonoBehaviour
{
    [SerializeField] private Button speedUpgrade;
    [SerializeField] private Text wolfFootText;
    public GameObject countdownCanvas;

    void Start() {

        wolfFootText.text = "x " + GameManager.Instance.wolfFootCost.ToString();

        if (GameManager.Instance.wolfFootAmt < GameManager.Instance.wolfFootCost) {
            speedUpgrade.interactable = false;
        }
    }

    public void UpgradeSpeed() {

       // TODO: increase speed of fireball attack

        GameManager.Instance.wolfFootAmt -= GameManager.Instance.wolfFootCost;
        GameManager.Instance.wolfFootCost += 3;
        wolfFootText.text = "x " + GameManager.Instance.wolfFootCost.ToString();
        speedUpgrade.interactable = false;
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
    }
}
