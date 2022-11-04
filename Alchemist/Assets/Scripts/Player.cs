using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float move_speed = 6.0f;
    [SerializeField] private float jump_height = 15.0f;

    private Rigidbody2D rigid_body_2d;

    private void Start() {
        rigid_body_2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // running
        float direction_x = Input.GetAxisRaw("Horizontal");
        rigid_body_2d.velocity = new Vector2(direction_x * move_speed, rigid_body_2d.velocity.y);

        // jumping
        if (Input.GetKeyDown("space") && Mathf.Abs(rigid_body_2d.velocity.y) < 0.01) {
            rigid_body_2d.velocity = new Vector2(rigid_body_2d.velocity.x, jump_height);
        }
    }
}
