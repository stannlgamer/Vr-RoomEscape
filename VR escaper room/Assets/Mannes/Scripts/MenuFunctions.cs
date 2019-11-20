using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    bool gameStarted;
    public float menuFadeDuration;

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

    public void PressOptions()
    {
        StartCoroutine("Options");
    }

    public void PressReturn()
    {
        StartCoroutine("Return");
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator Options()
    {
        yield return new WaitForSeconds(menuFadeDuration);

        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(menuFadeDuration);

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
