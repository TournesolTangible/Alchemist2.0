using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballOnClick : MonoBehaviour
{
    [SerializeField] private Button fireballUpgrade;
    [SerializeField] private Text vervainText;
    [SerializeField] private Text fireballTitle;
    [SerializeField] private Text fireballDesc;
    public GameObject fireball;
    [SerializeField] private AudioSource upgradeSound;

    void Start() {

        if (GameManager.Instance.vervainCost > 1) {
            fireballTitle.text = "FIREBALL UP";
            fireballDesc.text = "Increase damage dealt\nby fireball";
        }
        vervainText.text = "x " + GameManager.Instance.vervainCost.ToString();

        if (GameManager.Instance.vervainAmt < GameManager.Instance.vervainCost) {
            fireballUpgrade.interactable = false;
        }
    }

    public void UpgradeFireball() {

        if (GameManager.Instance.vervainCost == 1) {
        // ACTIVATES FIREBALL
        GameManager.Instance.Player.GetComponent<ShootFireballs>().Upgrade();
        }
        else {
            fireball.GetComponent<Fireball>().damage += 1;
        }

        GameManager.Instance.vervainAmt -= GameManager.Instance.vervainCost;
        GameManager.Instance.vervainCost += 3;
        vervainText.text = "x " + GameManager.Instance.vervainCost.ToString();
        upgradeSound.Play();
        fireballUpgrade.interactable = false;
        GameManager.Instance.countdownCanvas.GetComponent<CheckpointTimer>().IncreaseCountdown();
        GameManager.Instance.displayCollectibles.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
    }
}
