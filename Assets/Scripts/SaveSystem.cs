using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public const string FILENAME_SAVEDATA = "/savedata.json";

    public static void SaveGameState()
    {
        string filePathSaveData = Application.persistentDataPath + FILENAME_SAVEDATA;
        
        LogicScript logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        SaveData saveData = new SaveData(logic.highScore);
        string txt = JsonUtility.ToJson(saveData);
        File.WriteAllText(filePathSaveData, txt);
    }

    public static SaveData LoadGameData()
    {
        try
        {
            string filePathSaveData = Application.persistentDataPath + FILENAME_SAVEDATA;
            string fileContent = File.ReadAllText(filePathSaveData);
            SaveData saveData = JsonUtility.FromJson<SaveData>(fileContent);
            return saveData;
        }
        catch
        {
            return null;
        }
    }
}

[Serializable]
public class SaveData
{
    [SerializeField] public int highScore;
    public SaveData(int playerScore)
    {
        this.highScore = playerScore;
    }
}