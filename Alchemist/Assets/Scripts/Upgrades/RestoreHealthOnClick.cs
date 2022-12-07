using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthRestoreUpgrade;
    [SerializeField] private Text acornText;

    void Start() {

        acornText.text = "x " + GameManager.Instance.acornCost.ToString();

        if (GameManager.Instance.acornAmt < GameManager.Instance.acornCost) {
            healthRestoreUpgrade.interactable = false;
        }
    }

    public void UpgradeHealthRestore() {

        int maxHealth = GameManager.Instance.playerHealth;
        GameManager.Instance.currentHealth = maxHealth;
        GameManager.Instance.acornAmt -= GameManager.Instance.acornCost;
        GameManager.Instance.acornCost += 2;
        acornText.text = "x " + GameManager.Instance.acornCost.ToString();
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().Heal((float)maxHealth);
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
        healthRestoreUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
        
    }
}
