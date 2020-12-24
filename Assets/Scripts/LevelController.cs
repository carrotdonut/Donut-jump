using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject standingGoosePrefab;
    [SerializeField] private PlayerController player;
    protected float previousPlatformY;
    private float[] levelDistances = {20, 300, 500};
    private int level = 1;

    private Level currentLevel;

    // Start is called before the first frame update
    void Start() {
        // Spawn the starting platform underneath the player
        Vector3 spawnPosition = player.transform.position + new Vector3(0, -2, 0);
        Quaternion spawnRotation = Quaternion.identity; // Rotation (0,0,0)

        previousPlatformY = player.transform.position.y - 2;
        
        Instantiate<GameObject>(platformPrefab, spawnPosition, spawnRotation);

        // Initialize the level to level 1
        currentLevel = new Level1(platformPrefab, player, previousPlatformY);
    }

    // Update is called once per frame
    void Update() {
        // Spawn platforms/monsters for the current level
        currentLevel.spawn();

        // Update the level based on the player's height
        if (player.transform.position.y >= levelDistances[level - 1]) {
            level++;

            switch(level) {
            case 2:
                currentLevel = new Level2(platformPrefab, standingGoosePrefab, player, currentLevel.getPreviousPlatformY());
                break;
            }
        }
    }
}
