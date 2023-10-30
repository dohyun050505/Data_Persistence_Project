using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIFunctions : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI bestScore;
    // Start is called before the first frame update
    void Start()
    {
        PersistenceManager.LoadRecord();
        nameInput = GameObject.Find("NameInput").GetComponent<TMP_InputField>();
        bestScore=GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
        if (PersistenceManager.recordScore == 0)
        {
            bestScore.text = "Best Score : 0";
        }
        else
        {
            bestScore.text = "Best Score : " + PersistenceManager.recordScore + " by " + PersistenceManager.recordUserName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        PersistenceManager.currentUserName = nameInput.text;
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
