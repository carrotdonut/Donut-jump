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
    }
}
