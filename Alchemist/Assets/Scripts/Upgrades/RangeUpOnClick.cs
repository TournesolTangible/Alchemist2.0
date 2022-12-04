using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeUpOnClick : MonoBehaviour
{
    [SerializeField] private Button rangeUpgrade;
    [SerializeField] private Text featherText;
    public GameObject countdownCanvas;

    void Start() {

        featherText.text = "x " + GameManager.Instance.featherCost.ToString();

        if (GameManager.Instance.featherAmt < GameManager.Instance.featherCost) {
            rangeUpgrade.interactable = false;
        }
    }

    public void UpgradeAtkRange() {

        // TODO: increase range of fireball attack

        GameManager.Instance.featherAmt -= GameManager.Instance.featherCost;
        GameManager.Instance.featherCost += 3;
        featherText.text = "x " + GameManager.Instance.featherCost.ToString();
        rangeUpgrade.interactable = false;
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
