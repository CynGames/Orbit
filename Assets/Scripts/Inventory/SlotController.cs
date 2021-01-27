using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        transform.parent.GetComponent<InventoryController>().selectedSlot = this.transform;
    }

    private void OnMouseExit()
    {
        transform.parent.GetComponent<InventoryController>().selectedSlot = null;
    }

    private void OnMouseOver()
    {
        transform.parent.GetComponent<InventoryController>().selectedSlot = this.transform;
    }
}
