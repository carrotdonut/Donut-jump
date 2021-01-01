using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : Platform
{
    public SpriteRenderer platform1;
    public SpriteRenderer platform2;
    public BoxCollider boxCollider;
    public float rotationSpeed = 1f;

    public float breakTime = 2f;


    public float platformFallSpeed = 9.8f;

    public override void PlayerJumpPlatform(PlayerController player) {
        base.PlayerJumpPlatform(player);
        this.BreakPlatform();
    }

    public void BreakPlatform() {
        boxCollider.enabled = false;
        StartCoroutine(DoBreakPlatformAnim());
    }

    private IEnumerator DoBreakPlatformAnim() {
        float counter = 0;

        float platformVelocity = 0;

        while (counter < breakTime) {
            float t = counter / breakTime;

            Color newColor = new Color(platform1.color.r, platform1.color.g, platform1.color.b, 1 - t);
            platform1.color = newColor;
            platform2.color = newColor;

            platform1.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            platform2.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);

            //platformVelocity += this.platformFallSpeed * Time.deltaTime; // if want acceleration
            platformVelocity = this.platformFallSpeed;

            platform1.transform.position -= Vector3.up * platformVelocity * Time.deltaTime;
            platform2.transform.position -= Vector3.up * platformVelocity * Time.deltaTime;

            
            counter += Time.deltaTime;

            yield return null;
        }
        


    }
}
