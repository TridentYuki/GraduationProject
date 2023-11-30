using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        int minute = GlobalValue.time / 60;
        int second = GlobalValue.time % 60;

        scoreText.text = minute.ToString("00") + ":" + ((int)second).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
