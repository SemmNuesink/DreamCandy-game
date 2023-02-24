using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;


public class TestCamera : MonoBehaviour
{
    public GameObject objectCameraljdlf;
    public float x;
    
    public Vector3 cameraRotation1;
    public Vector3 thisPos;
    
    public float cameraOffset;
    public Vector3 newCameraPos;
    public float cameraSensitivity;
    public quaternion v3ToQuaternion;

    


    // Update is called once per frame
    void Update()
    {
        thisPos = this.transform.position;

        x += Input.GetAxis("Mouse X") * Time.deltaTime * cameraSensitivity;
        cameraRotation1 = new Vector3(thisPos.x, thisPos.y + x, thisPos.z);
        v3ToQuaternion = quaternion.Euler(cameraRotation1);

        newCameraPos.x = Mathf.Cos(180 - cameraRotation1.y) * cameraOffset;
        newCameraPos.y = 1f;
        newCameraPos.z = Mathf.Sin(180 - cameraRotation1.y) * cameraOffset;

        objectCameraljdlf.transform.rotation = v3ToQuaternion;
        objectCameraljdlf.transform.position = newCameraPos;


    }
}
