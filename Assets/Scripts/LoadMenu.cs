using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public GameObject GameControllerScore;

    public Scene nextScene;

    public GameObject loadingScreen;

    public int ProgressIndex;

    void Start()
    {
        if (ES3.FileExists("SaveData.es3"))
        {
            ProgressIndex = ES3.Load<int>("Progress");
        }
        else
        {
            Debug.Log("No hay data");
        }
    }

    private void Update()
    {
        if (GameControllerScore.GetComponent<Test03092019>().timerScore <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ReadySatellite(int sceneIndex)
    {
        if (GameObject.FindWithTag("Trash") != null)
        {
            GameObject trashscore = GameObject.FindWithTag("Trash");
            ES3.Save<int>("ScoreLevel", (GameControllerScore.GetComponent<Test03092019>().score + GameControllerScore.GetComponent<Test03092019>().scoreInSeconds + trashscore.GetComponent<TrashDestructor>().trashScore));
        }
        else
        {
            ES3.Save<int>("ScoreLevel", (GameControllerScore.GetComponent<Test03092019>().score + GameControllerScore.GetComponent<Test03092019>().scoreInSeconds));
        }

        // Guardado de variables
        //ES3.Save<int>("ScoreLevel", (GameControllerScore.GetComponent<Test03092019>().score + GameControllerScore.GetComponent<Test03092019>().scoreInSeconds + trashscore.GetComponent<TrashDestructor>().trashScore));
        ES3.Save<int>("TimerDragInSeconds", GameControllerScore.GetComponent<Test03092019>().timerDragInSeconds);
        ES3.Save<int>("ScoreInSeconds", GameControllerScore.GetComponent<Test03092019>().scoreInSeconds);
        SceneManager.LoadScene(sceneIndex);
    }

    // Cargar nivel nuevo
    public void LoadLevel(int sceneIndex)
    {
        if (ES3.Load<int>("ScoreLevel") >= ES3.Load<int>("ScoreToNextScene"))
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
            ES3.Save<int>("ScoreLevel", 0);
            ES3.Save<int>("TimerDragInSeconds", 0);
            ES3.Save<int>("ScoreInSeconds", 0);
            ES3.Save<int>("Progress", sceneIndex);
        }
    }

    // Cargar mapa nuevo
    public void LoadMapLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        ES3.Save<int>("ScoreLevel", 0);
        ES3.Save<int>("TimerDragInSeconds", 0);
        ES3.Save<int>("ScoreInSeconds", 0);
    }

    // Cargar partida guardada
    public void LoadProgress()
    {
        ES3.Save<int>("ScoreLevel", 0);
        ES3.Save<int>("TimerDragInSeconds", 0);
        ES3.Save<int>("ScoreInSeconds", 0);
        ProgressIndex = ES3.Load<int>("Progress");
        SceneManager.LoadScene(ProgressIndex);
    }

    #region Coroutines
    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadAsynchronously (int sceneIndex)
    {

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadAsynchronously2(int ProgressIndex)
    {

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        //AsyncOperation operation = 
        SceneManager.LoadScene(ES3.Load<int>("Progress"));

        loadingScreen.SetActive(true);
        Debug.Log(ES3.Load<int>("Progress"));

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        //while (!operation.isDone)
        //{
            yield return null;
        //}
    }
    #endregion
}
