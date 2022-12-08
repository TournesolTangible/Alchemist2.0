using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CornucopiaOnClick : MonoBehaviour
{
    [SerializeField] private Button cornucopiaUpgrade;
    [SerializeField] private Text cornucopiaDesc;
    [SerializeField] private Text devilEyeText;

    void Start() {

        devilEyeText.text = "x " + GameManager.Instance.devilEyeCost.ToString();

        if (GameManager.Instance.devilEyeAmt < GameManager.Instance.devilEyeCost) {
            cornucopiaUpgrade.interactable = false;
        }
    }

    public void Upgradecornucopia() {

        int cost = GameManager.Instance.devilEyeCost;

        GameManager.Instance.acornAmt += cost;
        GameManager.Instance.batWingAmt += cost;
        GameManager.Instance.fairyBellsAmt += cost;
        GameManager.Instance.devilEyeAmt += cost;
        GameManager.Instance.foxTailAmt += cost;
        GameManager.Instance.goatHoofAmt += cost;
        GameManager.Instance.graveyardDustAmt += cost;
        GameManager.Instance.juniperBerryAmt += cost;
        GameManager.Instance.lavenderAmt += cost;
        GameManager.Instance.mushroomAmt += cost;
        GameManager.Instance.quartzAmt += cost;
        GameManager.Instance.sageAmt += cost;
        GameManager.Instance.snakeHeadAmt += cost;
        GameManager.Instance.spiderSilkAmt += cost;
        GameManager.Instance.swineSnoutAmt += cost;
        GameManager.Instance.vervainAmt += cost;
        GameManager.Instance.wolfFootAmt += cost;

        GameManager.Instance.devilEyeAmt -= GameManager.Instance.devilEyeCost;
        GameManager.Instance.devilEyeCost += 2;
        devilEyeText.text = "x " + GameManager.Instance.devilEyeCost.ToString();
        cornucopiaDesc.text = "Instantly receive " + GameManager.Instance.devilEyeCost.ToString() + " of\nevery other collectible";
        cornucopiaUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
