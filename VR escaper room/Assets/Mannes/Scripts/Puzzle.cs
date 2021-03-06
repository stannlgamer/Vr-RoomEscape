﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform piecePlace;
    public GameObject winScreen;
    public ParticleSystem confetti;
    public float secondsToWait = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "Hand")
        {
            other.transform.parent.GetComponent<Grabbing>().LetGo();
            if (other.tag == "Puzzle")
            {
                other.transform.position = piecePlace.position;
                other.transform.rotation = piecePlace.rotation;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                winScreen.SetActive(true);
                GetComponent<AudioSource>().Play();
                confetti.Play();
                StartCoroutine("Quit");
            }
        }
    }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(secondsToWait);
        Application.Quit();
    }
}
