using UnityEngine;
using System.IO;
public class GameSaveAndLoad : MonoBehaviour
{
    string _selectedFilePath = $"{Application.dataPath}/SelectedSlot.json";
    string _filePath = "";
    public GameSaveData data = new GameSaveData();

    public void GetSelectedFilePath()
    {
        string temp = File.ReadAllText(_selectedFilePath);
        _filePath = $"{Application.dataPath}/{temp}.json";
    }
    #region Save
    void GetDataToSave()
    {
        //GET LATER
    }
    void SaveGameDataToJSon(GameSaveData _data, string path)
    {
        string lineToSave = JsonUtility.ToJson(_data);
        File.WriteAllText(path, lineToSave);
    }
    public void SaveGame()
    {
        GetSelectedFilePath();
        GetDataToSave();
        SaveGameDataToJSon(data, _filePath);
    }
    #endregion End Save
    #region Load
    GameSaveData LoadDataFromJson()
    {
        string loadedDataFromFile = File.ReadAllText(_filePath);
        return JsonUtility.FromJson<GameSaveData>(loadedDataFromFile);
    }
    void SendDataFromLoad()
    {
        // DO THIS LATER
    }
    public void LoadGame()
    {
        GetSelectedFilePath();
        data = LoadDataFromJson();
        SendDataFromLoad();
    }
    #endregion End Load
}
