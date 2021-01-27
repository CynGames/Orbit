using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test03092019 : MonoBehaviour
{
    // Variables de nivel
    public int indexMapMenu;

    // Variables Settings Controller
    public bool statusEffects;
    public bool statusMusic;
    public bool scriptIsActive;
    public int scoreToNextScene;

    // Modo de juego
    public bool isDrawLines = false;

    // Score
    public int timerDragInSeconds;
    public int score;
    public float timerScore;
    public int scoreInSeconds;
    public Text TimeScoreText;
    public bool isConnectUsed;
    public GameObject GameController;
    public GameObject BackgroundPlane;
    public bool connectReady;

    // Listas de GameObjects
    public List<GameObject> allLines = new List<GameObject>();

    // Componentes
    private LineRenderer lr;
    private Transform trans;
    private Transform transLr;
    private MeshCollider msCol;
    private MeshCollider msColCall;
    public Material correctColor;
    public Material wrongColor;
    public AudioSource correctSound;
    public AudioSource wrongSound;

    // Variables
    private float contLimit;
    private float distance;
    public float clicks;
    private string tag1;
    private string tag2;
    Vector3 start;
    Vector3 finish;
    Vector3 toCompare0;
    Vector3 toCompare1;
    private bool checkFigures = false;
    public int tCounter;
    public bool canDrawLine;

    private GameObject checkCollider1;
    private GameObject checkCollider2;

    void Start()
    {
        ES3.Save<float>("TimerScore", timerScore);
        ES3.Save<int>("ScoreToNextScene", scoreToNextScene);

        scriptIsActive = true;

        //Llamar al componente
        lr = GetComponent<LineRenderer>();
        trans = GetComponent<Transform>();
        msCol = GetComponent<MeshCollider>();
        transLr = GetComponent<Transform>();

        timerDragInSeconds = GameController.GetComponent<EnableConnect>().timerDragInSeconds;

    }

    void Update()
    {
        // Guardado de variables
        //ES3.Save<int>("ScoreLevel", (score + scoreInSeconds));
        //ES3.Save<int>("TimerDragInSeconds", timerDragInSeconds);
        //ES3.Save<int>("ScoreInSeconds", scoreInSeconds);

        statusEffects = GameController.GetComponent<SettingsController>().statusEffects;
        statusMusic = GameController.GetComponent<SettingsController>().music.mute;
        scoreInSeconds = (int)(timerScore);
        TimeScoreText.text = scoreInSeconds.ToString();

        if (isDrawLines == false)
        {
            // Cuando hacemos click con el boton del mouse ejecutamos ObjectsUnion
            if ((Input.GetMouseButtonDown(0)))
            {
                ObjectsUnion();
            }
        }
        else
        {
            // Cuando hacemos click con el boton del mouse ejecutamos ObjectsUnion
            if ((Input.GetMouseButtonDown(0)))
            {
                ObjectsUnion();
            }

            // Soltamos click y vuelve a ejecutar ObjectsUnion
            if (Input.GetMouseButtonUp(0))
            {
                ObjectsUnion();
            }
        }

        if (clicks == 2)
        {
            if (start != finish)
            {
                CompatibleCheck();
                if (checkFigures == true)
                {
                    canDrawLine = FCanDrawLine();
                    if (canDrawLine)
                    {
                        SpawnLineGenerator();
                        clicks = 0;
                        checkCollider1 = GameObject.FindWithTag(tag1);
                        checkCollider1.transform.position = new Vector3((checkCollider1.transform.position.x + 0.001f), checkCollider1.transform.position.y, checkCollider1.transform.position.z);
                        checkCollider2 = GameObject.FindWithTag(tag2);
                        checkCollider2.transform.position = new Vector3((checkCollider2.transform.position.x + 0.001f), checkCollider2.transform.position.y, checkCollider1.transform.position.z);
                        checkFigures = false;
                    }
                    
                    

                }
                else
                {
                    canDrawLine = FCanDrawLine();
                    if (canDrawLine)
                    {
                        SpawnLineGeneratorWrong();
                        clicks = 0;
                        checkFigures = false;
                    }
                }
            }
            else
            {
                clicks = 0;
            }
        }
        TimeScore();
    }

    #region LineCreation

    bool FCanDrawLine()
    {
        canDrawLine = true;
        if (allLines.Count > 0)
        {
            tCounter = 0;

            while ((canDrawLine) && (tCounter < allLines.Count))
            {
                // tCounter es el contador que va a pasar por todas las lineas creadas
                // toCompare0 hace referencia a la posicion 0
                // toCompare1 hace referencia a la posicion 1

                // Tomamos la posicion 0 de la linea
                toCompare0 = allLines[tCounter].GetComponent<LineRenderer>().GetPosition(0);
                // Tomamos la posicion 1 de la linea
                toCompare1 = allLines[tCounter].GetComponent<LineRenderer>().GetPosition(1);

                // Start con 0 y Finish con 1 para probar la misma posicion

                float dist0 = Mathf.Abs(toCompare0.x - start.x);
                float dist1 = Mathf.Abs(toCompare0.y - start.y);
                float dist2 = Mathf.Abs(toCompare1.x - finish.x);
                float dist3 = Mathf.Abs(toCompare1.y - finish.y);
                // Start con 1 y Finish con 0 para probar al reves
                float dist4 = Mathf.Abs(toCompare1.x - start.x);
                float dist5 = Mathf.Abs(toCompare1.y - start.y);
                float dist6 = Mathf.Abs(toCompare0.x - finish.x);
                float dist7 = Mathf.Abs(toCompare0.y - finish.y);


                // Preguntamos si la distancia entre las comparaciones de
                // start y finish en la misma posicion son menores a 0.01f


                if (((dist0 < 0.01f) && (dist1 < 0.01f) && (dist2 < 0.01f) && (dist3 < 0.01f)) || ((dist4 < 0.01f) && (dist5 < 0.01f) && (dist6 < 0.01f) && (dist7 < 0.01f)))
                {
                    canDrawLine = false;
                    Debug.Log("No se puede");
                    clicks = 0;
                }
                tCounter++;
            }
        }
        return canDrawLine;
    }

    // Esta funcion se utiliza para dar un inicio y fin de la linea a dibujar.
    // Además identifica cuales son los objetos a unir.
    void ObjectsUnion()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Circle" || hit.collider.tag == "Triangle" || hit.collider.tag == "Square" || hit.collider.tag == "Pentagon" || hit.collider.tag == "Diamond")
            {
                clicks = clicks + 1;
                if (clicks == 1)
                {
                    tag1 = hit.collider.tag;
                    start = hit.transform.position;
                }
                else if (clicks == 2)
                {
                    tag2 = hit.collider.tag;
                    finish = hit.transform.position;
                }
            }
            else if (hit.collider.tag != "Circle" || hit.collider.tag != "Triangle" || hit.collider.tag != "Square" || hit.collider.tag != "Pentagon" || hit.collider.tag != "Diamond")
            {
                clicks = 0;
            }
        }
    }

    // Funcion de chequeo de compatibilidad entre figuras.
    void CompatibleCheck()
    {
        if (tag1 == "Circle")
        {
            if (tag2 == "Square" || tag2 == "Triangle" || tag2 == "Pentagon" || tag2 == "Diamond")
            {
                checkFigures = true;
            }
        }

        if (tag1 == "Square")
        {
            if (tag2 == "Circle" || tag2 == "Pentagon" || tag2 == "Square")
            {
                checkFigures = true;
            }
        }

        if (tag1 == "Triangle")
        {
            if (tag2 == "Circle" || tag2 == "Pentagon" || tag2 == "Diamond" || tag2 == "Triangle")
            {
                checkFigures = true;
            }
        }

        if (tag1 == "Pentagon")
        {
            if (tag2 == "Circle" || tag2 == "Pentagon" || tag2 == "Triangle" || tag2 == "Square")
            {
                checkFigures = true;
            }
        }

        if (tag1 == "Diamond")
        {
            if (tag2 == "Circle" || tag2 == "Diamond" || tag2 == "Triangle")
            {
                checkFigures = true;
            }
        }
    }

    // Funcion para creación de GameObject con LineRenderer para unir figuras.
    void SpawnLineGenerator()
    {
        GameObject myLine = new GameObject();
        transLr = GetComponent<Transform>();

        myLine.tag = "FrameLine";
        myLine.name = "FrameLine";

        myLine.AddComponent<LineRenderer>();
        lr = myLine.GetComponent<LineRenderer>();
        lr.useWorldSpace = false;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, finish);
        lr.sortingLayerName = "Line";

        lr.material = correctColor;

        Mesh lineMesh = new Mesh();
        lr.BakeMesh(lineMesh);
        MeshCollider meshCollider = myLine.gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = lineMesh;

        allLines.Add(myLine);
        myLine.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        myLine.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        correctSound.Play(0);
        score = score + 100;
    }

    // Funcion para creación de GameObject con LineRenderer para unir figuras erróneas.
    void SpawnLineGeneratorWrong()
    {
        GameObject myLineWrong = new GameObject();
        transLr = GetComponent<Transform>();

        myLineWrong.tag = "FrameLineWrong";
        myLineWrong.name = "FrameLineWrong";

        myLineWrong.AddComponent<LineRenderer>();
        lr = myLineWrong.GetComponent<LineRenderer>();
        lr.useWorldSpace = false;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, finish);
        lr.sortingLayerName = "Line";

        lr.material = wrongColor;


        Mesh lineMesh = new Mesh();
        lr.BakeMesh(lineMesh);
        MeshCollider meshCollider = myLineWrong.gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = lineMesh;

        allLines.Add(myLineWrong);
        myLineWrong.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        myLineWrong.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        wrongSound.Play(0);
        score = score - 100;
    }

    #endregion

    // Funcion para verificar los puntos a sumar en el score debido al tiempo utilizado
    void TimeScore()
    {
        // Verificamos si el tiempo comienza desde la conexión o desde el principio del nivel
        if (isConnectUsed == true)
        {
            if (GameController.GetComponent<EnableConnect>().isEnabled == true)
            {
                connectReady = true;
            }
            if (connectReady == true)
            {
                timerScore -= Time.deltaTime;
            }
        }
        else
        {
            timerScore -= Time.deltaTime;
        }
    }

}