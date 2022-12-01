using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyResistOnClick : MonoBehaviour
{
    [SerializeField] private Button flyResistUpgrade;
    [SerializeField] private Text snakeHeadText;

    void Start() {

        snakeHeadText.text = "x " + GameManager.Instance.snakeHeadCost.ToString();

        if (GameManager.Instance.snakeHeadAmt < GameManager.Instance.snakeHeadCost) {
            flyResistUpgrade.interactable = false;
        }
    }

    public void UpgradeFlyResist() {

        // TODO: reduce damage from owl, ghost, bat
        
        GameManager.Instance.snakeHeadAmt -= GameManager.Instance.snakeHeadCost;
        GameManager.Instance.snakeHeadCost += 3;
        snakeHeadText.text = "x " + GameManager.Instance.snakeHeadCost.ToString();
        flyResistUpgrade.interactable = false;
    }
}
