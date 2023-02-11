using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raygast : MonoBehaviour
{
    public RaycastHit hit;
    public Rigidbody rb;
    public GameObject ui;


    private void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {



            if (hit.transform.gameObject.tag == "Lever")
            {
                if (hit.distance < 5)
                {
                    ui.SetActive(true);
                }
                if (Input.GetKey(KeyCode.E))
                {

                    Destroy(hit.transform.gameObject);
                    ui.SetActive(false);
                }

                
            }
            
        }
    }
}
