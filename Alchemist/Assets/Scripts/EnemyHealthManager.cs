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
        Instantiate(collectable, transform.position, new Quaternion(0,0,0,0));
    }
   }

   // take damage
   public void TakeDamage(float damage) {
    enemyCurrentHealth -= damage;
   }

}
