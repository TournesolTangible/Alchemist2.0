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
    public GameObject countdownCanvas;

    [SerializeField] private AudioSource _GameplayMusic;
    [SerializeField] private AudioSource _DeathRinger;
    [SerializeField] public AudioSource _CollectibleSFX;

    // reference stats for player
    [HideInInspector] public int playerHealth = 3;
    [HideInInspector] public int currentHealth = 3;
    [HideInInspector] public int playerStrength = 5; // adjust
    [HideInInspector] public int playerLuck = 0;
    [HideInInspector] public int playerPeace = 0; 
    [HideInInspector] public int playerProtection = 5; // adjust
    [HideInInspector] public int playerAlchemy = 6;
    [HideInInspector] public int stickDamage = 5; // adjust

    // reference stats for collectibles
    [HideInInspector] public int acornAmt = 1;
    [HideInInspector] public int acornCost = 1;

    [HideInInspector] public int batWingAmt = 1;
    [HideInInspector] public int batWingCost = 1;

    [HideInInspector] public int devilEyeAmt = 1;
    [HideInInspector] public int devilEyeCost = 1;

    [HideInInspector] public int fairyBellsAmt = 1;
    [HideInInspector] public int fairyBellsCost = 1;

    [HideInInspector] public int featherAmt = 1;
    [HideInInspector] public int featherCost = 1;

    [HideInInspector] public int foxTailAmt = 1;
    [HideInInspector] public int foxTailCost = 1;

    [HideInInspector] public int goatHoofAmt = 1;
    [HideInInspector] public int goatHoofCost = 1;

    [HideInInspector] public int graveyardDustAmt = 1;
    [HideInInspector] public int graveyardDustCost = 1;

    [HideInInspector] public int juniperBerryAmt = 1;
    [HideInInspector] public int juniperBerryCost = 1;

    [HideInInspector] public int lavenderAmt = 1;
    [HideInInspector] public int lavenderCost = 1;

    [HideInInspector] public int mushroomAmt = 1;
    [HideInInspector] public int mushroomCost = 1;

    [HideInInspector] public int quartzAmt = 1;
    [HideInInspector] public int quartzCost = 1;

    [HideInInspector] public int sageAmt = 5;
    [HideInInspector] public int sageCost = 1;

    [HideInInspector] public int snakeHeadAmt = 1;
    [HideInInspector] public int snakeHeadCost = 1;

    [HideInInspector] public int spiderSilkAmt = 1;
    [HideInInspector] public int spiderSilkCost = 1;

    [HideInInspector] public int swineSnoutAmt = 1;
    [HideInInspector] public int swineSnoutCost = 1;

    [HideInInspector] public int vervainAmt = 1;
    [HideInInspector] public int vervainCost = 1;

    [HideInInspector] public int wolfFootAmt = 1;
    [HideInInspector] public int wolfFootCost = 1;

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

        _GameplayMusic.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C)) {
            checkpointShop.GetComponent<CheckpointShop>().CloseCheckpointShop();
        }

        if (Input.GetKey("escape")) {
            pauseMenu.GetComponent<PauseMenu>().OpenPauseMenu();
        }

        // if player unalive, switch to Main Scene after death animation
        if (Player.GetComponent<PlayerStats>().ReturnHealth() == 0) {

            if (Player.GetComponent<UnalivePlayer>().isAlive()) {
                _GameplayMusic.Stop();
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
            GameObject.Destroy(Player);
            Player = PlayerInstance;
        }
        if (PlayerInstance == null) {
            Player = GameObject.Instantiate(_PlayerPrefabDefault);
        }
        return Player;

    }

}
