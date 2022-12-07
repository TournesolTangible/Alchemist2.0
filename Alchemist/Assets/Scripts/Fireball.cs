using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1.0f;
    [SerializeField] private float moveSpeed = .5f;
    [SerializeField] private float damage = 0f;
    public ParticleSystem PSP;
    private ParticleSystem CPS;

    private Vector2 _Direction;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
        CPS = Instantiate(PSP, this.transform.position, Quaternion.identity);
        CPS.Play();
        Destroy(CPS, lifeTime);
    }

    void Update()
    {
        CPS.transform.position = this.transform.position;
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

    public void SetDamage(float dmg) {
        damage += dmg;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Enemy") {
            other.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            CPS.Stop();
            Destroy(this.gameObject);
        }
    }



}
