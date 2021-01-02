using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2: Level {
    private bool firstGooseSpawned = false;
   public Level2(PlayerController player, float previousSpawnedPlatformY): 
   base(player, previousSpawnedPlatformY) {
       minDistanceBetweenPlatform = 2f;
       maxDistanceBetweenPlatform = 4.5f;
       Debug.Log("Level 2");
   }

    public override void UpdateLevel() {
        // We'll spawn 25% basic platforms, 25% cookie platforms, 30% geese platforms, and 20% breaking platforms in level 2
        if (base.ShouldUpdateLevel()) {
            GameObject platformPrefab = null;

            // For the first platform spawned in level 2, we want to spawn a goose on top
            if (!firstGooseSpawned) {
                platformPrefab = GameManager.Instance.prefabDataBase.platformWithGoosePrefab;
                firstGooseSpawned = true;
            } else {
                // We'll spawn 25% basic platforms, 25% cookie platforms, 30% geese platforms, and 20% breaking platforms in level 2
                platformPrefab = this.GetPlatformPrefabWithPercentages(new float[] {0.25f, 0.25f, 0.3f, 0.2f});
            }

            SpawnPlatformLevelItem(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, platformPrefab);
        }
    }
}
