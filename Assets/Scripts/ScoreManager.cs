using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    public static ScoreManager Instance;

    [System.Serializable]
    public class ScoreData
    {
        int highScore;
        string highScorePlayerName;
        string lastPlayerName;
    }

    public ScoreData scoreData;

    public void SaveData()
    {
        string savePath = Application.persistentDataPath + "/score.json";

        // Save data to disk
        string json = JsonUtility.ToJson(scoreData);
        File.WriteAllText(savePath, json);
    }

    public void LoadData()
    {
        string savePath = Application.persistentDataPath + "/score.json";

        // Get data from disk
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
    }

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
