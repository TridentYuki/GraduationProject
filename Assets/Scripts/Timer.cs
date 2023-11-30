using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    //[SerializeField]Text timeText;

    public float second = 0.0f;
    public int minute = 0;

    // Start is called before the first frame update
    void Start()
    {
        second = 0.0f;
        minute = 0;
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;

        if(second >= 60.0f)
        {
            minute++;
            second -= 60.0f;
        }

        //timeText.text = minute.ToString("00") + ":" + ((int)second).ToString("00");
    }
}
