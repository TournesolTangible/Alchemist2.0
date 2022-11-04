using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float jump_force = 50.0f;
    [SerializeField] float move_speed = 30.0f;

    private Rigidbody2D rigid_body_2d_transform;
    private Rigidbody2D rigid_body_2d;
    private bool facing_right;
    private float move_direction;

    private void Awake() {
        rigid_body_2d_transform = transform.GetComponent<Rigidbody2D>();
        rigid_body_2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // jump, but only if player is not falling or jumping
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rigid_body_2d_transform.velocity.y) < 0.001f) {
            rigid_body_2d_transform.velocity = Vector2.up * jump_force;
        }

        move_direction = Input.GetAxis("Horizontal");
        rigid_body_2d.velocity = new Vector2(move_direction * move_speed, rigid_body_2d.velocity.y);

    }
}
