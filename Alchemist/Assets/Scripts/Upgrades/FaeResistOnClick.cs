using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaeResistOnClick : MonoBehaviour
{
    [SerializeField] private Button faeResistUpgrade;
    [SerializeField] private Text quartzText;
    public GameObject countdownCanvas;

    void Start() {

        quartzText.text = "x " + GameManager.Instance.quartzCost.ToString();

        if (GameManager.Instance.quartzAmt < GameManager.Instance.quartzCost) {
            faeResistUpgrade.interactable = false;
        }
    }

    public void UpgradeFaeResist() {

        // TODO: decrease damage from satyr, pixie, demon
        
        GameManager.Instance.quartzAmt -= GameManager.Instance.quartzCost;
        GameManager.Instance.quartzCost += 3;
        quartzText.text = "x " + GameManager.Instance.quartzCost.ToString();
        faeResistUpgrade.interactable = false;
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
    }
}
