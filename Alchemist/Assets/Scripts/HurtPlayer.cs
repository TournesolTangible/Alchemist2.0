using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] private float _damageTime;        // Time at which the enemy can do damage again
    [SerializeField] private float _damageRate = 2.0f; // Time between refraction periods (between attacks)
    [SerializeField] public float damageAmt = 1;
    
    void OnTriggerStay2D(Collider2D other) {

        if (other.transform.tag == "Player" && other is CapsuleCollider2D && Time.time > _damageTime) {
            other.transform.GetComponent<PlayerStats>().TakeDamage(damageAmt);
            _damageTime = Time.time + _damageRate;
        }
    }



            


}
