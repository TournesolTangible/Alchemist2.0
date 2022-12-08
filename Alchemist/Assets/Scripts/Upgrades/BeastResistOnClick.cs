using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastResistOnClick : MonoBehaviour
{
    [SerializeField] private Button beastResistUpgrade;
    [SerializeField] private Text juniperBerryText;
    [SerializeField] private AudioSource upgradeSound;

    public GameObject boar;
    public GameObject fox;
    public GameObject wolf;

    void Start() {

        juniperBerryText.text = "x " + GameManager.Instance.juniperBerryCost.ToString();

        if (GameManager.Instance.juniperBerryAmt < GameManager.Instance.juniperBerryCost) {
            beastResistUpgrade.interactable = false;
        }
    }

    public void UpgradeBeastResist() {

        boar.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        fox.GetComponent<HurtPlayer>().damageAmt -= 0.1f;
        wolf.GetComponent<HurtPlayer>().damageAmt -= 0.1f;

        GameManager.Instance.juniperBerryAmt -= GameManager.Instance.juniperBerryCost;
        GameManager.Instance.juniperBerryCost += 3;
        juniperBerryText.text = "x " + GameManager.Instance.juniperBerryCost.ToString();
        upgradeSound.Play();
        beastResistUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
