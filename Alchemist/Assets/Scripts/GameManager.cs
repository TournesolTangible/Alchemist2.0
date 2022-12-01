using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public GameObject Player;

    public GameObject checkpointShop;
    public GameObject displayPlayerStats;
    public GameObject displayCollectibles;
    public GameObject healthBar;
    public GameObject healthBarController;
    public GameObject pauseMenu;

    [SerializeField] private AudioSource _DeathRinger;

    // reference stats for player
    public int playerHealth = 3;
    public int currentHealth = 3;
    public int playerStrength = 5; // adjust
    public int playerLuck = 5; // adjust
    public int playerPeace = 0; 
    public int playerProtection = 5; // adjust
    public int playerAlchemy = 8;
    public int stickDamage = 5; // adjust

    // reference stats for collectibles
    public int acornAmt = 0;
    public int batWingAmt = 0;
    public int devilEyeAmt = 0;
    public int emuEggAmt = 0;
    public int fairyBellsAmt = 0;
    public int featherAmt = 0;
    public int foxTailAmt = 0;
    public int goatHoofAmt = 0;
    public int graveyardDustAmt = 0;
    public int juniperBerryAmt = 0;
    public int lavenderAmt = 0;
    public int mushroomAmt = 0;
    public int quartzAmt = 0;
    public int sageAmt = 0;
    public int snakeHeadAmt = 0;
    public int spiderSilkAmt = 0;
    public int swineSnoutAmt = 0;
    public int vervainAmt = 0;
    public int wolfFootAmt = 0;

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

        if (Input.GetKey(KeyCode.V)) {
            checkpointShop.GetComponent<CheckpointShop>().CloseCheckpointShop();
        }

        if (Input.GetKey("escape")) {
            pauseMenu.GetComponent<PauseMenu>().OpenPauseMenu();
        }

        // if player unalive, switch to Main Scene after death animation
        if (Player.GetComponent<PlayerStats>().ReturnHealth() == 0) {

            if (Player.GetComponent<UnalivePlayer>().isAlive()) {
                PlayDeathRinger();
            }

            Player.GetComponent<UnalivePlayer>().Died();

            if ( Player.transform.localScale.x < 0.01) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
            }

        }
    }

    public void PlayDeathRinger() {
        _DeathRinger.Play();
    }

    }
