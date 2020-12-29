using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Per scene
public class GameController : MonoBehaviour {
    public CameraController mainCamera;
    public PlayerController player;
    public SprinkleController sprinkles;

    // Same as Start, except it is called before Start()
    void Awake() {
        GameManager.Instance.gameController = this;
    }

    void Start() {
    }

    public void UpdateCameraPositionSmooth(float currentPlatformY) {
        mainCamera.UpdateCameraPositionSmooth(currentPlatformY);
    }

    public void SetCameraPositionY(float y) {
        mainCamera.SetCameraPositionY(y);
    }

    public Vector3 GetPlayerPosition() {
        return player.transform.position;
    }

    public void ChangePlayerToDeadDonut() {
        player.ChangeToDeadDonut();
    }

    public void ShootSprinkle() {
        sprinkles.CreateSprinkle();
    }

}
