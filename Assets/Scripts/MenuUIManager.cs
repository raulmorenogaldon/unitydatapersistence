using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private Button startButton;

    public void StartGame()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
