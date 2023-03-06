using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;


public class TestCamera : MonoBehaviour
{
    public GameObject objectCameraljdlf;
    public float x1;
    public float x2;
    public float x3;
    
    public Vector3 cameraRotation;
    public Vector3 thisPos;
    public Vector3 thisRot;
    
    public float cameraOffset;
    public Vector3 newCameraPos;
    public float cameraSensitivity;
    public quaternion vector3ToQuaternion;


    // Update is called once per frame
    void Update()
    {
        thisPos = this.transform.position;
        x1 = Input.GetAxis("Mouse X");

        x2 += x1 * cameraSensitivity * Time.deltaTime / 180 * math.PI;
        
        newCameraPos = thisPos;
        newCameraPos.z -= math.cos(x2) * cameraOffset;
        newCameraPos.y += 1f;
        newCameraPos.x -= math.sin(x2) * cameraOffset;

        cameraRotation.y = x1 * cameraSensitivity * Time.deltaTime;

        objectCameraljdlf.transform.Rotate(cameraRotation);
        objectCameraljdlf.transform.position = newCameraPos;


    }
}
