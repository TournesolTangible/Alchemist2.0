using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckOnClick : MonoBehaviour
{
    [SerializeField] private Button luckUpgrade;
    [SerializeField] private Text foxTailText;
    [SerializeField] private AudioSource upgradeSound;

    void Start() {

        foxTailText.text = "x " + GameManager.Instance.foxTailCost.ToString();

        if (GameManager.Instance.foxTailAmt < GameManager.Instance.foxTailCost) {
            luckUpgrade.interactable = false;
        }
    }

    public void UpgradeLuck() {

        GameManager.Instance.playerLuck += 1;
        GameManager.Instance.foxTailAmt -= GameManager.Instance.foxTailCost;
        GameManager.Instance.foxTailCost += 3;
        foxTailText.text = "x " + GameManager.Instance.foxTailCost.ToString();
        upgradeSound.Play();
        luckUpgrade.interactable = false;

        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
