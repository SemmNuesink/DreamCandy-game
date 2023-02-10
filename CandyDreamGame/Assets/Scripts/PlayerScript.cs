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

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
    }
}
