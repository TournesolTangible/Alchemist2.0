using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public GameObject Player;

    public GameObject checkpointShop;
    public GameObject pauseMenu;

    [SerializeField] public int playerHealth = 3;
    [SerializeField] public int currentHealth = 3;
    [SerializeField] public int playerStrength = 5; // adjust
    [SerializeField] public int playerLuck = 5; // adjust
    [SerializeField] public int playerPeace = 5; // adjust
    [SerializeField] public int playerProtection = 5; // adjust
    [SerializeField] public int playerAlchemy = 8;

    [SerializeField] public int stickDamage = 5; // adjust

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

        else if (Instance != this){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C)) {
            checkpointShop.GetComponent<CheckpointShop>().OpenCheckpointShop();
        }

        if (Input.GetKey("escape")) {
            pauseMenu.GetComponent<PauseMenu>().OpenPauseMenu();
        }    
    }

}
