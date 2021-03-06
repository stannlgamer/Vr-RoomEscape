﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public bool random;
    public float resetDelay;
    public int[] code;
    public int[] enteredCode;
    public Text[] codeText;
    public Text[] digits;
    private int valuesEntered;

    public float pressDelay = .5f;
    float timer;
    bool canPress;
    public GameObject[] buttons;
    public GameObject tape;

    public AudioClip correct;
    public AudioClip incorrect;

    public void StartGame()
    {
        if (random)
        {
            int digit = 0;
            for (int i = 0; i < code.Length; i++)
            {
                digit = Random.Range(0, 10);
                digits[i].text = digit.ToString();
                code[i] = digit;
            }
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            canPress = true;
        }
    }

    public void AddValue(int value)
    {
        if (canPress)
        {
            if (valuesEntered < enteredCode.Length)
            {
                enteredCode[valuesEntered] = value;
                codeText[valuesEntered].text = value.ToString();
                valuesEntered++;

                if (valuesEntered == enteredCode.Length)
                {
                    CompareCode();
                }
            }
            canPress = false;
            timer = pressDelay;
        }
    }

    void CompareCode()
    {
        bool codeCorrect = true;
        for (int i = 0; i < code.Length; i++)
        {
            if (code[i] != enteredCode[i])
            {
                codeCorrect = false;
            }
        }
        if (codeCorrect)
        {
            Open();
            GetComponent<AudioSource>().clip = correct;
        }
        else
        {
            StartCoroutine(ResetCode());
            GetComponent<AudioSource>().clip = incorrect;
        }
        GetComponent<AudioSource>().Play();
    }

    void Open()
    {
        gameObject.tag = "Grab";
        tape.SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].tag = "Untagged";
        }
    }

    IEnumerator ResetCode()
    {
        yield return new WaitForSeconds(resetDelay);

        for (int i = 0; i < enteredCode.Length; i++)
        {
            codeText[i].text = "_";
            enteredCode[i] = 0;
            valuesEntered = 0;
        }
    }

}
