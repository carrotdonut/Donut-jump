using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null && player.CanHitPlatform()) {
                PlayerJumpPlatform(player);
            }
        }
    }
    public virtual void PlayerJumpPlatform(PlayerController player) {
        player.DoJump(player.BaseJumpStrength, this.transform.position.y);

        // Update the player's score when they jump on a higher platform than before
        if (this.transform.position.y > player.HighestPlatformJumped) {
            player.HighestPlatformJumped = this.transform.position.y;
            GameManager.Instance.gameController.IncreaseScore(Mathf.Pow(player.HighestPlatformJumped, 1.3f) + player.HighestPlatformJumped);
        }
    }
}
