using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthRestoreUpgrade;
    [SerializeField] private Text sageText;
    private int sageCost = 1;

    void Start() {

        if (GameManager.Instance.sageAmt < sageCost) {
            healthRestoreUpgrade.interactable = false;
        }
    }

    public void UpgradeHealthRestore() {

        int maxHealth = GameManager.Instance.playerHealth;
        GameManager.Instance.currentHealth = maxHealth;
        GameManager.Instance.sageAmt -= sageCost;
        sageCost += 3;
        sageText.text = "x " + sageCost.ToString();
        healthRestoreUpgrade.interactable = false;
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().Heal((float)maxHealth);
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
        
    }
}
