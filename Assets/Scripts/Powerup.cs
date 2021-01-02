using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public string powerupName;
    public float duration = 5f;
    public bool isTimed = true;

    protected PlayerController player;
    protected float durationCounter = 0;

    protected bool hasInitialized = false;

    public void Initialize(PlayerController player) {
        this.hasInitialized = true;
        this.player = player;

        this.OnInitialize();
    }

    public virtual void OnInitialize() {
        this.player.AddActivePowerup(this);
    }

    void Update() {
        if (hasInitialized) {
            this.OnUpdate();
        }
    }

    public virtual void OnUpdate() {
        if (this.isTimed) {
            this.durationCounter += Time.deltaTime;

            if (this.durationCounter >= duration) {
                this.OnRemovePowerup();
                Destroy(this.gameObject);        
            }
        }

    }

    public virtual void OnRemovePowerup() {
        this.player.RemovePowerup(this);
    }
}
