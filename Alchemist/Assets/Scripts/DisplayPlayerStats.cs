using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerStats : MonoBehaviour
{
    private int healthValue;
    private int luckValue;
    private int strengthValue;
    private int peaceValue;
    private int protectionValue;
    private int alchemyValue;

    [SerializeField] private Text healthCount;
    [SerializeField] private Text luckCount;
    [SerializeField] private Text strengthCount;
    [SerializeField] private Text peaceCount;
    [SerializeField] private Text protectionCount;
    [SerializeField] private Text alchemyCount;

    public GameObject GameManager;

    public void ShowPlayerStats() {

        healthValue = GameManager.GetComponent<GameManager>().playerHealth;
        luckValue = GameManager.GetComponent<GameManager>().playerLuck;
        strengthValue = GameManager.GetComponent<GameManager>().playerStrength;
        peaceValue = GameManager.GetComponent<GameManager>().playerPeace;
        protectionValue = GameManager.GetComponent<GameManager>().playerProtection;
        alchemyValue = GameManager.GetComponent<GameManager>().playerAlchemy;

        healthCount.text = healthValue.ToString();
        luckCount.text = luckValue.ToString();
        strengthCount.text = strengthValue.ToString();
        peaceCount.text = peaceValue.ToString();
        protectionCount.text = protectionValue.ToString();
        alchemyCount.text = alchemyValue.ToString();
    }
}
