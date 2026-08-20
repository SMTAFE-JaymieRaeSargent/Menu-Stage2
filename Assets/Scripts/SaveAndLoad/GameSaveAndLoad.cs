using UnityEngine;
using System.IO;
public class GameSaveAndLoad : MonoBehaviour
{
    string _selectedFilePath = $"{Application.dataPath}/SelectedSlot.json";
    string _filePath = "";
    public GameSaveData data = new GameSaveData();
    public GameObject player;
    public GameObject camera;
    public void GetSelectedFilePath()
    {
        string temp = File.ReadAllText(_selectedFilePath);
        _filePath = $"{Application.dataPath}/{temp}.json";
    }
    #region Save
    void GetDataToSave()
    {
        if (player == null)
        {
            return;
        }
        data.name = player.name;
        data.playerPosition = player.transform.position;
        data.playerRotation = player.transform.rotation.eulerAngles;
        data.cameraRotation = new Vector3(camera.transform.localRotation.eulerAngles.x, 0, 0); // not working 
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
        if (!player)
        {
            return;
        }
        // DO THIS LATER
        player.GetComponent<CharacterController>().enabled = false;
        player.name = data.name;
        player.transform.position = data.playerPosition;
        player.transform.rotation = Quaternion.Euler(data.playerRotation);
        camera.transform.localRotation = Quaternion.Euler(new Vector3(data.cameraRotation.x,0,0)); //not working
        player.GetComponent<CharacterController>().enabled = true;
    }
    public void LoadGame()
    {
        GetSelectedFilePath();
        data = LoadDataFromJson();
        SendDataFromLoad();
    }
    #endregion End Load
}
