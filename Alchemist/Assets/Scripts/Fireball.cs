using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1.0f;
    [SerializeField] private float moveSpeed = .5f;
    [SerializeField] public float damage = 3f;
    public ParticleSystem PSP;
    private ParticleSystem CPS;

    private Vector2 _Direction;
    private GameObject _Target;

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

        if( _Target == null ) {
            this.SelfDestruct();
        } else {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_Target.transform.position.x, _Target.transform.position.y), step);

        }



    }

    public void SetTarget(GameObject target) {
        if (target) {
            _Target = target;
        }
    }

    public void SetSpeed(float spd) {
        moveSpeed = spd;
    }

    public void SetDamage(float dmg) {
        damage += dmg;
    }

    public void SelfDestruct() {
        GameObject.Destroy(this);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Enemy") {
            other.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            CPS.Stop();
            Destroy(this.gameObject);
        }
    }



}
