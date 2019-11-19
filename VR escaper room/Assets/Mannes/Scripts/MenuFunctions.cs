using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    bool gameStarted;

    [Header("Menu's")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            print("Game starting!");
        }
        else
        {
            print("Game already started!");
        }
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
