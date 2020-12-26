using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameController gameController;
    // public static MusicController musicController;
    // public static DataController dataController;
    // public static PrefabDatabase prefabDataBase;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
