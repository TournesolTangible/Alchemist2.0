using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckOnClick : MonoBehaviour
{
    [SerializeField] private Button luckUpgrade;
    [SerializeField] private Text foxTailText;

    void Start() {

        if (GameManager.Instance.foxTailAmt < GameManager.Instance.foxTailCost) {
            luckUpgrade.interactable = false;
        }
    }

    public void UpgradeLuck() {

        GameManager.Instance.playerLuck += 2;
        GameManager.Instance.foxTailAmt -= GameManager.Instance.foxTailCost;
        GameManager.Instance.foxTailCost += 3;
        foxTailText.text = "x " + GameManager.Instance.foxTailCost.ToString();
        luckUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
