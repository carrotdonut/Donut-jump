using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1: Level {
   public Level1(GameObject platformPrefab, PlayerController player, float previousPlatformY): base(platformPrefab, player, previousPlatformY) {
       minDistanceBetweenPlatform = 1.2f;
       maxDistanceBetweenPlatform = 3f;
       Debug.Log("Level1");
   }

    public override void spawn() {
        // Every time the player jumps on a platform and moves upwards, we spawn new platforms
        // We only spawn platforms up to a certain Y distance above the player
        
        if (previousPlatformY < (player.transform.position.y + maxDistanceAbovePlayer)) {
            GameObject platform = spawnPlatform(minDistanceBetweenPlatform + previousPlatformY, maxDistanceBetweenPlatform + previousPlatformY);

            previousPlatformY = platform.transform.position.y;
        } 
    }
}
