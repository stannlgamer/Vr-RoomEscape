using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeStartMinutes;
    float time;
    public Text text;

    void Start()
    {
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            timeStartMinutes -= 1;
            time = 59;
            
        }
        text.text = timeStartMinutes.ToString("#") + ":" + time.ToString("#");
    }
}
