using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Per scene
public class PrefabDatabase : MonoBehaviour {
    public GameObject platformPrefab;
    public GameObject brokenPlatformPrefab;
    public GameObject platformWithGoosePrefab;
    public GameObject platformWithCookiePrefab;
    public GameObject platformWithJetpackPrefab;
    public GameObject flyingGoosePrefab;
    public GameObject sprinklePrefab;
    
    public List<GameObject> GetPlatformPrefabs() {
        return new List<GameObject>{
            platformPrefab,
            platformWithCookiePrefab,
            platformWithGoosePrefab,
            brokenPlatformPrefab,
            platformWithJetpackPrefab,
        };
    }
}