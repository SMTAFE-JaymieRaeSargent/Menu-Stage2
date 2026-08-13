using UnityEngine;

public class GameSceneLoadIn : MonoBehaviour
{
    public GameSaveAndLoad saveAndLoad;

    void Awake()
    {
        saveAndLoad = GetComponent<GameSaveAndLoad>();
        saveAndLoad.LoadGame();
    }
    
}
