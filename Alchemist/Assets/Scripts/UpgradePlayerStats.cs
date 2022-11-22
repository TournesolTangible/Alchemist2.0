using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePlayerStats : MonoBehaviour
{
    public GameObject GameManager;

    // access to buttons
    [SerializeField] private Button alchemyUpgrade;
    [SerializeField] private Button healthUpgrade;
    [SerializeField] private Button luckUpgrade;
    [SerializeField] private Button strengthUpgrade;
    [SerializeField] private Button peaceUpgrade;
    [SerializeField] private Button protectionUpgrade;
    [SerializeField] private Button healthRestoreUpgrade;
    [SerializeField] private Button atkRangeUpgrade;
    [SerializeField] private Button atkSpeedUpgrade;
    [SerializeField] private Button jumpHeightUpgrade;
    [SerializeField] private Button dblJumpUpgrade;

    public void UpgradeAlchemy() {

        GameManager.GetComponent<GameManager>().playerAlchemy += 1;
        alchemyUpgrade.interactable = false;
    }

    public void UpgradeHealth() {

        GameManager.GetComponent<GameManager>().playerHealth += 1;
        healthUpgrade.interactable = false;
    }

    public void UpgradeLuck() {

        GameManager.GetComponent<GameManager>().playerLuck += 1;
        luckUpgrade.interactable = false;
    }

    public void UpgradeStrength() {

        GameManager.GetComponent<GameManager>().playerStrength += 1;
        strengthUpgrade.interactable = false;
    }

    public void UpgradePeace() {

        GameManager.GetComponent<GameManager>().playerPeace += 1;
        peaceUpgrade.interactable = false;
    }

    public void UpgradeProtection() {

        GameManager.GetComponent<GameManager>().playerProtection += 1;
        protectionUpgrade.interactable = false;
    }

    public void UpgradeHealthRestore() {

       // GameManager.GetComponent<GameManager>().currentHealth == GameManager.GetComponent<GameManager>().playerHealth;
        healthRestoreUpgrade.interactable = false;
    }

    public void UpgradeAtkRange() {

    }

    public void UpgradeAtkSpeed() {

    }

    public void UpgradeJumpHeight() {

    }

    public void UpgradeDblJump() {

    }
}
