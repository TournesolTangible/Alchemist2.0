using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public GameObject Player;

    public GameObject checkpointShop;
    public GameObject pauseMenu;

    [SerializeField] private AudioSource _DeathRinger;

    [SerializeField] public float playerHealth = 5.0f;
    [SerializeField] public float playerStrength = 5.0f; // adjust
    [SerializeField] public float playerLuck = 5.0f; // adjust
    [SerializeField] public float playerPeace = 5.0f; // adjust
    [SerializeField] public float playerProtection = 5.0f; // adjust
    [SerializeField] public float playerAlchemy = 8.0f;

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
