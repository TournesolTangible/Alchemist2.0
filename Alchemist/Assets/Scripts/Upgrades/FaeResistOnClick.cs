using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaeResistOnClick : MonoBehaviour
{
    [SerializeField] private Button faeResistUpgrade;
    [SerializeField] private Text quartzText;
    [SerializeField] private AudioSource upgradeSound;

    public GameObject satyr;
    public GameObject pixie;
    public GameObject demon;

    void Start() {

        quartzText.text = "x " + GameManager.Instance.quartzCost.ToString();

        if (GameManager.Instance.quartzAmt < GameManager.Instance.quartzCost) {
            faeResistUpgrade.interactable = false;
        }
    }

    public void UpgradeFaeResist() {

        satyr.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        pixie.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        demon.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        
        GameManager.Instance.quartzAmt -= GameManager.Instance.quartzCost;
        GameManager.Instance.quartzCost += 3;
        quartzText.text = "x " + GameManager.Instance.quartzCost.ToString();
        upgradeSound.Play();
        faeResistUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
