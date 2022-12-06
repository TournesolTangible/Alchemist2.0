using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1.0f;
    [SerializeField] private float moveSpeed = .5f;
    [SerializeField] private float damage = 3.0f;

    private Vector2 _Direction;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile() {
        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _Direction, step);


    }

    public void SetTarget(Vector2 target) {
        _Direction = target;
    }

    public void SetSpeed(float spd) {
        moveSpeed = spd;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Enemy") {
            other.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }



}
