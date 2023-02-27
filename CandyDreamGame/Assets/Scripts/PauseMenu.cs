using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;
    public void CloseMenu()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }


    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
