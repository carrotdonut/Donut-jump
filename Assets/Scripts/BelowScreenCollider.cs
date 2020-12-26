using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is a box collider that is right below the visible screen
It checks collisions with platforms, to delete platforms offscreen
*/
public class BelowScreenCollider : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        // We want to check if we land on a platform and we're falling downwards
        // We want to go through platforms when moving upwards
        if (other.tag == "Platform") {
            Destroy(other.gameObject);
        }
    }
}
