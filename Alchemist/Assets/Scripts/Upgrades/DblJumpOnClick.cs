using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DblJumpOnClick : MonoBehaviour
{
    [SerializeField] private Button dblJumpUpgrade;
    [SerializeField] private Text swineSnoutText;
    public GameObject countdownCanvas;

    void Start() {

        swineSnoutText.text = "x " + GameManager.Instance.swineSnoutCost.ToString();

        if (GameManager.Instance.swineSnoutAmt < GameManager.Instance.swineSnoutCost) {
            dblJumpUpgrade.interactable = false;
        }
    }

    public void UpgradeDblJump() {

        // TODO: affect double jump + change effect after 2nd press?
        
        GameManager.Instance.swineSnoutAmt -= GameManager.Instance.swineSnoutCost;
        GameManager.Instance.swineSnoutCost += 3;
        swineSnoutText.text = "x " + GameManager.Instance.swineSnoutCost.ToString();
        dblJumpUpgrade.interactable = false;
        countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
    }
}
