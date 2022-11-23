using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthRestoreUpgrade;

    public void UpgradeHealthRestore() {

        int maxHealth = GameManager.Instance.playerHealth;
        GameManager.Instance.currentHealth = maxHealth;
        healthRestoreUpgrade.interactable = false;
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().Heal((float)maxHealth);
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
        
    }
}
