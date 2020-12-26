using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level {
    protected GameObject platformPrefab;
    protected GameObject standingGoosePrefab;
    protected PlayerController player;
    protected float previousPlatformY;
    protected float minDistanceBetweenPlatform;
    protected float maxDistanceBetweenPlatform;

    protected const float maxDistanceAbovePlayer = 6;
    public enum Items : sbyte {
        NONE = 0,
        STANDING_GOOSE = 1,
        FLYING_GOOSE = 2,
        ZIGZAG_GOOSE = 3,
        SPRING = 4
    }

   public Level(GameObject platformPrefab, PlayerController player, float previousPlatformY) {
       this.platformPrefab = platformPrefab;
       this.player = player;
       this.previousPlatformY = previousPlatformY;
   }

   public Level(GameObject platformPrefab, GameObject standingGoosePrefab, PlayerController player, float previousPlatformY) {
       this.platformPrefab = platformPrefab;
       this.standingGoosePrefab = standingGoosePrefab;
       this.player = player;
       this.previousPlatformY = previousPlatformY;
   }

   public float getPreviousPlatformY() {
       return previousPlatformY;
   }

    /*
    Abstract function for each level to implement, to spawn platforms, monsters, etc
    Each level has logic for how far apart platforms are, how often to spawn monsters, etc
    */
   public abstract void spawn();

    // add collider, and when the collider triggers, check if its a platform
    // collider.transform.gameobject - to get a reference to that game object
    public GameObject spawnPlatform(float minPlatformY, float maxPlatformY, Items item = Items.NONE) {
        float newPlatformY = Random.Range(minPlatformY, maxPlatformY);
        float newPlatformX = Random.Range(-2.5f, 2.5f);

        Vector3 spawnPosition = new Vector3(newPlatformX, newPlatformY, 0);
        Quaternion spawnRotation = Quaternion.identity; // Rotation (0,0,0)

        switch(item) {
            case Items.STANDING_GOOSE:
                spawnStandingGoose(newPlatformX, newPlatformY + 1);
                break;
        }

        return GameObject.Instantiate<GameObject>(platformPrefab, spawnPosition, spawnRotation);
    }

    public void spawnStandingGoose(float x, float y) {
        Debug.Log("SPAWN THE STANDING GOOSE");
        Vector3 spawnPosition = new Vector3(x, y, 0);
        Quaternion spawnRotation = Quaternion.identity; // Rotation (0,0,0)
        GameObject.Instantiate<GameObject>(standingGoosePrefab, spawnPosition, spawnRotation);
    }

    public GameObject spawnHorizontalFlyingGoose(float y) {
        return new GameObject();
    }

    public GameObject spawnZigzagGoose(float y) {
        return new GameObject();
    }
}
