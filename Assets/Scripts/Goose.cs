using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : Item {
    public override void GetItem() {
        Debug.Log("Goose get item");
        PlayerController player = GameManager.Instance.gameController.player;

        if (player.IsMovingDown() && !player.IsPlayerDead()) {
            // If the player is moving down, and isn't dead, then the player's jumping on top of the goose, and we kill the goose
            gameObject.SetActive(false);
        } else if (!player.IsMovingDown() && player.CanBeHit()) {
            // If the player is moving up and hits a goose, the player DIES
            player.ChangeToDeadDonut();
        }
    }
}
