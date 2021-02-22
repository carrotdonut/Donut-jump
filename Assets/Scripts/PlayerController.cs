using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float gravity = 1000f;
    [SerializeField] private float baseJumpStrength = 10f;
    private float highestPlatformJumped = 0f;

    public float HighestPlatformJumped { get { return highestPlatformJumped;} set { highestPlatformJumped = value; } }
    public float BaseJumpStrength { get { return baseJumpStrength;} set { baseJumpStrength = value; } }

    [SerializeField] private Sprite deadDonutSprite;
    private bool playerDead = false;
    private Vector3 displacement = Vector3.zero;
    private bool movingDown;

    private bool applyGravity = true;

    // Right after using a powerup like the jetpack, make the player invincible for 2 secs, so they have time to
    // regain their composure in the game
    // It's sad bee if they just finish a jetpack and crash into a goose
    private DateTime invincibleTime;

    private List<Powerup> activePowerups = new List<Powerup>();

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
        invincibleTime = DateTime.Now.AddSeconds(2);

        // Kinda hacky, simulate the previous platform to be 5 under the player
        GameManager.Instance.gameController.mainCamera.SetPreviousJumpedPlatformY(GetPosition().y - 5);
    }

    public bool CanBeHit() {
        if (DateTime.Now <= invincibleTime) {
            return false;
        }

        return this.playerDead == false && !this.HasPowerupWithName("Jetpack");
    }
}
