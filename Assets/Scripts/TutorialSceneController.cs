using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSceneController : MonoBehaviour
{

    public int clickSceneChange;
    public GameObject clickStart;

    // Start is called before the first frame update
    void Start()
    {
        clickSceneChange = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickSceneChange = clickSceneChange + 1;
        }

        if (clickSceneChange == 10)
        {
            clickStart.SetActive(true);
        }

        if (clickSceneChange == 11)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
