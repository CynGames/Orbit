using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeController : MonoBehaviour
{
    public GameObject[] Dialogos;
    public int i;
    public GameObject TocarParaComenzar;
    public GameObject TocarParaSeguir;

    // Start is called before the first frame update
    void Start()
    {
        TocarParaComenzar.SetActive(false);

        Dialogos[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(i < 3)
            {
                i = i + 1;
                Dialogos[i].SetActive(true);
                Dialogos[i - 1].SetActive(false);
            }
            if (i == 3)
            {
                TocarParaComenzar.SetActive(true);
                TocarParaSeguir.SetActive(false);
            }
        }
    }

    public void RuleOne()
    {
        SceneManager.LoadScene("RuleOne");
    }
}
