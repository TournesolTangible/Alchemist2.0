using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickOnClick : MonoBehaviour
{
    [SerializeField] private Button stickUpgrade;
    [SerializeField] private Text acornText;

    void Start() {

        acornText.text = "x " + GameManager.Instance.acornCost.ToString();

        if (GameManager.Instance.acornAmt < GameManager.Instance.acornCost) {
            stickUpgrade.interactable = false;
        }
    }

    public void UpgradeStick() {

        // TODO: increase frequency of stick attack

        GameManager.Instance.acornAmt -= GameManager.Instance.acornCost;
        GameManager.Instance.acornCost += 3;
        acornText.text = "x " + GameManager.Instance.acornCost.ToString();
        stickUpgrade.interactable = false;
    }
}
