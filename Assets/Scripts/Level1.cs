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
        // Every time the player jumps on a platform and moves upwards, we spawn new platforms
        // We only spawn platforms up to a certain Y distance above the player
        
        if (base.ShouldUpdateLevel()) {
            GameObject prefab = GameManager.Instance.prefabDataBase.platformPrefab;
            SpawnPlatform(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, prefab);
        }
    }
}
