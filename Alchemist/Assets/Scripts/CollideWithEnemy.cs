using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{
    [SerializeField] private HealthBarHUDTester _HB;

    public void Start() {
        
    }

    public void OnTriggerStay(Collider other) {
        if (other.tag is "Enemy") {

            print("worked");

        }




    } 



}
