using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject GameControllerScore;
    public GameObject RulesSprite;
    public int timeFlag;

    public Scene nextScene;

    public int indexMapMenu;

    // Start is called before the first frame update
    void Start()
    {
        RulesSprite.SetActive(false);
        indexMapMenu = GlobalControl.Instance.indexMapMenu;
    }

    private void Update()
    {
        if(GameControllerScore.GetComponent<Test03092019>().timerScore <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SoloMenu()
    {
        Debug.Log("clickSoloMenu");
        SceneManager.LoadScene("SoloMenu");
    }

    public void Gameplay()
    {
        GlobalControl.Instance.score = 0;
        GlobalControl.Instance.scoreInSeconds = 0;
        Debug.Log("clickGameplay");
        SceneManager.LoadScene("Gameplay");         
    }

    public void MainMenu()
    {
        Debug.Log("clickMainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void ResultsMenu()
    {
        GlobalControl.Instance.scoreInSeconds = GameControllerScore.GetComponent<Test03092019>().scoreInSeconds;
        GlobalControl.Instance.score = GameControllerScore.GetComponent<Test03092019>().score + GameControllerScore.GetComponent<Test03092019>().scoreInSeconds;
        Debug.Log("clickResultsMenu");
        SceneManager.LoadScene("ResultsMenu");
    }


    public void HelpButton()
    {
        Debug.Log("ClickEnHelp");
        if (RulesSprite.activeInHierarchy == false)
        {
            RulesSprite.SetActive(true);
        }
        else
        {
            RulesSprite.SetActive(false);
        }
    }

    public void TutorialMenu()
    {
        Debug.Log("clickTutorialMenu");
        SceneManager.LoadScene("TutorialMap");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void WelcomeOn()
    {
        SceneManager.LoadScene("Welcome");
    }

    public void MapMenu0()
    {
        SceneManager.LoadScene("MapMenu" + indexMapMenu.ToString());
    }


    public void NextMethodMap1()
    {
        SceneManager.LoadScene("MapMenu6");
    }

    public void NextMethodMap2()
    {
        SceneManager.LoadScene("MapMenu11");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
