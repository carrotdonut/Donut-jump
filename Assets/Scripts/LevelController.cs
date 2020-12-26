using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public float[] levelDistances = {20, 300, 500};
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject standingGoosePrefab;
    
    protected float previousSpawnedPlatformY;
    private int level = 1;

    private Level currentLevel;
    private PlayerController player;

    // Start is called before the first frame update
    void Start() {
        this.player = GameManager.gameController.player;
        previousSpawnedPlatformY = this.player.transform.position.y - 2;
        
        // Initialize the level to level 1
        currentLevel = new Level1(platformPrefab, player, previousSpawnedPlatformY);
    }

    // Update is called once per frame
    void Update() {
        // Spawn platforms/monsters for the current level
        currentLevel.UpdateLevel();

        // Update the level based on the player's height
        if (player.transform.position.y >= levelDistances[level - 1]) {
            level++;

            switch(level) {
                case 2:
                    currentLevel = new Level2(platformPrefab, standingGoosePrefab, player, currentLevel.GetPreviousSpawnedPlatformY());
                    break;
                }
        }
    }
}
