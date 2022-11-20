using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject checkpointShop;
    public GameObject pauseMenu;

    [SerializeField] public float playerHealth = 5.0f;
    [SerializeField] public float playerStrength = 5.0f; // adjust
    [SerializeField] public float playerLuck = 5.0f; // adjust
    [SerializeField] public float playerPeace = 5.0f; // adjust
    [SerializeField] public float playerProtection = 5.0f; // adjust
    [SerializeField] public float playerAlchemy = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void Awake() {

        if (instance == null) {
            instance = this;
        }

        else if (instance != this) {
            Destroy(gameObject);
        }
    }
}
