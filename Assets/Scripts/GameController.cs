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
    public Text cookieScoreText;
    private float score;
    private int cookieCounter;

    // Same as Start, except it is called before Start()
    void Awake() {
        GameManager.Instance.gameController = this;
    }

    void Start() {
        scoreText.text = "Score: " + 0;
        cookieScoreText.text = "" + 0;
        score = 0;
        cookieCounter = 0;
    }

    public void IncrementCookieCounter() {
        cookieCounter++;
        cookieScoreText.text = "" + cookieCounter;
    }

    public void IncreaseScore(float score) {
        this.score += score;
        scoreText.text = "Score: " + Mathf.RoundToInt(this.score);
    }

}
