using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectionOnClick : MonoBehaviour
{
    [SerializeField] private Button protectionUpgrade;

    public void UpgradeProtection() {

        GameManager.Instance.playerProtection += 1;
        protectionUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
