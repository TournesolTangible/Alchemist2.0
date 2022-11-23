using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckOnClick : MonoBehaviour
{
    [SerializeField] private Button luckUpgrade;

    public void UpgradeLuck() {

        GameManager.Instance.playerLuck += 1;
        luckUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
