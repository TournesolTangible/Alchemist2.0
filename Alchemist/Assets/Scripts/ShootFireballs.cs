using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireballs : MonoBehaviour
{

    [SerializeField] private GameObject _FireballPrefab;
    [SerializeField] private float _FireballForce = 0.01f;
    [SerializeField] private float _FireballRate = .5f;
    [SerializeField] private float _FireballTimer = 2f;

    private Vector2 target;
    private bool collidingWithEnemy;


    void Update()
    {
        if (collidingWithEnemy) {
            Shoot();
        }
    }

    void Shoot() {

        if(Time.time > _FireballTimer) {

            GameObject fireball = Instantiate(_FireballPrefab, transform.position, Quaternion.identity); //Quaternion.Euler(30, 0, 0));
            fireball.GetComponent<Fireball>().SetSpeed(_FireballForce);
            fireball.GetComponent<Fireball>().SetTarget(target);
            
            _FireballTimer = Time.time + _FireballRate; // Set your fire rate cooldown
        }

    }


    void OnTriggerStay2D(Collider2D other) {

        if (other.transform.tag == "Enemy") {
            collidingWithEnemy = true;
            target = new Vector2(other.transform.position.x, other.transform.position.y);
            target = target*5;
        }
    }

    // void OnTriggerExit2D(Collider2D other) {
    //     if (other.transform.tag == "Enemy") {
    //         collidingWithEnemy = false;
    //     }
    // }


}
