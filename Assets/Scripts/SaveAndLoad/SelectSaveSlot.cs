using System.IO;
using UnityEngine;

public class SelectSaveSlot : MonoBehaviour
{
    [SerializeField] string _selectedFilePath = $"{Application.dataPath}/SelectedSlot.json";

    public void SaveSelectedPath(string saveSlotName)
    {
        File.WriteAllText(_selectedFilePath, saveSlotName);
    }
}
