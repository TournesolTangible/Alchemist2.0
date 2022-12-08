using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlessingOnClick : MonoBehaviour
{
    [SerializeField] private Button blessingUpgrade;
    [SerializeField] private Text blessingDesc;
    [SerializeField] private Text featherText;
    [SerializeField] private AudioSource upgradeSound;

    void Start() {

        featherText.text = "x " + GameManager.Instance.featherCost.ToString();

        if (GameManager.Instance.featherAmt < GameManager.Instance.featherCost) {
            blessingUpgrade.interactable = false;
        }
    }

    public void UpgradeBlessing() {

        int cost = GameManager.Instance.featherCost;

        var num = Random.Range(1, 17);

        switch (num) 
        {
            case 1:
            GameManager.Instance.acornAmt += cost;
            break;
            case 2:
            GameManager.Instance.batWingAmt += cost;
            break;
            case 3:
            GameManager.Instance.fairyBellsAmt += cost;
            break;
            case 4:
            GameManager.Instance.featherAmt += cost;
            break;
            case 5:
            GameManager.Instance.foxTailAmt += cost;
            break;
            case 6:
            GameManager.Instance.goatHoofAmt += cost;
            break;
            case 7:
            GameManager.Instance.graveyardDustAmt += cost;
            break;
            case 8:
            GameManager.Instance.juniperBerryAmt += cost;
            break;
            case 9:
            GameManager.Instance.lavenderAmt += cost;
            break;
            case 10:
            GameManager.Instance.mushroomAmt += cost;
            break;
            case 11:
            GameManager.Instance.quartzAmt += cost;
            break;
            case 12:
            GameManager.Instance.sageAmt += cost;
            break;
            case 13:
            GameManager.Instance.snakeHeadAmt += cost;
            break;
            case 14:
            GameManager.Instance.spiderSilkAmt += cost;
            break;
            case 15:
            GameManager.Instance.swineSnoutAmt += cost;
            break;
            case 16:
            GameManager.Instance.vervainAmt += cost;
            break;
            case 17:
            GameManager.Instance.wolfFootAmt += cost;
            break;
        }
        
        GameManager.Instance.featherAmt -= GameManager.Instance.featherCost;
        GameManager.Instance.featherCost += 2;
        featherText.text = "x " + GameManager.Instance.featherCost.ToString();
        blessingDesc.text = "Instantly receive " + GameManager.Instance.featherCost.ToString() + " of\na random collectible";
        upgradeSound.Play();
        blessingUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
