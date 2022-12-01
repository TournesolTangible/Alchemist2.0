using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckOnClick : MonoBehaviour
{
    [SerializeField] private Button luckUpgrade;
    [SerializeField] private Text foxTailText;
    private int foxTailCost = 1;

    void Start() {

        if (GameManager.Instance.foxTailAmt < foxTailCost) {
            luckUpgrade.interactable = false;
        }
    }

    public void UpgradeLuck() {

        GameManager.Instance.playerLuck += 2;
        GameManager.Instance.foxTailAmt -= foxTailCost;
        foxTailCost += 3;
        foxTailText.text = "x " + foxTailCost.ToString();
        luckUpgrade.interactable = false;
        GameManager.Instance.displayPlayerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
    }
}
