using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{

    private float damage = 1.0f;
    private float damageRate = 1.0f;
    private float damageTime;
    private bool facingDirection;


    public Transform attackPosition;
    public Vector2 attackSize = new Vector2(5,10);
    public int maxObjectsHit = 5;
    public RaycastHit2D[] objectsHit;
    public LayerMask selectObjectsToHit;

 
    void Start () {
        objectsHit = new RaycastHit2D[maxObjectsHit];

        InvokeRepeating("AttackBase", 0f, 1.0f);
    }
 
    void AttackBase () {


        // what did we hit
        if (this.gameObject.GetComponent<PlayerMovement>().is_facing_right) {
            Debug.Log("Hitting Right");
            objectsHit = Physics2D.BoxCastAll(attackPosition.position, attackSize, 0, new Vector2(1,0), 5);
        }
        if (!this.gameObject.GetComponent<PlayerMovement>().is_facing_right) {
            Debug.Log("Hitting Left");
            objectsHit = Physics2D.BoxCastAll(attackPosition.position, attackSize, 0, new Vector2(-1,0), 5);
        }
        
        // make sure we hit more than one gameObject
        if(objectsHit.Length > 0) {

            // iterate through objects
            foreach(RaycastHit2D hit in objectsHit) {

                // if object is an enemy
                if (hit.transform.CompareTag("Enemy")) {
                    Debug.Log("hitting enemy");
                    hit.transform.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                }
            }
        }
        
    }
    
}

