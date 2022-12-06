using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireballs : MonoBehaviour
{

    [SerializeField] private GameObject _FireballPrefab;
    [SerializeField] private AudioSource _FireballSFX;
    [SerializeField] private float _FireballForce = 0.01f;
    [SerializeField] private float _FireballRate = .5f;
    [SerializeField] private float _FireballTimer = 2f;

    private List<Collider2D> _Enemies = new List<Collider2D>();
    private GameObject LastEnemyAdded;

    private Vector2 target;
    private bool collidingWithEnemy;
    
    [SerializeField] private bool upgraded;


    void Update()
    {
        if (collidingWithEnemy) {
            Shoot();
        }

        foreach (Collider2D c in _Enemies) {
            print(c);
        }
    }

    void Shoot() {

        // If fireballs have been upgraded ...
        if (upgraded) {
            if(Time.time > _FireballTimer) {
                _FireballSFX.Play();
                GameObject fireball = Instantiate(_FireballPrefab, transform.position, Quaternion.identity);
                fireball.GetComponent<Fireball>().SetSpeed(_FireballForce);
                fireball.GetComponent<Fireball>().SetTarget(target);
                
                _FireballTimer = Time.time + _FireballRate; // Set your fire rate cooldown
            }
        }
    }

    void Upgrade() {
        upgraded = true;
    }


    void OnTriggerStay2D(Collider2D other) {

        if (other.transform.tag == "Enemy") {
            collidingWithEnemy = true;

            if (! (_Enemies.Contains(other))) {
                _Enemies.Add(other);
                LastEnemyAdded = other.gameObject;
            }

            target = new Vector2(other.transform.position.x, other.transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.transform.tag == "Enemy") {
            _Enemies.Add(other);
            GameObject LastEnemyAdded = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.transform.tag == "Enemy") {
            if (_Enemies.Contains(other)) {
                _Enemies.Remove(_Enemies[_Enemies.IndexOf(other)]);
            }

        }
    }

}