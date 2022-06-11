using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Text nameText;
    public Text bestScoreText;
    void Start()
    {
        bestScoreText = GameObject.Find("Best Score Text").GetComponent<Text>();
        if (GameManager.bestScoreOwner != "")
        {
            bestScoreText.text = "Best Score is : " + GameManager.bestScore + " From : " + GameManager.bestScoreOwner;

        }
        else
        {
            bestScoreText.text = "There is no best score";
        }
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TakePlayerName()   // take input to name...
    {
        name = nameText.text.ToString();
        GameManager.name = name;
    }

}
