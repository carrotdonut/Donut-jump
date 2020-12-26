using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float gravity = 1000f;
    [SerializeField] private float jumpStrength = 13f;
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

        transform.position += displacement * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        // We want to check if we land on a platform and we're falling downwards
        // We want to go through platforms when moving upwards
        if (other.tag == "Platform" && movingDown) {
            // When we land on a platform, we want to jump upwards
            displacement.y = jumpStrength;

            GameManager.Instance.gameController.UpdateCameraPosition(other.transform.position.y);
        } else if (other.tag == "Goose" && movingDown) {
            // You kill the goose when you jump on top of it
            Destroy(other.gameObject);
        } else if (other.tag == "Goose" && !movingDown) {
            // You die if you hit a goose and you're jumping up
            Debug.Log("You ded");
        }
    }
}
