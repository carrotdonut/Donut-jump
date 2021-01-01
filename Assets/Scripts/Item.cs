using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.GetItem();
        }
    }

    public virtual void GetItem() {}
}
