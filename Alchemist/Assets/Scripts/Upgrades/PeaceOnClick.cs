using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeaceOnClick : MonoBehaviour
{
    [SerializeField] private Button peaceUpgrade;
    [SerializeField] private Text lavenderText;
    private int lavenderCost = 1;

    void Start() {

        if (GameManager.Instance.lavenderAmt < lavenderCost) {
            peaceUpgrade.interactable = false;
        }
    }

    public void UpgradePeace() {

        GameManager.Instance.playerPeace += 1;
        GameManager.Instance.lavenderAmt -= lavenderCost;
        lavenderCost += 3;
        lavenderText.text = "x " + lavenderCost.ToString();
        peaceUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
