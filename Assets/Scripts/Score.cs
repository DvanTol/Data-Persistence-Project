using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int highScore;
    public string username;
    public string highScoreName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }





    // save the username and highscore between sessions
    [System.Serializable] // needed to use JSON utility later on
    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);
        // The 1st parameter is where the file will be stored, the 2nd parameter is what to store.
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // need using statement at the top: using System.IO; 

        Debug.Log("highscore saved: " + highScore + " " + highScoreName);
    }

    public void LoadHighScore() // reversal of the SaveUsernameScore method
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;

            Debug.Log("highscore loaded: " + highScore + " " + highScoreName);
        }
    }
}
