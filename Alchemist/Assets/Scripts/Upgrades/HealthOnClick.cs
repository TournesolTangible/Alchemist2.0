using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthUpgrade;
    [SerializeField] private Text graveyardDustText;
    public GameObject countdownCanvas;

    void Start() {

        graveyardDustText.text = "x " + GameManager.Instance.graveyardDustCost.ToString();

        if (GameManager.Instance.graveyardDustAmt < GameManager.Instance.graveyardDustCost) {
            healthUpgrade.interactable = false;
        }
    }

    public void UpgradeHealth() {

        GameManager.Instance.playerHealth += 1;
        GameManager.Instance.graveyardDustAmt -= GameManager.Instance.graveyardDustCost;
        GameManager.Instance.graveyardDustCost += 2;
        graveyardDustText.text = "x " + GameManager.Instance.graveyardDustCost.ToString();
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        healthUpgrade.interactable = false;
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().AddHealth();
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();    
    }
}
