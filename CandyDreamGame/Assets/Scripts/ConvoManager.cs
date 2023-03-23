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
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                
                if (hit.collider.gameObject.tag == "MrMellow")
                {
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
                    if (positionInArray < convo.indexToStartNamingObjectCollected)
                    {
                        print(convo.text[positionInArray]);
                    }
                    else
                    {
                        print(convo.text[convo.indexToStartNamingObjectCollected] + convo.namesOfItemsToCollect);
                    }
                }
            }
        }





        
    }

}
