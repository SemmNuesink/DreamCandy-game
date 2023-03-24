using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ConvoManager : MonoBehaviour
{
    public int positionInArray;
    public Conversation convo;
    public RaycastHit hit;
    public bool candyInHand;
    public string textToPrint;
    public PlaceFullWekker wekkerScript;
    public string onderdelenOpgepakt;
    public string onderdelenOpTePakken;
    public bool[] PickedObjects = new bool[5];
    
    // Start is called before the first frame update

    private void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                
                if (hit.collider.gameObject.tag == "MrMellow")
                {
                    PickedObjects[0] = wekkerScript.linker;
                    PickedObjects[1] = wekkerScript.rechter;
                    PickedObjects[2] = wekkerScript.hamer;
                    PickedObjects[3] = wekkerScript.wekker;


                    if (positionInArray < convo.indexToPickupCandy)
                    {
                        positionInArray += 1;
                    }
                    else if (positionInArray == convo.indexToPickupCandy)
                    {
                        if (candyInHand)
                        {
                            positionInArray = convo.indexToPickupCandy + 1;
                        }
                    }
                    else if (positionInArray < convo.indexToStartAlarmQuest)
                    {
                        positionInArray += 1;
                    }



                    for (int i = 0; i < 3; i++)
                    {
                        if (PickedObjects[i] == true)
                        {
                            onderdelenOpgepakt += convo.namesOfItemsToCollect[i];
                        }
                        else
                        {
                            onderdelenOpTePakken += convo.namesOfItemsToCollect[i];
                        }
                    }





                    if (positionInArray < convo.indexToStartNamingObjectCollected)
                    {
                        textToPrint = convo.text[positionInArray];
                    }
                    else
                    {
                        textToPrint = convo.text[positionInArray] + "je hebt gepakt:" + onderdelenOpgepakt + "je moet nog pakken:" +onderdelenOpTePakken;
                    }

                    print(textToPrint);
                }
            }
        }





        
    }

}
