using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;


public class TestCamera : MonoBehaviour
{
    public GameObject cameraThing;
    public float mouseMovement;
    public float rotationForCalculation;
    
    
    public Vector3 cameraRotation;
    public Vector3 thisPos;
    
    
    public float cameraOffset;
    public Vector3 newCameraPos;
    public float cameraSensitivity;

    public RaycastHit hit;
    public bool viewObscured;
    public float viewZoom;
    public Vector3 zoomPos;


    // Update is called once per frame
    void Update()
    {
        thisPos = this.transform.position;
        mouseMovement = Input.GetAxis("Mouse X");

        rotationForCalculation += mouseMovement * cameraSensitivity * Time.deltaTime / 180 * math.PI;
        
        newCameraPos = thisPos;
        newCameraPos.z -= math.cos(rotationForCalculation) * cameraOffset;
        newCameraPos.y += 0f;
        newCameraPos.x -= math.sin(rotationForCalculation) * cameraOffset;

        cameraRotation.y = mouseMovement * cameraSensitivity * Time.deltaTime;

        cameraThing.transform.Rotate(cameraRotation);
        zoomPos = newCameraPos;
        do
        {
            if (Physics.Raycast(zoomPos, cameraThing.transform.forward, out hit, 5))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    viewObscured = false;
                    viewZoom = 0f;
                    break;
                }
                else
                {
                    viewZoom += 0.01f;
                    zoomPos = Vector3.Lerp(newCameraPos, thisPos, viewZoom);
                    viewObscured = true;
                }
                //als er iets heel raars gebeurt
                if (viewZoom > 1f)
                {
                    viewZoom = 1f;
                    zoomPos = Vector3.Lerp(newCameraPos, thisPos, viewZoom);
                    print("Player is niet in beeld!");
                    break;
                }
            }
        }while (true);
        cameraThing.transform.position = zoomPos;
    }
}
