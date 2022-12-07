using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickOnClick : MonoBehaviour
{
    [SerializeField] private Button stickUpgrade;
    [SerializeField] private Text sageText;

    void Start() {

        sageText.text = "x " + GameManager.Instance.sageCost.ToString();

        if (GameManager.Instance.sageAmt < GameManager.Instance.sageCost) {
            stickUpgrade.interactable = false;
        }
    }

    public void UpgradeStick() {

        GameManager.Instance.Player.GetComponent<BasicAttack>().damageRate -= 0.05f;

        GameManager.Instance.sageAmt -= GameManager.Instance.sageCost;
        GameManager.Instance.sageCost += 3;
        sageText.text = "x " + GameManager.Instance.sageCost.ToString();
        stickUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
