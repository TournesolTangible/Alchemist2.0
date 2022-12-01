using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballOnClick : MonoBehaviour
{
    [SerializeField] private Button fireballUpgrade;
    [SerializeField] private Text vervainText;

    void Start() {

        vervainText.text = "x " + GameManager.Instance.vervainCost.ToString();

        if (GameManager.Instance.vervainAmt < GameManager.Instance.vervainCost) {
            fireballUpgrade.interactable = false;
        }
    }

    public void UpgradeFireball() {

        // TODO: activate fireball, then change to upgrade damage

        GameManager.Instance.vervainAmt -= GameManager.Instance.vervainCost;
        GameManager.Instance.vervainCost += 3;
        vervainText.text = "x " + GameManager.Instance.vervainCost.ToString();
        fireballUpgrade.interactable = false;
    }
}
