using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2: Level {
    private bool firstGooseSpawned = false;
   public Level2(GameObject platformPrefab, GameObject standingGoosePrefab, PlayerController player, float previousPlatformY): base(platformPrefab, standingGoosePrefab, player, previousPlatformY) {
       minDistanceBetweenPlatform = 2f;
       maxDistanceBetweenPlatform = 4.5f;
       Debug.Log("Level2");
   }

    public override void spawn() {
        // Every time the player jumps on a platform and moves upwards, we spawn new platforms
        // We only spawn platforms up to a certain Y distance above the player

        Items item = Items.NONE;
        
        if (previousPlatformY < (player.transform.position.y + maxDistanceAbovePlayer)) {
            // For the first platform spawned in level 2, we want to spawn a goose on top
            if (!firstGooseSpawned) {
                item = Items.STANDING_GOOSE;
                firstGooseSpawned = true;
            }
            GameObject platform = spawnPlatform(minDistanceBetweenPlatform + previousPlatformY, maxDistanceBetweenPlatform + previousPlatformY, item);

            previousPlatformY = platform.transform.position.y;
        } 
    }
}
