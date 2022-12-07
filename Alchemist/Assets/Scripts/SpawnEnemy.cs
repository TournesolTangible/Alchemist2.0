using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemies;

    // Reference to GameManager for difficulty modifications
    private static GameObject _GameManager;

    // Difficulty mod
    private int _PeaceStat;
    private int _Roll;
    private int numberOfEnemies;


    void Awake() {
        _GameManager = GameObject.Find("GameManager");
        _PeaceStat = _GameManager.GetComponent<GameManager>().playerPeace;

    }

    void Start() {

        _Roll = Random.Range(0, 20);

        if (_Roll < 2) {
            // worst
            numberOfEnemies = 4 - _PeaceStat;
        }
        else if (_Roll > 10) {
            // bad roll
            numberOfEnemies = 3 - _PeaceStat;
        }
        else if (_Roll > 15) {
            // good roll
            numberOfEnemies = 2 - _PeaceStat;
        }
        else if (_Roll > 19) {
            // best roll
            numberOfEnemies = 1 - _PeaceStat;
        }

        for ( int i = 0; i < numberOfEnemies; i++ ) { // spawn an enemy for (random - peace) counts
            Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, transform.rotation);
            transform.position = new Vector2(transform.position.x + i*5, transform.position.y - i*5);
        }
        
    }
}
