using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    // Score
    public int score;
    public int scoreInSeconds;
    public int scoreToNextScene;
    public int timerDragInSeconds; 
    public Test03092019 scriptPrincipal;

    // Map Menu
    public int sceneIndex;
    public int indexMapMenu;

    // Settings Controller
    //public SettingsController scriptSettingsController;
    public bool statusEffects;
    public bool statusMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("Creando");
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("Destruir extra");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.sceneLoaded += OnSceneLoaded;
        //FindObjectOfType<CanvasScaler>().matchWidthOrHeight = 1;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (FindObjectOfType<BoxInteractController>() != null)
        {
            FindObjectOfType<CanvasScaler>().matchWidthOrHeight = 1;
        }
    }

    private void Update()
    {
        
    }
}
