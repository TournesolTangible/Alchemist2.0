using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemyOnClick : MonoBehaviour
{
    [SerializeField] private Button alchemyUpgrade;

    public void UpgradeAlchemy() {

        GameManager.Instance.playerAlchemy += 1;
        alchemyUpgrade.interactable = false;
    }
}
