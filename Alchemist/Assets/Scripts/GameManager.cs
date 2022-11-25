using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public GameObject Player;
    private GameObject Spawn;

    public GameObject checkpointShop;
    public GameObject displayPlayerStats;
    public GameObject healthBar;
    public GameObject healthBarController;
    public GameObject pauseMenu;

    [SerializeField] private AudioSource _DeathRinger;

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

    void Start() {
        Spawn = GameObject.Find("Spawn");
        GameObject.Destroy(Player);
        Player = FindPlayerInstance();
        SpawnPlayer();
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
            print("No Player Instance found, original Player returned");
        }
        return Player;

    }

}
