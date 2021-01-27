using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WelcomeMusic: MonoBehaviour
{
    public static WelcomeMusic Instance;

    public string sceneName;

    void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("Creando MUSIC CONTROLLER");
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("Music MURIO");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == ("Level01"))
        {
            Destroy(gameObject);
        }
    }
}