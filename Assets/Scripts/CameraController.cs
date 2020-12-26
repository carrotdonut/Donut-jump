using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 startCameraPosition;
    private Vector3 endCameraPosition;
    private float moveDuration = 0.5f;
    private float timeElapsed = 0.5f;

    private bool isMovingCamera = false;

    // Start is called before the first frame update
    void Start() {
    }

    public void updateCameraYDisplacement(float displacement) {
        if (!isMovingCamera) {
            InitializeVariables(displacement);
            StartCoroutine(UpdateCameraYDisplacementCor(displacement));
        } else {
            InitializeVariables(displacement);
        }
    }

    private IEnumerator UpdateCameraYDisplacementCor(float displacement) {
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
