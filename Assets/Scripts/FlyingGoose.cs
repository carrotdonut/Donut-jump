using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGoose : MonoBehaviour {
    private sbyte direction = -1; // Initialize the geese to fly left
    private float movementSpeed = 10f;

    // Update is called once per frame
    void Update() {
        // Keep moving left or right
        transform.Translate(Vector3.right * direction * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Goose crashed into collider");
        if (other.tag == "SideScreenCollider") {
            // When we bump into a side collider, the flying goose switches directions
            direction *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
