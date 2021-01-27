using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OneVSOneController : MonoBehaviour
{
    //public static OneVSOneController Instance;

    public GameObject loadingScreen;
    int levelSelect;
    int[] levelsIndex = { 88, 89, 90 };
    int LevelToPlay;
    int ResultsMenu = 87;
    int MainMenu = 1;

    //public int playerCount;

    /*private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //levelSelect = Random.Range(0, levelsIndex.Length);
        //ES3.Save<int>("LevelToPlay", levelsIndex[levelSelect]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Level1vs1()
    {
        ES3.Save<int>("PlayerCount", 0);
        //playerCount = 0;
        //Debug.Log(levelsIndex[levelSelect]);
        ES3.Save<int>("Player1Points", 0);
        ES3.Save<int>("Player2Points", 0);
        //ES3.Load<int>("LevelToPlay");
        levelSelect = Random.Range(0, levelsIndex.Length);
        ES3.Save<int>("LevelToPlay", levelsIndex[levelSelect]);
        LevelToPlay = ES3.Load<int>("LevelToPlay");
        StartCoroutine(LoadAsynchronously(LevelToPlay));
    }

    public void PlayAgain1vs1()
    {
        //playerCount = playerCount + 1;
        //ES3.Load<int>("PlayerCount");
        ES3.Save<int>("PlayerCount", 1);
        ES3.Load<int>("LevelToPlay");
        StartCoroutine(LoadAsynchronously(LevelToPlay));
    }

    public void Random1vs1()
    {
        //playerCount = 0;
        levelSelect = Random.Range(0, levelsIndex.Length);
        ES3.Save<int>("LevelToPlay", levelsIndex[levelSelect]);

        //ES3.Load<int>("PlayerCount");
        ES3.Save<int>("PlayerCount", 0);

        ES3.Save<int>("Player1Points", 0);
        ES3.Save<int>("Player2Points", 0);

        StartCoroutine(LoadAsynchronously(LevelToPlay));
    }

    public void BackToMenu()
    {
        ES3.Save<int>("PlayerCount", 0);

        ES3.Save<int>("Player1Points", 0);
        ES3.Save<int>("Player2Points", 0);

        StartCoroutine(LoadAsynchronously3(MainMenu));
    }

    public void PlayButton()
    {
        if (ES3.Load<int>("PlayerCount") == 0)
        {
            ES3.Save<int>("Player1Points", ES3.Load<int>("ScoreLevel"));
            StartCoroutine(LoadAsynchronously2(ResultsMenu));
        }

        if (ES3.Load<int>("PlayerCount") == 1)
        {
            ES3.Save<int>("Player2Points", ES3.Load<int>("ScoreLevel"));
            StartCoroutine(LoadAsynchronously2(ResultsMenu));
        }
    }

    IEnumerator LoadAsynchronously(int LevelToPlay)
    {

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation operation = SceneManager.LoadSceneAsync(ES3.Load<int>("LevelToPlay"));

        loadingScreen.SetActive(true);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadAsynchronously2(int ResultsMenu)
    {

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation operation = SceneManager.LoadSceneAsync(87);

        loadingScreen.SetActive(true);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadAsynchronously3(int MainMenu)
    {

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        loadingScreen.SetActive(true);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
