using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3: Level {
    private bool firstFlyingGooseSpawned = false;
   public Level3(PlayerController player, float previousSpawnedPlatformY): 
   base(player, previousSpawnedPlatformY) {
       minDistanceBetweenPlatform = 2f;
       maxDistanceBetweenPlatform = 4.5f;
       Debug.Log("Level 3");
   }

    public override void UpdateLevel() {
        // Every time the player jumps on a platform and moves upwards, we spawn new platforms
        // We only spawn platforms up to a certain Y distance above the player

        GameObject prefab = null;
        
        if (base.ShouldUpdateLevel()) {
            // At the beginning of the level, we want to spawn a flying goose that flies horizontally
            // Throughout the level, we want to continuously randomly spawn flying geese and geese on platforms
            if (!firstFlyingGooseSpawned || Random.Range(0.0f, 1.0f) < 0.2f) {
                float y = Random.Range(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY);
                prefab = GameManager.Instance.prefabDataBase.flyingGoosePrefab;
                SpawnLevelItem(y, prefab);
                firstFlyingGooseSpawned = true;
            }
            
            // Randomly spawn platforms with geese
            if (Random.Range(0.0f, 1.0f) < 0.4f) {
                prefab = GameManager.Instance.prefabDataBase.platformWithGoosePrefab;
            } else {
                prefab = this.GetRandomPlatformPrefab();
            }

            SpawnPlatformLevelItem(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, prefab);
        } 
    }
}
