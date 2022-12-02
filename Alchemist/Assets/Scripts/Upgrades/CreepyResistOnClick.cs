using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreepyResistOnClick : MonoBehaviour
{
    [SerializeField] private Button creepyResistUpgrade;
    [SerializeField] private Text mushroomText;
    public GameObject countdownCanvas;

    void Start() {

        mushroomText.text = "x " + GameManager.Instance.mushroomCost.ToString();

        if (GameManager.Instance.mushroomAmt < GameManager.Instance.mushroomCost) {
            creepyResistUpgrade.interactable = false;
        }
    }

    public void UpgradeCreepyResist() {

        // TODO: reduce damage from spider/snake/mush

        GameManager.Instance.mushroomAmt -= GameManager.Instance.mushroomCost;
        GameManager.Instance.mushroomCost += 3;
        mushroomText.text = "x " + GameManager.Instance.mushroomCost.ToString();
        creepyResistUpgrade.interactable = false;
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
    }
}
