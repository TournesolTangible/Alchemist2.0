using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCollectibles : MonoBehaviour
{
    private int acornValue;
    private int batWingValue;
    private int devilEyeValue;
    private int fairyBellsValue;
    private int featherValue;
    private int foxTailValue;
    private int goatHoofValue;
    private int graveyardDustValue;
    private int juniperBerryValue;
    private int lavenderValue;
    private int mushroomValue;
    private int quartzValue;
    private int sageValue;
    private int snakeHeadValue;
    private int spiderSilkValue;
    private int swineSnoutValue;
    private int vervainValue;
    private int wolfFootValue; 

    [SerializeField] private Text acornCount;
    [SerializeField] private Text batWingCount;
    [SerializeField] private Text devilEyeCount;
    [SerializeField] private Text fairyBellsCount;
    [SerializeField] private Text featherCount;
    [SerializeField] private Text foxTailCount;
    [SerializeField] private Text goatHoofCount;
    [SerializeField] private Text graveyardDustCount;
    [SerializeField] private Text juniperBerryCount;
    [SerializeField] private Text lavenderCount;
    [SerializeField] private Text mushroomCount;
    [SerializeField] private Text quartzCount;
    [SerializeField] private Text sageCount;
    [SerializeField] private Text snakeHeadCount;
    [SerializeField] private Text spiderSilkCount;
    [SerializeField] private Text swineSnoutCount;
    [SerializeField] private Text vervainCount;
    [SerializeField] private Text wolfFootCount;

    public GameObject GameManager;

    public void ShowCollectibleAmounts() {

        acornValue = GameManager.GetComponent<GameManager>().acornAmt;
        batWingValue = GameManager.GetComponent<GameManager>().batWingAmt;
        devilEyeValue = GameManager.GetComponent<GameManager>().devilEyeAmt;
        fairyBellsValue = GameManager.GetComponent<GameManager>().fairyBellsAmt;
        featherValue = GameManager.GetComponent<GameManager>().featherAmt;
        foxTailValue = GameManager.GetComponent<GameManager>().foxTailAmt;
        goatHoofValue = GameManager.GetComponent<GameManager>().goatHoofAmt;
        graveyardDustValue = GameManager.GetComponent<GameManager>().graveyardDustAmt;
        juniperBerryValue = GameManager.GetComponent<GameManager>().juniperBerryAmt;
        lavenderValue = GameManager.GetComponent<GameManager>().lavenderAmt;
        mushroomValue = GameManager.GetComponent<GameManager>().mushroomAmt;
        quartzValue = GameManager.GetComponent<GameManager>().quartzAmt;
        sageValue = GameManager.GetComponent<GameManager>().sageAmt;
        snakeHeadValue = GameManager.GetComponent<GameManager>().snakeHeadAmt;
        spiderSilkValue = GameManager.GetComponent<GameManager>().spiderSilkAmt;
        swineSnoutValue = GameManager.GetComponent<GameManager>().swineSnoutAmt;
        vervainValue = GameManager.GetComponent<GameManager>().vervainAmt;
        wolfFootValue = GameManager.GetComponent<GameManager>().wolfFootAmt;

        acornCount.text = "x " + acornValue.ToString();
        batWingCount.text = "x " + batWingValue.ToString();
        devilEyeCount.text = "x " + devilEyeValue.ToString();
        fairyBellsCount.text = "x " + fairyBellsValue.ToString();
        featherCount.text = "x " + featherValue.ToString();
        foxTailCount.text = "x " + foxTailValue.ToString();
        goatHoofCount.text = "x " + goatHoofValue.ToString();
        graveyardDustCount.text = "x " + graveyardDustValue.ToString();
        juniperBerryCount.text = "x " + juniperBerryValue.ToString();
        lavenderCount.text = "x " + lavenderValue.ToString();
        mushroomCount.text = "x " + mushroomValue.ToString();
        quartzCount.text = "x " + quartzValue.ToString();
        sageCount.text = "x " + sageValue.ToString();
        snakeHeadCount.text = "x " + snakeHeadValue.ToString();
        spiderSilkCount.text = "x " + spiderSilkValue.ToString();
        swineSnoutCount.text = "x " + swineSnoutValue.ToString();
        vervainCount.text = "x " + vervainValue.ToString();
        wolfFootCount.text = "x " + wolfFootValue.ToString();
    }
}
