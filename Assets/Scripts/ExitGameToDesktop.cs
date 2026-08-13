using UnityEditor;
using UnityEngine;

public class ExitGameToDesktop : MonoBehaviour
{
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
