using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectionOnClick : MonoBehaviour
{
    [SerializeField] private Button protectionUpgrade;
    [SerializeField] private Text batWingText;

    void Start() {

        batWingText.text = "x " + GameManager.Instance.batWingCost.ToString();

        if (GameManager.Instance.batWingAmt < GameManager.Instance.batWingCost) {
            protectionUpgrade.interactable = false;
        }
    }

    public void UpgradeProtection() {

        GameManager.Instance.playerProtection += 1;
        GameManager.Instance.batWingAmt -= GameManager.Instance.batWingCost;
        GameManager.Instance.batWingCost += 3;
        batWingText.text = "x " + GameManager.Instance.batWingCost.ToString();
        protectionUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
