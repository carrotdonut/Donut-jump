using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 startCameraPosition;
    private Vector3 endCameraPosition;
    private float moveDuration = 0.5f;
    private float timeElapsed = 0.5f;
    private bool isMovingCamera = false;
    private float previousJumpedPlatformY = -4; // Y coordinate of the starting platform

    // Start is called before the first frame update
    void Start() {
    }

    // Set the camera to the updated y position
    // Used for when the donut falls down, and we set the camera downwards to see the donut fall
    public void SetCameraPositionY(float y) {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        this.previousJumpedPlatformY = y;
    }

    // Smoothly move the camera position to the next platform position
    public void UpdateCameraPositionSmooth(float currentPlatformY) {
        // We don't need to update the camera if we jump on the same platform as before
        if (currentPlatformY == previousJumpedPlatformY) return;

        float displacement = currentPlatformY - previousJumpedPlatformY;
        previousJumpedPlatformY = currentPlatformY;

        if (!isMovingCamera) {
            InitializeVariables(displacement);
            StartCoroutine(UpdateCameraPositionCor());
        } else {
            // If the camera's already moving, we just want to update the start and end camera position to continue
            // in the same coroutine
            InitializeVariables(displacement);
        }
    }

    private IEnumerator UpdateCameraPositionCor() {
        isMovingCamera = true;

        while (timeElapsed < moveDuration) {
            transform.position = Vector3.Lerp(startCameraPosition, endCameraPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        isMovingCamera = false;
    }

    private void InitializeVariables(float displacement) {
        startCameraPosition = transform.position;
        endCameraPosition = new Vector3(transform.position.x, transform.position.y + displacement, transform.position.z);
        timeElapsed = 0;
    }

}
