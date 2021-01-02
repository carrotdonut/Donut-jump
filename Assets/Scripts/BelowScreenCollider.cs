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
        if (other.tag  == "Player" && !GameManager.Instance.gameController.player.IsPlayerDead()) {
            // If the player falls through and dies, we want to move the camera downwards
            Vector3 playerPosition =  GameManager.Instance.gameController.player.GetPosition();
            GameManager.Instance.gameController.mainCamera.SetCameraPositionY(playerPosition.y - 6);
            playerDead = true;
        } else if (other.tag != "Player") {
            // Destroy all other platforms and items that go underneath the camera view
            Destroy(other.gameObject);
        }
    }
}
