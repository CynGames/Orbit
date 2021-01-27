using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicMenuController : MonoBehaviour
{
    public static MusicMenuController Instance;

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
        if ((SceneManager.GetActiveScene().name != ("MainMenu")) && (SceneManager.GetActiveScene().name != ("SoloMenu")))
        {
            Destroy(gameObject);
        }
    }
}
