using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ConvoManager : MonoBehaviour
{
    public int positionInArray;
    public Conversation convo;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("hallo");
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                print("hi");
                if (hit.collider.gameObject.tag == "MrMellow")
                {
                    positionInArray += 1;
                    print(convo.text[positionInArray]);
                }
            }
        }





        
    }

}
