using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;


public class TestCamera : MonoBehaviour
{
    public GameObject CameraThing;
    public float playerMovementSpeed;
    public float cameraSensitivityv;
    public float cameraSensitivityh;

    public float x1;
    public float x2;
    public float y1;
    public float y2;

    public float h;
    public float v;

    public Vector3 newPlayerPos;
    public Vector3 newCameraPos;

    public Vector3 cameraRotation;
    public Vector3 thisPos;
    
    
    public float cameraOffset;
    
    
    
    public RaycastHit hit;
    public float neededZoom;
    public Vector3 newCameraZoom;
    

    // Update is called once per frame
    void Update()
    {
        
        x1 = Input.GetAxis("Mouse X");
        y1 = Input.GetAxis("Mouse Y");
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        x2 += x1 * cameraSensitivityh * Time.deltaTime / 180 * math.PI; ;
        
        newPlayerPos.x = h;
        newPlayerPos.z = v;

        y2 += y1 * cameraSensitivityv;

        if (y2 > 5)
        {
            y2= 5;
        }
        else if (y2 < 1)
        {
            y2= 1f;
        }  

        transform.Translate(newPlayerPos * Time.deltaTime * playerMovementSpeed);

        if (!((h == 0) && (v == 0)))
        {
            transform.rotation = CameraThing.transform.rotation;
        }
        
        thisPos = this.transform.position;

        newCameraPos = thisPos;
        newCameraPos.z -= math.cos(x2) * y2;
        newCameraPos.y += y2 * 0.5f;
        newCameraPos.x -= math.sin(x2) * y2;

        cameraRotation.y = x1 * cameraSensitivityh * Time.deltaTime;

        CameraThing.transform.Rotate(cameraRotation);
        do
        {
            newCameraZoom = Vector3.Lerp(newCameraPos, thisPos, neededZoom);
            if (Physics.Raycast(newCameraZoom, CameraThing.transform.forward, out hit, 10f))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    neededZoom = 0;
                    break;
                }
                else
                {
                    neededZoom += 0.01f;
                }
                if (neededZoom > 0.9f)
                {
                    neededZoom = 0.9f;
                    print("Oei! de player kan niet in beeld worden gebracht");
                    break;
                }
            }
            else
            {
                print("Oeps! de camera is niet gericht op de player");
                break;
            }
        } while (true);

        CameraThing.transform.position = newCameraZoom;

    }
}
