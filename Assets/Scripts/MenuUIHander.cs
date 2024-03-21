using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHander : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button startButton;
    public Button exitButton;
    public static MenuUIHander Instance;
    public string playerName;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        nameInput.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        MenuUIHander.Instance.playerName = nameInput.text;
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        nameInput.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
