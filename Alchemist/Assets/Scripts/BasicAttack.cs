using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicAttack : MonoBehaviour
{

    public float damage = 1.0f;
    public float attackRangeX;
    public float attackRangeY;
    public float damageRate = 0.8f;

    private static GameObject _GameManager;
    private int _StrengthStat;

    private bool mainScreen;
    private bool cr_running;

    public Transform attackPosition;
    public LayerMask layerToHit;
    private Collider2D[] enemiesToDamage;

    public GameObject sprite;

    void Awake() {
        _GameManager = GameObject.Find("GameManager");
        _StrengthStat = _GameManager.GetComponent<GameManager>().playerStrength;
    }
 
    void Start () {

        InvokeRepeating("AttackBase", 0f, damageRate);
        
        // checks for main screen
        // if (SceneManager.GetActiveScene().buildIndex == 0) {
        //     mainScreen = true;
        // } else {
        //     mainScreen = false;
        //     InvokeRepeating("AttackBase", 0f, damageRate);
        // }
    }

    void Update() {
        _StrengthStat = _GameManager.GetComponent<GameManager>().playerStrength;
    }
 
    void AttackBase () {

        cr_running = true;

        if (this.gameObject.GetComponent<PlayerMovement>().is_facing_right) {
            // what did we hit (position, size(x,y), angle, layer)
            enemiesToDamage = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(attackRangeX, attackRangeY), 0, layerToHit);
            GameObject swipe = (GameObject) Instantiate(sprite, attackPosition.position, Quaternion.identity);
            Destroy (swipe, 0.1f);
        }
        if (!this.gameObject.GetComponent<PlayerMovement>().is_facing_right) {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1)); // gotta do this because of how we animated
            enemiesToDamage = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(attackRangeX, attackRangeY), 0, layerToHit);
            GameObject swipe = (GameObject) Instantiate(sprite, new Vector3(attackPosition.position.x, attackPosition.position.y, 1), Quaternion.Euler(0,180,0));
            Destroy (swipe, 0.1f);
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1)); // and gotta switch back
        }

        for (int i = 0; i < enemiesToDamage.Length; i++) {
            // damage enemies
            if (enemiesToDamage[i].transform.tag == "Enemy") {
                Debug.Log("Hitting enemy");
                // ADDED: strength added to received damage
                enemiesToDamage[i].transform.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage + _StrengthStat);
            }
        }
    }

    // wireframe for hitbox
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
    
}

