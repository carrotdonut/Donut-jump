using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float gravity = 1000f;
    [SerializeField] private float baseJumpStrength = 10f;
    public float BaseJumpStrength { get { return baseJumpStrength;} set { baseJumpStrength = value; } }

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

    public void ChangeToDeadDonut() {
        Debug.Log("You ded");
        playerDead = true;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deadDonutSprite;
    }

    public void DoJump(float jumpStrength, float cameraYOffset) {
        displacement.y = jumpStrength;
        GameManager.Instance.gameController.mainCamera.UpdateCameraPositionSmooth(cameraYOffset);
    }

    public bool CanHitPlatform() {
        return movingDown && !playerDead;
    }
}
