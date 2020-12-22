using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 startCameraPosition;
    private Vector3 endCameraPosition;
    private float moveDuration = 0.5f;
    private float timeElapsed = 0.5f;

    [SerializeField] private float cameraSpeed = 5.0f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (timeElapsed < moveDuration) {
            transform.position = Vector3.Lerp(startCameraPosition, endCameraPosition, timeElapsed / moveDuration);

            timeElapsed += Time.deltaTime;
        }
    }

    public void updateCameraYDisplacement(float displacement) {
        startCameraPosition = transform.position;
        endCameraPosition = new Vector3(transform.position.x, transform.position.y + displacement, transform.position.z);
        timeElapsed = 0;
    }
}
