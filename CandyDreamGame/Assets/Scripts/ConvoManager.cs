using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ConvoManager : MonoBehaviour
{
    public int positionInArray;
    public Conversation convo;
    public RaycastHit hit;
    public bool candyCollected;
    public string textToPrint;
    public PlaceFullWekker wekkerScript;
    public string onderdelenOpgepakt;
    public string onderdelenOpTePakken;
    public bool[] pickedObjects = new bool[3];
    public int partsCollected;
    public bool textIsDynamic;
    public TMP_Text display;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                if (hit.collider.gameObject.tag == "MrMellow")
                {
                    //set bools in array
                    pickedObjects[0] = wekkerScript.linker;
                    pickedObjects[1] = wekkerScript.rechter;
                    pickedObjects[2] = wekkerScript.hamer;
                    pickedObjects[3] = wekkerScript.body;
                    candyCollected = wekkerScript.candy;
                    


                    //voegt strings samen van opgepakte objecten
                    partsCollected = 0;
                    onderdelenOpgepakt = "";
                    onderdelenOpTePakken = "";
                    for (int i = 0; i < 4; i++)
                    {
                        if (pickedObjects[i] == true)
                        {
                            if (partsCollected > 0)
                            {
                                onderdelenOpgepakt += "the, ";
                            }
                            onderdelenOpgepakt += convo.namesOfItemsToCollect[i];
                            partsCollected++;
                        }
                        else
                        {
                            if (partsCollected > 0)
                            {
                                onderdelenOpgepakt += "the, ";
                            }
                            onderdelenOpTePakken += convo.namesOfItemsToCollect[i];
                        }
                    }



                    //houd bij waar je bent in het gesprek
                    textIsDynamic= false;
                    if (positionInArray < convo.indexToPickupCandy)
                    {
                        positionInArray += 1;
                    }
                    else if (positionInArray == convo.indexToPickupCandy)
                    {
                        if (candyCollected)
                        {
                            positionInArray = convo.indexToPickupCandy + 1;
                        }
                    }
                    else if (positionInArray < convo.indexToStartNamingObjectCollected)
                    {
                        positionInArray += 1;
                    }
                    else if (positionInArray < convo.indexWhenAllObjectsCollected)
                    {
                        for (int i = 1; i < 5; i++)
                        {
                            if (partsCollected == i)
                            {
                                positionInArray = convo.indexToStartNamingObjectCollected + i;
                                if (i < 4)
                                {
                                    textIsDynamic = true;
                                }
                            }
                        }
                    }
                    else if (positionInArray < convo.text.Length - 1)
                    {
                        positionInArray += 1;
                    }


                    //bepaalt welk text format gebruikt moet worden
                    if (!textIsDynamic)
                    {
                        textToPrint = convo.text[positionInArray];
                    }
                    else
                    {
                        textToPrint = convo.text[positionInArray] + onderdelenOpgepakt + "you still need to find the " +onderdelenOpTePakken;
                    }

                    //print de text
                    print(textToPrint);
                    display.text = textToPrint;
                }
            }
        }

        
    }

}
