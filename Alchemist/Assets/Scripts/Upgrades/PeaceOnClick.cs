using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeaceOnClick : MonoBehaviour
{
    [SerializeField] private Button peaceUpgrade;

    public void UpgradePeace() {

        GameManager.Instance.playerPeace += 1;
        peaceUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
