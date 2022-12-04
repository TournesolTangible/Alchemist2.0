using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyResistOnClick : MonoBehaviour
{
    [SerializeField] private Button flyResistUpgrade;
    [SerializeField] private Text snakeHeadText;

    public GameObject owl;
    public GameObject ghost;
    public GameObject bat;

    void Start() {

        snakeHeadText.text = "x " + GameManager.Instance.snakeHeadCost.ToString();

        if (GameManager.Instance.snakeHeadAmt < GameManager.Instance.snakeHeadCost) {
            flyResistUpgrade.interactable = false;
        }
    }

    public void UpgradeFlyResist() {

        owl.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        ghost.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        bat.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        
        GameManager.Instance.snakeHeadAmt -= GameManager.Instance.snakeHeadCost;
        GameManager.Instance.snakeHeadCost += 3;
        snakeHeadText.text = "x " + GameManager.Instance.snakeHeadCost.ToString();
        flyResistUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
