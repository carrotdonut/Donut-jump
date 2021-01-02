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

    private bool applyGravity = true;

    private List<Powerup> activePowerups = new List<Powerup>();

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // Add the gravity acceleration since we're always jumping in the air

        if (applyGravity) {
            displacement.y -= gravity * Time.deltaTime;
        }

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
            GameManager.Instance.gameController.ShootSprinkle();
        }
    }

    private void OnTriggerEnter(Collider other) {
        // We want to check if we land on a platform and we're falling downwards
        // We want to go through platforms when moving upwards
        if (other.tag == "Goose" && movingDown && !playerDead) {
            // You kill the goose when you jump on top of it
            other.gameObject.SetActive(false);
        } else if (other.tag == "Goose" && !movingDown && CanBeHit()) {
            // You die if you hit a goose and you're jumping up
            playerDead = true;
            ChangeToDeadDonut();
            Debug.Log("You ded");
        }
    }

    public void ChangeToDeadDonut() {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deadDonutSprite;
    }

    public void DoJump(float jumpStrength, float cameraYOffset) {
        displacement.y = jumpStrength;
        GameManager.Instance.gameController.UpdateCameraPositionSmooth(cameraYOffset);
    }

    public bool CanHitPlatform() {
        return movingDown && !playerDead;
    }

    public void SetApplyGravity(bool gravity) {
        this.applyGravity = gravity;
    }

    public void SetDisplacement(Vector3 displace) {
        this.displacement = displace;
    }

    public Vector3 GetDisplacement() {
        return this.displacement;
    }

    public void AddActivePowerup(Powerup powerup) {
        this.activePowerups.Add(powerup);
    }
    
    public bool HasPowerupWithName(string powerUpName) {
        return this.activePowerups.Find( (Powerup powerup) => powerup.powerupName == powerUpName ) != null;
    }

    public void RemovePowerup(Powerup powerup) {
        this.activePowerups.Remove(powerup);
    }

    public bool CanBeHit() {
        return !this.HasPowerupWithName("Jetpack");
    }
}
