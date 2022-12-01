using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordOnClick : MonoBehaviour
{
    [SerializeField] private Button swordUpgrade;
    [SerializeField] private Text devilEyeText;

    void Start() {

        devilEyeText.text = "x " + GameManager.Instance.devilEyeCost.ToString();

        if (GameManager.Instance.devilEyeAmt < GameManager.Instance.devilEyeCost) {
            swordUpgrade.interactable = false;
        }
    }

    public void UpgradeSword() {

        // TODO: unlock sword, then change to upgrade damage

        GameManager.Instance.playerAlchemy += 1;
        GameManager.Instance.devilEyeAmt -= GameManager.Instance.devilEyeCost;
        GameManager.Instance.devilEyeCost += 3;
        devilEyeText.text = "x " + GameManager.Instance.devilEyeCost.ToString();
        swordUpgrade.interactable = false;
    }
}
