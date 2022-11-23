using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthOnClick : MonoBehaviour
{
    [SerializeField] private Button strengthUpgrade;

    public void UpgradeStrength() {

        GameManager.Instance.playerStrength += 1;
        strengthUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
