using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectionOnClick : MonoBehaviour
{
    [SerializeField] private Button protectionUpgrade;
    [SerializeField] private Text batWingText;
    private int batWingCost = 1;

    void Update() {

        if (GameManager.Instance.batWingAmt < batWingCost) {
            protectionUpgrade.interactable = false;
        }
    }

    public void UpgradeProtection() {

        GameManager.Instance.playerProtection += 1;
        GameManager.Instance.batWingAmt -= batWingCost;
        batWingCost += 3;
        batWingText.text = "x " + batWingCost.ToString();
        protectionUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
