using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2: Level {
    private bool firstGooseSpawned = false;
   public Level2(PlayerController player, float previousSpawnedPlatformY): 
   base(player, previousSpawnedPlatformY) {
       minDistanceBetweenPlatform = 2f;
       maxDistanceBetweenPlatform = 4.5f;

        // We'll spawn 10% basic platforms, 25% cookie platforms, 30% geese platforms, and 35% breaking platforms in level 2
       normalPlatformRate = 0.1f;
       cookiePlatformRate = 0.25f;
       goosePlatformRate = 0.3f;
       brokenPlatformRate = 0.35f;
       jetpackPlatformRate = 0f;
       Debug.Log("Level 2");
   }

    public override void UpdateLevel() {
        if (base.ShouldUpdateLevel()) {
            GameObject platformPrefab = null;

            // For the first platform spawned in level 2, we want to spawn a goose on top
            if (!firstGooseSpawned) {
                platformPrefab = GameManager.Instance.prefabDataBase.platformWithGoosePrefab;
                firstGooseSpawned = true;
            } else {
                platformPrefab = this.GetPlatformPrefabWithSpawnRate();
            }

            SpawnPlatformLevelItem(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, platformPrefab);
        }
    }
}
