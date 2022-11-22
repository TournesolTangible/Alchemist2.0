using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    private void Start()
    {
        // set the enemy to moving
        _animator.SetBool("isMoving", true);
    }
}
