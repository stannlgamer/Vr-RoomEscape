using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    bool gameStarted;
    public bool cableRepaired;
    public float menuFadeDuration;
    public GameObject kutKast;
    public GameObject countDown;

    [Header("Menu's")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            kutKast.GetComponent<DoorPopOff>().PopDoor();
            countDown.SetActive(true);
        }
        else if(cableRepaired)
        {
            SceneManager.LoadScene("Eind level");
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
