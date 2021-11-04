using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public string playerWithHighScore;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void SetNewHighScore(int newHighScore)
    {
        highScore = newHighScore;
    }

    public string GetPlayerWithHighScore()
    {
        return playerWithHighScore;
    }

    public void SetNewPlayerWithHighScore(string playerWithNewHighScore)
    {
        playerWithHighScore = playerWithNewHighScore;
    }

    [System.Serializable]
    class HighScoreSaveData
    {
        public int highScore;
        public string playerName;
    }

    public void SaveHighScoreData()
    {
        HighScoreSaveData data = new HighScoreSaveData();
        data.highScore = highScore;
        data.playerName = playerWithHighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreSaveData data = JsonUtility.FromJson<HighScoreSaveData>(json);

            highScore = data.highScore;
            Debug.Log(highScore);
            playerWithHighScore = data.playerName;
            Debug.Log(playerWithHighScore);
        }
    }
}
