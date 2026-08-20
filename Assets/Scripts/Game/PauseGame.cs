using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameSaveAndLoad saveAndLoad;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pause and Save (pause dont work yet)");
            saveAndLoad.SaveGame();
        }
    }
}
