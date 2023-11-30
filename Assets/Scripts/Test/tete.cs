using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tete : MonoBehaviour
{
    GameObject child;
    bool nowIsLocking;
    // Start is called before the first frame update
    void Start()
    {
        child = GameObject.Find("d");
        child.SetActive(false);
        nowIsLocking = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        if (!nowIsLocking)
        {
            child.SetActive(true);
            nowIsLocking = true;
        }
        else
        {
            child.SetActive(false);
            nowIsLocking = false;
        }
    }
}
