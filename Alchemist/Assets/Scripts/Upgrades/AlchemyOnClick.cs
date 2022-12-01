using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemyOnClick : MonoBehaviour
{
    [SerializeField] private Button alchemyUpgrade;
    [SerializeField] private Text fairyBellsText;
    private int fairyBellsCost = 1;

    void Start() {

        if (GameManager.Instance.fairyBellsAmt < fairyBellsCost) {
            alchemyUpgrade.interactable = false;
        }
    }

    public void UpgradeAlchemy() {

        GameManager.Instance.playerAlchemy += 1;
        GameManager.Instance.fairyBellsAmt -= fairyBellsCost;
        fairyBellsCost += 3;
        fairyBellsText.text = "x " + fairyBellsCost.ToString();
        alchemyUpgrade.interactable = false;
    }
}
