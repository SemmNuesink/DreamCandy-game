using System.Collections;
using System.Collections.Generic;
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


    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, jumpHeight, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
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


    }
}
