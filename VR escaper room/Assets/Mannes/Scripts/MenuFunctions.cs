using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public AudioSource brokenCable;
    public AudioSource sparks;
    bool gameStarted;
    public bool cableRepaired;
    public float menuFadeDuration;
    public GameObject kutKast;
    public GameObject countDown;

    [Header("Menu's")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public UnityEvent gameStart;

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            kutKast.GetComponent<DoorPopOff>().PopDoor();
            brokenCable.Play();
            sparks.Play();
            countDown.SetActive(true);
            gameStart.Invoke();
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
