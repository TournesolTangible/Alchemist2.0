using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
   private float enemyMaxHealth = 3.0f;
   private float enemyCurrentHealth;

   [SerializeField] private GameObject collectable;

   void Start() {
    enemyCurrentHealth = enemyMaxHealth;
   }

   void Update() {
    if (enemyCurrentHealth <= 0) {
        Destroy(this.gameObject);
        int random_number = Random.Range(0,10); // ganerates a random number between 1 to 10
        if (10 == random_number) { // if roll is 10 get 3 collectables
            Instantiate(collectable, transform.position, new Quaternion(0,0,0,0));
        }
        if (7 < random_number) { // if roll is greater than 7 get 2 collectables
            Instantiate(collectable, transform.position, new Quaternion(0,0,0,0));
        }
        if (4 < random_number) { // if roll is greater than 4 get 1 collectable
            Instantiate(collectable, transform.position, new Quaternion(0,0,0,0));
        }
        // if roll is 4 or less get nothing
    }
   }

   // take damage
   public void TakeDamage(float damage) {
    enemyCurrentHealth -= damage;
   }

}
