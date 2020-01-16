using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public GameObject tape;
    public GameObject menu;
    public GameObject cable;

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject == tape)
        {
            menu.GetComponent<MenuFunctions>().cableRepaired = true;
            c.gameObject.GetComponent<AudioSource>().Play();
            Instantiate(cable, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
