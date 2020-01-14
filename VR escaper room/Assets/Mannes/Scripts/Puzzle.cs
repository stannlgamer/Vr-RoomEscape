using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform piecePlace;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Puzzle")
        {
            other.transform.position = piecePlace.position;
            other.transform.rotation = piecePlace.rotation;

            //WIN
        }
    }
}
