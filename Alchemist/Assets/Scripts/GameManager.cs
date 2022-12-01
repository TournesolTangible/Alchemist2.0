using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public GameObject Player;
    [SerializeField] private GameObject _PlayerPrefabDefault;
    private GameObject Spawn;

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
    public int playerLuck = 0;
    public int playerPeace = 0; 
    public int playerProtection = 5; // adjust
    public int playerAlchemy = 8;
    public int stickDamage = 5; // adjust

    // reference stats for collectibles
    public int acornAmt = 0;
    public int acornCost = 1;

    public int batWingAmt = 0;
    public int batWingCost = 1;

    public int devilEyeAmt = 0;
    public int devilEyeCost = 1;

    public int fairyBellsAmt = 0;
    public int fairyBellsCost = 1;

    public int featherAmt = 0;
    public int featherCost = 1;

    public int foxTailAmt = 0;
    public int foxTailCost = 1;

    public int goatHoofAmt = 0;
    public int goatHoofCost = 1;

    public int graveyardDustAmt = 0;
    public int graveyardDustCost = 1;

    public int juniperBerryAmt = 0;
    public int juniperBerryCost = 1;

    public int lavenderAmt = 0;
    public int lavenderCost = 1;

    public int mushroomAmt = 0;
    public int mushroomCost = 1;

    public int quartzAmt = 0;
    public int quartzCost = 1;

    public int sageAmt = 0;
    public int sageCost = 1;

    public int snakeHeadAmt = 0;
    public int snakeHeadCost = 1;

    public int spiderSilkAmt = 0;
    public int spiderSilkCost = 1;

    public int swineSnoutAmt = 0;
    public int swineSnoutCost = 1;

    public int vervainAmt = 0;
    public int vervainCost = 1;

    public int wolfFootAmt = 0;
    public int wolfFootCost = 1;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

        else if (Instance != this){
            Destroy(gameObject);
        }

    }

    void Start() {
        Spawn = GameObject.Find("Spawn");
        GameObject.Destroy(Player);
        Player = FindPlayerInstance();
        SpawnPlayer();

        print(Camera.main.transform.position.z);
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
                GameObject.Destroy(Player);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
            }
        }

        healthBarController.GetComponent<HealthBarController>().UpdateHeartsHUD();
    }

    public void PlayDeathRinger() {
        _DeathRinger.Play();
    }

    private void SpawnPlayer() {
        Player.transform.position = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);

    }

    // Checks for each variant of the player, returns that clone type
    private GameObject FindPlayerInstance() {
        GameObject PlayerInstance = null;

        PlayerInstance = GameObject.Find("tan_hat_player");

        // If PlayerInstance null, checks for each other player instance type by name
        if (PlayerInstance == null) {
            PlayerInstance = GameObject.Find("tan_hat_player(Clone)");
        }
        if (PlayerInstance == null) {
            PlayerInstance = GameObject.Find("dark_hat_player(Clone)");
        }
        if (PlayerInstance == null) {
            PlayerInstance = GameObject.Find("pale_hat_player(Clone)");
        }
        if (PlayerInstance == null) {
            PlayerInstance = GameObject.Find("tan_hood_player(Clone)");
        }
        if (PlayerInstance == null) {
            PlayerInstance = GameObject.Find("dark_hood_player(Clone)");
        }
        if (PlayerInstance == null) {
            PlayerInstance = GameObject.Find("pale_hood_player(Clone)");
        }
    
        if (!(PlayerInstance == null)) {
            // Sets Player in GameManager to found PlayerInstance
            Player = PlayerInstance;
        }
        if (PlayerInstance == null) {
            Player = GameObject.Instantiate(_PlayerPrefabDefault);
        }
        return Player;

    }

}
