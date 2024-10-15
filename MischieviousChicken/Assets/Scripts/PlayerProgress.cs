using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.IO;
using System;

public class PlayerProgressScript : MonoBehaviour
{
    public static PlayerProgressScript instance;

    public int coins;
    public int keys;
    public int levelsDefeated;

    private string filePath;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Path.Combine(Application.persistentDataPath, "player_data.json");
        LoadData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }

    private void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            coins = 0;
            keys = 0;
            levelsDefeated = 0;
            SaveData();
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveData();
    }

    public void AddKeys(int amount)
    {
        keys += amount;
        SaveData();
    }

    public void DefeatLevel()
    {
        levelsDefeated++;
        SaveData();
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetKeys()
    {
        return keys;
    }

    public int GetLevelsDefeated()
    {
        return levelsDefeated;
    }
}