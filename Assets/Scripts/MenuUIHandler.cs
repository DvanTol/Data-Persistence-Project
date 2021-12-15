using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public static string userName;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTextEntry()
    {
        userName = inputField.GetComponent<TMP_InputField>().text;
        Score.instance.username = userName;
        Debug.Log("username: " + userName);
    }

    public void ResetHighScore()
    {
        Score.instance.highScore = 0;
        Score.instance.highScoreName = "";
        Score.instance.SaveHighScore();
    }

}
