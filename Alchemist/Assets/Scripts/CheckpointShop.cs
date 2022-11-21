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
    [SerializeField] private GameObject FireballButton;
    [SerializeField] private GameObject AtkRangeButton;
    [SerializeField] private GameObject AtkSpeedButton;
    [SerializeField] private GameObject DblJumpButton;
    [SerializeField] private GameObject JumpHeightButton;
    [SerializeField] private GameObject StickButton;
    [SerializeField] private GameObject SwordButton;
    [SerializeField] private GameObject ResistBatButton;
    [SerializeField] private GameObject ResistBirdButton;
    [SerializeField] private GameObject ResistCactusButton;
    [SerializeField] private GameObject ResistFaeButton;
    [SerializeField] private GameObject ResistGhostButton;
    [SerializeField] private GameObject ResistKangaButton;
    [SerializeField] private GameObject ResistRatButton;
    [SerializeField] private GameObject ResistSpiderButton;
    [SerializeField] private GameObject ResistWolfButton;

    // slots for instantiating buttons
    public GameObject slotOne;
    public GameObject slotTwo;
    public GameObject slotThree;

    public void OpenCheckpointShop() {

        Time.timeScale = 0f;
        if (!checkpointCanvas.activeSelf) { // if active, pressing C multiple times won't recycle the buttons
            checkpointCanvas.SetActive(true);
            slotOne.SetActive(true);
            slotTwo.SetActive(true);
            slotThree.SetActive(true);
            CreateRandomButtons();
        }
    }

    public void CloseCheckpointShop() {

        Time.timeScale = 1.0f;
        checkpointCanvas.SetActive(false);
        Destroy(slotOne.transform.GetChild(0).gameObject);
        slotOne.SetActive(false);
        Destroy(slotTwo.transform.GetChild(0).gameObject);
        slotTwo.SetActive(false);
        Destroy(slotThree.transform.GetChild(0).gameObject);
        slotThree.SetActive(false);
    }

    
    public void CreateRandomButtons() 
    {
        List<GameObject> options = new List<GameObject>();

        options.Add(HealthButton);
        options.Add(LuckButton);
        options.Add(StrengthButton);
        options.Add(PeaceButton);
        options.Add(ProtectionButton);
        options.Add(AlchemyButton); // needs counter
        options.Add(FireballButton); // once unlocked, switch to upgrade
        options.Add(StickButton);

        // Options below here should only be unlocked one at a time 
        // once the Alchemy stat increases. Once all potions are 
        // unlocked, destroy Alchemy button

        options.Add(AtkRangeButton);
        options.Add(AtkSpeedButton);
        options.Add(SwordButton); // once unlocked, switch to upgrade
        options.Add(DblJumpButton); // once unlocked, destroy
        options.Add(JumpHeightButton); // needs cap
        options.Add(ResistBatButton);
        options.Add(ResistBirdButton);
        options.Add(ResistCactusButton);
        options.Add(ResistFaeButton);
        options.Add(ResistGhostButton);
        options.Add(ResistKangaButton);
        options.Add(ResistRatButton);
        options.Add(ResistSpiderButton);
        options.Add(ResistWolfButton);

        var num = Random.Range(0, options.Count);
        GameObject firstOption = Instantiate(options[num]) as GameObject;
        firstOption.transform.SetParent(slotOne.transform, false);
        options.RemoveAt(num); // remove chosen button so it does not potentially repeat

        num = Random.Range(0, options.Count);
        GameObject secondOption = Instantiate(options[num]) as GameObject;
        secondOption.transform.SetParent(slotTwo.transform, false);
        options.RemoveAt(num); // remove chosen button so it does not potentially repeat

        num = Random.Range(0, options.Count);
        GameObject thirdOption = Instantiate(options[num]) as GameObject;
        thirdOption.transform.SetParent(slotThree.transform, false);
        options.RemoveAt(num); 
    }

    public void UpgradeAlchemy() {

        
    }
}
