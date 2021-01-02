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
        // Every time the player jumps on a platform and moves upwards, we spawn new platforms
        // We only spawn platforms up to a certain Y distance above the player
        
        if (base.ShouldUpdateLevel()) {
            GameObject prefab = this.GetPlatformPrefab();
            SpawnPlatformLevelItem(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, prefab);
        } 
    }

    protected override GameObject GetPlatformPrefab(){
        GameObject prefab = null;

        // For the first platform spawned in level 2, we want to spawn a goose on top
        if (!firstGooseSpawned || Random.Range(0.0f, 1.0f) < 0.2f) {
            prefab = GameManager.Instance.prefabDataBase.platformWithGoosePrefab;
            firstGooseSpawned = true;
        } else {
            // Else, we'll spawn 50% normal platforms, 30% geese platforms, and 20% breaking platforms
            float rand = Random.Range(0.0f, 1.0f);
            if (rand < 0.5) {
                prefab = GameManager.Instance.prefabDataBase.platformPrefab;
            } else if (0.5 <= rand && rand < 0.8) {
                prefab = GameManager.Instance.prefabDataBase.platformWithGoosePrefab;
            } else {
                prefab = GameManager.Instance.prefabDataBase.brokenPlatformPrefab;
            }
        }

        return prefab;
    }
}
