using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeUpOnClick : MonoBehaviour
{
    [SerializeField] private Button rangeUpgrade;
    [SerializeField] private Text featherText;

    void Start() {

        featherText.text = "x " + GameManager.Instance.featherCost.ToString();

        if (GameManager.Instance.featherAmt < GameManager.Instance.featherCost) {
            rangeUpgrade.interactable = false;
        }
    }

    public void UpgradeAtkRange() {


        GameManager.Instance.featherAmt -= GameManager.Instance.featherCost;
        GameManager.Instance.featherCost += 3;
        featherText.text = "x " + GameManager.Instance.featherCost.ToString();
        rangeUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
