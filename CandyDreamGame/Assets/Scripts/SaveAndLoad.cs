using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public GameObject player;
    public Vector3 position;
    public static SaveAndLoad instance;

    public void Update()
    {
       /*
        if(instance == null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
       */
      

        DontDestroyOnLoad(this.gameObject);
    }


    public void Save()
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);
        Debug.Log("Saved");
        Destroy(gameObject);
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
        
        yield return new WaitForSeconds(0.1f);
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");

        position = new Vector3(x, y, z);
        player.transform.position = position;
        Debug.Log("Loaded");


       
    }

}
