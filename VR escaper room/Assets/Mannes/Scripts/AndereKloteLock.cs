using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AndereKloteLock : MonoBehaviour
{
    public AudioClip correct;
    public AudioClip incorrect;
    public GameObject room2;
    public GameObject door;
    public float resetDelay;
    public int[] code;
    public int[] enteredCode;
    public Text[] codeText;
    public Text[] digits;
    private int valuesEntered;

    public float pressDelay;
    float timer;
    bool canPress;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
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
        door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        room2.SetActive(true);
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
