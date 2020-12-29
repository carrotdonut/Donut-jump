using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level {
    protected PlayerController player;
    protected float minDistanceBetweenPlatform;
    protected float maxDistanceBetweenPlatform;
    protected float previousSpawnedPlatformY;

    protected const float maxDistanceAbovePlayer = 6;

   public Level(PlayerController player, float previousSpawnedPlatformY) {
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
    public void SpawnLevelItem(float minPlatformY, float maxPlatformY, GameObject prefab) {
        float newPlatformY = Random.Range(minPlatformY, maxPlatformY);
        float newPlatformX = Random.Range(-2.5f, 2.5f);

        Vector3 spawnPosition = new Vector3(newPlatformX, newPlatformY, 0);
        Quaternion spawnRotation = Quaternion.identity; // Rotation (0,0,0)

        GameObject.Instantiate<GameObject>(prefab, spawnPosition, spawnRotation);
        previousSpawnedPlatformY = newPlatformY;
    }

    protected bool ShouldUpdateLevel() {
        return previousSpawnedPlatformY < (player.transform.position.y + maxDistanceAbovePlayer);
    }
}
