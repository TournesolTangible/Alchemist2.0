using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpOnClick : MonoBehaviour
{
    [SerializeField] private Button speedUpgrade;
    [SerializeField] private Text wolfFootText;

    void Start() {

        wolfFootText.text = "x " + GameManager.Instance.wolfFootCost.ToString();

        if (GameManager.Instance.wolfFootAmt < GameManager.Instance.wolfFootCost) {
            speedUpgrade.interactable = false;
        }
    }

    public void UpgradeSpeed() {

       GameManager.Instance.Player.GetComponent<ShootFireballs>()._FireballRate -= 0.1f;
       
        GameManager.Instance.wolfFootAmt -= GameManager.Instance.wolfFootCost;
        GameManager.Instance.wolfFootCost += 3;
        wolfFootText.text = "x " + GameManager.Instance.wolfFootCost.ToString();
        speedUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
