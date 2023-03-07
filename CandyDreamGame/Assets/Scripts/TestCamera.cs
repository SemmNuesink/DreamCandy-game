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
    public float cameraSensitivity;

    public float x1;
    public float x2;

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
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        x2 += x1 * cameraSensitivity * Time.deltaTime / 180 * math.PI; ;
        
        newPlayerPos.x = h;
        newPlayerPos.z = v;

        transform.Translate(newPlayerPos * Time.deltaTime * playerMovementSpeed);

        if (!((h == 0) && (v == 0)))
        {
            transform.rotation = CameraThing.transform.rotation;
        }
        

        thisPos = this.transform.position;

        newCameraPos = thisPos;
        newCameraPos.z -= math.cos(x2) * cameraOffset;
        newCameraPos.y += 0f;
        newCameraPos.x -= math.sin(x2) * cameraOffset;

        cameraRotation.y = x1 * cameraSensitivity * Time.deltaTime;

        CameraThing.transform.Rotate(cameraRotation);
        do
        {
            newCameraZoom = Vector3.Lerp(newCameraPos, thisPos, neededZoom);
            if (Physics.Raycast(newCameraZoom, CameraThing.transform.forward, out hit, 5))
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
                if (neededZoom > 1)
                {
                    neededZoom = 1;
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
