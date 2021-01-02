using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1: Level {
   public Level1(PlayerController player, float previousSpawnedPlatformY): 
   base(player, previousSpawnedPlatformY) {
       minDistanceBetweenPlatform = 1.2f;
       maxDistanceBetweenPlatform = 3f;
       Debug.Log("Level 1");
   }

    public override void UpdateLevel() {
        // We'll spawn 50% basic platforms and 50% cookie platforms in level 1
        if (base.ShouldUpdateLevel()) {
            GameObject platformPrefab = this.GetPlatformPrefabWithPercentages(new float[] {0.5f, 0.5f});
            SpawnPlatformLevelItem(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, platformPrefab);
        }
    }
}
