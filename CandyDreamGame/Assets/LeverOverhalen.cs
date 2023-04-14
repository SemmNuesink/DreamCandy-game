using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOverhalen : MonoBehaviour
{
    public Animator anim;
    public GameObject openBridge;
    public GameObject closedbridge;
  
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void LeverOverhalenn()
    {
        anim.SetBool("Overhalen", true);
        openBridge.SetActive(true);
        closedbridge.SetActive(false);

    }
}
