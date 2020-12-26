using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level {
    protected GameObject platformPrefab;
    protected GameObject standingGoosePrefab;
    protected PlayerController player;
    protected float minDistanceBetweenPlatform;
    protected float maxDistanceBetweenPlatform;
    protected float previousSpawnedPlatformY;

    protected const float maxDistanceAbovePlayer = 6;
    public enum Items : sbyte {
        NONE = 0,
        STANDING_GOOSE = 1,
        FLYING_GOOSE = 2,
        ZIGZAG_GOOSE = 3,
        SPRING = 4
    }

   public Level(GameObject platformPrefab, PlayerController player, float previousSpawnedPlatformY) {
       this.platformPrefab = platformPrefab;
       this.player = player;
       this.previousSpawnedPlatformY = previousSpawnedPlatformY;
   }

   public Level(GameObject platformPrefab, GameObject standingGoosePrefab, PlayerController player, float previousSpawnedPlatformY) {
       this.platformPrefab = platformPrefab;
       this.standingGoosePrefab = standingGoosePrefab;
       this.player = player;
       this.previousSpawnedPlatformY = previousSpawnedPlatformY;
   }

    /*
    Abstract function for each level to implement, to spawn platforms, monsters, etc
    Each level has logic for how far apart platforms are, how often to spawn monsters, etc
    */
   public abstract void UpdateLevel();

   public float GetPreviousSpawnedPlatformY() {
       return previousSpawnedPlatformY;
   }

    // add collider, and when the collider triggers, check if its a platform
    // collider.transform.gameobject - to get a reference to that game object
    public void SpawnPlatform(float minPlatformY, float maxPlatformY, Items item = Items.NONE) {
        float newPlatformY = Random.Range(minPlatformY, maxPlatformY);
        float newPlatformX = Random.Range(-2.5f, 2.5f);

        Vector3 spawnPosition = new Vector3(newPlatformX, newPlatformY, 0);
        Quaternion spawnRotation = Quaternion.identity; // Rotation (0,0,0)

        switch(item) {
            case Items.STANDING_GOOSE:
                SpawnStandingGoose(newPlatformX, newPlatformY + 1);
                break;
        }

        GameObject.Instantiate<GameObject>(platformPrefab, spawnPosition, spawnRotation);
        previousSpawnedPlatformY = newPlatformY;
    }

    public void SpawnStandingGoose(float x, float y) {
        Debug.Log("SPAWN THE STANDING GOOSE");
        Vector3 spawnPosition = new Vector3(x, y, 0);
        Quaternion spawnRotation = Quaternion.identity; // Rotation (0,0,0)
        GameObject.Instantiate<GameObject>(standingGoosePrefab, spawnPosition, spawnRotation);
    }

    public GameObject SpawnHorizontalFlyingGoose(float y) {
        return new GameObject();
    }

    public GameObject SpawnZigzagGoose(float y) {
        return new GameObject();
    }

    protected bool ShouldUpdateLevel() {
        return previousSpawnedPlatformY < (player.transform.position.y + maxDistanceAbovePlayer);
    }
}
