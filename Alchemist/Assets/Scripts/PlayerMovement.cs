using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float speed = 12f;
    public float jumping_power = 40f;
    public bool is_facing_right;
    private float _DriftLeft = 4.5f;

    private float coyote_time = 0.2f;
    private float coyote_time_counter;

    public Animator animator;

    [SerializeField] private Rigidbody2D rigid_body_2d;
    [SerializeField] private Transform ground_check;
    [SerializeField] private LayerMask ground_layer;

    [SerializeField] private AudioSource _StepSound;
    [SerializeField] private float _StepTimer;
    [SerializeField] private float _StepRate;

    [SerializeField] private AudioSource _JumpSound;

    void Start() {
        is_facing_right = true;
    }

    void Update() {
        // set animator
        animator.SetFloat("Speed", horizontal);
        animator.SetBool("Grounded", IsGrounded());

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

        // play stepping sounds while keys pressed
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && IsGrounded()) {
            if (Time.time > _StepTimer) {
            _StepSound.Play();
            _StepTimer = Time.time + _StepRate;
            }
        }

        // play jumping sound when 'space' pressed
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            _JumpSound.Play();
        }

        // Checks scene to stop/start leftward drift
        if (!(SceneManager.GetActiveScene().buildIndex == 1)) {
            _DriftLeft = 0f;
        } else {
            _DriftLeft = 4.5f;
        }

    }

    private void FixedUpdate() {
        rigid_body_2d.velocity = new Vector2(horizontal * speed - _DriftLeft, rigid_body_2d.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(ground_check.position, 0.1f, ground_layer);
    }

    private void Flip() {
        if (is_facing_right && horizontal < 0f || !is_facing_right && horizontal > 0f) {
            is_facing_right = !is_facing_right;
        }
    }
}
