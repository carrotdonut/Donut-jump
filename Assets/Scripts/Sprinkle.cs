using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkle : MonoBehaviour {
    [SerializeField] private float movementSpeed = 100f;
    [SerializeField] private float distanceToTravel = 3;
    private float distanceTravelled = 0;

    // Update is called once per frame
    void Update() {
        // Keep shooting upwards, until the sprinkle goes offscreen or hits a monster
        if (distanceTravelled >= distanceToTravel) {
            Destroy(gameObject);
        } else {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            distanceTravelled += movementSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        // If the sprinkle collides with a goose, we kill that goose!
        if (other.tag == "Goose") {
            other.gameObject.SetActive(false);
        }
    }
}
