using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1: Level {
   public Level1(PlayerController player, float previousSpawnedPlatformY): 
   base(player, previousSpawnedPlatformY) {
       minDistanceBetweenPlatform = 1.2f;
       maxDistanceBetweenPlatform = 3f;

       // We'll spawn 40% basic platforms, 40% cookie platforms, and 20% broken platforms in level 1
       normalPlatformRate = 0.4f;
       cookiePlatformRate = 0.4f;
       goosePlatformRate = 0.0f;
       brokenPlatformRate = 0.2f;
       jetpackPlatformRate = 0f;
       Debug.Log("Level 1");
   }

    public override void UpdateLevel() {
        if (base.ShouldUpdateLevel()) {
            GameObject platformPrefab = this.GetPlatformPrefabWithSpawnRate();
            SpawnPlatformLevelItem(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, platformPrefab);
        }
    }
}
