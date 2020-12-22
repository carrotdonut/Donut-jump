using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float jumpStrength = 10f;
    private Vector3 displacement = Vector3.zero;

    private bool movingDown = true;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Add the gravity acceleration since we're always jumping in the air
        displacement.y -= gravity * Time.deltaTime;
        if (displacement.y >= 0) {
            movingDown = false;
        } else {
            movingDown = true;
        }

        // Check for horizontal movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        displacement.x = horizontalMovement * movementSpeed;

        transform.position = transform.position + displacement * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        // We want to check if we land on a platform and we're falling downwards
        // We want to go through platforms when moving upwards
        if (other.tag == "Platform" && movingDown) {
            // When we land on a platform, we want to jump upwards
            displacement.y = jumpStrength;
        }
    }
}
