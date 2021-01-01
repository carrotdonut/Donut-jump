using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : Item {
    public override void GetItem() {
        GameManager.Instance.gameController.IncrementCookieCounter();
    }
}
