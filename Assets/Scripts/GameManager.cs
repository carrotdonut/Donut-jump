using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameController gameController {get; set;}
    // public static MusicController musicController;
    // public static DataController dataController;
    public PrefabDatabase prefabDataBase;
}
