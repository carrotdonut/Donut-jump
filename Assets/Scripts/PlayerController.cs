using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float gravity = 500f;
    [SerializeField] private float jumpStrength = 13f;
    [SerializeField] private Sprite deadDonutSprite;
    private bool playerDead = false;
    private Vector3 displacement = Vector3.zero;
    private bool movingDown = true;

    // Start is called before the first frame update
    void Start() {
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public bool IsMovingDown() {
        return movingDown;
    }

    public bool IsPlayerDead() {
        return playerDead;
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

        if (Input.GetKeyDown(KeyCode.Space) && !playerDead) {
            // Pressing space shoots out a sprinkle to kill geese
            GameManager.Instance.gameController.sprinkles.CreateSprinkle();
        }
    }

    private void OnTriggerEnter(Collider other) {
        // We want to check if we land on a platform and we're falling downwards
        // We want to go through platforms when moving upwards
        if (other.tag == "Platform" && movingDown && !playerDead) {
            // When we land on a platform, we want to jump upwards
            displacement.y = jumpStrength;

            GameManager.Instance.gameController.mainCamera.UpdateCameraPositionSmooth(other.transform.position.y);
        }
    }

    public void ChangeToDeadDonut() {
        Debug.Log("You ded");
        playerDead = true;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deadDonutSprite;
    }
}
