using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthUpgrade;
    [SerializeField] private Text graveyardDustText;
    private int graveyardDustCost = 1;

    void Start() {

        if (GameManager.Instance.graveyardDustAmt < graveyardDustCost) {
            healthUpgrade.interactable = false;
        }
    }

    public void UpgradeHealth() {

        GameManager.Instance.playerHealth += 1;
        GameManager.Instance.graveyardDustAmt -= graveyardDustCost;
        graveyardDustCost += 3;
        graveyardDustText.text = "x " + graveyardDustCost.ToString();
        healthUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().AddHealth();
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
    }
}
