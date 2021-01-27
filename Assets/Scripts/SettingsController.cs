using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    public GameObject GameController;

    // Canvas
    public Canvas pauseUI;
    public Canvas gameUI;

    // Music and Effects Controller
    public Text effectsText;
    public AudioSource[] effects;
    public Text musicText;
    public AudioSource music;
    public bool statusEffects;

    int i = 0;

    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Start()
    {
        statusEffects = ES3.Load<bool>("EffectStatus");
        music.mute = ES3.Load<bool>("MusicStatus");


        if (ES3.Load<bool>("EffectStatus") == true)
        {
            effectsText.text = ("EFECTOS: NO");
        }
        else
        {
            effectsText.text = ("EFECTOS: SI");
        }


        if (ES3.Load<bool>("MusicStatus") == true)
        {
            musicText.text = ("MÚSICA: NO");
        }
        else
        {
            musicText.text = ("MÚSICA: SI");
        }


        pauseUI.gameObject.SetActive(false);

        for (i = 0; i < effects.Length; i++)
        {
            effects[i].GetComponent<AudioSource>();
            effects[i].mute = ES3.Load<bool>("EffectStatus");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Pause
    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
        GameController.GetComponent<Test03092019>().enabled = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        if(GameController.GetComponent<Test03092019>().scriptIsActive == false)
        {
            GameController.GetComponent<Test03092019>().enabled = false;
        }
        else
        {
            GameController.GetComponent<Test03092019>().enabled = true;
        }
    }

    public void MusicStatus()
    {
        music.mute = !music.mute;
        ES3.Save<bool>("MusicStatus", music.mute);
        if (ES3.Load<bool>("MusicStatus") == true)
        {
            musicText.text = ("MÚSICA: NO");
        }
        else
        {
            musicText.text = ("MÚSICA: SI");
        }
    }

    public void EffectsStatus()
    {
        for (i = 0; i < effects.Length; i++)
        {
            effects[i].mute = !effects[i].mute;
            if(effects[i].mute == true)
            {
                effectsText.text = ("EFECTOS: NO");
                ES3.Save<bool>("EffectStatus", statusEffects);
            }
            else
            {
                effectsText.text = ("EFECTOS: SI");
                ES3.Save<bool>("EffectStatus", statusEffects);
            }
        }
        i = 0;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
