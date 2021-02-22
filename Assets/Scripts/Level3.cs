using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Level3: Level {
    private bool firstFlyingGooseSpawned = false;
    private bool firstJetpackSpawned = false;

    private DateTime nextJetpackCanSpawn;
   public Level3(PlayerController player, float previousSpawnedPlatformY): 
   base(player, previousSpawnedPlatformY) {
       minDistanceBetweenPlatform = 2f;
       maxDistanceBetweenPlatform = 4.5f;

       // We'll spawn 5% basic platforms, 30% cookie platforms, 30% geese platforms, and 35% breaking platforms in level 3
       normalPlatformRate = 0.05f;
       cookiePlatformRate = 0.3f;
       goosePlatformRate = 0.25f;
       brokenPlatformRate = 0.3f;
       jetpackPlatformRate = 0.1f;
       Debug.Log("Level 3");
   }

    public override void UpdateLevel() {
        // Every time the player jumps on a platform and moves upwards, we spawn new platforms
        // We only spawn platforms up to a certain Y distance above the player

        GameObject prefab = null;
        
        if (base.ShouldUpdateLevel()) {
            // At the beginning of the level, we want to spawn a flying goose 20% of the time that flies horizontally
            // Throughout the level, we want to continuously randomly spawn flying geese and geese on platforms
            if (!firstFlyingGooseSpawned || UnityEngine.Random.Range(0.0f, 1.0f) < 0.2f) {
                float y = UnityEngine.Random.Range(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY);
                prefab = GameManager.Instance.prefabDataBase.flyingGoosePrefab;
                SpawnLevelItem(y, prefab);
                firstFlyingGooseSpawned = true;
            }

            if (!firstJetpackSpawned) {
                prefab = GameManager.Instance.prefabDataBase.platformWithJetpackPrefab;
                firstJetpackSpawned = true;
                nextJetpackCanSpawn = DateTime.Now.AddMinutes(2);
            } else {
                if (DateTime.Now < nextJetpackCanSpawn) {
                    jetpackPlatformRate = 0;
                    goosePlatformRate = 0.35f;
            
                } else {
                    jetpackPlatformRate = 0.1f;
                    goosePlatformRate = 0.25f;
                }

                prefab = this.GetPlatformPrefabWithSpawnRate();

                if (prefab == GameManager.Instance.prefabDataBase.platformWithJetpackPrefab) {
                    nextJetpackCanSpawn = DateTime.Now.AddMinutes(2);
                }
            }
                        
            SpawnPlatformLevelItem(minDistanceBetweenPlatform + previousSpawnedPlatformY, maxDistanceBetweenPlatform + previousSpawnedPlatformY, prefab);
        } 
    }
}
