using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level {
    protected GameObject platformPrefab;
    protected PlayerController player;
    protected float previousPlatformY;
    protected float minDistanceBetweenPlatform;
    protected float maxDistanceBetweenPlatform;

    protected const float maxDistanceAbovePlayer = 10;

   public Level(GameObject platformPrefab, PlayerController player, float previousPlatformY) {
       this.platformPrefab = platformPrefab;
       this.player = player;
       this.previousPlatformY = previousPlatformY;
   }

   public float getPreviousPlatformY() {
       return previousPlatformY;
   }

   public abstract void spawn();

    public GameObject spawnPlatform(float minPlatformY, float maxPlatformY, string item = "") {
        float newPlatformY = Random.Range(minPlatformY, maxPlatformY);
        float newPlatformX = Random.Range(-2.5f, 2.5f);

        Vector3 spawnPosition = new Vector3(newPlatformX, newPlatformY, 0);
        Quaternion spawnRotation = Quaternion.identity; // Rotation (0,0,0)

        return GameObject.Instantiate<GameObject>(platformPrefab, spawnPosition, spawnRotation);
    }

    public GameObject spawnMonsterStationary(float x, float y) {
        return new GameObject();
    }

    public GameObject spawnMonsterMovingHorizontal(float y) {
        return new GameObject();
    }

    public GameObject spawnMonsterMovingZigZag(float y) {
        return new GameObject();
    }
}
