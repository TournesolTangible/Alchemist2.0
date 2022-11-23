using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWeaponStats : MonoBehaviour
{
    public GameObject GameManager;

    // access to buttons
    [SerializeField] private Button stickUpgrade;
    [SerializeField] private Button swordUpgrade;
    [SerializeField] private Button fireballUpgrade;

    public void UpgradeStick() {

        GameManager.GetComponent<GameManager>().stickDamage += 1;
        stickUpgrade.interactable = false;
    }
}
