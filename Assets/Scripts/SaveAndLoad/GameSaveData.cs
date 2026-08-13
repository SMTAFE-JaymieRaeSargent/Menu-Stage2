using UnityEngine;

[System.Serializable]
public class GameSaveData
{
    public string name;
    public int level;
    public float currentHealth;
    public int maxHealth;
    public Vector3 playerPosition;
    public Vector3 playerRotation;
    public string systemTimeDate;
}
