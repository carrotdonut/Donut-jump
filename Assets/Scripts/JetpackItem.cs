using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackItem : Item
{
    public JetpackPowerup jetpackPowerup;
    public override void GetItem() {
        PlayerController player = GameManager.Instance.gameController.player;
        
        if (!player.HasPowerupWithName("Jetpack")) {
            JetpackPowerup powerupInstance = Instantiate<JetpackPowerup>(jetpackPowerup);
            powerupInstance.transform.position = player.transform.position;
            powerupInstance.transform.parent = player.transform;

            powerupInstance.Initialize(player);
        }

        Destroy(this.gameObject);
    }
}
