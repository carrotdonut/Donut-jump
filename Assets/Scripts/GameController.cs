using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Per scene
public class GameController : MonoBehaviour {
    public CameraController mainCamera;
    public PlayerController player;
    public SprinkleController sprinkles;
    public Text scoreText;

    private int cookieCounter;

    // Same as Start, except it is called before Start()
    void Awake() {
        GameManager.Instance.gameController = this;
    }

    void Start() {
        scoreText.text = "Score: " + 0;
        cookieCounter = 0;
    }
    public void IncrementCookieCounter() {
        cookieCounter++;
    }

}
