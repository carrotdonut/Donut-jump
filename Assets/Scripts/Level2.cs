using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2: Level {
   public Level2(GameObject platformPrefab, PlayerController player, float previousPlatformY): base(platformPrefab, player, previousPlatformY) {
       minDistanceBetweenPlatform = 3.5f;
       maxDistanceBetweenPlatform = 5f;
       Debug.Log("Level2");
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
