using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public float resetDelay;
    public int[] code;
    public int[] enteredCode;
    public Text[] codeText;
    public Text[] digits;
    private int valuesEntered;

    void Start()
    {
        int digit = 0;
        for (int i = 0; i < code.Length; i++)
        {
            digit = Random.Range(0, 10);
            code[i] = digit;
        }
    }

    public void AddValue(int value)
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
        else if (valuesEntered == enteredCode.Length)
        {
            CompareCode();
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
        }
        else
        {
            StartCoroutine(ResetCode());
        }
    }

    void Open()
    {
        print("Unlocked");
        gameObject.tag = "Grab";
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
