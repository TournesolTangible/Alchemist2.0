using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlessingOnClick : MonoBehaviour
{
    [SerializeField] private Button blessingUpgrade;
    [SerializeField] private Text blessingDesc;
    [SerializeField] private Text devilEyeText;

    void Start() {

        devilEyeText.text = "x " + GameManager.Instance.devilEyeCost.ToString();

        if (GameManager.Instance.devilEyeAmt < GameManager.Instance.devilEyeCost) {
            blessingUpgrade.interactable = false;
        }
    }

    public void UpgradeBlessing() {

        

        GameManager.Instance.devilEyeAmt -= GameManager.Instance.devilEyeCost;
        GameManager.Instance.devilEyeCost += 2;
        devilEyeText.text = "x " + GameManager.Instance.devilEyeCost.ToString();
        blessingDesc.text = "Instantly receive " + GameManager.Instance.devilEyeCost.ToString() + "of\nevery other collectible";
        blessingUpgrade.interactable = false;
        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
