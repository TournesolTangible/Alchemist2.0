using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthOnClick : MonoBehaviour
{
    [SerializeField] private Button strengthUpgrade;
    [SerializeField] private Text goatHoofText;
    private int goatHoofCost = 1;

    void Start() {

        if (GameManager.Instance.goatHoofAmt < goatHoofCost) {
            strengthUpgrade.interactable = false;
        }
    }

    public void UpgradeStrength() {

        GameManager.Instance.playerStrength += 1;
        GameManager.Instance.goatHoofAmt -= goatHoofCost;
        goatHoofCost += 3;
        goatHoofText.text = "x " + goatHoofCost.ToString();
        strengthUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
