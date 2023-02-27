using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour

{
    public GameObject credits;
    public GameObject mainMenu;

    public void NextScenes()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
    public void BackCredits()
    {
        credits.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }


}
