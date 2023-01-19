using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private Button startButton;

    public void StartGame()
    {
        // Set player name
        ScoreManager.Instance.SetLastPlayerName(nameField.text);

        SceneManager.LoadScene(1);
    }

    public void ChangedName()
    {
        if (string.IsNullOrEmpty(nameField.text))
        {
            startButton.interactable = false;
            //ScoreManager.Instance.scoreData.lastPlayerName = 
            //string inputName = nameField.text;
        }
        else
        {
            startButton.interactable = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load previous data
        ScoreManager.Instance.LoadData();

        string lastPlayerName = ScoreManager.Instance.GetLastPlayerName();
        if (lastPlayerName != null) nameField.text = lastPlayerName;
    }

    public void Exit()
    {
        // Save Data
        ScoreManager.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
