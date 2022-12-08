using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreepyResistOnClick : MonoBehaviour
{
    [SerializeField] private Button creepyResistUpgrade;
    [SerializeField] private Text mushroomText;
    [SerializeField] private AudioSource upgradeSound;

    public GameObject spider;
    public GameObject snake;
    public GameObject mush;

    void Start() {

        mushroomText.text = "x " + GameManager.Instance.mushroomCost.ToString();

        if (GameManager.Instance.mushroomAmt < GameManager.Instance.mushroomCost) {
            creepyResistUpgrade.interactable = false;
        }
    }

    public void UpgradeCreepyResist() {

        spider.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        snake.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        mush.GetComponent<HurtPlayer>().damageAmt -= 0.1f;

        GameManager.Instance.mushroomAmt -= GameManager.Instance.mushroomCost;
        GameManager.Instance.mushroomCost += 3;
        mushroomText.text = "x " + GameManager.Instance.mushroomCost.ToString();
        upgradeSound.Play();
        creepyResistUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
