using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Text nameText;
    public static Text bestScoreText;
    public static int bestScore;
    public static string bestScoreOwner;
    public static string name;
    public static GameManager gameManager;

    private void Awake()
    {
        if (gameManager!=null)
        {
            Destroy(gameObject);
            return;
        }
        gameManager = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        nameText = GameObject.Find("Name Text").GetComponent<Text>();
        bestScoreText = GameObject.Find("Best Score Text").GetComponent<Text>();
        gameManager.LoadName();

    }

    public void ShowBestScore()
    {
        if (bestScoreOwner!="")
        {
            bestScoreText.text = "Best Score is : " + bestScore + " From : " + bestScoreOwner;

        }
        else
        {
            bestScoreText.text = "There is no best score";
        }

    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveName(string bestScoreName,int bestScore)  // P.S using System.IO required. And we made a class named "SaveData"  and we decleare 1 string and 1 int variable.
    {
        SaveData data = new SaveData();
        data.playerName = bestScoreName;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreOwner = data.playerName;
            bestScore = data.bestScore;

        }
    }

}

