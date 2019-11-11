using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public int[] code;
    public int[] enteredCode;
    private int valuesEntered;

    void Start()
    {
        for (int i = 0; i < code.Length; i++)
        {
            code[i] = Random.Range(0, 9);
        }
    }

    public void AddValue(int value)
    {
        if (valuesEntered < enteredCode.Length)
        {
            enteredCode[valuesEntered] = value;
            valuesEntered++;
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
            if(code[i] != enteredCode[i])
            {
                codeCorrect = false;
            }
        }
        if (codeCorrect)
        {
            Open();
        }
    }

    void Open()
    {
        print("Safe unlocked");
    }
}
