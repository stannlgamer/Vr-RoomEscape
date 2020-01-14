using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public GameObject tape;
    public GameObject menu;

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject == tape)
        {
            menu.GetComponent<MenuFunctions>().cableRepaired = true;
        }
    }
}
