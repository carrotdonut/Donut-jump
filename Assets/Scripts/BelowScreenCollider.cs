using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is a box collider that is right below the visible screen
It checks collisions with platforms, to delete platforms offscreen
*/
public class BelowScreenCollider : MonoBehaviour {
    private bool pannedDownAfterDeath = false; // So we only pan the camera downwards once, when the player falls through
    private void OnTriggerEnter(Collider other) {
        if (other.tag  == "Player" && !pannedDownAfterDeath) {
            // If the player falls through and dies, we want to move the camera downwards
            Vector3 playerPosition =  GameManager.Instance.gameController.player.GetPosition();
            GameManager.Instance.gameController.mainCamera.SetCameraPositionY(playerPosition.y - 6);
            pannedDownAfterDeath = true;
        } else if (other.tag != "Player" && other.tag != "SideScreenCollider") {
            // Destroy all other platforms and items that go underneath the camera view
            Destroy(other.gameObject);
        }
    }
}
