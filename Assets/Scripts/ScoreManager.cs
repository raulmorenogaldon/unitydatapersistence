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
    class ScoreData
    {
        public int highScore;
        public string highScorePlayerName;
        public string lastPlayerName;
    }

    private ScoreData scoreData;

    public void SetLastPlayerName(string lastPlayerName)
    {
        scoreData.lastPlayerName = lastPlayerName;

        // Save changes to data
        SaveData();
    }

    public string GetLastPlayerName()
    {
        return scoreData.lastPlayerName;
    }

    public void SaveData()
    {
        if(scoreData != null)
        {
            string savePath = Application.persistentDataPath + "/score.json";

            // Save data to disk
            string json = JsonUtility.ToJson(scoreData);
            File.WriteAllText(savePath, json);
        }
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

            // Initialize score data
            scoreData = new ScoreData();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
