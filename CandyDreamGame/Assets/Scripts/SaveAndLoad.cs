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

    public void Update()
    {
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
        

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(1);
        
        yield return new WaitForSeconds(1);
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");

        position = new Vector3(x, y, z);
        player.transform.position = position;
        Debug.Log("Loaded");
    }

}
