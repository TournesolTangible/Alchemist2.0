using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DblJumpOnClick : MonoBehaviour
{
    [SerializeField] private Button dblJumpUpgrade;
    [SerializeField] private Text swineSnoutText;
    [SerializeField] private AudioSource upgradeSound;

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
        upgradeSound.Play();
        dblJumpUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
