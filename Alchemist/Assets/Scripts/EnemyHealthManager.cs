using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
   [SerializeField] private float enemyMaxHealth = 3.0f;
   private float enemyCurrentHealth;

   [SerializeField] private GameObject collectable;
   [SerializeField] private GameObject heart;

   // Reference to GameManager to moderate drop amount (stats)
   private static GameObject GameManager;

   void Awake() {
    GameManager = GameObject.Find("GameManager");
   }

   void Start() {
    enemyCurrentHealth = enemyMaxHealth;
   }

   void Update() {
    if (enemyCurrentHealth <= 0) {
        GameManager.GetComponent<GameManager>()._EnemySFX.Play();
        Destroy(this.gameObject);
        int random_number = Random.Range(0,10); // ganerates a random number between 1 to 10
        random_number += GameManager.GetComponent<GameManager>().playerLuck; // Add player luck to 'random_number'
        if (random_number >= 10) { // if roll is >= 10 get 3 collectables
            Instantiate(collectable, transform.position, new Quaternion(0,0,0,0));
        }
        if (7 < random_number) { // if roll is greater than 7 get 2 collectables
            Instantiate(collectable, transform.position, new Quaternion(0,0,0,0));
        }
        if (4 < random_number) { // if roll is greater than 4 get 1 collectable
            Instantiate(collectable, transform.position, new Quaternion(0,0,0,0));
        } // if roll is 4 or less get nothing
        
        // Small chance of heart drop
        int random_number_two = Random.Range(0,5);
        if (random_number_two >= 4) {
            Instantiate(heart, transform.position, new Quaternion(0,0,0,0));
        }
    }
   }

   // take damage
   public void TakeDamage(float damage) {
    enemyCurrentHealth -= damage;
    GameManager.GetComponent<GameManager>().countdownCanvas.GetComponent<CheckpointTimer>().ReduceCountdown();
   }

}
