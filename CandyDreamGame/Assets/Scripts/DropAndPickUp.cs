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
    public GameObject player;


    private void Update()
    {

        findObject = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!(!(hit.transform.gameObject.tag == "Linkerbel") && !(hit.transform.gameObject.tag == "RechterBel") && !(hit.transform.gameObject.tag == "Body") && !(hit.transform.gameObject.tag == "Hamer")))
                {
                    objectt = hit.transform.gameObject;
                }
               
            }
           
            findObject = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectt)
            {
                if (!(!(objectt.tag == "Linkerbel") && !(objectt.tag == "RechterBel") && !(objectt.tag == "Body") && !(objectt.tag == "Hamer")))
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
                            objectt = null;
                        }
                        inHand = false;
                    }
                }
            }
        }
        if (inHand == true)
        {
            objectt.transform.position = grabSlot.transform.position;
            objectt.transform.rotation = grabSlot.transform.rotation;
        }

        
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (inHand == true)
        {
            if (collision.transform.gameObject.tag == "Chocola")
            {
                inHand = false;
            }
        }
    }
}
