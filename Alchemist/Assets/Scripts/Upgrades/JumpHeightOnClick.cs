using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpHeightOnClick : MonoBehaviour
{
    [SerializeField] private Button jumpHeightUpgrade;
    [SerializeField] private Text spiderSilkText;

    void Start() {

        spiderSilkText.text = "x " + GameManager.Instance.spiderSilkCost.ToString();

        if (GameManager.Instance.spiderSilkAmt < GameManager.Instance.spiderSilkCost) {
            jumpHeightUpgrade.interactable = false;
        }
    }

    public void UpgradeJumpHeight() {

        GameManager.Instance.Player.GetComponent<PlayerMovement>().jumping_power += 2;
        
        GameManager.Instance.spiderSilkAmt -= GameManager.Instance.spiderSilkCost;
        GameManager.Instance.spiderSilkCost += 3;
        spiderSilkText.text = "x " + GameManager.Instance.spiderSilkCost.ToString();
        jumpHeightUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
