using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector3 move;
    public Vector3 cameraDraaien;
    public float h;
    public float v;
    public float speed;
    public float x;
    public float sensitivity;

    public float jumpHeight;
    public Vector3 jump;
    public bool onGround;
    public Rigidbody rb;
    public GameObject canvas;

    public GameObject targetPoint;
    public GameObject player;

    public GameObject deadUI;


    public void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, jumpHeight, 0);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.gameObject.tag == "Ground")
        {
            onGround = true;
        }
        
        
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }






    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        x = Input.GetAxis("Mouse X");

        move.x = h;
        move.z = v;
        cameraDraaien.y = x;

        transform.Translate(move * Time.deltaTime * speed);
        transform.Rotate(cameraDraaien * Time.deltaTime * sensitivity);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            onGround = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7f;
        }
        else
        {
            speed = 5f;
        }


    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Chocola")
        {
            deadUI.SetActive(true);
            Time.timeScale = 0;

        }
    }

    public void respawn()
    {
        deadUI.SetActive(false);
        player.transform.position = targetPoint.transform.position;
        Time.timeScale = 1;
    }









    
}
