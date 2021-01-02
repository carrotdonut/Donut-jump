using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackPowerup : Powerup
{
    public float jetpackSpeed = 10f;

    public float maxCamOffset = 5f;

    public override void OnInitialize()
    {
        base.OnInitialize();
        this.powerupName = "Jetpack";
        this.player.SetApplyGravity(false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector3 displacement = this.player.GetDisplacement();
        displacement.y = jetpackSpeed;

        this.player.SetDisplacement(displacement);

        Transform camTransform = GameManager.Instance.gameController.mainCamera.transform;

        if (player.transform.position.y - camTransform.position.y >= maxCamOffset) {
            GameManager.Instance.gameController.mainCamera.SetCameraPositionY(this.player.transform.position.y - maxCamOffset);
        }
    }

    public override void OnRemovePowerup() {
        base.OnRemovePowerup();
        this.player.SetApplyGravity(true);
    }
}
