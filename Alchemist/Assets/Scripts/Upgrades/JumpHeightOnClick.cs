using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpHeightOnClick : MonoBehaviour
{
    [SerializeField] private Button jumpHeightUpgrade;
    [SerializeField] private Text spiderSilkText;
    public GameObject countdownCanvas;

    void Start() {

        spiderSilkText.text = "x " + GameManager.Instance.spiderSilkCost.ToString();

        if (GameManager.Instance.spiderSilkAmt < GameManager.Instance.spiderSilkCost) {
            jumpHeightUpgrade.interactable = false;
        }
    }

    public void UpgradeJumpHeight() {

        // TODO: increase height of player jump by small increment
        
        GameManager.Instance.spiderSilkAmt -= GameManager.Instance.spiderSilkCost;
        GameManager.Instance.spiderSilkCost += 3;
        spiderSilkText.text = "x " + GameManager.Instance.spiderSilkCost.ToString();
        jumpHeightUpgrade.interactable = false;
    }
}
