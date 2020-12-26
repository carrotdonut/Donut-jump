using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Per scene
public class GameController : MonoBehaviour
{
    public CameraController mainCamera;
    public PlayerController player;

    // Same as Start, except it is called before Start()
    void Awake() {
        GameManager.gameController = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCameraYDisplacement(float displacementY) {
        mainCamera.updateCameraYDisplacement(displacementY);
    }

}
