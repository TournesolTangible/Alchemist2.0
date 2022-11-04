using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float speed = 12f;
    private float jumping_power = 40f;
    private bool is_facing_right;

    private float coyote_time = 0.2f;
    private float coyote_time_counter;

    [SerializeField] private Rigidbody2D rigid_body_2d;
    [SerializeField] private Transform ground_check;
    [SerializeField] private LayerMask ground_layer;

    void Update() {
        // movement
        horizontal = Input.GetAxisRaw("Horizontal");

        // coyote time counter
        if (IsGrounded()) {
            coyote_time_counter = coyote_time;
        }
        else {
            coyote_time_counter -= Time.deltaTime;
        }

        // jumping
        if (Input.GetKeyDown("space") && coyote_time_counter > 0f) {
            rigid_body_2d.velocity = new Vector2(rigid_body_2d.velocity.x, jumping_power);
        }

        // higher jump if holding jump button
        if (Input.GetKeyUp("space") && rigid_body_2d.velocity.y > 0f) {
            rigid_body_2d.velocity = new Vector2(rigid_body_2d.velocity.x, rigid_body_2d.velocity.y * 0.5f);
            
            // reset coyote time counter
            coyote_time_counter = 0f;
        }

        // flips player character
        Flip();
    }

    private void FixedUpdate() {
        rigid_body_2d.velocity = new Vector2(horizontal * speed, rigid_body_2d.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(ground_check.position, 0.1f, ground_layer);
    }

    private void Flip() {
        if (is_facing_right && horizontal > 0f || !is_facing_right && horizontal < 0f) {
            is_facing_right = !is_facing_right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
