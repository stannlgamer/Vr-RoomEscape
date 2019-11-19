using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteraction : MonoBehaviour
{
    private bool gameStarted;

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Button")
        {
            c.isTrigger = true;
            ExecuteFunction(c.gameObject);
        }
    }

    void ExecuteFunction(GameObject button)
    {
        button.GetComponent<MenuButton>().Pressed();
    }
}
