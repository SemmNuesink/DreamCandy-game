using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAndPickUp : MonoBehaviour
{
    RaycastHit hit;
    public GameObject grabSlot;
    public bool inHand;
    public GameObject objectt;
    public bool findObject;
    public GameObject dropSlot;


    private void Update()
    {

        findObject = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hit.transform.gameObject.tag == "Wekker")
                {
                    objectt = hit.transform.gameObject;
                }
               
            }
           
            findObject = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (objectt.tag == "Wekker")
            {
                if ((inHand == false) && (findObject == true))
                {
                    inHand = true;
                }
                else
                {
                    if (inHand == true)
                    {
                        objectt.transform.position = dropSlot.transform.position;
                    }
                    inHand = false;
                }
            }
        }
        if (inHand == true)
        {
            objectt.transform.position = grabSlot.transform.position;
            objectt.transform.rotation = grabSlot.transform.rotation;
        }
    }
}
