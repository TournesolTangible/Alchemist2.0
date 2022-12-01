using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointShop : MonoBehaviour
{

    [SerializeField] private GameObject checkpointCanvas;

   // All upgrade buttons are prefabs
    [SerializeField] private GameObject HealthButton;
    [SerializeField] private GameObject AlchemyButton;
    [SerializeField] private GameObject LuckButton;
    [SerializeField] private GameObject StrengthButton;
    [SerializeField] private GameObject PeaceButton;
    [SerializeField] private GameObject ProtectionButton;
    [SerializeField] private GameObject HealthRestoreButton;
    [SerializeField] private GameObject FireballButton;
    [SerializeField] private GameObject AtkRangeButton;
    [SerializeField] private GameObject AtkSpeedButton;
    [SerializeField] private GameObject DblJumpButton;
    [SerializeField] private GameObject JumpHeightButton;
    [SerializeField] private GameObject StickButton;
    [SerializeField] private GameObject SwordButton;
    [SerializeField] private GameObject ResistFlyingButton;
    [SerializeField] private GameObject ResistFaeButton;
    [SerializeField] private GameObject ResistCreepyButton;
    [SerializeField] private GameObject ResistBeastButton;

    // slots for instantiating buttons
    public GameObject slotOne;
    public GameObject slotTwo;
    public GameObject slotThree;
    public GameObject playerStats;
    public GameObject collectibleStats;

    private int alchemyValue;
    public GameObject GameManager;

    public void OpenCheckpointShop() {

        Time.timeScale = 0f;
        if (!checkpointCanvas.activeSelf) { // if active, pressing C multiple times won't recycle the buttons
            checkpointCanvas.SetActive(true);
            slotOne.SetActive(true);
            slotTwo.SetActive(true);
            slotThree.SetActive(true);
            CreateRandomButtons();
            playerStats.GetComponent<DisplayPlayerStats>().ShowPlayerStats();
            collectibleStats.GetComponent<DisplayCollectibles>().ShowCollectibleAmounts();
        }
    }

    public void CloseCheckpointShop() {

        Time.timeScale = 1.0f;
        if (checkpointCanvas.activeSelf) {
            checkpointCanvas.SetActive(false);
            Destroy(slotOne.transform.GetChild(0).gameObject);
            slotOne.SetActive(false);
            Destroy(slotTwo.transform.GetChild(0).gameObject);
            slotTwo.SetActive(false);
            Destroy(slotThree.transform.GetChild(0).gameObject);
            slotThree.SetActive(false);
        }
    }
    
    public void CreateRandomButtons() 
    {
        List<GameObject> options = new List<GameObject>();
        
        options.Add(AlchemyButton); 
        options.Add(HealthButton);
        options.Add(LuckButton);
        options.Add(StrengthButton);
        options.Add(PeaceButton);
        options.Add(ProtectionButton);
        options.Add(StickButton);
        options.Add(HealthRestoreButton);

        // Options below here only unlocked one at a time 
        // once the Alchemy stat increases

        options.Add(AtkRangeButton);
        options.Add(AtkSpeedButton);
        options.Add(FireballButton); // once unlocked, switch to upgrade
        options.Add(SwordButton); // once unlocked, switch to upgrade
        options.Add(DblJumpButton); // once unlocked, destroy
        options.Add(JumpHeightButton); // needs cap
        options.Add(ResistFlyingButton);
        options.Add(ResistFaeButton);
        options.Add(ResistCreepyButton);
        options.Add(ResistBeastButton);

        alchemyValue = GameManager.GetComponent<GameManager>().playerAlchemy;

        // once all potions are unlocked, destroy Alchemy button
        if (alchemyValue == 18) {
            options.RemoveAt(0);
            alchemyValue -= 1;
        }

        // TODO: Remove Health Upgrade after health points reaches 10

        var num = Random.Range(0, alchemyValue);
        GameObject firstOption = Instantiate(options[num]) as GameObject;
        firstOption.transform.SetParent(slotOne.transform, false);
        options.RemoveAt(num); // remove chosen button so it does not potentially repeat

        num = Random.Range(0, alchemyValue-1);
        GameObject secondOption = Instantiate(options[num]) as GameObject;
        secondOption.transform.SetParent(slotTwo.transform, false);
        options.RemoveAt(num); // remove chosen button so it does not potentially repeat

        num = Random.Range(0, alchemyValue-2);
        GameObject thirdOption = Instantiate(options[num]) as GameObject;
        thirdOption.transform.SetParent(slotThree.transform, false);
        options.RemoveAt(num); 
    }
}
