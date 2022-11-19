using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeRandomOptions : MonoBehaviour
{

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
    //[SerializeField] private GameObject StickButton;
    //[SerializeField] private GameObject SwordButton;
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
    public Canvas slotOne;
    public Canvas slotTwo;
    public Canvas slotThree;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> options = new List<GameObject>();

        options.Add(HealthButton);
        options.Add(LuckButton);
        options.Add(StrengthButton);
        options.Add(PeaceButton);
        options.Add(ProtectionButton);
        options.Add(AlchemyButton); // needs counter

        // Options below here should only be unlocked one at a time 
        // once the Alchemy stat increases. Once all potions are 
        // unlocked, destroy Alchemy button

        options.Add(FireballButton); // once unlocked, destroy
        options.Add(AtkRangeButton);
        options.Add(AtkSpeedButton);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}