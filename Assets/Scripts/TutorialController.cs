using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public float timeLeft = 0.1f;
    public float timeLeft1 = 0.1f;
    public float timeLeft2 = 0.1f;

    public GameObject RulesSprite;
    public int posPop = 0;
    public GameObject[] tutorialsObjects;
    public GameObject[] figuresDestryDrag;
    public GameObject invInteract;
    public GameObject BoxAnimation;
    public GameObject BackgroundInventory;
    public GameObject CanvasTutorial;
    public GameObject LineRenderer;

    LineRenderer lr;
    Animator Anim;

    Vector3 startCircle;
    Vector3 startSquare;
    Vector3 finishCircle;
    Vector3 finishSquare;

    //Parametros
    public bool WorkAreaFunction = true;
    public bool OpenTouchFunction = false;
    public bool InventoryShowFunction = false;
    public bool DragFiguresFunction = false;
    public bool ConnectButtonOnFunction = false;
    public bool EnableConnectionsFunction = false;
    public bool TimePopUpFunction = false;
    public bool PauseButtonOnFunction = false;
    public bool HelpButtonOnFunction = false;                                     
    public bool PointsBarFunction = false;
    public bool NecessaryPointsFunction = false;
    public bool ReadyButtonOnFunction = false;
    public bool AreYouReadyFunction = false;

    public bool CircleMoved = false;
    public bool SquareMoved = false;
    public bool FigureCirclePress = false;
    public bool FigureSquarePress = false;
    public bool FigureCircleUp = false;
    public bool FigureSquareUp = false;
                                                                 

    // Start is called before the first frame update
    void Start()
    {
        RulesSprite.SetActive(false);
        tutorialsObjects[0].SetActive(true);
        Anim = BoxAnimation.GetComponent<Animator>();
        invInteract.SetActive(false);
        lr = LineRenderer.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WorkAreaFunction == true)
        {
            WorkArea();
        }
        if (WorkAreaFunction == false && OpenTouchFunction == true)
        {
            OpenTouch();
        }
        if (OpenTouchFunction == false && InventoryShowFunction == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                InventoryShow();
                timeLeft = 0;
            }
        }
        if (InventoryShowFunction == false && DragFiguresFunction == true)
        {
            DragFigures();
        }
        if (DragFiguresFunction == false && ConnectButtonOnFunction == true)
        {
            ConnectButtonOn();
        }
        if (ConnectButtonOnFunction == false && EnableConnectionsFunction == true)
        {
            EnableConnections();
        }
        if (EnableConnectionsFunction == false && TimePopUpFunction == true)
        {
            timeLeft1 -= Time.deltaTime;
            if (timeLeft1 < 0)
            {
                TimePopUp();
                timeLeft1 = 0;
            }
        }
        if (TimePopUpFunction == false && PauseButtonOnFunction == true)
        {
            PauseButtonOn();
        }
        if (PauseButtonOnFunction == false && HelpButtonOnFunction == true)
        {
            HelpButtonOn();
        }
        if (HelpButtonOnFunction == false && PointsBarFunction == true)
        {
            PointsBar();
        }
        if (PointsBarFunction == false && NecessaryPointsFunction == true)
        {
            NecessaryPoints();
        }
        if (NecessaryPointsFunction == false && ReadyButtonOnFunction == true)
        {
            ReadyButtonOn();
        }
        if (ReadyButtonOnFunction == false && AreYouReadyFunction == true)
        {
            timeLeft2 -= Time.deltaTime;
            if (timeLeft2 < 0)
            {
                AreYouReady();
                timeLeft2 = 0;
            }
        }
    }

    public void WorkArea()
    {
        BoxAnimation.SetActive(false);
        CanvasTutorial.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            invInteract.SetActive(false);
            BoxAnimation.SetActive(false);
            CanvasTutorial.SetActive(false);
            WorkAreaFunction = false;
            OpenTouchFunction = true;
            tutorialsObjects[0].SetActive(false);
            tutorialsObjects[1].SetActive(true);
        }
    }

    public void OpenTouch()
    {
        BoxAnimation.SetActive(true);
        CanvasTutorial.SetActive(false);


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Box")
                {
                    OpenTouchFunction = false;
                    InventoryShowFunction = true;
                    Anim.SetBool("BoxOpen", true);
                    Anim.SetBool("BoxStay", false);     
                    invInteract.SetActive(true);
                    figuresDestryDrag[0].SetActive(false);
                    figuresDestryDrag[1].SetActive(false);
                    tutorialsObjects[1].SetActive(false);
                    tutorialsObjects[2].SetActive(true);
                }
            }
        }
    }

    public void InventoryShow()
    {
        CanvasTutorial.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            InventoryShowFunction = false;
            DragFiguresFunction = true;
            tutorialsObjects[2].SetActive(false);
            tutorialsObjects[3].SetActive(true);
        }
    }

    public void DragFigures()
    {
        CanvasTutorial.SetActive(false);

        figuresDestryDrag[0].SetActive(true);
        figuresDestryDrag[1].SetActive(true);

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Circle")
                {
                    CircleMoved = true;
                }
                if (hit.collider.tag == "Square")
                {
                    SquareMoved = true;
                }
            }
            if (CircleMoved == true && SquareMoved == true)
            {
                DragFiguresFunction = false;
                ConnectButtonOnFunction = true;
                tutorialsObjects[3].SetActive(false);
                tutorialsObjects[4].SetActive(true);
            }
        }
    }

    public void ConnectButtonOn()
    {
        CanvasTutorial.SetActive(false);
        BoxAnimation.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "ConnectButton")
                {
                    ConnectButtonOnFunction = false;
                    EnableConnectionsFunction = true;
                    figuresDestryDrag[0].tag = "FigureCircle";
                    figuresDestryDrag[1].tag = "FigureSquare";
                    Destroy(figuresDestryDrag[0].GetComponent<DragAndDrop>());
                    Destroy(figuresDestryDrag[1].GetComponent<DragAndDrop>());
                    tutorialsObjects[4].SetActive(false);
                    tutorialsObjects[5].SetActive(true);
                }
            }
        }
    }

    public void EnableConnections()
    {
        CanvasTutorial.SetActive(false);

        BoxAnimation.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "FigureCircle")
                {
                    startCircle = hit.transform.position;
                    FigureCirclePress = true;
                }
                if (hit.collider.tag == "FigureSquare")
                {
                    startSquare = hit.transform.position;
                    FigureSquarePress = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "FigureCircle")
                {
                    finishCircle = hit.transform.position;
                    FigureCircleUp = true;
                }
                if (hit.collider.tag == "FigureSquare")
                {
                    finishSquare = hit.transform.position;
                    FigureSquareUp = true;
                }
            }
        }

        if (FigureCirclePress == true && FigureSquareUp == true)
        {
            lr.useWorldSpace = false;
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.SetPosition(0, startCircle);
            lr.SetPosition(1, finishSquare);

            EnableConnectionsFunction = false;
            TimePopUpFunction = true;

            tutorialsObjects[5].SetActive(false);
            tutorialsObjects[6].SetActive(true);
        }

        if (FigureSquarePress == true && FigureCircleUp == true)
        {
            lr.useWorldSpace = false;
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.SetPosition(0, startSquare);
            lr.SetPosition(1, finishCircle);

            EnableConnectionsFunction = false;
            TimePopUpFunction = true;

            tutorialsObjects[5].SetActive(false);
            tutorialsObjects[6].SetActive(true);
        }
    }

    public void TimePopUp()
    {
        figuresDestryDrag[0].transform.position = new Vector3(figuresDestryDrag[0].transform.position.x, figuresDestryDrag[0].transform.position.y, -0.75f);
        figuresDestryDrag[1].transform.position = new Vector3(figuresDestryDrag[1].transform.position.x, figuresDestryDrag[1].transform.position.y, -0.75f);

        BoxAnimation.SetActive(false);
        CanvasTutorial.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            TimePopUpFunction = false;
            PauseButtonOnFunction = true;
            tutorialsObjects[6].SetActive(false);
            tutorialsObjects[7].SetActive(true);
        }
    }

    public void PauseButtonOn()
    {
        CanvasTutorial.SetActive(false);

        BoxAnimation.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "OptionButton")
                {
                    PauseButtonOnFunction = false;
                    HelpButtonOnFunction = true;
                    tutorialsObjects[7].SetActive(false);
                    tutorialsObjects[8].SetActive(true);
                }
            }
        }
    }

    public void HelpButtonOn()
    {
        CanvasTutorial.SetActive(false);

        BoxAnimation.SetActive(false);


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "HelpButton")
                {
                    HelpButtonOnFunction = false;
                    PointsBarFunction = true;
                    tutorialsObjects[8].SetActive(false);
                    tutorialsObjects[9].SetActive(true);
                }
            }
        }   
    }

    public void PointsBar()
    {
        CanvasTutorial.SetActive(false);

        BoxAnimation.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            PointsBarFunction = false;
            NecessaryPointsFunction = true;
            tutorialsObjects[9].SetActive(false);
            tutorialsObjects[10].SetActive(true);
        }
    }

    public void NecessaryPoints()
    {
        CanvasTutorial.SetActive(false);

        BoxAnimation.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            NecessaryPointsFunction = false;
            ReadyButtonOnFunction = true;
            tutorialsObjects[10].SetActive(false);
            tutorialsObjects[11].SetActive(true);
        }
    }


    public void ReadyButtonOn()
    { 
        CanvasTutorial.SetActive(false);

        BoxAnimation.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "ReadyButton")
                {
                    ReadyButtonOnFunction = false;
                    AreYouReadyFunction = true;
                    tutorialsObjects[11].SetActive(false);
                    tutorialsObjects[12].SetActive(true);
                    CanvasTutorial.SetActive(false);
                }
            }
        }
    }

    public void AreYouReady()
    {
        CanvasTutorial.SetActive(false);

        BoxAnimation.SetActive(false);
    }
}                                                                   