using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayaZicht : MonoBehaviour
{
    public navigation navigation;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            navigation.freeRoam = false;
        }
    }
}
