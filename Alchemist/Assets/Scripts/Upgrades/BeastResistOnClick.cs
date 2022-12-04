using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastResistOnClick : MonoBehaviour
{
    [SerializeField] private Button beastResistUpgrade;
    [SerializeField] private Text juniperBerryText;
    public GameObject countdownCanvas;

    void Start() {

        juniperBerryText.text = "x " + GameManager.Instance.juniperBerryCost.ToString();

        if (GameManager.Instance.juniperBerryAmt < GameManager.Instance.juniperBerryCost) {
            beastResistUpgrade.interactable = false;
        }
    }

    public void UpgradeBeastResist() {

        // TODO: reduce damage of wolf/fox/boar 

        GameManager.Instance.juniperBerryAmt -= GameManager.Instance.juniperBerryCost;
        GameManager.Instance.juniperBerryCost += 3;
        juniperBerryText.text = "x " + GameManager.Instance.juniperBerryCost.ToString();
        beastResistUpgrade.interactable = false;
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
