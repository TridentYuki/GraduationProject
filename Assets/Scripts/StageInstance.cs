using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInstance : MonoBehaviour
{
    private string m_CreateStage;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetCreateStage(string name)
    {
        m_CreateStage = name;
    }

    public string GetCreateStage()
    {
        return m_CreateStage;
    }
}
