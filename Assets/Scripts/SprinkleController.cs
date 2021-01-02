
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SprinkleController : MonoBehaviour {
    // Sprinkle colors to cycle through
    private Color[] colors = {Color.green, Color.red, Color.cyan, Color.yellow, Color.white};
    private sbyte colorIndex = 0;

    public void CreateSprinkle() {
        GameObject sprinklePrefab = GameManager.Instance.prefabDataBase.sprinklePrefab;
        sprinklePrefab.GetComponent<SpriteRenderer>().color = colors[colorIndex]; // Set the color of the sprinkle

        Vector3 playerPosition = GameManager.Instance.gameController.player.GetPosition();
        playerPosition.y = playerPosition.y + 1; // Put the sprinkle right above the donut

        Instantiate(sprinklePrefab, playerPosition, Quaternion.identity);
        colorIndex = (sbyte)((colorIndex + 1) % colors.Length);
    }
}