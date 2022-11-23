using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthOnClick : MonoBehaviour
{
    [SerializeField] private Button healthUpgrade;

    public void UpgradeHealth() {

        GameManager.Instance.playerHealth += 1;
        healthUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        GameManager.Instance.healthBar.GetComponent<HealthBarHud>().AddHealth();
        GameManager.Instance.healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
    }
}
