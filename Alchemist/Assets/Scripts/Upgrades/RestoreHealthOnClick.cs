using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthRestoreUpgrade;
    [SerializeField] private Text sageText;

    void Start() {

        sageText.text = "x " + GameManager.Instance.sageCost.ToString();

        if (GameManager.Instance.sageAmt < GameManager.Instance.sageCost) {
            healthRestoreUpgrade.interactable = false;
        }
    }

    public void UpgradeHealthRestore() {

        int maxHealth = GameManager.Instance.playerHealth;
        GameManager.Instance.currentHealth = maxHealth;
        GameManager.Instance.sageAmt -= GameManager.Instance.sageCost;
        GameManager.Instance.sageCost += 2;
        sageText.text = "x " + GameManager.Instance.sageCost.ToString();
        healthRestoreUpgrade.interactable = false;
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().Heal((float)maxHealth);
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
        
    }
}
