using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteraction : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject main;
    public GameObject options;
    private bool gameStarted;
    

    private void OnTriggerEnter(Collider c)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (c.gameObject == buttons[i])
            {
                c.isTrigger = true;
                ExecuteFunction(buttons[i].name, c.gameObject);
            }
        }
    }

    void ExecuteFunction(string function, GameObject button)
    {
        button.GetComponent<MenuButton>().Pressed();

        if (function == "Start")
        {
            if (!gameStarted)
            {
                gameStarted = true;
                print("Start game");
            }
            else
            {
                print("Game has already begun");
            }
        }
        else if (function == "Options")
        {
            main.SetActive(false);
            options.SetActive(true);
        }
        else if (function == "Quit")
        {
            Application.Quit();
        }
    }
}
