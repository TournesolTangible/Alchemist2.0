using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectionOnClick : MonoBehaviour
{
    [SerializeField] private Button protectionUpgrade;
    [SerializeField] private Text batWingText;
    [SerializeField] private AudioSource upgradeSound;

    void Start() {

        batWingText.text = "x " + GameManager.Instance.batWingCost.ToString();

        if (GameManager.Instance.batWingAmt < GameManager.Instance.batWingCost) {
            protectionUpgrade.interactable = false;
        }
    }

    public void UpgradeProtection() {

        GameManager.Instance.Player.GetComponent<PlayerStats>().invincibilityDurationInSec += 1.0f;

        GameManager.Instance.playerProtection += 1;
        GameManager.Instance.batWingAmt -= GameManager.Instance.batWingCost;
        GameManager.Instance.batWingCost += 3;
        batWingText.text = "x " + GameManager.Instance.batWingCost.ToString();
        upgradeSound.Play();
        protectionUpgrade.interactable = false;
        
        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
