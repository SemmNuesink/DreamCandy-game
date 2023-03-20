using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolaWhenHit : MonoBehaviour
{
    public GameObject targetPoint;
    public GameObject player;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.tag == "Chocola")
        {
            player.transform.position = targetPoint.transform.position; 
        }
    }

}
