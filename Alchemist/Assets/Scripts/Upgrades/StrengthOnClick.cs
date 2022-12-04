using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthOnClick : MonoBehaviour
{
    [SerializeField] private Button strengthUpgrade;
    [SerializeField] private Text goatHoofText;
    public GameObject countdownCanvas;

    void Start() {

        goatHoofText.text = "x " + GameManager.Instance.goatHoofCost.ToString();

        if (GameManager.Instance.goatHoofAmt < GameManager.Instance.goatHoofCost) {
            strengthUpgrade.interactable = false;
        }
    }

    public void UpgradeStrength() {

        GameManager.Instance.playerStrength += 1;
        GameManager.Instance.goatHoofAmt -= GameManager.Instance.goatHoofCost;
        GameManager.Instance.goatHoofCost += 3;
        goatHoofText.text = "x " + GameManager.Instance.goatHoofCost.ToString();
        strengthUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
    }
}
