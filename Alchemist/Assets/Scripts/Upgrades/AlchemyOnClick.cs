using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemyOnClick : MonoBehaviour
{
    [SerializeField] private Button alchemyUpgrade;
    [SerializeField] private Text fairyBellsText;
    public GameObject countdownCanvas;

    void Start() {

        fairyBellsText.text = "x " + GameManager.Instance.fairyBellsCost.ToString();

        if (GameManager.Instance.fairyBellsAmt < GameManager.Instance.fairyBellsCost) {
            alchemyUpgrade.interactable = false;
        }
    }

    public void UpgradeAlchemy() {

        GameManager.Instance.playerAlchemy += 1;
        GameManager.Instance.fairyBellsAmt -= GameManager.Instance.fairyBellsCost;
        GameManager.Instance.fairyBellsCost += 2;
        fairyBellsText.text = "x " + GameManager.Instance.fairyBellsCost.ToString();
        alchemyUpgrade.interactable = false;
        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
