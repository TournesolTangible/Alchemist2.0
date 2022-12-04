using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeaceOnClick : MonoBehaviour
{
    [SerializeField] private Button peaceUpgrade;
    [SerializeField] private Text lavenderText;
    public GameObject countdownCanvas;

    void Start() {

        lavenderText.text = "x " + GameManager.Instance.lavenderCost.ToString();

        if (GameManager.Instance.lavenderAmt < GameManager.Instance.lavenderCost) {
            peaceUpgrade.interactable = false;
        }
    }

    public void UpgradePeace() {

        GameManager.Instance.playerPeace += 1;
        GameManager.Instance.lavenderAmt -= GameManager.Instance.lavenderCost;
        GameManager.Instance.lavenderCost += 3;
        lavenderText.text = "x " + GameManager.Instance.lavenderCost.ToString();
        peaceUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
    }
}
