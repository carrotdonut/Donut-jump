using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is a box collider that is right below the visible screen
It checks collisions with platforms, to delete platforms offscreen
*/
public class BelowScreenCollider : MonoBehaviour {
    private bool playerDead = false;
    private void OnTriggerEnter(Collider other) {
        // We want to check if we land on a platform and we're falling downwards
        // We want to go through platforms when moving upwards
        if (other.tag == "PlatformWithItem" || other.tag == "Platform") {
            Destroy(other.gameObject);
        } else if (other.tag  == "Player" && !playerDead) {
            Debug.Log("Move camera down");
            // If the player falls through and dies, we want to move the camera downwards
            Vector3 playerPosition =  GameManager.Instance.gameController.player.GetPosition();
            GameManager.Instance.gameController.mainCamera.SetCameraPositionY(playerPosition.y - 6);
            playerDead = true;
        }
    }
}
