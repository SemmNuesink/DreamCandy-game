using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float[] objectPos = new float[18];
    public GameObject player;
    public Vector3 position;
    public static SaveAndLoad instance;
    public TMP_Text saved;
    public GameObject linkerBel;
    public GameObject rechterBel;
    public GameObject hamer;
    public GameObject bodyWekker;
    public string[] names = new string[18];
    public GameObject maya;
    


    public void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void Save()
    {
        objectPos[0] = linkerBel.transform.position.x;
        objectPos[1] = linkerBel.transform.position.y;
        objectPos[2] = linkerBel.transform.position.z;

        objectPos[3] = rechterBel.transform.position.x;
        objectPos[4] = rechterBel.transform.position.y;
        objectPos[5] = rechterBel.transform.position.z;

        objectPos[6] = hamer.transform.position.x;
        objectPos[7] = hamer.transform.position.y;
        objectPos[8] = hamer.transform.position.z;

        objectPos[9] = bodyWekker.transform.position.x;
        objectPos[10] = bodyWekker.transform.position.y;
        objectPos[11] = bodyWekker.transform.position.z;

        objectPos[12] = maya.transform.position.x;
        objectPos[13] = maya.transform.position.y;
        objectPos[14] = maya.transform.position.z;

        objectPos[15] = player.transform.position.x;
        objectPos[16] = player.transform.position.y;
        objectPos[17] = player.transform.position.z;


        for (int i = 0; i < 18; i++)
        {
            PlayerPrefs.SetFloat(names[i], objectPos[i]);
        }

       
        Debug.Log("Saved");
        saved.text = "Saved";
    }
    public void Load()
    {
        
        StartCoroutine(LoadPosition());
        
    }

    IEnumerator LoadPosition()
    {
        

        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene(1);
        yield return new WaitForSeconds(0.1f);

        player = GameObject.Find("Player");
        linkerBel = GameObject.Find("LinkerBel");
        rechterBel = GameObject.Find("RechterBel");
        hamer = GameObject.Find("HamerWekker");
        bodyWekker = GameObject.Find("WekkerKlok");
        maya = GameObject.Find("Maya");


        yield return new WaitForSeconds(0.1f);
       
        Debug.Log("Loaded");

        for(int i = 0; i < 18; i++)
        {
            objectPos[i] = PlayerPrefs.GetFloat(names[i]);
        }


        position = new Vector3(objectPos[0], objectPos[1], objectPos[2]);
        linkerBel.transform.position = position;
        position = new Vector3(objectPos[3], objectPos[4], objectPos[5]);
        rechterBel.transform.position = position;
        position = new Vector3(objectPos[6], objectPos[7], objectPos[8]);
        hamer.transform.position = position;
        position = new Vector3(objectPos[9], objectPos[10], objectPos[11]);
        bodyWekker.transform.position = position;
        position = new Vector3(objectPos[12], objectPos[13], objectPos[14]);
        maya.transform.position = position;
        position = new Vector3(objectPos[15], objectPos[16], objectPos[17]);
        player.transform.position = position;









    }




}
