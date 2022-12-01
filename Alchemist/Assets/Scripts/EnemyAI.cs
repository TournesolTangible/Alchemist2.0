using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    // Needed for animations
    //[SerializeField] private Animator _animator;

    // When we have game manager set up with player, this will hopefully just need to be changed to
    //  GameManager.instance.player.GetComponent<Player>()
    private Transform _target;

    [SerializeField] private float _speed = 200f;
    // How close to a waypoint the enemy must be before moving on to the next one
    public float NextWaypointDistance = 3f;

    public Transform EnemyGFX;

    // the current path
    Path Path;
    int CurrentWaypoint = 0;
    bool ReachedEndOfPath = false;

    // Need references to the seeker and rigidbody components of the object
    Seeker Seeker;
    Rigidbody2D Rb;

    // fliping sprite (enemy is always spawned facing left
    private bool _facingRight;


    // Start is called before the first frame update
    void Start()
    {

        _target = GameManager.Instance.Player.transform;

        // Set the components
        Seeker = GetComponent<Seeker>();
        Rb = GetComponent<Rigidbody2D>();

        // Invoke the update path function on repeat so that the path is being updated consistently
        InvokeRepeating("UpdatePath", 0f, .5f);
    }


    void UpdatePath()
    {
        if (Seeker.IsDone())
        {
            // First variable (start position), second variable (end position), third variable (funcion to call when complete)
            Seeker.StartPath(Rb.position, _target.position, OnPathComplete);
        }
    }


    void OnPathComplete(Path p)
    {
        // Make sure we don't have any errors
        if (!p.error)
        {
            // Path = the new generated path
            // current waypoint = 0, so we start at the beginning of the new path
            Path = p;
            CurrentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Only create the path and move the enemy if the distance is close enough to the player and not outside of the game center
        if (Mathf.Abs(this.transform.position.x - _target.transform.position.x) < 46 && this.transform.position.x > -24)
        {

            // the enemy at this point will always be moving so just set it to true
            //_animator.SetBool("isMoving", true);

            _target = GameManager.Instance.Player.transform;

            // case for when we don't have a path
            if (Path == null)
            {
                return;
            }
            ////////////////////////////
            /// Checking Waypoints ////
            ///////////////////////////

            // if the current number of waypoints is greater than the path's number of waypoints
            // we have reached the end of the path
            if (CurrentWaypoint >= Path.vectorPath.Count)
            {
                ReachedEndOfPath = true;
                return;
            }
            // else we haven't reached the end
            else
            {
                ReachedEndOfPath = false;
            }

            ////////////////////////////
            //// Movement of Enemy ////
            ///////////////////////////

            // Get the position of the current waypoint, subtract our current position and normalize it (length = 1.0)
            Vector2 direction = ((Vector2)Path.vectorPath[CurrentWaypoint] - Rb.position).normalized;
            // calculate and add the force to move the enemy toward that direction
            Vector2 force = direction * _speed * Time.deltaTime;
            Rb.AddForce(force);

            // 
            float distance = Vector2.Distance(Rb.position, Path.vectorPath[CurrentWaypoint]);

            // if we have reached the end of the current waypoint, move toward the next waypoint
            if (distance < NextWaypointDistance)
            {
                CurrentWaypoint++;
            }


            /////////////////////////////////////////////////////////
            //// Flip the sprite when facing the other direction ////
            /////////////////////////////////////////////////////////

            if (Rb.velocity.x >= 0.01f && !_facingRight)
            {
                //transform.localScale = new Vector3(-1f, 1f, 1f);
                Flip();
            }
            else if (Rb.velocity.x <= -0.01f && _facingRight)
            {
                //transform.localScale = new Vector3(1f, 1f, 1f);
                Flip();
            }


            void Flip()
            {
                Vector3 currnetScale = gameObject.transform.localScale;
                currnetScale.x *= -1;
                gameObject.transform.localScale = currnetScale;

                _facingRight = !_facingRight;
            }
        }
    }
}
