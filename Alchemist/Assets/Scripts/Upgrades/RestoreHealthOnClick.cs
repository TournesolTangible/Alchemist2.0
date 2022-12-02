using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthRestoreUpgrade;
    [SerializeField] private Text sageText;
    public GameObject countdownCanvas;

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
        GameManager.Instance.sageCost += 3;
        sageText.text = "x " + GameManager.Instance.sageCost.ToString();
        healthRestoreUpgrade.interactable = false;
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().Heal((float)maxHealth);
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        
    }
}
