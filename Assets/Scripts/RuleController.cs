using UnityEngine;

public class RuleController : MonoBehaviour
{
    public GameObject[] Rules;
    public GameObject Canvas;
    int clickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCount = clickCount + 1;

            if (clickCount == 1)
            {
                Rules[0].SetActive(false);
                Rules[1].SetActive(true);
                Rules[2].SetActive(false);
            }

            if (clickCount == 2)
            {
                Rules[0].SetActive(false);
                Rules[1].SetActive(false);
                Rules[2].SetActive(true);
                Canvas.SetActive(true);
            }
        }
    }
}
