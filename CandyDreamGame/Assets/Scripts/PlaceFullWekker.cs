using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlaceFullWekker : MonoBehaviour
{
    public bool linker = false;
    public bool rechter = false;
    public bool hamer = false;
    public bool body = false;
    public bool wekkerAf = false;
    public bool candy = false;
    public GameObject wekker;
    public GameObject fullWekker;
    public Transform podiumPlace;
    public SaveAndLoad script;
    private void OnCollisionStay(Collision collision)
    {


        if (collision.gameObject.tag == "Snoepje")
        {
            candy = true;

        }




        if (collision.gameObject.tag == "Linkerbel")
        {
            linker = true;

        }

        if (collision.gameObject.tag == "RechterBel")
        {
            rechter = true;
        }

        if (collision.gameObject.tag == "Hamer")
        {
            hamer = true;
        }

        if (collision.gameObject.tag == "Body")
        {
            body = true;
        }
        if (wekkerAf == false)
        {
            if (linker == true && rechter == true && hamer == true && body == true)
            {
                Destroy(wekker);
                Instantiate(fullWekker, new Vector3(0, .5f, 0) + podiumPlace.transform.position, Quaternion.identity);
                wekkerAf = true;

            }
        }

    }
}
