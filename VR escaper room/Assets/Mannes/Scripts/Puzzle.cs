using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform piecePlace;
    public GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "Hand")
        {
            other.transform.parent.GetComponent<Grabbing>().LetGo();
            if (other.tag == "Puzzle")
            {
                other.transform.position = piecePlace.position;
                other.transform.rotation = piecePlace.rotation;

                winScreen.SetActive(true);
            }
        }
    }
}
