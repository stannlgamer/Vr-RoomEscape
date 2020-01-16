using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeStartMinutes;
    public float time;
    public Text text;

    void Start()
    {
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0 && timeStartMinutes <= 0)
        {
            Application.Quit();
        }
        if(time <= 0)
        {
            timeStartMinutes -= 1;
            time = 59;
            
        }
        if(time < 9.5)
        {
            text.text = timeStartMinutes.ToString("#") + ":0" + time.ToString("#");
        }
        else
        {
            text.text = timeStartMinutes.ToString("#") + ":" + time.ToString("#");

        }

    }
}
